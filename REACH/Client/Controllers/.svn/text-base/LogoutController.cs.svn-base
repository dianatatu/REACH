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
	public class LogoutController : ControllerBase<LoggedInUserModel>
	{
		/* Constructor */
		public LogoutController()
		{
			model = LoggedInUserModel.Instance;
		}

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnConnect, OnConnectRule);
            Context.RegisterTriggerRule(OnDisconnect, OnDisconnectRule);
            Context.RegisterTriggerRule(OnGetUserInfo, OnGetUserInfoRule);
            Context.RegisterTriggerRule(OnServerOffline, OnServerOfflineRule);
        }

		public void UnregisterHandlers()
		{
			Context.UnregisterTriggerRule(OnConnect, OnConnectRule);
			Context.UnregisterTriggerRule(OnDisconnect, OnDisconnectRule);
            Context.UnregisterTriggerRule(OnGetUserInfo, OnGetUserInfoRule);
            Context.UnregisterTriggerRule(OnServerOffline, OnServerOfflineRule);
		}

		/*
		 * Events section
		 */
		#region events

		public event ExternalEventHandler ConnectAccept;
		public event ExternalEventHandler DisconnectAccept;
        public event ExternalEventHandler GetUserInfoFromServer;

		#endregion

		/* 
		 * Commands section 
		 */
		#region commands

		public void Disconnect()
		{            
            double seconds = (new TimeSpan(DateTime.Now.Ticks - LoggedInUserModel.Instance.ConnectionTime.Ticks)).TotalSeconds;
            RMessage msg0 = new RMessage(MessageType.RANK_USER_LOGGED_TIME_REQUEST, seconds);
            Service.Instance.AddMessage(msg0);
			RMessage msg = new RMessage(MessageType.CHANGE_USER_STATE_REQUEST, false);
			Service.Instance.AddMessage(msg);
			RMessage msg2 = new RMessage(MessageType.SIGN_OUT_REQUEST, model.User);
			Service.Instance.AddMessage(msg2);
		}

        public bool OnGetUserInfoRule(RMessage message)
        {
            if (message.Type != MessageType.GET_USER_INFO_REPLY)
                return false;
            return true;
        }

        public void GetUserInfo()
        {
            RMessage msg = new RMessage(MessageType.GET_USER_INFO_REQUEST, model.User);
            Service.Instance.AddMessage(msg);
        }

		#endregion

		/* 
		 * Trigger rules for callback functions 
		 */
		#region rules

		public bool OnConnectRule(RMessage message)
		{
			if (message.Type != MessageType.SIGN_IN_REPLY || message.Data == null)
				return false;
			
			return true;
		}

		public bool OnDisconnectRule(RMessage message)
		{
			if (message.Type != MessageType.SIGN_OUT_REPLY)
				return false;

			return true;
		}

        public bool OnServerOfflineRule(RMessage message)
        {
            if (message.Type != MessageType.SERVER_OFFLINE_EVENT)
                return false;
            return true;
        }

		#endregion

		/* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
		#region callbacks

		public void OnConnect(RMessage message)
		{
			ConnectAccept(model);
		}

		public void OnDisconnect(RMessage message)
		{
			DisconnectAccept(model);
		}		
    
    	public void OnGetUserInfo(RMessage message)
		{
            List<Object> list = (List<Object>)message.Data;
            model.User = (UserData)list[0];
            model.AllDomains = (List<DomainData>)list[1];
            model.CertifiedDomains = (List<DomainData>)list[2];
            GetUserInfoFromServer(model);
		}

    	public void OnServerOffline(RMessage message)
		{
            DisconnectAccept(model);
		}

		#endregion
    }
}
