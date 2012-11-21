using System;
using System.Collections.Generic;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Views;
using REACH.Common;
using REACH.Common.Base;
using REACH.Common.Data;


namespace REACH.Client.Controllers
{
    public class ConversationController : ControllerBase<ConversationModel>
    {
        uint id;

        /* Constructor */
        public ConversationController(uint id)
        {
            this.id = id;
            model = new ConversationModel();            
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnAddSay, OnAddSayRule);
            Context.RegisterTriggerRule(OnChangeUserState, OnChangeUserStateRule);
            Context.RegisterTriggerRule(OnReceivedPartnerInfo, OnReceivedPartnerInfoRule);
        }

        /* Destructor */
        ~ConversationController()
        {
        }

		public void UnregisterHandlers()
        {            
            Context.UnregisterTriggerRule(OnAddSay, OnAddSayRule);
            Context.UnregisterTriggerRule(OnChangeUserState, OnChangeUserStateRule);
            Context.UnregisterTriggerRule(OnReceivedPartnerInfo, OnReceivedPartnerInfoRule);
        }

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler NewSay;
        public event ExternalEventHandler ChangeUserState;
        public event ExternalEventHandler ReceivedPartnerInfo;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void GetPartnerInfo()
        {
            // Create a new request
            RMessage msg = new RMessage(MessageType.PARTNER_INFO_REQUEST, id);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void AddSay(string normal, string rich)
        {
            model.Says.Add(new SayData(LoggedInUserModel.Instance.User.Id, rich, normal));
            NewSay(model);
            // Create a new request
            RMessage msg = new RMessage(MessageType.ADD_SAY_REQUEST, new SayData(id,rich, normal));
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        #endregion

        /* 
		 * Trigger rules for callback functions 
		 */
        #region rules

        public bool OnAddSayRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_SAY_REPLY)
                return false;
            if (((SayData)message.Data).Id != id)
                return false;
            return true;
        }

        public bool OnChangeUserStateRule(RMessage message)
        {
            if (message.Type != MessageType.CHANGE_USER_STATE_REPLY)
                return false;

            if (((UserData)message.Data).Id != id)
                return false;

            return true;
        }

        public bool OnReceivedPartnerInfoRule(RMessage message)
		{
			if (message.Type != MessageType.PARTNER_INFO_REPLY)
				return false;
            if (((UserData)message.Data).Id != id)
                return false;
			return true;
		}

        #endregion

        /* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
        #region callbacks

        public void OnChangeUserState(RMessage message)
		{
            UserData friend = (UserData)message.Data;
            model.Partner.Status = friend.Status;
            ChangeUserState(model);
		}


        public void OnAddSay(RMessage message)
        {
            model.Says.Add((SayData)message.Data);
            NewSay(model);
        }
    
    	public void OnReceivedPartnerInfo(RMessage message)
		{
            model.Partner = (UserData)message.Data;
            ReceivedPartnerInfo(model);
		}

        #endregion

    }
}
