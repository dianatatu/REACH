using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using REACH.Client.Core;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Controllers;
using REACH.Common.Base;
using REACH.Common.Data;
using Rating;

namespace REACH.Client.Views
{
    public partial class QuestionView : Form, IView
    {
        private QuestionController controller;
        private Dictionary<Label, uint> userLabels = new Dictionary<Label, uint>();
        private Dictionary<Label, uint> resourceLabels = new Dictionary<Label, uint>();
        private List<uint> resourceIds = new List<uint>();
        private Dictionary<RatingControl, UserData> ratingUsers = new Dictionary<RatingControl, UserData>();

        public delegate void EmptyFunction();

        public QuestionView(Object question)
        {
            // Create the controller
            controller = new QuestionController(question);

            // Handlers for external events
            controller.QuestionDomainsReceived += new QuestionController.ExternalEventHandler(OnQuestionDomainsReceived);
            controller.QuestionOwnerReceived += new QuestionController.ExternalEventHandler(OnQuestionOwnerReceived);
            controller.QuestionStatusChanged += new QuestionController.ExternalEventHandler(OnQuestionStatusChanged);
            controller.QuestionAnswersReceived += new QuestionController.ExternalEventHandler(OnQuestionAnswersReceived);
            controller.QuestionDomainsResourcesReceived += new QuestionController.ExternalEventHandler(OnQuestionDomainsResourcesReceived);
            controller.ThisUserStateChanged += new QuestionController.ExternalEventHandler(OnThisUserStateChanged);
            controller.QuestionResourcesReceived += new QuestionController.ExternalEventHandler(OnQuestionResourcesReceived);
            controller.UserVoteChecked += new QuestionController.ExternalEventHandler(OnUserVoteChecked);
            controller.UserRankUpdated += new QuestionController.ExternalEventHandler(OnUserRankUpdated);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();

            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

            // Handlers for internal events			
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);

            //initialize
            //question status
            if (((QuestionData)question).Status == true)
            {
                QuestionTitleLabel.ForeColor = System.Drawing.Color.MediumBlue;
                stateButton.ForeColor = System.Drawing.Color.MediumBlue;
                stateButton.Text = "solved";
            }
            else
            {
                QuestionTitleLabel.ForeColor = System.Drawing.Color.Green;
                stateButton.ForeColor = System.Drawing.Color.Green;
                stateButton.Text = "unsolved";
            }

            //question content
            QuestionContentRichTextBox.SelectedRtf = ((QuestionData)question).Content;

            //question date
            DateAndTimeLabel.Text = ((QuestionData)question).Timestamp.ToString();

            //question title
            QuestionTitleLabel.Text = ((QuestionData)question).Title;
        }

