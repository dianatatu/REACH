namespace REACH.Client.Views
{
    partial class FriendListView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendListView));
			this.invitingCheckBox = new System.Windows.Forms.CheckBox();
			this.invitedCheckBox = new System.Windows.Forms.CheckBox();
			this.offlineCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.addFriendTextBox = new System.Windows.Forms.TextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toggleStatusButton = new System.Windows.Forms.Button();
			this.customStylesCheckbox = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// invitingCheckBox
			// 
			this.invitingCheckBox.AutoSize = true;
			this.invitingCheckBox.Checked = true;
			this.invitingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.invitingCheckBox.Location = new System.Drawing.Point(270, 417);
			this.invitingCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.invitingCheckBox.Name = "invitingCheckBox";
			this.invitingCheckBox.Size = new System.Drawing.Size(60, 17);
			this.invitingCheckBox.TabIndex = 2;
			this.invitingCheckBox.Text = "Inviting";
			this.invitingCheckBox.UseVisualStyleBackColor = true;
			this.invitingCheckBox.CheckedChanged += new System.EventHandler(this.invitingCheckBox_CheckedChanged);
			// 
			// invitedCheckBox
			// 
			this.invitedCheckBox.AutoSize = true;
			this.invitedCheckBox.Checked = true;
			this.invitedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.invitedCheckBox.Location = new System.Drawing.Point(144, 417);
			this.invitedCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.invitedCheckBox.Name = "invitedCheckBox";
			this.invitedCheckBox.Size = new System.Drawing.Size(58, 17);
			this.invitedCheckBox.TabIndex = 1;
			this.invitedCheckBox.Text = "Invited";
			this.invitedCheckBox.UseVisualStyleBackColor = true;
			this.invitedCheckBox.CheckedChanged += new System.EventHandler(this.invitedCheckBox_CheckedChanged);
			// 
			// offlineCheckBox
			// 
			this.offlineCheckBox.AutoSize = true;
			this.offlineCheckBox.Checked = true;
			this.offlineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.offlineCheckBox.Location = new System.Drawing.Point(12, 417);
			this.offlineCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.offlineCheckBox.Name = "offlineCheckBox";
			this.offlineCheckBox.Size = new System.Drawing.Size(56, 17);
			this.offlineCheckBox.TabIndex = 0;
			this.offlineCheckBox.Text = "Offline";
			this.offlineCheckBox.UseVisualStyleBackColor = true;
			this.offlineCheckBox.CheckedChanged += new System.EventHandler(this.offlineCheckBox_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(12, 81);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(318, 307);
			this.panel1.TabIndex = 7;
			// 
			// addFriendTextBox
			// 
			this.addFriendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.addFriendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addFriendTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(73)))), ((int)(((byte)(104)))));
			this.addFriendTextBox.Location = new System.Drawing.Point(12, 390);
			this.addFriendTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.addFriendTextBox.Name = "addFriendTextBox";
			this.addFriendTextBox.Size = new System.Drawing.Size(318, 23);
			this.addFriendTextBox.TabIndex = 12;
			this.addFriendTextBox.Text = "Add a friend...";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(4, 6);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(58, 58);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.label1.Location = new System.Drawing.Point(111, -21);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 18);
			this.label1.TabIndex = 16;
			this.label1.Text = "test";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.label2.Location = new System.Drawing.Point(80, -19);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 15);
			this.label2.TabIndex = 17;
			this.label2.Text = "Hello,";
			// 
			// toggleStatusButton
			// 
			this.toggleStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(209)))), ((int)(((byte)(228)))));
			this.toggleStatusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(150)))), ((int)(((byte)(193)))));
			this.toggleStatusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.toggleStatusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(182)))));
			this.toggleStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.toggleStatusButton.ForeColor = System.Drawing.Color.Black;
			this.toggleStatusButton.Location = new System.Drawing.Point(264, 8);
			this.toggleStatusButton.Margin = new System.Windows.Forms.Padding(2);
			this.toggleStatusButton.Name = "toggleStatusButton";
			this.toggleStatusButton.Size = new System.Drawing.Size(80, 26);
			this.toggleStatusButton.TabIndex = 1;
			this.toggleStatusButton.Text = "Go Online";
			this.toggleStatusButton.UseVisualStyleBackColor = false;
			this.toggleStatusButton.Click += new System.EventHandler(this.toggleStatusButton_Click);
			// 
			// customStylesCheckbox
			// 
			this.customStylesCheckbox.AutoSize = true;
			this.customStylesCheckbox.Checked = true;
			this.customStylesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.customStylesCheckbox.Location = new System.Drawing.Point(225, 47);
			this.customStylesCheckbox.Margin = new System.Windows.Forms.Padding(2);
			this.customStylesCheckbox.Name = "customStylesCheckbox";
			this.customStylesCheckbox.Size = new System.Drawing.Size(128, 17);
			this.customStylesCheckbox.TabIndex = 18;
			this.customStylesCheckbox.Text = "Enable Custom Styles";
			this.customStylesCheckbox.UseVisualStyleBackColor = true;
			this.customStylesCheckbox.Visible = false;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(166)))), ((int)(((byte)(203)))));
			this.button1.FlatAppearance.BorderSize = 2;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(4, 74);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(340, 370);
			this.button1.TabIndex = 14;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// FriendListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(355, 454);
			this.Controls.Add(this.invitingCheckBox);
			this.Controls.Add(this.customStylesCheckbox);
			this.Controls.Add(this.offlineCheckBox);
			this.Controls.Add(this.invitedCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.addFriendTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toggleStatusButton);
			this.Controls.Add(this.button1);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(87)))), ((int)(((byte)(147)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(800, 0);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "FriendListView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Talk with friends";
			this.Load += new System.EventHandler(this.FriendListView_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.CheckBox invitingCheckBox;
        private System.Windows.Forms.CheckBox invitedCheckBox;
		private System.Windows.Forms.CheckBox offlineCheckBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox addFriendTextBox;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button toggleStatusButton;
		private System.Windows.Forms.CheckBox customStylesCheckbox;
		private System.Windows.Forms.Button button1;
    }
}