using System;
using System.Collections.Generic;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Views;
using REACH.Common.Data;
using REACH.Common.Base;
using REACH.Common;

namespace REACH.Client.Controllers
{
    public class QuestionController : ControllerBase<QuestionModel>
    {
        /* Constructor */
        public QuestionController(Object question)
        {
            model = new QuestionModel();
            model.Question = (QuestionData)question;
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnQuestionDomainsReceived, OnQuestionDomainsReceivedRule);
            Context.RegisterTriggerRule(OnQuestionOwnerReceived, OnQuestionOwnerReceivedRule);
            Context.RegisterTriggerRule(OnQuestionStatusChanged, OnQuestionStatusChangedRule);
            Context.RegisterTriggerRule(OnQuestionAnswersReceived, OnQuestionAnswersReceivedRule);
            Context.RegisterTriggerRule(OnQuestionDomainsResourcesReceived, OnQuestionDomainsResourcesReceivedRule);
            Context.RegisterTriggerRule(OnThisUserStateChanged, OnThisUserStateChangedRule);
            Context.RegisterTriggerRule(OnQuestionResourcesReceived, OnQuestionResourcesReceivedRule);
            Context.RegisterTriggerRule(OnQuestionResourceAdded, OnQuestionResourceAddedRule);
            Context.RegisterTriggerRule(OnUserVoteChecked, OnUserVoteCheckedRule);
            Context.RegisterTriggerRule(OnUserVoteAdded, OnUserVoteAddedRule);
            Context.RegisterTriggerRule(OnRankUserUpdated, OnRankUserUpdatedRule);
            Context.RegisterTriggerRule(OnAnswerReceived, OnAnswerReceivedRule);
        }

