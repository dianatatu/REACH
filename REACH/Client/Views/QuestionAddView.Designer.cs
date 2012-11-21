﻿namespace REACH.Client.Views
{
    partial class QuestionAddView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionAddView));
			this.questionTitleLabel = new System.Windows.Forms.Label();
			this.questionTitleTextBox = new System.Windows.Forms.TextBox();
			this.questionContentLabel = new System.Windows.Forms.Label();
			this.contentQuestionRichTextbox = new System.Windows.Forms.RichTextBox();
			this.syntaxHighlightButton = new System.Windows.Forms.Button();
			this.pseudocodeButton = new System.Windows.Forms.Button();
			this.questionSubmitButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.domainList = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// questionTitleLabel
			// 
			this.questionTitleLabel.AutoSize = true;
			this.questionTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.questionTitleLabel.Location = new System.Drawing.Point(16, 13);
			this.questionTitleLabel.Name = "questionTitleLabel";
			this.questionTitleLabel.Size = new System.Drawing.Size(39, 16);
			this.questionTitleLabel.TabIndex = 0;
			this.questionTitleLabel.Text = "Title";
			// 
			// questionTitleTextBox
			// 
			this.questionTitleTextBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.questionTitleTextBox.Location = new System.Drawing.Point(76, 12);
			this.questionTitleTextBox.Name = "questionTitleTextBox";
			this.questionTitleTextBox.Size = new System.Drawing.Size(698, 21);
			this.questionTitleTextBox.TabIndex = 1;
			// 
			// questionContentLabel
			// 
			this.questionContentLabel.AutoSize = true;
			this.questionContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.questionContentLabel.Location = new System.Drawing.Point(16, 54);
			this.questionContentLabel.Name = "questionContentLabel";
			this.questionContentLabel.Size = new System.Drawing.Size(64, 16);
			this.questionContentLabel.TabIndex = 2;
			this.questionContentLabel.Text = "Content:";
			// 
			// contentQuestionRichTextbox
			// 
			this.contentQuestionRichTextbox.AcceptsTab = true;
			this.contentQuestionRichTextbox.EnableAutoDragDrop = true;
			this.contentQuestionRichTextbox.Font = new System.Drawing.Font("Verdana", 8F);
			this.contentQuestionRichTextbox.Location = new System.Drawing.Point(19, 86);
			this.contentQuestionRichTextbox.Name = "contentQuestionRichTextbox";
			this.contentQuestionRichTextbox.Size = new System.Drawing.Size(493, 489);
			this.contentQuestionRichTextbox.TabIndex = 3;
			this.contentQuestionRichTextbox.Text = "";
			// 
			// syntaxHighlightButton
			// 
			this.syntaxHighlightButton.Location = new System.Drawing.Point(371, 51);
			this.syntaxHighlightButton.Name = "syntaxHighlightButton";
			this.syntaxHighlightButton.Size = new System.Drawing.Size(141, 23);
			this.syntaxHighlightButton.TabIndex = 4;
			this.syntaxHighlightButton.Text = "Syntax Highlight";
			this.syntaxHighlightButton.UseVisualStyleBackColor = true;
			this.syntaxHighlightButton.Click += new System.EventHandler(this.syntaxHighlightButton_Click);
			// 
			// pseudocodeButton
			// 
			this.pseudocodeButton.Location = new System.Drawing.Point(290, 51);
			this.pseudocodeButton.Name = "pseudocodeButton";
			this.pseudocodeButton.Size = new System.Drawing.Size(75, 23);
			this.pseudocodeButton.TabIndex = 5;
			this.pseudocodeButton.Text = "Pseudocode";
			this.pseudocodeButton.UseVisualStyleBackColor = true;
			this.pseudocodeButton.Click += new System.EventHandler(this.pseudocodeButton_Click);
			// 
			// questionSubmitButton
			// 
			this.questionSubmitButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.questionSubmitButton.ForeColor = System.Drawing.Color.Green;
			this.questionSubmitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.questionSubmitButton.Location = new System.Drawing.Point(693, 543);
			this.questionSubmitButton.Name = "questionSubmitButton";
			this.questionSubmitButton.Size = new System.Drawing.Size(70, 32);
			this.questionSubmitButton.TabIndex = 6;
			this.questionSubmitButton.Text = "Submit";
			this.questionSubmitButton.UseVisualStyleBackColor = true;
			this.questionSubmitButton.Click += new System.EventHandler(this.questionSubmitButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(539, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Domain(s):";
			// 
			// domainList
			// 
			this.domainList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.domainList.FormattingEnabled = true;
			this.domainList.Location = new System.Drawing.Point(542, 86);
			this.domainList.Name = "domainList";
			this.domainList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.domainList.Size = new System.Drawing.Size(221, 134);
			this.domainList.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(542, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Select at least one domain from the list";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(55, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(15, 20);
			this.label3.TabIndex = 16;
			this.label3.Text = "*";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(72, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 20);
			this.label4.TabIndex = 17;
			this.label4.Text = "*";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(616, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 20);
			this.label5.TabIndex = 18;
			this.label5.Text = "*";
			// 
			// QuestionAddView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 587);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.domainList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.questionSubmitButton);
			this.Controls.Add(this.pseudocodeButton);
			this.Controls.Add(this.syntaxHighlightButton);
			this.Controls.Add(this.contentQuestionRichTextbox);
			this.Controls.Add(this.questionContentLabel);
			this.Controls.Add(this.questionTitleTextBox);
			this.Controls.Add(this.questionTitleLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "QuestionAddView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add a Question";
			this.Load += new System.EventHandler(this.QuestionAddView_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionTitleLabel;
        private System.Windows.Forms.TextBox questionTitleTextBox;
        private System.Windows.Forms.Label questionContentLabel;
        private System.Windows.Forms.RichTextBox contentQuestionRichTextbox;
        private System.Windows.Forms.Button syntaxHighlightButton;
        private System.Windows.Forms.Button pseudocodeButton;
        private System.Windows.Forms.Button questionSubmitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox domainList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}