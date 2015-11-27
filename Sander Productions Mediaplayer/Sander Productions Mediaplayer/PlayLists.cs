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
    public partial class PlayLists : Form
    {
        bool Selected;
        bool Changed;
        List<string> Init = new List<string>();
        public PlayLists()
        {
            InitializeComponent();
        }

        private void PlayLists_Shown(object sender, EventArgs e)
        {
            foreach (var item in Player.InTrackList)
            {
                TagLib.File tagFile = TagLib.File.Create(item);
                FileInfo fileInfo = new FileInfo(item);
                ListViewItem ListViewItem = new ListViewItem();
                ListViewItem.Text = item;

                if (tagFile.Tag.Title != null)
                {
                    ListViewItem.SubItems.Add(tagFile.Tag.Title);
                }
                else
                {
                    string ShowName = fileInfo.Name;
                    ShowName = ShowName.Replace(fileInfo.Extension, "");
                    ListViewItem.SubItems.Add(ShowName);
                }
                Current_List.Items.Add(ListViewItem);
            }
        }

        private void PlayLists_Activated(object sender, EventArgs e)
        {
            foreach (var file in Directory.GetFiles(Player.Path))
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!EditBox.Items.Contains(fileInfo.Name.Replace(fileInfo.Extension, "")))
                {
                    EditBox.Items.Add(fileInfo.Name.Replace(fileInfo.Extension, ""));
                }
            }
        }

        private void SaveListButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in Play_List.Items)
            {
                if (!Init.Contains(item.Text))
                {
                    try
                    {
                        System.IO.File.WriteAllText(Player.Path + NameText.Text + ".txt", System.IO.File.ReadAllText(Player.Path + NameText.Text + ".txt") + item.Text + Environment.NewLine);
                    }
                    catch (FileNotFoundException ex)
                    {
                        System.IO.File.WriteAllText(Player.Path + NameText.Text + ".txt", item.Text + Environment.NewLine);
                    }
                }
            }
            foreach (var file in Directory.GetFiles(Player.Path))
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!EditBox.Items.Contains(fileInfo.Name.Replace(fileInfo.Extension, "")))
                {
                    EditBox.Items.Add(fileInfo.Name.Replace(fileInfo.Extension, ""));
                }
            }
        }

        private void Current_List_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Current_List.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (!Play_List.Items.Contains(Current_List.FocusedItem))
                    {
                        TagLib.File tagFile = TagLib.File.Create(Current_List.FocusedItem.Text);
                        FileInfo fileInfo = new FileInfo(Current_List.FocusedItem.Text);
                        ListViewItem ListViewItem = new ListViewItem();
                        ListViewItem.Text = Current_List.FocusedItem.Text;

                        if (tagFile.Tag.Title != null)
                        {
                            ListViewItem.SubItems.Add(tagFile.Tag.Title);
                        }
                        else
                        {
                            string ShowName = fileInfo.Name;
                            ShowName = ShowName.Replace(fileInfo.Extension, "");
                            ListViewItem.SubItems.Add(ShowName);
                        }
                        Play_List.Items.Add(ListViewItem);
                        Current_List.Items.Remove(Current_List.FocusedItem);
                    }
                }
            }
        }

        private void Play_List_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Play_List.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    FileInfo fileInfo = new FileInfo(Play_List.FocusedItem.Text);
                    TagLib.File tagFile = TagLib.File.Create(Play_List.FocusedItem.Text + fileInfo.Extension);
                    ListViewItem ListViewItem = new ListViewItem();
                    ListViewItem.Text = Play_List.FocusedItem.Text;

                    if (tagFile.Tag.Title != null)
                    {
                        ListViewItem.SubItems.Add(tagFile.Tag.Title);
                    }
                    else
                    {
                        string ShowName = fileInfo.Name;
                        ShowName = ShowName.Replace(fileInfo.Extension, "");
                        ListViewItem.SubItems.Add(ShowName);
                    }
                    Current_List.Items.Add(ListViewItem);
                    Play_List.Items.Remove(Play_List.FocusedItem);
                }
            }
        }

        private void EditBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Changed)
            {
                Play_List.Items.Clear();
                Init.Clear();
                int counter = 0;
                string line;

                if (EditBox.SelectedItem == null)
                {
                    System.IO.StreamReader AddFile = new System.IO.StreamReader(Player.Path + NameText.Text + ".txt");

                    while ((line = AddFile.ReadLine()) != null)
                    {
                        Init.Add(line);
                        counter++;
                    }
                }
                else
                {
                    System.IO.StreamReader AddFile = new System.IO.StreamReader(Player.Path + EditBox.SelectedItem + ".txt");
                    while ((line = AddFile.ReadLine()) != null)
                    {
                        Init.Add(line);
                        counter++;
                    }
                }

                foreach (var item in Init)
                {
                    TagLib.File tagFile = TagLib.File.Create(item);
                    FileInfo fileInfo = new FileInfo(item);
                    ListViewItem ListViewItem = new ListViewItem();
                    ListViewItem.Text = item.Replace(fileInfo.Extension, "");

                    if (tagFile.Tag.Title != null)
                    {
                        ListViewItem.SubItems.Add(tagFile.Tag.Title);
                    }
                    else
                    {
                        string ShowName = fileInfo.Name;
                        ShowName = ShowName.Replace(fileInfo.Extension, "");
                        ListViewItem.SubItems.Add(ShowName);
                    }
                    Play_List.Items.Add(ListViewItem);
                }

                Selected = true;
                NameText.Text = EditBox.Text;
                Play_List.Focus();
            }
            Changed = false;
        }

        private void PlayLists_SizeChanged(object sender, EventArgs e)
        {
            RealNameCur.Width = Play_List.Width / 100 * 0;
            ViewNameCur.Width = Play_List.Width / 100 * 89;
            RealNamePlay.Width = Current_List.Width / 100 * 0;
            ViewNamePlay.Width = Current_List.Width / 100 * 89;
        }

        private void Play_List_DragEnter(object sender, DragEventArgs e)
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

        private void Play_List_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var file in (string[])(e.Data.GetData(DataFormats.FileDrop)))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    try
                    {
                        TagLib.File tagFile = TagLib.File.Create(file);
                        ListViewItem ListViewItem = new ListViewItem();
                        ListViewItem.Text = file;

                        if (tagFile.Tag.Title != null)
                        {
                            ListViewItem.SubItems.Add(tagFile.Tag.Title);
                        }
                        else
                        {
                            string ShowName = fileInfo.Name;
                            ShowName = ShowName.Replace(fileInfo.Extension, "");
                            ListViewItem.SubItems.Add(ShowName);
                        }
                        Play_List.Items.Add(ListViewItem);
                    }
                    catch (CorruptFileException ex)
                    {
                        Player.Corrupt.Add(fileInfo.Name);
                    }

                }
                if (Player.Corrupt.Count > 0)
                {
                    string message = "";
                    foreach (var item in Player.Corrupt)
                        Player.Corrupted = Player.Corrupted + item;

                    if (Player.Corrupt.Count == 1)
                        message = "The following item: " + Player.Corrupted + " is corrupted";
                    if (Player.Corrupt.Count > 1)
                        message = "The following items: " + Player.Corrupted + " are corrupted";


                    MessageBox.Show(message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void NameText_TextChanged(object sender, EventArgs e)
        {
            Changed = true;

            if (!Selected)
            {
                EditBox.SelectedItem = null;
            }
            Selected = false;
        }
    }
}