        public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnQuestionDomainsReceived, OnQuestionDomainsReceivedRule);
            Context.UnregisterTriggerRule(OnQuestionOwnerReceived, OnQuestionOwnerReceivedRule);
            Context.UnregisterTriggerRule(OnQuestionStatusChanged, OnQuestionStatusChangedRule);
            Context.UnregisterTriggerRule(OnQuestionAnswersReceived, OnQuestionAnswersReceivedRule);
            Context.UnregisterTriggerRule(OnQuestionDomainsResourcesReceived, OnQuestionDomainsResourcesReceivedRule);
            Context.UnregisterTriggerRule(OnThisUserStateChanged, OnThisUserStateChangedRule);
            Context.UnregisterTriggerRule(OnQuestionResourcesReceived, OnQuestionResourcesReceivedRule);
            Context.UnregisterTriggerRule(OnQuestionResourceAdded, OnQuestionResourceAddedRule);
            Context.UnregisterTriggerRule(OnUserVoteChecked, OnUserVoteCheckedRule);
            Context.UnregisterTriggerRule(OnUserVoteAdded, OnUserVoteAddedRule);
            Context.UnregisterTriggerRule(OnRankUserUpdated, OnRankUserUpdatedRule);
            Context.UnregisterTriggerRule(OnAnswerReceived, OnAnswerReceivedRule);
		}

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler QuestionDomainsReceived;
        public event ExternalEventHandler QuestionOwnerReceived;
        public event ExternalEventHandler QuestionStatusChanged;
        public event ExternalEventHandler QuestionAnswersReceived;
        public event ExternalEventHandler QuestionDomainsResourcesReceived;
        public event ExternalEventHandler ThisUserStateChanged;
        public event ExternalEventHandler QuestionResourcesReceived;
        public event ExternalEventHandler UserVoteChecked;
        public event ExternalEventHandler UserRankUpdated;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void SubmitAnswer(String text)
        {
            //Create a new AnswerData
            AnswerData answer = new AnswerData(0, model.Question.Id, LoggedInUserModel.Instance.User.Id, DateTime.Now, text);

            // Create a new request
            RMessage msg = new RMessage(MessageType.ADD_ANSWER_REQUEST, answer);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void GetDomains()
        {
            //Create new request
            RMessage message = new RMessage(MessageType.GET_QUESTION_DOMAINS_REQUEST, model.Question);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void GetAnswers()
        {
            //Create new request
            RMessage message = new RMessage(MessageType.GET_QUESTION_ANSWERS_REQUEST, model.Question.Id);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void GetQuestionOwner()
        {
            //Create new request
            RMessage message = new RMessage(MessageType.GET_USER_BY_ID_REQUEST, model.Question.Owner);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void ChangeQuestionStatus()
        {
            //Create new request
            RMessage message = new RMessage(MessageType.CHANGE_QUESTION_STATUS_REQUEST, model.Question);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void GetResources()
        {
            //Create new request
            RMessage message = new RMessage(MessageType.GET_QUESTION_RESOURCES_REQUEST, model.Question);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void AddReference(List<UInt32> id)
        {
            //Create new request
            List<UInt32> ids = id;
            ids.Insert(0, model.Question.Id);
            RMessage message = new RMessage(MessageType.ADD_QUESTION_REFERENCE_REQUEST, ids);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void StartConversationWithOwner()
        {
            StartConversationWithUser(model.QuestionOwner.Id);
        }

        public void StartConversationWithUser(uint id)
        {
            System.Windows.Forms.Form conversationView = null;
            foreach (System.Windows.Forms.Form child in Context.EntryPoint.MdiChildren)
                if ((child is ConversationView) && !(((ConversationView)child).IsDisposed) && ((ConversationView)child).Id == id)
                    conversationView = child;
            if (conversationView == null)
                new ConversationView(id, true);
            else
                conversationView.Focus();
        }

        public void ViewResource(UInt32 id)
        {
            ResourceData resource = null;
            DomainData domain = null;

            for (int i = 0; i < model.Resources.Count; i ++)
                if (model.Resources[i].Id == id)
                {
                    resource = model.Resources[i];
                    break;
                }

            for (int i = 0; i < model.Domains.Count; i ++)
                if (resource.Domain == model.Domains[i].ID)
                {
                    domain = model.Domains[i];
                    break;
                }

            new ShelfView(domain.Name, resource);
        }

        public void CheckUserVote(UserData user)
        {
            UserVoteData voteData = new UserVoteData(LoggedInUserModel.Instance.User.Id, user.Id, model.Question.Id, 0);
            //Create new request
            RMessage message = new RMessage(MessageType.CHECK_USER_VOTE_REQUEST, voteData);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        public void VoteUser(UserData user, int rating)
        {
            UserVoteData userVote = new UserVoteData(LoggedInUserModel.Instance.User.Id, user.Id, model.Question.Id, rating);
            //Create new request
            RMessage message = new RMessage(MessageType.ADD_USER_VOTE_REQUEST, userVote);
            //Handle the request to the service
            Service.Instance.AddMessage(message);
        }

        #endregion

        /* 
		 * Trigger rules for callback functions 
		 */
        #region rules

        public bool OnUserVoteAddedRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_USER_VOTE_REPLY)
                return false;
            return true;
        }
    
        public bool OnUserVoteCheckedRule(RMessage message)
        {
            if (message.Type != MessageType.CHECK_USER_VOTE_REPLY)
                return false;
            return true;
        }
        
        public bool OnQuestionResourceAddedRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_QUESTION_REFERENCE_REPLY)
                return false;
            return true;
        }

		public bool OnThisUserStateChangedRule(RMessage message)
		{
			if (message.Type != MessageType.CHANGE_USER_STATE_REPLY)
				return false;			
            if(((UserData)message.Data).Id != LoggedInUserModel.Instance.User.Id)
                return false;
			return true;
		}

        public bool OnQuestionDomainsReceivedRule(RMessage message)
		{
			if (message.Type != MessageType.GET_QUESTION_DOMAINS_REPLY)
				return false;			
			return true;
		}

        public bool OnQuestionOwnerReceivedRule(RMessage message)
        {
            if (message.Type != MessageType.GET_USER_BY_ID_REPLY)
                return false;
            return true;
        }

        public bool OnQuestionStatusChangedRule(RMessage message)
		{
			if (message.Type != MessageType.CHANGE_QUESTION_STATUS_REPLY)
				return false;			
			return true;
		}
        
        public bool OnQuestionAnswersReceivedRule(RMessage message)
		{
			if (message.Type != MessageType.GET_QUESTION_ANSWERS_REPLY)
				return false;			
			return true;
		}

        public bool OnQuestionDomainsResourcesReceivedRule(RMessage message)
        {
            if (message.Type != MessageType.GET_QUESTION_DOMAINS_RESOURCES_REPLY)
                return false;
            return true;
        }

        public bool OnQuestionResourcesReceivedRule(RMessage message)
		{
			if (message.Type != MessageType.GET_QUESTION_RESOURCES_REPLY)
				return false;
			return true;
		}

        public bool OnRankUserUpdatedRule(RMessage message)
        {
            if (message.Type != MessageType.RANK_USER_UPDATED)
                return false;
            return true;
        }

        public bool OnAnswerReceivedRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_ANSWER_REPLY)
                return false;
            if (((AnswerData)message.Data).Question != model.Question.Id)
                return false;
            return true;
        }
    
        #endregion

        /* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
        #region callbacks

    	public void OnUserVoteAdded(RMessage message)
		{
            UserVoteData vote = (UserVoteData)message.Data;
            if (model.My_votes.ContainsKey(vote.Id_votee_user))
                model.My_votes[vote.Id_votee_user] = vote.Value_user_vote;
            else
                model.My_votes.Add(vote.Id_votee_user, vote.Value_user_vote);
            UserVoteChecked(model);
		}

    	public void OnUserVoteChecked(RMessage message)
		{
            if (message.Data != null)
            {
                UserVoteData userVote = (UserVoteData)message.Data;
                if (model.My_votes.ContainsKey(userVote.Id_votee_user))
                    model.My_votes[userVote.Id_votee_user] = userVote.Value_user_vote;
                else
                    model.My_votes.Add(userVote.Id_votee_user, userVote.Value_user_vote);
                UserVoteChecked(model);
            }
		}
        
        public void OnThisUserStateChanged(RMessage message)
        {
            LoggedInUserModel.Instance.User.Status = ((UserData)message.Data).Status;
            ThisUserStateChanged(model);
        }

        public void OnQuestionDomainsReceived(RMessage message)
        {
            model.Domains = (List<DomainData>)message.Data;
            QuestionDomainsReceived(model);
            //Create new request
            RMessage message2 = new RMessage(MessageType.GET_QUESTION_DOMAINS_RESOURCES_REQUEST, model.Domains);
            //Handle the request to the service
            Service.Instance.AddMessage(message2);
        }

        public void OnQuestionOwnerReceived(RMessage message)
		{
            model.QuestionOwner = (UserData)message.Data;
            QuestionOwnerReceived(model);
		}

        public void OnQuestionStatusChanged(RMessage message)
        {
            if (model.Question.Id == ((QuestionData)message.Data).Id)
            {
                model.Question = (QuestionData)message.Data;
                QuestionStatusChanged(model);
            }
        }

        public void OnQuestionAnswersReceived(RMessage message)
		{
            model.Answers = (List<AnswerData>) ((List<Object>)message.Data)[0];
            List<UserData> list = (List<UserData>)((List<Object>)message.Data)[1];
            model.AnswerOwners = new List<UserData>();
            for(int i=0; i<list.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < model.AnswerOwners.Count; j++ )
                    if (model.AnswerOwners[j].Id == list[i].Id)
                    {
                        found = true;
                    }
                if (found == false)
                {
                    model.AnswerOwners.Add(list[i]);
                }
            }
            QuestionAnswersReceived(model);
		}

        public void OnQuestionDomainsResourcesReceived(RMessage message)
		{
            model.Resources = null;
            model.Resources = (List<ResourceData>)message.Data;
            QuestionDomainsResourcesReceived(model);            
		}


        public void OnQuestionResourcesReceived(RMessage message)
        {
            model.QuestionResources = (List<ResourceData>)message.Data;
            QuestionResourcesReceived(model);
        }

    	public void OnQuestionResourceAdded(RMessage message)
		{
            //Create new request
            RMessage message2 = new RMessage(MessageType.GET_QUESTION_RESOURCES_REQUEST, model.Question);
            //Handle the request to the service
            Service.Instance.AddMessage(message2);
		}
 
    	public void OnRankUserUpdated(RMessage message)
		{
            UserData user = (UserData)message.Data;
            foreach (UserData userI in model.AnswerOwners)
                if (userI.Id == user.Id)
                    userI.Rank = user.Rank;
            UserRankUpdated(model);
		}

    	public void OnAnswerReceived(RMessage message)
		{
            GetAnswers();
		}

        #endregion
    }
}
