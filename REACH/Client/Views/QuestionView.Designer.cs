namespace REACH.Client.Views
{
    partial class QuestionView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionView));
			this.QuestionTitleLabel = new System.Windows.Forms.Label();
			this.QuestionContentRichTextBox = new System.Windows.Forms.RichTextBox();
			this.DateAndTimeLabel = new System.Windows.Forms.Label();
			this.QuestionOwnerButton = new System.Windows.Forms.Button();
			this.postRichTextBox = new System.Windows.Forms.RichTextBox();
			this.QuestionPostedByLabel = new System.Windows.Forms.Label();
			this.postAnswerLabel = new System.Windows.Forms.Label();
			this.syntaxHighlightButton = new System.Windows.Forms.Button();
			this.pseudocodeButton = new System.Windows.Forms.Button();
			this.answerSubmitButton = new System.Windows.Forms.Button();
			this.usersPanel = new System.Windows.Forms.Panel();
			this.domainsPanel = new System.Windows.Forms.Panel();
			this.domainsLabel = new System.Windows.Forms.Label();
			this.referencesPanel = new System.Windows.Forms.Panel();
			this.answersRichTextBox = new System.Windows.Forms.RichTextBox();
			this.answersLabel = new System.Windows.Forms.Label();
			this.stateButton = new System.Windows.Forms.Button();
			this.addReferenceListBox = new System.Windows.Forms.ListBox();
			this.AddReferencesLabel = new System.Windows.Forms.Label();
			this.usersLabel = new System.Windows.Forms.Label();
			this.referencesLabel = new System.Windows.Forms.Label();
			this.domainsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// QuestionTitleLabel
			// 
			this.QuestionTitleLabel.AutoSize = true;
			this.QuestionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuestionTitleLabel.ForeColor = System.Drawing.Color.Green;
			this.QuestionTitleLabel.Location = new System.Drawing.Point(92, 11);
			this.QuestionTitleLabel.Name = "QuestionTitleLabel";
			this.QuestionTitleLabel.Size = new System.Drawing.Size(115, 20);
			this.QuestionTitleLabel.TabIndex = 0;
			this.QuestionTitleLabel.Text = "QuestionTitle";
			// 
			// QuestionContentRichTextBox
			// 
			this.QuestionContentRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.QuestionContentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.QuestionContentRichTextBox.Location = new System.Drawing.Point(15, 39);
			this.QuestionContentRichTextBox.Name = "QuestionContentRichTextBox";
			this.QuestionContentRichTextBox.ReadOnly = true;
			this.QuestionContentRichTextBox.Size = new System.Drawing.Size(484, 171);
			this.QuestionContentRichTextBox.TabIndex = 2;
			this.QuestionContentRichTextBox.Text = "";
			// 
			// DateAndTimeLabel
			// 
			this.DateAndTimeLabel.AutoSize = true;
			this.DateAndTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.DateAndTimeLabel.ForeColor = System.Drawing.Color.Green;
			this.DateAndTimeLabel.Location = new System.Drawing.Point(375, 220);
			this.DateAndTimeLabel.Name = "DateAndTimeLabel";
			this.DateAndTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.DateAndTimeLabel.Size = new System.Drawing.Size(125, 13);
			this.DateAndTimeLabel.TabIndex = 8;
			this.DateAndTimeLabel.Text = "00.00.0000 00:00:00";
			this.DateAndTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// QuestionOwnerButton
			// 
			this.QuestionOwnerButton.AutoSize = true;
			this.QuestionOwnerButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
			this.QuestionOwnerButton.FlatAppearance.BorderSize = 2;
			this.QuestionOwnerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.QuestionOwnerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.QuestionOwnerButton.Location = new System.Drawing.Point(70, 214);
			this.QuestionOwnerButton.Name = "QuestionOwnerButton";
			this.QuestionOwnerButton.Size = new System.Drawing.Size(90, 23);
			this.QuestionOwnerButton.TabIndex = 9;
			this.QuestionOwnerButton.Text = "QuestionOwner";
			this.QuestionOwnerButton.UseVisualStyleBackColor = true;
			this.QuestionOwnerButton.Click += new System.EventHandler(this.QuestionOwnerButton_Click);
			// 
			// postRichTextBox
			// 
			this.postRichTextBox.AcceptsTab = true;
			this.postRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.postRichTextBox.Location = new System.Drawing.Point(15, 557);
			this.postRichTextBox.Name = "postRichTextBox";
			this.postRichTextBox.Size = new System.Drawing.Size(483, 108);
			this.postRichTextBox.TabIndex = 0;
			this.postRichTextBox.Text = "";
			// 
			// QuestionPostedByLabel
			// 
			this.QuestionPostedByLabel.AutoSize = true;
			this.QuestionPostedByLabel.Location = new System.Drawing.Point(14, 219);
			this.QuestionPostedByLabel.Name = "QuestionPostedByLabel";
			this.QuestionPostedByLabel.Size = new System.Drawing.Size(54, 13);
			this.QuestionPostedByLabel.TabIndex = 10;
			this.QuestionPostedByLabel.Text = "Posted by";
			// 
			// postAnswerLabel
			// 
			this.postAnswerLabel.AutoSize = true;
			this.postAnswerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.postAnswerLabel.Location = new System.Drawing.Point(13, 533);
			this.postAnswerLabel.Name = "postAnswerLabel";
			this.postAnswerLabel.Size = new System.Drawing.Size(107, 18);
			this.postAnswerLabel.TabIndex = 11;
			this.postAnswerLabel.Text = "Post answer:";
			// 
			// syntaxHighlightButton
			// 
			this.syntaxHighlightButton.Location = new System.Drawing.Point(356, 528);
			this.syntaxHighlightButton.Name = "syntaxHighlightButton";
			this.syntaxHighlightButton.Size = new System.Drawing.Size(141, 23);
			this.syntaxHighlightButton.TabIndex = 15;
			this.syntaxHighlightButton.Text = "Syntax Highlight";
			this.syntaxHighlightButton.UseVisualStyleBackColor = true;
			this.syntaxHighlightButton.Click += new System.EventHandler(this.syntaxHighlightButton_Click);
			// 
			// pseudocodeButton
			// 
			this.pseudocodeButton.Location = new System.Drawing.Point(275, 528);
			this.pseudocodeButton.Name = "pseudocodeButton";
			this.pseudocodeButton.Size = new System.Drawing.Size(75, 23);
			this.pseudocodeButton.TabIndex = 16;
			this.pseudocodeButton.Text = "Pseudocode";
			this.pseudocodeButton.UseVisualStyleBackColor = true;
			this.pseudocodeButton.Click += new System.EventHandler(this.pseudocodeButton_Click);
			// 
			// answerSubmitButton
			// 
			this.answerSubmitButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.answerSubmitButton.ForeColor = System.Drawing.Color.Green;
			this.answerSubmitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.answerSubmitButton.Location = new System.Drawing.Point(428, 671);
			this.answerSubmitButton.Name = "answerSubmitButton";
			this.answerSubmitButton.Size = new System.Drawing.Size(70, 32);
			this.answerSubmitButton.TabIndex = 17;
			this.answerSubmitButton.Text = "Submit";
			this.answerSubmitButton.UseVisualStyleBackColor = true;
			this.answerSubmitButton.Click += new System.EventHandler(this.answerSubmitButton_Click);
			// 
			// usersPanel
			// 
			this.usersPanel.AutoScroll = true;
			this.usersPanel.BackColor = System.Drawing.SystemColors.Control;
			this.usersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.usersPanel.Location = new System.Drawing.Point(516, 269);
			this.usersPanel.Name = "usersPanel";
			this.usersPanel.Size = new System.Drawing.Size(186, 112);
			this.usersPanel.TabIndex = 18;
			// 
			// domainsPanel
			// 
			this.domainsPanel.AutoScroll = true;
			this.domainsPanel.BackColor = System.Drawing.SystemColors.Control;
			this.domainsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.domainsPanel.Controls.Add(this.domainsLabel);
			this.domainsPanel.Location = new System.Drawing.Point(516, 39);
			this.domainsPanel.Name = "domainsPanel";
			this.domainsPanel.Size = new System.Drawing.Size(186, 171);
			this.domainsPanel.TabIndex = 19;
			// 
			// domainsLabel
			// 
			this.domainsLabel.AutoSize = true;
			this.domainsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.domainsLabel.Location = new System.Drawing.Point(-1, 0);
			this.domainsLabel.Name = "domainsLabel";
			this.domainsLabel.Size = new System.Drawing.Size(55, 13);
			this.domainsLabel.TabIndex = 22;
			this.domainsLabel.Text = "Domains";
			// 
			// referencesPanel
			// 
			this.referencesPanel.AutoScroll = true;
			this.referencesPanel.BackColor = System.Drawing.SystemColors.Control;
			this.referencesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.referencesPanel.Location = new System.Drawing.Point(516, 389);
			this.referencesPanel.Name = "referencesPanel";
			this.referencesPanel.Size = new System.Drawing.Size(186, 113);
			this.referencesPanel.TabIndex = 20;
			// 
			// answersRichTextBox
			// 
			this.answersRichTextBox.AcceptsTab = true;
			this.answersRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.answersRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.answersRichTextBox.Location = new System.Drawing.Point(15, 269);
			this.answersRichTextBox.Name = "answersRichTextBox";
			this.answersRichTextBox.ReadOnly = true;
			this.answersRichTextBox.Size = new System.Drawing.Size(482, 233);
			this.answersRichTextBox.TabIndex = 21;
			this.answersRichTextBox.Text = "";
			// 
			// answersLabel
			// 
			this.answersLabel.AutoSize = true;
			this.answersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.answersLabel.Location = new System.Drawing.Point(13, 248);
			this.answersLabel.Name = "answersLabel";
			this.answersLabel.Size = new System.Drawing.Size(72, 18);
			this.answersLabel.TabIndex = 22;
			this.answersLabel.Text = "Answers";
			// 
			// stateButton
			// 
			this.stateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stateButton.ForeColor = System.Drawing.Color.Green;
			this.stateButton.Location = new System.Drawing.Point(14, 10);
			this.stateButton.Name = "stateButton";
			this.stateButton.Size = new System.Drawing.Size(75, 23);
			this.stateButton.TabIndex = 23;
			this.stateButton.Text = "unsolved";
			this.stateButton.UseVisualStyleBackColor = true;
			this.stateButton.Click += new System.EventHandler(this.stateButton_Click);
			// 
			// addReferenceListBox
			// 
			this.addReferenceListBox.FormattingEnabled = true;
			this.addReferenceListBox.HorizontalScrollbar = true;
			this.addReferenceListBox.Location = new System.Drawing.Point(517, 557);
			this.addReferenceListBox.Name = "addReferenceListBox";
			this.addReferenceListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.addReferenceListBox.Size = new System.Drawing.Size(185, 108);
			this.addReferenceListBox.TabIndex = 24;
			// 
			// AddReferencesLabel
			// 
			this.AddReferencesLabel.AutoSize = true;
			this.AddReferencesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.AddReferencesLabel.Location = new System.Drawing.Point(514, 541);
			this.AddReferencesLabel.Name = "AddReferencesLabel";
			this.AddReferencesLabel.Size = new System.Drawing.Size(106, 13);
			this.AddReferencesLabel.TabIndex = 25;
			this.AddReferencesLabel.Text = "Add Reference(s)";
			// 
			// usersLabel
			// 
			this.usersLabel.AutoSize = true;
			this.usersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.usersLabel.Location = new System.Drawing.Point(517, 271);
			this.usersLabel.Name = "usersLabel";
			this.usersLabel.Size = new System.Drawing.Size(39, 13);
			this.usersLabel.TabIndex = 28;
			this.usersLabel.Text = "Users";
			// 
			// referencesLabel
			// 
			this.referencesLabel.AutoSize = true;
			this.referencesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.referencesLabel.Location = new System.Drawing.Point(517, 392);
			this.referencesLabel.Name = "referencesLabel";
			this.referencesLabel.Size = new System.Drawing.Size(72, 13);
			this.referencesLabel.TabIndex = 30;
			this.referencesLabel.Text = "References";
			// 
			// QuestionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(718, 711);
			this.Controls.Add(this.referencesLabel);
			this.Controls.Add(this.usersLabel);
			this.Controls.Add(this.AddReferencesLabel);
			this.Controls.Add(this.addReferenceListBox);
			this.Controls.Add(this.stateButton);
			this.Controls.Add(this.answersLabel);
			this.Controls.Add(this.answersRichTextBox);
			this.Controls.Add(this.referencesPanel);
			this.Controls.Add(this.domainsPanel);
			this.Controls.Add(this.usersPanel);
			this.Controls.Add(this.answerSubmitButton);
			this.Controls.Add(this.pseudocodeButton);
			this.Controls.Add(this.syntaxHighlightButton);
			this.Controls.Add(this.postAnswerLabel);
			this.Controls.Add(this.postRichTextBox);
			this.Controls.Add(this.QuestionPostedByLabel);
			this.Controls.Add(this.QuestionOwnerButton);
			this.Controls.Add(this.DateAndTimeLabel);
			this.Controls.Add(this.QuestionContentRichTextBox);
			this.Controls.Add(this.QuestionTitleLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "QuestionView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Question";
			this.Load += new System.EventHandler(this.QuestionView_Load);
			this.domainsPanel.ResumeLayout(false);
			this.domainsPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionTitleLabel;
        private System.Windows.Forms.RichTextBox QuestionContentRichTextBox;
        private System.Windows.Forms.Label DateAndTimeLabel;
        private System.Windows.Forms.Button QuestionOwnerButton;
        private System.Windows.Forms.RichTextBox postRichTextBox;
        private System.Windows.Forms.Label QuestionPostedByLabel;
        private System.Windows.Forms.Label postAnswerLabel;
        private System.Windows.Forms.Button syntaxHighlightButton;
        private System.Windows.Forms.Button pseudocodeButton;
        private System.Windows.Forms.Button answerSubmitButton;
        private System.Windows.Forms.Panel usersPanel;
        private System.Windows.Forms.Panel domainsPanel;
        private System.Windows.Forms.Panel referencesPanel;
        private System.Windows.Forms.RichTextBox answersRichTextBox;
		private System.Windows.Forms.Label domainsLabel;
        private System.Windows.Forms.Label answersLabel;
        private System.Windows.Forms.Button stateButton;
        private System.Windows.Forms.ListBox addReferenceListBox;
        private System.Windows.Forms.Label AddReferencesLabel;
        private System.Windows.Forms.Label usersLabel;
		private System.Windows.Forms.Label referencesLabel;
    }
}