        private void SetMdiParent()
        {
            ReachWindow f = (ReachWindow)Context.EntryPoint;
            if (f.InvokeRequired)
            {
                f.Invoke((EmptyFunction)SetMdiParent, null);
                return;
            }
            this.MdiParent = f;
        }

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((EmptyFunction)ShowForm, null);
                return;
            }
            this.Show();
        }

        /*
         * Handlers for internal events
         */
        #region internal_events

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            controller.UnregisterHandlers();
        }

        private void QuestionView_Load(object sender, EventArgs e)
        {
            controller.GetQuestionOwner(); 
            controller.GetDomains();      
            controller.GetAnswers();
            controller.GetResources();
        }

        private void QuestionOwnerButton_Click(object sender, EventArgs e)
        {
            if(((Button)sender).Enabled)
                controller.StartConversationWithOwner();
        }

        private void pseudocodeButton_Click(object sender, EventArgs e)
        {
            if (postRichTextBox.SelectedText.Length > 0)
                do_pseudocode();
            initial_settings();
            postRichTextBox.Focus();
        }

        private void syntaxHighlightButton_Click(object sender, EventArgs e)
        {
            if (postRichTextBox.SelectedText.Length > 0)
                do_syntax();
            initial_settings();
            postRichTextBox.Focus();
        }

        private void answerSubmitButton_Click(object sender, EventArgs e)
        {
            if (postRichTextBox.Text.Length == 0)
                MessageBox.Show("Fill in all the information required before you submit an answer.");
            else
            {
                controller.SubmitAnswer(postRichTextBox.Rtf);
                postRichTextBox.Text = "";                
                
                List<UInt32> ref_ids = new List<UInt32>();
                foreach (int i in addReferenceListBox.SelectedIndices)                
                    ref_ids.Add(resourceIds[i]);                    

                controller.AddReference(ref_ids);

                for (int i = 0; i < addReferenceListBox.Items.Count; i++)
                    addReferenceListBox.SetSelected(i, false);
            }
        }
        
        private void stateButton_Click(object sender, EventArgs e)
        {
            controller.ChangeQuestionStatus();
        }

        #endregion

        /*
		 * Handlers for external events
		 */
        #region external_events

        public void OnUserVoteChecked(QuestionModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((QuestionController.ExternalEventHandler)
                    OnUserVoteChecked, model);
                return;
            }
            
            foreach (KeyValuePair<RatingControl, UserData> pair in ratingUsers)
                if (model.My_votes.ContainsKey(pair.Value.Id))
                    pair.Key.Rating = model.My_votes[pair.Value.Id];
            
        }

        private void OnThisUserStateChanged(QuestionModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((QuestionController.ExternalEventHandler)
					OnThisUserStateChanged, model);
				return;
			}
            changeStateIMButtons(model);
		}

        private void changeStateIMButtons(QuestionModel model)
        {
            QuestionOwnerButton.Enabled = LoggedInUserModel.Instance.User.Status && (model.QuestionOwner.Id != LoggedInUserModel.Instance.User.Id);
            foreach (Label label in userLabels.Keys)
                label.Enabled = LoggedInUserModel.Instance.User.Status && (userLabels[label] != LoggedInUserModel.Instance.User.Id);
        }

        private void OnQuestionDomainsReceived(QuestionModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionDomainsReceived, model);
				return;
			}
			
            int index = 0;

            foreach (DomainData domain in model.Domains)
            {
                Label domainLabel = new Label();
                domainLabel.Text = domain.Name;
                domainLabel.Location = new Point(10, 15 + index * 22);
                domainLabel.AutoSize = true;
                domainsPanel.Controls.Add(domainLabel);
                index ++;
            }
		}

        private void OnQuestionOwnerReceived(QuestionModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionOwnerReceived, model);
                return;
            }
           
            QuestionOwnerButton.Text = model.QuestionOwner.Username;

           if (LoggedInUserModel.Instance.User.Id == model.Question.Owner)
                stateButton.Enabled = true;
            else
                stateButton.Enabled = false;
            changeStateIMButtons(model);
        }

        private void OnQuestionStatusChanged(QuestionModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionStatusChanged, model);
				return;
			}
            
            if (model.Question.Status == true)
            {
                QuestionTitleLabel.ForeColor = System.Drawing.Color.MediumBlue;
                stateButton.ForeColor = System.Drawing.Color.MediumBlue;
                stateButton.Text = "solved";
            }
            else
            {
                QuestionTitleLabel.ForeColor = System.Drawing.Color.Green;
                stateButton.ForeColor = System.Drawing.Color.Green;
                stateButton.Text = "unsolved";
            }

            if (LoggedInUserModel.Instance.User.Id == model.Question.Owner)
                stateButton.Enabled = true;
            else
                stateButton.Enabled = false;
        }

        private void OnQuestionAnswersReceived(QuestionModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
				this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionAnswersReceived, model);
				return;
			}
            int start = 0;
            if (answersRichTextBox.Text.Length != 0)
                start = model.Answers.Count - 1;

            for (int i=start; i<model.Answers.Count; i++)
            {
                answersRichTextBox.SelectionStart = answersRichTextBox.Text.Length;
                answersRichTextBox.SelectionFont = new Font("Verdana", 8, FontStyle.Bold);
                answersRichTextBox.SelectionBackColor = Color.LightGray;
                UserData owner = new UserData("x","y");
                for (int j = 0; j < model.AnswerOwners.Count; j++)
                    if (model.Answers[i].Owner == model.AnswerOwners[j].Id)
                    {
                        owner = model.AnswerOwners[j];
                        break;
                    }
                answersRichTextBox.SelectedText = owner.Username + "\t" + model.Answers[i].Timestamp + "\n";
                answersRichTextBox.SelectedRtf = model.Answers[i].Content;
                answersRichTextBox.SelectedText = "\n\n";
            }
            answersRichTextBox.ScrollToCaret();

            int index = 0;
            ratingUsers = new Dictionary<RatingControl, UserData>();
            usersPanel.Controls.Clear();
            foreach (UserData user in model.AnswerOwners)
            {
                RatingControl voteWidget = new RatingControl();
                voteWidget.Location = new Point(10, 27 + index * 45);
                voteWidget.AutoSize = false;
                voteWidget.Scale(new SizeF((float)0.45, (float)0.5));
                voteWidget.Fixed = false;
                if (user.Id == LoggedInUserModel.Instance.User.Id)
                    voteWidget.Enabled = false;
                voteWidget.SelectRating += new Rating.RatingControl.SelectRatingHandler(this.onVoteWidgetClick);
                if (model.My_votes.ContainsKey(user.Id))
                    voteWidget.Rating = model.My_votes[user.Id];
                else
                    controller.CheckUserVote(user);
                usersPanel.Controls.Add(voteWidget);


                Label userLabel = new Label();
                userLabel.Text = user.Username + " (" + String.Format("{0:0.##}", user.Rank) + ")";
                userLabel.Location = new Point(55, 15 + index * 22);
                userLabel.AutoSize = true;
                usersPanel.Controls.Add(userLabel);
                userLabels.Add(userLabel, user.Id);
                userLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(userClicked);
                index++;

                ratingUsers.Add(voteWidget, user);
            }

            postRichTextBox.Focus();
            changeStateIMButtons(model);
		}

        private void onVoteWidgetClick(object sender, int rating)
        {
            RatingControl voteWidget = (RatingControl)sender;
            controller.VoteUser(ratingUsers[voteWidget], rating);
        }

        private void userClicked(object sender, EventArgs args)
        {
            if(((Label)sender).Enabled)
                controller.StartConversationWithUser(userLabels[(Label)sender]);
        }

        private void referenceClicked(object sender, EventArgs args)
        {
            controller.ViewResource(resourceLabels[(Label)sender]);
        }

        private void OnQuestionDomainsResourcesReceived(QuestionModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionDomainsResourcesReceived, model);
                return;
            }

            List<String> descriptions = new List<String>();
            resourceIds.Clear();
            for (int i = 0; i < model.Resources.Count; i++)
            {
                descriptions.Add(model.Resources[i].Title);
                resourceIds.Add(model.Resources[i].Id);
            }   
            
            addReferenceListBox.DataSource = descriptions;
            for (int i = 0; i < model.Resources.Count; i++)
                addReferenceListBox.SetSelected(i, false);
        }

        private void OnQuestionResourcesReceived(QuestionModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((QuestionController.ExternalEventHandler)
                    OnQuestionResourcesReceived, model);
                return;
            }

            referencesPanel.Controls.Clear();
            int index = 0;
            resourceLabels.Clear();

            foreach (ResourceData question in model.QuestionResources)
            {
                Label referenceLabel = new Label();
                referenceLabel.Text = question.Title;
                referenceLabel.Location = new Point(10, 15 + index * 22);
                referenceLabel.AutoSize = true;
                referenceLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(referenceClicked);
                referencesPanel.Controls.Add(referenceLabel);
                resourceLabels.Add(referenceLabel, question.Id);
                index++;
            }
        }

        private void OnUserRankUpdated(QuestionModel model)
		{
			while (!this.IsHandleCreated);
			if (this.InvokeRequired)
			{
                this.Invoke((QuestionController.ExternalEventHandler)
					OnUserRankUpdated, model);
				return;
			}
			foreach(Label userLabel in userLabels.Keys) {
                uint id = userLabels[userLabel];
                foreach(UserData user in model.AnswerOwners)
                    if(user.Id == id)
                        userLabel.Text = user.Username + " (" + String.Format("{0:0.##}", user.Rank) +")";
            }
		}

        #endregion

        /*
         * Useful Methods
         */
        #region useful_methods

        private void do_syntax()
        {
            string[] keywords1 = { "false", "true", "int", "double", "short", "enum", "string", 
                                     "bool", "object", "union", "unsigned", "char", "byte", "class",
                                     "const", "struct", "template", "this" };
            string[] keywords2 = { "void", "if", "else", "static", "public", "case", "switch", "catch",
                                     "try", "throw", "goto", "while", "inline", "mutable", "new", "private",
                                     "protected", "static", "public", "sizeof", "true", "false", "typedef" };
            string[] keywords3 = { "return", "break", "continue", "namespace", "default", "delete", "export" };
            string codeText = postRichTextBox.SelectedText;

            string INC = "#include";
            string DEF_sp = "#define ";
            string DEF_tab = "#define\t";

            int stare, poz;

            postRichTextBox.SelectionColor = Color.Black;

            int slen = 0;
            int start = postRichTextBox.SelectionStart;
            int length = postRichTextBox.SelectionLength;
            string codeTxt = postRichTextBox.SelectedText;

            postRichTextBox.SelectionStart = start;
            postRichTextBox.SelectionLength = length;
            postRichTextBox.SelectionColor = Color.DarkGray;

            int sstart = postRichTextBox.SelectionStart - 1;

            codeText = codeTxt;
            string[] lines = codeText.Split('\n');
            foreach (string line in lines)
            {
                sstart++;

                if (line.Length > DEF_sp.Length - 1 && line.Substring(0, DEF_sp.Length) == DEF_sp)
                {
                    slen = line.Length;

                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = line.Length;

                    postRichTextBox.SelectionColor = Color.Violet;
                    postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;

                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = slen;
                }
                else if (line.Length > DEF_tab.Length - 1 && line.Substring(0, DEF_tab.Length) == DEF_tab)
                {
                    slen = line.Length;

                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = line.Length;

                    postRichTextBox.SelectionColor = Color.Violet;
                    postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;

                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = slen;
                }
                else if (line.Length > INC.Length - 1 && line.Substring(0, INC.Length) == INC)
                {
                    slen = line.Length;

                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = slen;

                    postRichTextBox.SelectionColor = Color.Orange;
                    postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;
                    postRichTextBox.SelectionStart = sstart;
                    postRichTextBox.SelectionLength = slen;
                }
                else
                {
                    slen = line.Length;

                    postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
                    char[] splits = { ',', ' ', '{', '}', '(', ')', ';', '=', '[', ']', '\t' };
                    string[] tokens = line.Split(splits);

                    int index = 0;

                    foreach (string token in tokens)
                    {
                        postRichTextBox.SelectionStart = sstart + index;
                        postRichTextBox.SelectionLength = token.Length;

                        foreach (string kw1 in keywords1)
                        {
                            if (kw1 == token)
                            {
                                postRichTextBox.SelectionColor = Color.Blue;
                                break;
                            }
                        }
                        foreach (string kw2 in keywords2)
                        {
                            if (kw2 == token)
                            {
                                postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                                postRichTextBox.SelectionColor = Color.Red;
                                break;
                            }
                        }
                        foreach (string kw3 in keywords3)
                        {
                            if (kw3 == token)
                            {
                                postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                                postRichTextBox.SelectionColor = Color.Purple;
                                break;
                            }
                        }
                        index += token.Length + 1;
                    }
                    sstart += line.Length;
                }
            }

            // parantheses
            poz = start;
            codeText = codeTxt;
            Console.WriteLine("sel start = " + poz);
            Console.WriteLine(codeText);

            foreach (char ch in codeText)
            {
                if (ch == ')' || ch == '(' || ch == '{' || ch == '}' || ch == '[' || ch == ']' || ch == '<' || ch == '>')
                {
                    postRichTextBox.SelectionStart = poz;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Orange;

                }
                poz++;
                if (poz > start + length)
                    break;
            }

            // "" qoutes
            stare = 0;
            poz = start;
            codeText = codeTxt;

            foreach (char ch in codeText)
            {
                if (ch == '"')
                {
                    stare = 1 - stare;
                    postRichTextBox.SelectionStart = poz;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Pink;
                }
                if (stare == 1)
                {
                    postRichTextBox.SelectionStart = poz;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Pink;
                }
                poz++;
            }

            // '' qoutes
            poz = start;
            codeText = codeTxt;
            stare = 0;

            foreach (char ch in codeText)
            {
                if (ch == '\'')
                {
                    stare = 1 - stare;
                    postRichTextBox.SelectionStart = poz;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Pink;
                }
                if (stare == 1)
                {
                    postRichTextBox.SelectionStart = poz;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Pink;
                }
                poz++;
            }

            // single-line comments
            stare = 0;
            codeText = codeTxt;

            for (poz = 0; poz < length; poz++)
            {
                if (codeText[poz] == '/' && codeText[poz + 1] == '/')
                    stare = 1;

                if (codeText[poz] == '\n' && stare == 1)
                    stare = 0;
                if (stare == 1)
                {
                    postRichTextBox.SelectionStart = poz + start;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Green;
                }
            }

            // multi-line comments
            stare = 0;
            codeText = codeTxt;
            for (poz = 0; poz < length; poz++)
            {
                if (codeText[poz] == '/' && codeText[poz + 1] == '*')
                    stare = 1;

                if (codeText[poz] == '/' && codeText[poz - 1] == '*' && stare == 1)
                {
                    stare = 0;
                    postRichTextBox.SelectionStart = poz + start;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Green;
                }
                if (stare == 1)
                {
                    postRichTextBox.SelectionStart = poz + start;
                    postRichTextBox.SelectionLength = 1;
                    postRichTextBox.SelectionColor = Color.Green;
                }
            }

            // set font for all selected text
            postRichTextBox.SelectionStart = start;
            postRichTextBox.SelectionLength = length;
            postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
        }

        private void do_pseudocode()
        {
            int start = postRichTextBox.SelectionStart;
            int length = postRichTextBox.SelectionLength;

            postRichTextBox.SelectionStart = start;
            postRichTextBox.SelectionLength = length;
            postRichTextBox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
            postRichTextBox.SelectionColor = Color.DarkGray;
        }

        private void initial_settings()
        {
            postRichTextBox.SelectionStart = postRichTextBox.Text.Length;
            postRichTextBox.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
            postRichTextBox.SelectionColor = Color.Black;
        }

        #endregion
    }
}
