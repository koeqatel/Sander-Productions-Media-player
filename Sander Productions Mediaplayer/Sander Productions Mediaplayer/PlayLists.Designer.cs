namespace Sander_Productions_Mediaplayer
{
    partial class PlayLists
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
            this.Current_List = new System.Windows.Forms.ListView();
            this.RealNameCur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewNameCur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Play_List = new System.Windows.Forms.ListView();
            this.RealNamePlay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViewNamePlay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveListButton = new System.Windows.Forms.Button();
            this.NameText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Current_List
            // 
            this.Current_List.AllowDrop = true;
            this.Current_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Current_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RealNameCur,
            this.ViewNameCur});
            this.Current_List.Location = new System.Drawing.Point(12, 67);
            this.Current_List.Name = "Current_List";
            this.Current_List.Size = new System.Drawing.Size(199, 261);
            this.Current_List.TabIndex = 35;
            this.Current_List.UseCompatibleStateImageBehavior = false;
            this.Current_List.View = System.Windows.Forms.View.Details;
            this.Current_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Current_List_MouseClick);
            // 
            // RealNameCur
            // 
            this.RealNameCur.DisplayIndex = 1;
            this.RealNameCur.Text = "FilePath";
            this.RealNameCur.Width = 0;
            // 
            // ViewNameCur
            // 
            this.ViewNameCur.DisplayIndex = 0;
            this.ViewNameCur.Text = "Current List";
            this.ViewNameCur.Width = 175;
            // 
            // Play_List
            // 
            this.Play_List.AllowDrop = true;
            this.Play_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Play_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RealNamePlay,
            this.ViewNamePlay});
            this.Play_List.Location = new System.Drawing.Point(272, 67);
            this.Play_List.Name = "Play_List";
            this.Play_List.Size = new System.Drawing.Size(209, 261);
            this.Play_List.TabIndex = 36;
            this.Play_List.UseCompatibleStateImageBehavior = false;
            this.Play_List.View = System.Windows.Forms.View.Details;
            this.Play_List.DragDrop += new System.Windows.Forms.DragEventHandler(this.Play_List_DragDrop);
            this.Play_List.DragEnter += new System.Windows.Forms.DragEventHandler(this.Play_List_DragEnter);
            this.Play_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Play_List_MouseClick);
            // 
            // RealNamePlay
            // 
            this.RealNamePlay.DisplayIndex = 1;
            this.RealNamePlay.Text = "FilePath";
            this.RealNamePlay.Width = 0;
            // 
            // ViewNamePlay
            // 
            this.ViewNamePlay.DisplayIndex = 0;
            this.ViewNamePlay.Text = "PlayList";
            this.ViewNamePlay.Width = 175;
            // 
            // SaveListButton
            // 
            this.SaveListButton.Location = new System.Drawing.Point(12, 9);
            this.SaveListButton.Name = "SaveListButton";
            this.SaveListButton.Size = new System.Drawing.Size(75, 23);
            this.SaveListButton.TabIndex = 37;
            this.SaveListButton.Text = "Save List";
            this.SaveListButton.UseVisualStyleBackColor = true;
            this.SaveListButton.Click += new System.EventHandler(this.SaveListButton_Click);
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(56, 38);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(425, 23);
            this.NameText.TabIndex = 38;
            this.NameText.Text = "";
            this.NameText.TextChanged += new System.EventHandler(this.NameText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Name:";
            // 
            // EditBox
            // 
            this.EditBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditBox.FormattingEnabled = true;
            this.EditBox.Location = new System.Drawing.Point(93, 11);
            this.EditBox.Name = "EditBox";
            this.EditBox.Size = new System.Drawing.Size(121, 21);
            this.EditBox.TabIndex = 40;
            this.EditBox.Tag = "";
            this.EditBox.SelectedIndexChanged += new System.EventHandler(this.EditBox_SelectedIndexChanged);
            // 
            // PlayLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 340);
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.SaveListButton);
            this.Controls.Add(this.Play_List);
            this.Controls.Add(this.Current_List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayLists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayLists";
            this.Activated += new System.EventHandler(this.PlayLists_Activated);
            this.Shown += new System.EventHandler(this.PlayLists_Shown);
            this.SizeChanged += new System.EventHandler(this.PlayLists_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Current_List;
        private System.Windows.Forms.ColumnHeader RealNameCur;
        private System.Windows.Forms.ColumnHeader ViewNameCur;
        private System.Windows.Forms.ListView Play_List;
        private System.Windows.Forms.ColumnHeader RealNamePlay;
        private System.Windows.Forms.ColumnHeader ViewNamePlay;
        private System.Windows.Forms.Button SaveListButton;
        private System.Windows.Forms.RichTextBox NameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EditBox;
    }
}