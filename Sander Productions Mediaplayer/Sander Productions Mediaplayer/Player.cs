using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using NAudio.Wave;
using NAudio;
using TagLib;

namespace Sander_Productions_Mediaplayer
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
            #region Supported extensions
            SuppExt.Add(".mp3");
            SuppExt.Add(".wav");
            #endregion            
            TimeBar.TickFrequency = 2500;
        }
        public bool Development = false;


        #region Public Fields & Stuff
        public int CurrentSeconds = 0;
        public int MilliSeconds = 0;
        public int Seconds = 1;
        public int Minutes = 0;
        public int Hours = 0;
        public double Time;
        public bool Pause;
        public bool Autoplay;
        public bool Playing;
        public string DisplayTime;
        public string currentTime;
        public string ShowTime;
        public string Corrupted;

        List<string> SuppExt = new List<string>();
        List<string> duplicates = new List<string>();
        List<string> Corrupt = new List<string>();
        OpenFileDialog Dialog = new OpenFileDialog();
        IWavePlayer MediaPlayer = new WaveOut();
        #endregion

        private void Player_Load(object sender, EventArgs e)
        {
            StyleBox.Visible = Development;
            Volume.Visible = Development;
            VolumeLabel.Visible = Development;
            BugsButton.Visible = Development;
        }

        #region Buttons
        private void Playbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrackList.Items.Count == 0)
                {
                    StatusLabel.Text = "No media selected";
                }

                if (TrackList.Items.Count != 0)
                {
                    if (!Playing)
                    {
                        CurrentTimer.Start();
                        if (!Pause)
                        {
                            AudioFileReader fileReader = new AudioFileReader(TrackList.Items[0].Text);
                            MediaPlayer.Init(fileReader);
                        }
                        Pause = false;
                        LengthTimer.Start();
                        MediaPlayer.Play();
                        string Title = TrackList.Items[0].SubItems[1].Text;
                        StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
                        WhatMedia.Text = Title;
                        TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
                        try
                        {
                            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            AlbumPicBox.BackgroundImage = image;
                        }
                        catch(IndexOutOfRangeException)
                        {
                            AlbumPicBox.BackgroundImageLayout = ImageLayout.Stretch;
                            AlbumPicBox.BackgroundImageLayout = ImageLayout.None;
                            AlbumPicBox.BackgroundImage = AlbumPicBox.ErrorImage;
                        }
                    }
                    Playing = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
            Pause = true;
            Playing = false;
            MediaPlayer.Pause();
            LengthTimer.Stop();
            CurrentTimer.Stop();
            StatusLabel.Text = MediaPlayer.PlaybackState.ToString();

        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            Playing = false;
            Pause = false;
            MediaPlayer.Stop();
            MediaPlayer.Dispose();
            LengthTimer.Stop();
            CurrentTimer.Stop();
            MilliSeconds = 0;
            Seconds = 1;
            Minutes = 0;
            Hours = 0;
            CurrentSeconds = 0;
            Time = 0;
            TimeLabel.Text = "0:00:00/0:00:00";
            TimeBar.Value = 0;
            StatusLabel.Text = "Stopped";
        }
        #endregion

        #region Timers
        private void LengthTimer_Tick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(TrackList.Items[0].Text);
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
            AudioFileReader reader = new AudioFileReader(TrackList.Items[0].Text);
            if (Hours * 60 * 60 + Minutes * 60 + Seconds > reader.TotalTime.TotalSeconds)
            {
                LengthTimer.Stop();
                MediaPlayer.Stop();
                CurrentTimer.Stop();
            }
            else
            {
                if (TrackList.Items.Count != 0)
                {
                    if (Seconds == 0)
                        Time = CurrentSeconds * 10000 / reader.TotalTime.TotalSeconds;
                    else
                        Time = CurrentSeconds * 10000 / reader.TotalTime.TotalSeconds;
                    TimeBar.Value = Convert.ToInt32(Math.Round(Time, 0));
                    TimeLabel.Text = currentTime + "/" + ShowTime;
                }
            }
        }
        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(TrackList.Items[0].Text);
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
            AudioFileReader reader = new AudioFileReader(TrackList.Items[0].Text);
            #region Time
            if (Seconds > 59)
            {
                Seconds = 0;
                Minutes++;
            }
            if (Minutes > 59)
            {
                Minutes = 0;
                Hours++;
            }
            ShowTime = reader.TotalTime.Hours.ToString();
            if (reader.TotalTime.Minutes < 10)
            {
                ShowTime = ShowTime + ":0" + Convert.ToString(reader.TotalTime.Minutes);
            }
            else
            {
                ShowTime = ShowTime + ":" + Convert.ToString(reader.TotalTime.Minutes);
            }
            if (reader.TotalTime.Seconds < 10)
            {
                ShowTime = ShowTime + ":0" + Convert.ToString(reader.TotalTime.Seconds);
            }
            else
            {
                ShowTime = ShowTime + ":" + Convert.ToString(reader.TotalTime.Seconds);
            }

            currentTime = Hours.ToString();
            if (Minutes < 10)
            {
                currentTime = currentTime + ":0" + Minutes.ToString();
            }
            else
            {
                currentTime = currentTime + ":" + Minutes.ToString();
            }
            if (Seconds < 10)
            {
                currentTime = currentTime + ":0" + Seconds.ToString();
            }
            else
            {
                currentTime = currentTime + ":" + Seconds.ToString();
            }
            Seconds++;
            CurrentSeconds++;
            #endregion

        }
        private void AutoPlayTimer_Tick(object sender, EventArgs e)
        {

            if (AutoPlayBox.Checked)
            {
                if (TrackList.Items.Count > 0)
                {
                    AudioFileReader reader = new AudioFileReader(TrackList.Items[0].Text);
                    TimeSpan totalTime = reader.TotalTime;
                    if (CurrentSeconds == Math.Round(reader.TotalTime.TotalSeconds, 0) - 1)
                    {
                        LengthTimer.Stop();
                        CurrentTimer.Stop();
                        MilliSeconds = 0;
                        Seconds = 1;
                        Minutes = 0;
                        Hours = 0;
                        CurrentSeconds = 0;
                        Time = 0;
                        TimeBar.Value = 0;
                        if (TrackList.Items.Count > 1)
                        {
                            LengthTimer.Start();
                            CurrentTimer.Start();

                            MediaPlayer.Stop();
                            var item = TrackList.Items[0];
                            TrackList.Items.RemoveAt(0);
                            TrackList.Items.Insert(TrackList.Items.Count, item);
                            AudioFileReader fileReader = new AudioFileReader(TrackList.Items[0].Text);
                            MediaPlayer.Init(fileReader);
                            MediaPlayer.Play();
                            string Title = TrackList.Items[0].SubItems[1].Text;
                            StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
                            WhatMedia.Text = Title;
                        }
                        else
                        {
                            CurrentTimer.Start();
                            LengthTimer.Start();
                            MediaPlayer.Stop();
                            AudioFileReader fileReader = new AudioFileReader(TrackList.Items[0].Text);
                            MediaPlayer.Init(fileReader);
                            MediaPlayer.Play();
                            string Title = TrackList.Items[0].SubItems[1].Text;
                            StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
                            WhatMedia.Text = Title;
                        }
                    }
                }
                else
                {
                    AutoPlayBox.Checked = false;
                }
            }
        }
        #endregion

        private void FileButton_Click(object sender, EventArgs e)
        {
            Dialog.Multiselect = true;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Dialog.FileNames;
                if (Playing)
                {
                    MediaPlayer.Pause();
                    CurrentTimer.Stop();
                }
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    if (SuppExt.Contains(fileInfo.Extension))
                    {
                    TagLib.File tagFile = TagLib.File.Create(file);
                    ListViewItem item = new ListViewItem();
                    item.Text = file;
                    AudioFileReader reader = new AudioFileReader(file);
                    TimeSpan totalTime = reader.TotalTime;
                    
                        if (!duplicates.Contains(file))
                        {
                            duplicates.Add(file);
                            try
                            {
                                #region DisplayTime

                                DisplayTime = totalTime.Hours.ToString();
                                if (totalTime.Minutes < 10)
                                {
                                    DisplayTime = DisplayTime + ":0" + totalTime.Minutes.ToString();
                                }
                                else
                                {
                                    DisplayTime = DisplayTime + ":" + totalTime.Minutes.ToString();
                                }
                                if (totalTime.Seconds < 10)
                                {
                                    DisplayTime = DisplayTime + ":0" + totalTime.Seconds.ToString();
                                }
                                else
                                {
                                    DisplayTime = DisplayTime + ":" + totalTime.Seconds.ToString();
                                }

                                #endregion

                                if (tagFile.Tag.Title != null)
                                {
                                    item.SubItems.Add(tagFile.Tag.Title);
                                }
                                else
                                {
                                    item.SubItems.Add(fileInfo.Name);
                                }

                                item.SubItems.Add(tagFile.Tag.FirstPerformer);
                                item.SubItems.Add(tagFile.Tag.Album);
                                item.SubItems.Add(DisplayTime);
                                TrackList.Items.Add(item);
                            }
                            catch (CorruptFileException ex)
                            {
                                Corrupt.Add(fileInfo.Name);
                            }
                        }
                    }
                }
                if (Playing)
                {
                    MediaPlayer.Play();
                    CurrentTimer.Start();
                }
            }
            if (Corrupt.Count > 0)
            {
                string message = "";
                foreach (var item in Corrupt)
                    Corrupted = Corrupted + item;

                if (Corrupt.Count == 1)
                    message = "The following item: " + Corrupted + " is corrupted";
                if (Corrupt.Count > 1)
                    message = "The following items: " + Corrupted + " are corrupted";


                MessageBox.Show(message, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Playing = false;
            Pause = false;
            LengthTimer.Stop();
            MediaPlayer.Stop();
            CurrentTimer.Stop();
            MilliSeconds = 0;
            Seconds = 1;
            Minutes = 0;
            Hours = 0;
            CurrentSeconds = 0;
            Time = 0;
            TimeLabel.Text = "0:00:00/0:00:00";
            TimeBar.Value = 0;
            StatusLabel.Text = "Stopped";
            var item = TrackList.Items[0];
            TrackList.Items.RemoveAt(0);
            TrackList.Items.Insert(TrackList.Items.Count, item);
            Playing = true;
            Pause = false;
            LengthTimer.Start();
            CurrentTimer.Start();
            AudioFileReader fileReader = new AudioFileReader(TrackList.Items[0].Text);
            MediaPlayer.Init(fileReader);
            MediaPlayer.Play();
            string Title = TrackList.Items[0].SubItems[1].Text;
            StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
            WhatMedia.Text = Title;
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
            try
            {
                MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                AlbumPicBox.BackgroundImage = image;
            }
            catch (IndexOutOfRangeException)
            {
                AlbumPicBox.BackgroundImageLayout = ImageLayout.Stretch;
                AlbumPicBox.BackgroundImageLayout = ImageLayout.None;
                AlbumPicBox.BackgroundImage = AlbumPicBox.ErrorImage;
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            Playing = false;
            Pause = false;
            LengthTimer.Stop();
            MediaPlayer.Stop();
            CurrentTimer.Stop();
            MilliSeconds = 0;
            Seconds = 1;
            Minutes = 0;
            Hours = 0;
            CurrentSeconds = 0;
            Time = 0;
            TimeLabel.Text = "0:00:00/0:00:00";
            TimeBar.Value = 0;
            StatusLabel.Text = "Stopped";
            List<ListViewItem> List = new List<ListViewItem>();
            foreach (ListViewItem Item in TrackList.Items)
            {
                List.Add(Item);
            }
            int Count = List.Count;
            TrackList.Items.Clear();
            TrackList.Items.Add(List[List.Count - 1]);
            for (int j = 0; j < Count; j++)
            {
                if (j != TrackList.Items.Count - 1)
                {
                    TrackList.Items.Insert(TrackList.Items.Count, List[0]);
                    List.RemoveAt(0);
                }
            }
            Playing = true;
            Pause = false;
            LengthTimer.Start();
            CurrentTimer.Start();
            AudioFileReader fileReader = new AudioFileReader(TrackList.Items[0].Text);
            MediaPlayer.Init(fileReader);
            MediaPlayer.Play();
            string Title = TrackList.Items[0].SubItems[1].Text;
            StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
            WhatMedia.Text = Title;
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
            try
            {
                MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                AlbumPicBox.BackgroundImage = image;
            }
            catch (IndexOutOfRangeException)
            {
                AlbumPicBox.BackgroundImageLayout = ImageLayout.Stretch;
                AlbumPicBox.BackgroundImageLayout = ImageLayout.None;
                AlbumPicBox.BackgroundImage = AlbumPicBox.ErrorImage;
            }
        }

        private void AutoPlayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoPlayBox.Checked)
                AutoPlayTimer.Start();
            else
                AutoPlayTimer.Stop();
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            {
                Random rnd = new Random(Convert.ToInt32(DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 6)));
                List<ListViewItem> randomized = new List<ListViewItem>();

                int totalCount = 0;
                while (totalCount != TrackList.Items.Count)
                {
                    int i = rnd.Next(0, TrackList.Items.Count);

                    while (randomized.Contains(TrackList.Items[i]))
                    {
                        i = rnd.Next(0, TrackList.Items.Count);
                    }

                    if (!randomized.Contains(TrackList.Items[i]))
                        randomized.Add(TrackList.Items[i]);

                    totalCount++;
                }

                TrackList.Items.Clear();
                foreach (ListViewItem s in randomized)
                    TrackList.Items.Add(s);
            }
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            //            VolumeLabel.Text = Volume.Value.ToString();
            //            MediaPlayer.Volume = Volume.Value / 10000;
        }

        private void TrackList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (TrackList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    Playing = false;
                    LengthTimer.Stop();
                    MediaPlayer.Stop();
                    CurrentTimer.Stop();
                    duplicates.Remove(TrackList.FocusedItem.Text);
                    TrackList.Items.Remove(TrackList.FocusedItem);
                    MilliSeconds = 0;
                    Seconds = 1;
                    Minutes = 0;
                    Hours = 0;
                    CurrentSeconds = 0;
                    Time = 0;
                    TimeLabel.Text = "0:00:00/0:00:00";
                    TimeBar.Value = 0;
                    StatusLabel.Text = "Stopped";
                }
            }
        }

        private void BugsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not anymore :D",
                "Bugs",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void StyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StyleBox.Focused.ToString() == "Normal")
            {

            }
            if (StyleBox.Focused.ToString() == "Dark")
            {

            }
        }

        private void Player_SizeChanged(object sender, EventArgs e)
        {
            RealName.Width = TrackList.Width / 100 * 0;
            ViewName.Width = TrackList.Width / 100 * 42;
            ViewArtist.Width = TrackList.Width / 100 * 27;
            ViewAlbum.Width = TrackList.Width / 100 * 27;
            ViewLength.Width = TrackList.Width / 100 * 16;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Playing = false;
            LengthTimer.Stop();
            MediaPlayer.Stop();
            CurrentTimer.Stop();
            duplicates.Clear();
            TrackList.Items.Clear();
            MilliSeconds = 0;
            Seconds = 1;
            Minutes = 0;
            Hours = 0;
            CurrentSeconds = 0;
            Time = 0;
            TimeLabel.Text = "0:00:00/0:00:00";
            TimeBar.Value = 0;
            StatusLabel.Text = "Stopped";
        }
    }
}