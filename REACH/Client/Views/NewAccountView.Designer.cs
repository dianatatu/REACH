namespace REACH.Client.Views
{
	partial class NewAccountView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAccountView));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.errorMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.domains = new System.Windows.Forms.CheckedListBox();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.confirm = new System.Windows.Forms.TextBox();
			this.email = new System.Windows.Forms.TextBox();
			this.status = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.tryagain = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.formContainer = new System.Windows.Forms.Panel();
			this.CreateNewAccountBtn = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.formContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.AutoSize = false;
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 333);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
			this.statusStrip1.Size = new System.Drawing.Size(681, 18);
			this.statusStrip1.TabIndex = 13;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// errorMessage
			// 
			this.errorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorMessage.ForeColor = System.Drawing.Color.Red;
			this.errorMessage.Name = "errorMessage";
			this.errorMessage.Size = new System.Drawing.Size(0, 13);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(403, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 17);
			this.label1.TabIndex = 20;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(403, 63);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(404, 89);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 17);
			this.label3.TabIndex = 22;
			this.label3.Text = "Confirm password:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(404, 114);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 17);
			this.label4.TabIndex = 23;
			this.label4.Text = "E-mail:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(403, 187);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 17);
			this.label5.TabIndex = 24;
			this.label5.Text = "Domains:";
			// 
			// domains
			// 
			this.domains.CheckOnClick = true;
			this.domains.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.domains.FormattingEnabled = true;
			this.domains.Location = new System.Drawing.Point(539, 138);
			this.domains.Margin = new System.Windows.Forms.Padding(2);
			this.domains.Name = "domains";
			this.domains.Size = new System.Drawing.Size(131, 148);
			this.domains.Sorted = true;
			this.domains.TabIndex = 30;
			// 
			// username
			// 
			this.username.BackColor = System.Drawing.Color.White;
			this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.username.Cursor = System.Windows.Forms.Cursors.Default;
			this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.username.Location = new System.Drawing.Point(539, 35);
			this.username.Margin = new System.Windows.Forms.Padding(2);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(131, 23);
			this.username.TabIndex = 26;
			// 
			// password
			// 
			this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.password.Cursor = System.Windows.Forms.Cursors.Default;
			this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.password.Location = new System.Drawing.Point(539, 61);
			this.password.Margin = new System.Windows.Forms.Padding(2);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(131, 23);
			this.password.TabIndex = 27;
			// 
			// confirm
			// 
			this.confirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.confirm.Cursor = System.Windows.Forms.Cursors.Default;
			this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.confirm.Location = new System.Drawing.Point(539, 87);
			this.confirm.Margin = new System.Windows.Forms.Padding(2);
			this.confirm.Name = "confirm";
			this.confirm.PasswordChar = '*';
			this.confirm.Size = new System.Drawing.Size(131, 23);
			this.confirm.TabIndex = 28;
			// 
			// email
			// 
			this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.email.Cursor = System.Windows.Forms.Cursors.Default;
			this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.email.Location = new System.Drawing.Point(539, 112);
			this.email.Margin = new System.Windows.Forms.Padding(2);
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(131, 23);
			this.email.TabIndex = 29;
			// 
			// status
			// 
			this.status.BackColor = System.Drawing.Color.White;
			this.status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.status.Location = new System.Drawing.Point(539, 138);
			this.status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(131, 148);
			this.status.TabIndex = 30;
			this.status.Text = "Loading...";
			this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(10, 11);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(351, 18);
			this.label6.TabIndex = 31;
			this.label6.Text = "Become a member of the REACH community!";
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(589, 296);
			this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(60, 24);
			this.CancelBtn.TabIndex = 32;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// tryagain
			// 
			this.tryagain.AutoSize = true;
			this.tryagain.BackColor = System.Drawing.Color.White;
			this.tryagain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tryagain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tryagain.ForeColor = System.Drawing.Color.Blue;
			this.tryagain.Location = new System.Drawing.Point(562, 232);
			this.tryagain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.tryagain.Name = "tryagain";
			this.tryagain.Size = new System.Drawing.Size(81, 17);
			this.tryagain.TabIndex = 36;
			this.tryagain.Text = "Try again!";
			this.tryagain.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(11, 51);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(379, 248);
			this.pictureBox2.TabIndex = 37;
			this.pictureBox2.TabStop = false;
			// 
			// formContainer
			// 
			this.formContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
			this.formContainer.Controls.Add(this.pictureBox2);
			this.formContainer.Controls.Add(this.tryagain);
			this.formContainer.Controls.Add(this.CancelBtn);
			this.formContainer.Controls.Add(this.CreateNewAccountBtn);
			this.formContainer.Controls.Add(this.label6);
			this.formContainer.Controls.Add(this.status);
			this.formContainer.Controls.Add(this.email);
			this.formContainer.Controls.Add(this.confirm);
			this.formContainer.Controls.Add(this.password);
			this.formContainer.Controls.Add(this.username);
			this.formContainer.Controls.Add(this.domains);
			this.formContainer.Controls.Add(this.label5);
			this.formContainer.Controls.Add(this.label4);
			this.formContainer.Controls.Add(this.label3);
			this.formContainer.Controls.Add(this.label2);
			this.formContainer.Controls.Add(this.label1);
			this.formContainer.Location = new System.Drawing.Point(0, 2);
			this.formContainer.Margin = new System.Windows.Forms.Padding(2);
			this.formContainer.Name = "formContainer";
			this.formContainer.Size = new System.Drawing.Size(683, 331);
			this.formContainer.TabIndex = 20;
			// 
			// CreateNewAccountBtn
			// 
			this.CreateNewAccountBtn.Enabled = false;
			this.CreateNewAccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreateNewAccountBtn.Location = new System.Drawing.Point(437, 296);
			this.CreateNewAccountBtn.Margin = new System.Windows.Forms.Padding(2);
			this.CreateNewAccountBtn.Name = "CreateNewAccountBtn";
			this.CreateNewAccountBtn.Size = new System.Drawing.Size(148, 24);
			this.CreateNewAccountBtn.TabIndex = 31;
			this.CreateNewAccountBtn.Text = "Create New Account";
			this.CreateNewAccountBtn.UseVisualStyleBackColor = true;
			// 
			// NewAccountView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 351);
			this.Controls.Add(this.formContainer);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewAccountView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Account";
			this.Load += new System.EventHandler(this.NewAccountView_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewAccountView_MouseMove);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.formContainer.ResumeLayout(false);
			this.formContainer.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel errorMessage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox domains;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox confirm;
		private System.Windows.Forms.TextBox email;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label tryagain;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Panel formContainer;
		private System.Windows.Forms.Button CreateNewAccountBtn;
	}
}