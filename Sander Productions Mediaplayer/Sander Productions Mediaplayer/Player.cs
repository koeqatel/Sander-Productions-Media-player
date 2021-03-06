﻿using System;
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
            SuppExt.Add(".mp4");
            #endregion            
            TimeBar.TickFrequency = 2500;
            FolderPicker.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1) + @":\Users\" + Environment.UserName + @"\Music\";
            RealName.Width = TrackList.Width / 100 * 0;
            ViewName.Width = TrackList.Width / 100 * 42;
            ViewArtist.Width = TrackList.Width / 100 * 26;
            ViewAlbum.Width = TrackList.Width / 100 * 26;
        }

        #region Public Fields & Stuff
        public int CurrentSeconds = 0;
        public int Seconds = 1;
        public int Minutes = 0;
        public int Hours = 0;
        public double Time;
        public bool Pause;
        public bool Playing;
        public string DisplayTime;
        public string currentTime;
        public string ShowTime;
        public static string Corrupted;
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1) + @":\Users\" + Environment.UserName + @"\SP-PlayLists\";
        private int lockColumnIndex = 0;



        public static List<string> files = new List<string>();
        public static List<string> SuppExt = new List<string>();
        public static List<string> InTrackList = new List<string>();
        public static List<string> Corrupt = new List<string>();
        OpenFileDialog Dialog = new OpenFileDialog();
        IWavePlayer MediaPlayer = new WaveOut();
        #endregion

        #region Methods
        public void Add()
        {
            Corrupt.Clear();
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
                    try
                    {
                        TagLib.File tagFile = TagLib.File.Create(file);
                        ListViewItem item = new ListViewItem();
                        item.Text = file;
                        TimeSpan totalTime = tagFile.Properties.Duration;

                        if (!InTrackList.Contains(file))
                        {
                            InTrackList.Add(file);

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
                                string ShowName = fileInfo.Name;
                                ShowName = ShowName.Replace(fileInfo.Extension, "");
                                item.SubItems.Add(ShowName);
                            }

                            item.SubItems.Add(tagFile.Tag.FirstPerformer);
                            item.SubItems.Add(tagFile.Tag.Album);
                            item.SubItems.Add(DisplayTime);
                            TrackList.Items.Add(item);
                        }
                    }
                    catch (CorruptFileException)
                    {
                        Corrupt.Add(fileInfo.Name);
                    }
                }
            }
            if (Playing)
            {
                MediaPlayer.Play();
                CurrentTimer.Start();
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
        public void Start()
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
                        string Artist = TrackList.Items[0].SubItems[2].Text;
                        StatusLabel.Text = MediaPlayer.PlaybackState.ToString();
                        WhatMedia.Text = Artist + " - " + Title;
                        TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
                        try
                        {
                            AlbumPicBox.BackgroundImageLayout = ImageLayout.Stretch;
                            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            AlbumPicBox.BackgroundImage = image;
                        }
                        catch (IndexOutOfRangeException)
                        {
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
        public void Stop()
        {
            Playing = false;
            Pause = false;
            MediaPlayer.Stop();
            MediaPlayer.Dispose();
            LengthTimer.Stop();
            CurrentTimer.Stop();
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

        private void Player_Shown(object sender, EventArgs e)
        {
            {
                try
                {
                    foreach (var file in Directory.GetFiles(Path))
                        files.Add(file);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    if (!System.IO.Directory.Exists(Path))
                        System.IO.Directory.CreateDirectory(Path);
                }
            }
        }

        #region Buttons
        private void Playbutton_Click(object sender, EventArgs e)
        {
            Start();
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
            Stop();
        }
        #endregion

        #region Timers
        private void LengthTimer_Tick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(TrackList.Items[0].Text);
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
            if (Hours * 60 * 60 + Minutes * 60 + Seconds > tagFile.Properties.Duration.TotalSeconds + 1)
            {
                Stop();
            }
            else
            {
                if (TrackList.Items.Count != 0)
                {
                    if (Seconds == 0)
                        Time = CurrentSeconds * 10000 / tagFile.Properties.Duration.TotalSeconds;
                    else
                        Time = CurrentSeconds * 10000 / tagFile.Properties.Duration.TotalSeconds;
                    TimeBar.Value = Convert.ToInt32(Math.Round(Time, 0));
                    TimeLabel.Text = currentTime + "/" + ShowTime;
                }
            }
        }
        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(TrackList.Items[0].Text);
            TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
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
            ShowTime = tagFile.Properties.Duration.Hours.ToString();
            if (tagFile.Properties.Duration.Minutes < 10)
            {
                ShowTime = ShowTime + ":0" + Convert.ToString(tagFile.Properties.Duration.Minutes);
            }
            else
            {
                ShowTime = ShowTime + ":" + Convert.ToString(tagFile.Properties.Duration.Minutes);
            }
            if (tagFile.Properties.Duration.Seconds < 10)
            {
                ShowTime = ShowTime + ":0" + Convert.ToString(tagFile.Properties.Duration.Seconds);
            }
            else
            {
                ShowTime = ShowTime + ":" + Convert.ToString(tagFile.Properties.Duration.Seconds);
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
                    TagLib.File tagFile = TagLib.File.Create(TrackList.Items[0].Text);
                    TimeSpan totalTime = tagFile.Properties.Duration;
                    if (CurrentSeconds == Math.Round(tagFile.Properties.Duration.TotalSeconds, 0) - 1)
                    {
                        Stop();
                        if (TrackList.Items.Count > 1)
                        {
                            Stop();
                            var item = TrackList.Items[0];
                            TrackList.Items.RemoveAt(0);
                            TrackList.Items.Insert(TrackList.Items.Count, item);
                            Start();
                        }
                        else
                        {
                            Start();
                        }
                    }
                }
            }
        }
        #endregion

        private void FileButton_Click(object sender, EventArgs e)
        {
            Dialog.Multiselect = true;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in Dialog.FileNames)
                    files.Add(file);
                Add();
            }
        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            if (FolderPicker.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in Directory.GetFiles(FolderPicker.SelectedPath))
                    files.Add(file);
                Add();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Stop();
            var item = TrackList.Items[0];
            TrackList.Items.RemoveAt(0);
            TrackList.Items.Insert(TrackList.Items.Count, item);
            Start();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            Stop();
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
            Start();
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

        private void TrackList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (TrackList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    InTrackList.Remove(TrackList.FocusedItem.Text);
                    TrackList.Items.Remove(TrackList.FocusedItem);
                }
            }
        }

        private void Player_SizeChanged(object sender, EventArgs e)
        {
            RealName.Width = TrackList.Width / 100 * 0;
            ViewName.Width = TrackList.Width / 100 * 42;
            ViewArtist.Width = TrackList.Width / 100 * 26;
            ViewAlbum.Width = TrackList.Width / 100 * 26;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Stop();
            InTrackList.Clear();
            TrackList.Items.Clear();
        }

        private void PlayListButton_Click(object sender, EventArgs e)
        {
            PlayLists List = new PlayLists();
            List.ShowDialog();
        }

        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TrackList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TrackList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var file in (string[])(e.Data.GetData(DataFormats.FileDrop)))
                    files.Add(file);
                Add();
            }
        }

        private void PlayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop();
            InTrackList.Clear();
            TrackList.Items.Clear();
            files.Clear();

            string line;

            List<string> Init = new List<string>();
            // Read the file and display it line by line.
            System.IO.StreamReader AddFile = new System.IO.StreamReader(Path + PlayListBox.SelectedItem + ".txt");
            while ((line = AddFile.ReadLine()) != null)
            {
                files.Add(line);
            }
            Add();
            TrackList.Focus();
        }

        private void Player_Activated(object sender, EventArgs e)
        {
            try
            {
                foreach (var file in Directory.GetFiles(Path))
                {

                    FileInfo fileInfo = new FileInfo(file);

                    if (!PlayListBox.Items.Contains(fileInfo.Name.Replace(fileInfo.Extension, "")))
                    {
                        PlayListBox.Items.Add(fileInfo.Name.Replace(fileInfo.Extension, ""));
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Application.Restart();
            }
        }

        private void TrackList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == lockColumnIndex)
            {
                //Keep the width not changed.
                e.NewWidth = this.TrackList.Columns[e.ColumnIndex].Width;
                //Cancel the event.
                e.Cancel = true;
            }
        }
    }
}