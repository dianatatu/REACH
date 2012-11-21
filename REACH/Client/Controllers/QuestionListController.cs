using System;
using System.Collections.Generic;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Views;
using REACH.Common.Data;
using REACH.Common.Base;
using REACH.Common;
using System.Windows.Forms;

namespace REACH.Client.Controllers
{
    public class QuestionListController : ControllerBase<QuestionListModel>
    {   
        /* Constructor */
        public  QuestionListController()
        {
            model = new QuestionListModel();
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnListQuestions, OnListQuestionsRule);
            Context.RegisterTriggerRule(OnListDomains, OnListDomainsRule);
            Context.RegisterTriggerRule(OnListDomainQuestions, OnListDomainQuestionsRule);
            Context.RegisterTriggerRule(OnAddQuestion, OnAddQuestionRule);
            Context.RegisterTriggerRule(OnChangeQuestionStatus, OnChangeQuestionStatusRule);		
        }

        public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnListQuestions, OnListQuestionsRule);
            Context.UnregisterTriggerRule(OnListDomains, OnListDomainsRule);
            Context.UnregisterTriggerRule(OnListDomainQuestions, OnListDomainQuestionsRule);
            Context.UnregisterTriggerRule(OnAddQuestion, OnAddQuestionRule);
            Context.UnregisterTriggerRule(OnChangeQuestionStatus, OnChangeQuestionStatusRule);		    
        }

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler QuestionsDomainsUpdated;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void QuestionListReset()
        {
            List<QuestionData> questions = model.All_questions;
            List<QuestionData> my_questions = new List<QuestionData>();
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Owner == (UInt32)LoggedInUserModel.Instance.User.Id)
                    my_questions.Add(questions[i]);
            }

            /* organize the list of questions:
             * former part: unsolved questions
             * latter part: solved questions
             */

            List<QuestionData> myList = new List<QuestionData>();
            for (int i = 0; i < my_questions.Count; i++)
                if (my_questions[i].Status == false)
                    myList.Add(my_questions[i]);

            for (int i = 0; i < my_questions.Count; i++)
                if (my_questions[i].Status == true)
                    myList.Add(my_questions[i]);

            my_questions = myList;

            model.Current_my_questions = my_questions;
            QuestionsDomainsUpdated(model);
        }

        public void QuestionSearch(String searchString)
        {
            List<QuestionData> titleSearch = new List<QuestionData>();
            List<QuestionData> contentSearch = new List<QuestionData>();
            List<QuestionData> questions = model.All_questions;

            /* filter questions by owner id and title/content
             */
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Owner == LoggedInUserModel.Instance.User.Id)
                {
                    if (questions[i].Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                        titleSearch.Add(questions[i]);
                    else if (questions[i].Content.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                        contentSearch.Add(questions[i]);
                }
            }

            /* sorting questions
             */
            QuestionData temp;
            for (int i = 0; i < titleSearch.Count - 1; i++)
                for (int j = i + 1; j < titleSearch.Count; j++ )
                    if (titleSearch[i].Timestamp.CompareTo(titleSearch[j].Timestamp) < 0)
                    {
                        temp = titleSearch[i];
                        titleSearch[i] = titleSearch[j];
                        titleSearch[j] = temp;
                    }
            for (int i = 0; i < contentSearch.Count - 1; i++)
                for (int j = i + 1; j < contentSearch.Count; j++)
                    if (contentSearch[i].Timestamp.CompareTo(contentSearch[j].Timestamp) < 0)
                    {
                        temp = contentSearch[i];
                        contentSearch[i] = contentSearch[j];
                        contentSearch[j] = temp;
                    }
            for (int i = 0; i < contentSearch.Count; i++)
                titleSearch.Add(contentSearch[i]);

            model.Current_my_questions = titleSearch;
            QuestionsDomainsUpdated(model);
        }

        public void DomainListReset()
        {
            model.State = QuestionListModel.DOMAINLIST;
            model.Current_domain = null;
            
            QuestionsDomainsUpdated(model);
        }

        public void GetDomain(String domainName)
        {
            int i;
            for (i = 0; i < model.Domains.Count; i++)
            {
                if (model.Domains[i].ToString().CompareTo(domainName) == 0)
                    break;
            }
            model.Current_domain = model.Domains[i];
            model.State = QuestionListModel.QUESTIONLIST;
            RMessage replyMessage = new RMessage(MessageType.GET_DOMAIN_QUESTIONS_REQUEST, model.Current_domain);
            Service.Instance.AddMessage(replyMessage);
        }

        public int GetState()
        {
            return model.State;
        }

        public void ListQuestions()
        {
            // Create a new request
            RMessage msg = new RMessage(MessageType.GET_ALL_QUESTIONS_REQUEST, null);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void ListDomains()
        {
            // Create a new request
            RMessage msg = new RMessage(MessageType.GET_ALL_DOMAINS_ORDERED_REQUEST, null);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void DomainSearch(String searchString)
        {
            List<QuestionData> questions;
            if (model.Current_domain == null)
                questions = model.All_questions;
            else
                questions = model.Current_all_questions;
                List<QuestionData> titleSearch = new List<QuestionData>();
                List<QuestionData> contentSearch = new List<QuestionData>();

                /* filter questions by owner id and title/content
                 */
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                        titleSearch.Add(questions[i]);
                    else
                    {
                        RichTextBox richTextBox = new RichTextBox();
                        richTextBox.Rtf = questions[i].Content;
                        if (richTextBox.Text.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                            contentSearch.Add(questions[i]);
                    }
                }

                /* sorting questions
                 */
                QuestionData temp;
                for (int i = 0; i < titleSearch.Count - 1; i++)
                    for (int j = i + 1; j < titleSearch.Count; j++)
                        if (titleSearch[i].Timestamp.CompareTo(titleSearch[j].Timestamp) < 0)
                        {
                            temp = titleSearch[i];
                            titleSearch[i] = titleSearch[j];
                            titleSearch[j] = temp;
                        }
                for (int i = 0; i < contentSearch.Count - 1; i++)
                    for (int j = i + 1; j < contentSearch.Count; j++)
                        if (contentSearch[i].Timestamp.CompareTo(contentSearch[j].Timestamp) < 0)
                        {
                            temp = contentSearch[i];
                            contentSearch[i] = contentSearch[j];
                            contentSearch[j] = temp;
                        }
                for (int i = 0; i < contentSearch.Count; i++)
                    titleSearch.Add(contentSearch[i]);

                model.Current_all_questions = titleSearch;
                model.State = QuestionListModel.QUESTIONLIST;
                QuestionsDomainsUpdated(model);
            }
        
        #endregion

        /* 
		 * Trigger rules for callback functions 
		 */
        #region rules

        public bool OnListQuestionsRule(RMessage message)
        {
            if (message.Type != MessageType.GET_ALL_QUESTIONS_REPLY)
                return false;
            return true;
        }
		
		public bool OnListDomainsRule(RMessage message)
		{
            if (message.Type != MessageType.GET_ALL_DOMAINS_ORDERED_REPLY)
				return false;			
			return true;
		}

        public bool OnAddQuestionRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_QUESTION_REPLY)
                return false;
            return true;
        }

        public bool OnListDomainQuestionsRule(RMessage message)
        {
            if (message.Type != MessageType.GET_DOMAIN_QUESTIONS_REPLY)
                return false;
            return true;
        }

        public bool OnChangeQuestionStatusRule(RMessage message)
        {
            if (message.Type != MessageType.CHANGE_QUESTION_STATUS_REPLY)
                return false;
            return true;
        }
        
        #endregion

        /* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
        #region callbacks

        public void OnListQuestions(RMessage message)
        {
            List<QuestionData> questions = (List<QuestionData>)message.Data;
            model.All_questions = questions;
            QuestionListReset();
        }

        public void OnListDomains(RMessage message)
        {
            List<DomainData> domains = (List<DomainData>)message.Data;
            model.Domains = domains;
            QuestionsDomainsUpdated(model);
        }
         
    	public void OnListDomainQuestions(RMessage message)
		{
            List<QuestionData> questions = (List<QuestionData>)message.Data;
            model.Current_all_questions = questions;
            QuestionsDomainsUpdated(model);
		}

    	public void OnAddQuestion(RMessage message)
		{
            QuestionData question = (QuestionData)message.Data;
            if (question.Owner == LoggedInUserModel.Instance.User.Id)
            {
                model.Current_my_questions.Add(question);
            }
            model.All_questions.Add(question);
            QuestionsDomainsUpdated(model);
		}
                
    	public void OnChangeQuestionStatus(RMessage message)
		{
            QuestionData question = (QuestionData)message.Data;
            
            for (int i = 0; i < model.All_questions.Count; i ++ )
            {
                if (model.All_questions[i].Id == question.Id)
                {
                    model.All_questions[i].Status = question.Status;
                    break;
                }
            }

            for (int i = 0; i < model.Current_my_questions.Count; i++)
            {
                if (model.Current_my_questions[i].Id == question.Id)
                {
                    model.Current_my_questions[i].Status = question.Status;
                    break;
                }
            }

            for (int i = 0; i < model.Current_all_questions.Count; i++)
            {
                if (model.Current_all_questions[i].Id == question.Id)
                {
                    model.Current_all_questions[i].Status = question.Status;
                    break;
                }
            }

            QuestionsDomainsUpdated(model);
		}

        #endregion
    }
}
