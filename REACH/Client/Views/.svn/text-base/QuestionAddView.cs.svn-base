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

namespace REACH.Client.Views
{
    public partial class QuestionAddView : Form, IView
    {
        private QuestionAddController controller;

        public delegate void EmptyFunction();

        public QuestionAddView()
        {
            // Create the controller
            controller = new QuestionAddController();

            // Handlers for external events
            controller.DomainsUpdated += new QuestionAddController.ExternalEventHandler(OnDomainsUpdated);

            // Register the controller handlers to the service
            controller.RegisterHandlers();

            // Initialize Component
            InitializeComponent();

            // Set the parent and display the window
            SetMdiParent();
            ShowForm();

            // Handlers for internal events			
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnFormClosing);
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

        private void QuestionAddView_Load(object sender, EventArgs e)
        {
            controller.ListDomains();            
        }

        private void syntaxHighlightButton_Click(object sender, EventArgs e)
        {
            if (contentQuestionRichTextbox.SelectedText.Length > 0)
                do_syntax();
            initial_settings();
            contentQuestionRichTextbox.Focus();
        }

        private void pseudocodeButton_Click(object sender, EventArgs e)
        {
            if (contentQuestionRichTextbox.SelectedText.Length > 0)
                do_pseudocode();
            initial_settings();
            contentQuestionRichTextbox.Focus();
        }

        private void questionSubmitButton_Click(object sender, EventArgs e)
        {
            if (questionTitleTextBox.Text.Length == 0 || contentQuestionRichTextbox.Text.Length == 0 || domainList.SelectedItems.Count == 0)
                MessageBox.Show("Fill in all the information required before you submit a question.");
            else
            {
                List<DomainData> domains = new List<DomainData>(domainList.Items.Count);
                domains.AddRange(domainList.SelectedItems.Cast<DomainData>());

                controller.SubmitQuestion(LoggedInUserModel.Instance.User.Id, questionTitleTextBox.Text,
                                            contentQuestionRichTextbox.Rtf, domains);
                this.Close();
            }
        }

        #endregion

        /*
		 * Handlers for external events
		 */
        #region external_events

        private void OnDomainsUpdated(QuestionAddModel model)
        {
            while (!this.IsHandleCreated) ;
            if (this.InvokeRequired)
            {
                this.Invoke((QuestionAddController.ExternalEventHandler)
                    OnDomainsUpdated, model);
                return;
            }
            domainList.DataSource = model.Domains;
            for (int i = 0; i < model.Domains.Count; i++)
                domainList.SetSelected(i, false);
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
            string codeText = contentQuestionRichTextbox.SelectedText;

            string INC = "#include";
            string DEF_sp = "#define ";
            string DEF_tab = "#define\t";

            int stare, poz;

            contentQuestionRichTextbox.SelectionColor = Color.Black;

            int slen = 0;
            int start = contentQuestionRichTextbox.SelectionStart;
            int length = contentQuestionRichTextbox.SelectionLength;
            string codeTxt = contentQuestionRichTextbox.SelectedText;

            contentQuestionRichTextbox.SelectionStart = start;
            contentQuestionRichTextbox.SelectionLength = length;
            contentQuestionRichTextbox.SelectionColor = Color.DarkGray;

            int sstart = contentQuestionRichTextbox.SelectionStart - 1;

            codeText = codeTxt;
            string[] lines = codeText.Split('\n');
            foreach (string line in lines)
            {
                sstart++;

                if (line.Length > DEF_sp.Length - 1 && line.Substring(0, DEF_sp.Length) == DEF_sp)
                {
                    slen = line.Length;

                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = line.Length;

                    contentQuestionRichTextbox.SelectionColor = Color.Violet;
                    contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;

                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = slen;
                }
                else if (line.Length > DEF_tab.Length - 1 && line.Substring(0, DEF_tab.Length) == DEF_tab)
                {
                    slen = line.Length;

                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = line.Length;

                    contentQuestionRichTextbox.SelectionColor = Color.Violet;
                    contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;

                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = slen;
                }
                else if (line.Length > INC.Length - 1 && line.Substring(0, INC.Length) == INC)
                {
                    slen = line.Length;

                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = slen;

                    contentQuestionRichTextbox.SelectionColor = Color.Orange;
                    contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);

                    sstart += slen;
                    contentQuestionRichTextbox.SelectionStart = sstart;
                    contentQuestionRichTextbox.SelectionLength = slen;
                }
                else
                {
                    slen = line.Length;

                    contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
                    char[] splits = { ',', ' ', '{', '}', '(', ')', ';', '=', '[', ']', '\t' };
                    string[] tokens = line.Split(splits);

                    int index = 0;

                    foreach (string token in tokens)
                    {
                        contentQuestionRichTextbox.SelectionStart = sstart + index;
                        contentQuestionRichTextbox.SelectionLength = token.Length;

                        foreach (string kw1 in keywords1)
                        {
                            if (kw1 == token)
                            {
                                contentQuestionRichTextbox.SelectionColor = Color.Blue;
                                break;
                            }
                        }
                        foreach (string kw2 in keywords2)
                        {
                            if (kw2 == token)
                            {
                                contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                                contentQuestionRichTextbox.SelectionColor = Color.Red;
                                break;
                            }
                        }
                        foreach (string kw3 in keywords3)
                        {
                            if (kw3 == token)
                            {
                                contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Bold);
                                contentQuestionRichTextbox.SelectionColor = Color.Purple;
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
                    contentQuestionRichTextbox.SelectionStart = poz;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Orange;

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
                    contentQuestionRichTextbox.SelectionStart = poz;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Pink;
                }
                if (stare == 1)
                {
                    contentQuestionRichTextbox.SelectionStart = poz;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Pink;
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
                    contentQuestionRichTextbox.SelectionStart = poz;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Pink;
                }
                if (stare == 1)
                {
                    contentQuestionRichTextbox.SelectionStart = poz;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Pink;
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
                    contentQuestionRichTextbox.SelectionStart = poz + start;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Green;
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
                    contentQuestionRichTextbox.SelectionStart = poz + start;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Green;
                }
                if (stare == 1)
                {
                    contentQuestionRichTextbox.SelectionStart = poz + start;
                    contentQuestionRichTextbox.SelectionLength = 1;
                    contentQuestionRichTextbox.SelectionColor = Color.Green;
                }
            }

            // set font for all selected text
            contentQuestionRichTextbox.SelectionStart = start;
            contentQuestionRichTextbox.SelectionLength = length;
            contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
        }

        private void do_pseudocode()
        {
            int start = contentQuestionRichTextbox.SelectionStart;
            int length = contentQuestionRichTextbox.SelectionLength;
           
            contentQuestionRichTextbox.SelectionStart = start;
            contentQuestionRichTextbox.SelectionLength = length;
            contentQuestionRichTextbox.SelectionFont = new Font("Courier New", 8, FontStyle.Regular);
            contentQuestionRichTextbox.SelectionColor = Color.DarkGray;
        }

        private void initial_settings()
        {
            contentQuestionRichTextbox.SelectionStart = contentQuestionRichTextbox.Text.Length;
            contentQuestionRichTextbox.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
            contentQuestionRichTextbox.SelectionColor = Color.Black;
        }

        #endregion

    }
}
