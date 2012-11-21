﻿namespace REACH.Client.Views
{
	partial class MyAccountView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAccountView));
			this.loggedInUser = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.certsContainer = new System.Windows.Forms.Panel();
			this.certs = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.crtRating = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.uncertsContainer = new System.Windows.Forms.Panel();
			this.certsContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.SuspendLayout();
			// 
			// loggedInUser
			// 
			this.loggedInUser.AutoSize = true;
			this.loggedInUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loggedInUser.ForeColor = System.Drawing.Color.Blue;
			this.loggedInUser.Location = new System.Drawing.Point(157, 7);
			this.loggedInUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.loggedInUser.Name = "loggedInUser";
			this.loggedInUser.Size = new System.Drawing.Size(33, 16);
			this.loggedInUser.TabIndex = 15;
			this.loggedInUser.Text = "test";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "You are logged in as:";
			// 
			// certsContainer
			// 
			this.certsContainer.Controls.Add(this.certs);
			this.certsContainer.Location = new System.Drawing.Point(6, 80);
			this.certsContainer.Name = "certsContainer";
			this.certsContainer.Size = new System.Drawing.Size(248, 112);
			this.certsContainer.TabIndex = 18;
			// 
			// certs
			// 
			this.certs.FormattingEnabled = true;
			this.certs.ItemHeight = 16;
			this.certs.Location = new System.Drawing.Point(7, 6);
			this.certs.Name = "certs";
			this.certs.Size = new System.Drawing.Size(235, 100);
			this.certs.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 31);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 16);
			this.label3.TabIndex = 19;
			this.label3.Text = "Your current rating:";
			// 
			// crtRating
			// 
			this.crtRating.AutoSize = true;
			this.crtRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.crtRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.crtRating.Location = new System.Drawing.Point(142, 31);
			this.crtRating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.crtRating.Name = "crtRating";
			this.crtRating.Size = new System.Drawing.Size(40, 16);
			this.crtRating.TabIndex = 20;
			this.crtRating.Text = "1200";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(-2, 23);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 32);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 21;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 22;
			this.pictureBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 55);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(206, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = "You already have a certificate for:";
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(-2, 47);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(32, 32);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 24;
			this.pictureBox3.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 208);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(220, 16);
			this.label2.TabIndex = 25;
			this.label2.Text = "You can try to obtain a certificate for:";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(1, 200);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(32, 32);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox4.TabIndex = 26;
			this.pictureBox4.TabStop = false;
			// 
			// uncertsContainer
			// 
			this.uncertsContainer.Location = new System.Drawing.Point(6, 264);
			this.uncertsContainer.Name = "uncertsContainer";
			this.uncertsContainer.Size = new System.Drawing.Size(248, 92);
			this.uncertsContainer.TabIndex = 19;
			// 
			// MyAccountView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 419);
			this.Controls.Add(this.uncertsContainer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.crtRating);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.certsContainer);
			this.Controls.Add(this.loggedInUser);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox3);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(130, 5);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MyAccountView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MyAccountView";
			this.certsContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label loggedInUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel certsContainer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label crtRating;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Panel uncertsContainer;
		private System.Windows.Forms.ListBox certs;


	}
}