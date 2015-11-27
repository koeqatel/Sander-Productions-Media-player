namespace Sander_Productions_Mediaplayer
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.StatusLabel = new System.Windows.Forms.Label();
            this.FileButton = new System.Windows.Forms.Button();
            this.LengthTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.TrackList = new System.Windows.Forms.ListView();
            this.RealName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.AutoPlayBox = new System.Windows.Forms.CheckBox();
            this.AutoPlayTimer = new System.Windows.Forms.Timer(this.components);
            this.WhatMedia = new System.Windows.Forms.TextBox();
            this.CurrentTimer = new System.Windows.Forms.Timer(this.components);
            this.AlbumPicBox = new System.Windows.Forms.PictureBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.FolderButton = new System.Windows.Forms.Button();
            this.FolderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.PlayListButton = new System.Windows.Forms.Button();
            this.PlayListBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(179, 17);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(95, 13);
            this.StatusLabel.TabIndex = 23;
            this.StatusLabel.Text = "No media selected";
            // 
            // FileButton
            // 
            this.FileButton.BackColor = System.Drawing.SystemColors.Control;
            this.FileButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.FileButton.FlatAppearance.BorderSize = 3;
            this.FileButton.Location = new System.Drawing.Point(12, 12);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(75, 23);
            this.FileButton.TabIndex = 21;
            this.FileButton.Text = "Choose file";
            this.FileButton.UseVisualStyleBackColor = false;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // LengthTimer
            // 
            this.LengthTimer.Interval = 10;
            this.LengthTimer.Tick += new System.EventHandler(this.LengthTimer_Tick);
            // 
            // TimeBar
            // 
            this.TimeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeBar.Enabled = false;
            this.TimeBar.Location = new System.Drawing.Point(12, 125);
            this.TimeBar.Maximum = 10000;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(316, 45);
            this.TimeBar.TabIndex = 28;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(28, 41);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(50, 50);
            this.StopButton.TabIndex = 27;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(88, 41);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.TabIndex = 26;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlayButton.Location = new System.Drawing.Point(148, 41);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(50, 50);
            this.PlayButton.TabIndex = 25;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.Playbutton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(12, 97);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(60, 23);
            this.PreviousButton.TabIndex = 30;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(157, 96);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(60, 23);
            this.NextButton.TabIndex = 31;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // TrackList
            // 
            this.TrackList.AllowDrop = true;
            this.TrackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RealName,
            this.ViewName,
            this.ViewArtist,
            this.ViewAlbum,
            this.ViewLength});
            this.TrackList.Cursor = System.Windows.Forms.Cursors.Default;
            this.TrackList.Location = new System.Drawing.Point(12, 178);
            this.TrackList.Name = "TrackList";
            this.TrackList.Size = new System.Drawing.Size(469, 152);
            this.TrackList.TabIndex = 34;
            this.TrackList.UseCompatibleStateImageBehavior = false;
            this.TrackList.View = System.Windows.Forms.View.Details;
            this.TrackList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.TrackList_ColumnWidthChanging);
            this.TrackList.DragDrop += new System.Windows.Forms.DragEventHandler(this.TrackList_DragDrop);
            this.TrackList.DragEnter += new System.Windows.Forms.DragEventHandler(this.TrackList_DragEnter);
            this.TrackList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrackList_MouseClick);
            // 
            // RealName
            // 
            this.RealName.DisplayIndex = 4;
            this.RealName.Text = "FilePath";
            this.RealName.Width = 0;
            // 
            // ViewName
            // 
            this.ViewName.DisplayIndex = 0;
            this.ViewName.Text = "Name";
            this.ViewName.Width = 175;
            // 
            // ViewArtist
            // 
            this.ViewArtist.DisplayIndex = 1;
            this.ViewArtist.Text = "Artist";
            this.ViewArtist.Width = 100;
            // 
            // ViewAlbum
            // 
            this.ViewAlbum.DisplayIndex = 2;
            this.ViewAlbum.Text = "Album";
            this.ViewAlbum.Width = 100;
            // 
            // ViewLength
            // 
            this.ViewLength.DisplayIndex = 3;
            this.ViewLength.Text = "Length";
            this.ViewLength.Width = 72;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.Location = new System.Drawing.Point(204, 68);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(59, 23);
            this.ShuffleButton.TabIndex = 39;
            this.ShuffleButton.Text = "Shuffle";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // AutoPlayBox
            // 
            this.AutoPlayBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoPlayBox.AutoSize = true;
            this.AutoPlayBox.Checked = true;
            this.AutoPlayBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoPlayBox.Location = new System.Drawing.Point(269, 68);
            this.AutoPlayBox.Name = "AutoPlayBox";
            this.AutoPlayBox.Size = new System.Drawing.Size(59, 23);
            this.AutoPlayBox.TabIndex = 40;
            this.AutoPlayBox.Text = "AutoPlay";
            this.AutoPlayBox.UseVisualStyleBackColor = true;
            // 
            // AutoPlayTimer
            // 
            this.AutoPlayTimer.Enabled = true;
            this.AutoPlayTimer.Interval = 1000;
            this.AutoPlayTimer.Tick += new System.EventHandler(this.AutoPlayTimer_Tick);
            // 
            // WhatMedia
            // 
            this.WhatMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WhatMedia.BackColor = System.Drawing.SystemColors.Control;
            this.WhatMedia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WhatMedia.Cursor = System.Windows.Forms.Cursors.Default;
            this.WhatMedia.Location = new System.Drawing.Point(12, 153);
            this.WhatMedia.Name = "WhatMedia";
            this.WhatMedia.ReadOnly = true;
            this.WhatMedia.Size = new System.Drawing.Size(469, 13);
            this.WhatMedia.TabIndex = 44;
            this.WhatMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentTimer
            // 
            this.CurrentTimer.Interval = 1000;
            this.CurrentTimer.Tick += new System.EventHandler(this.CurrentTimer_Tick);
            // 
            // AlbumPicBox
            // 
            this.AlbumPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlbumPicBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AlbumPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlbumPicBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("AlbumPicBox.ErrorImage")));
            this.AlbumPicBox.Location = new System.Drawing.Point(336, 12);
            this.AlbumPicBox.Name = "AlbumPicBox";
            this.AlbumPicBox.Size = new System.Drawing.Size(145, 135);
            this.AlbumPicBox.TabIndex = 46;
            this.AlbumPicBox.TabStop = false;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(73, 107);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(84, 13);
            this.TimeLabel.TabIndex = 36;
            this.TimeLabel.Text = "0:00:00/0:00:00";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(204, 39);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(59, 23);
            this.ClearButton.TabIndex = 47;
            this.ClearButton.Text = "Clear List";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // FolderButton
            // 
            this.FolderButton.BackColor = System.Drawing.SystemColors.Control;
            this.FolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.FolderButton.FlatAppearance.BorderSize = 3;
            this.FolderButton.Location = new System.Drawing.Point(93, 12);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(80, 23);
            this.FolderButton.TabIndex = 48;
            this.FolderButton.Text = "Choose folder";
            this.FolderButton.UseVisualStyleBackColor = false;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // FolderPicker
            // 
            this.FolderPicker.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderPicker.SelectedPath = "C:\\Users\\Sander\\Music";
            // 
            // PlayListButton
            // 
            this.PlayListButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.PlayListButton.Location = new System.Drawing.Point(269, 39);
            this.PlayListButton.Name = "PlayListButton";
            this.PlayListButton.Size = new System.Drawing.Size(59, 23);
            this.PlayListButton.TabIndex = 49;
            this.PlayListButton.Text = "PlayLists";
            this.PlayListButton.UseVisualStyleBackColor = true;
            this.PlayListButton.Click += new System.EventHandler(this.PlayListButton_Click);
            // 
            // PlayListBox
            // 
            this.PlayListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PlayListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayListBox.FormattingEnabled = true;
            this.PlayListBox.Location = new System.Drawing.Point(223, 97);
            this.PlayListBox.Name = "PlayListBox";
            this.PlayListBox.Size = new System.Drawing.Size(105, 21);
            this.PlayListBox.TabIndex = 50;
            this.PlayListBox.SelectedIndexChanged += new System.EventHandler(this.PlayListBox_SelectedIndexChanged);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 340);
            this.Controls.Add(this.PlayListBox);
            this.Controls.Add(this.PlayListButton);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.AutoPlayBox);
            this.Controls.Add(this.ShuffleButton);
            this.Controls.Add(this.TrackList);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.WhatMedia);
            this.Controls.Add(this.TimeBar);
            this.Controls.Add(this.AlbumPicBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sander Productions MediaPlayer";
            this.Activated += new System.EventHandler(this.Player_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Player_FormClosing);
            this.Shown += new System.EventHandler(this.Player_Shown);
            this.SizeChanged += new System.EventHandler(this.Player_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.Timer LengthTimer;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.ColumnHeader ViewName;
        private System.Windows.Forms.ColumnHeader ViewArtist;
        private System.Windows.Forms.ColumnHeader ViewAlbum;
        public System.Windows.Forms.TrackBar TimeBar;
        internal System.Windows.Forms.ColumnHeader ViewLength;
        private System.Windows.Forms.ColumnHeader RealName;
        private System.Windows.Forms.Button ShuffleButton;
        private System.Windows.Forms.CheckBox AutoPlayBox;
        private System.Windows.Forms.Timer AutoPlayTimer;
        private System.Windows.Forms.TextBox WhatMedia;
        private System.Windows.Forms.Timer CurrentTimer;
        private System.Windows.Forms.PictureBox AlbumPicBox;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.FolderBrowserDialog FolderPicker;
        private System.Windows.Forms.Button PlayListButton;
        private System.Windows.Forms.ComboBox PlayListBox;
        public System.Windows.Forms.ListView TrackList;
    }
}

