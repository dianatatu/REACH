using System;
using System.Collections.Generic;

using REACH.Client.Helpers;
using REACH.Client.Base;
using REACH.Client.Models;
using REACH.Client.Views;
using REACH.Common.Data;
using REACH.Common.Base;
using REACH.Common;

namespace REACH.Client.Controllers
{
	public class LoginController : ControllerBase<LoggedInUserModel>
	{
		/* Constructor */
		public LoginController()
		{
			model = LoggedInUserModel.Instance;
		}

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnConnect, OnConnectRule);
            Context.RegisterTriggerRule(OnConnectTimeOut, OnConnectTimeOutRule);
        }

		public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnConnect, OnConnectRule);
			Context.UnregisterTriggerRule(OnConnectTimeOut, OnConnectTimeOutRule);
        }

		/*
		 * Events section
		 */
		#region events

		public event ExternalEventHandler ConnectAccept;
		public event ExternalEventHandler ConnectDeny;
		public event ExternalEventHandler ConnectTimeOut;

		#endregion

		/* 
		 * Commands section 
		 */
		#region commands

		public void Connect(String username, String password)
		{
			UserData user = new UserData(username, Md5Helper.GetMd5(password));
			RMessage msg = new RMessage(MessageType.SIGN_IN_REQUEST, user);

			// Handle the request to the service
			Service.Instance.AddMessage(msg);
		}

		#endregion

		/* 
		 * Trigger rules for callback functions 
		 */
		#region rules

		public bool OnConnectRule(RMessage message)
		{
			if (message.Type != MessageType.SIGN_IN_REPLY)
				return false;
			
			return true;
		}

		public bool OnConnectTimeOutRule(RMessage message)
		{
			// If a timeout occurs, the initial request is passed back
			if (message.Type != MessageType.SIGN_IN_REQUEST)
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
			if (message.Data == null)
			{
				ConnectDeny(model);
				return;
			}

			List<Object> payload = (List<Object>)message.Data;
			model.User = (UserData)payload[0];
			model.AllDomains = (List<DomainData>)payload[1];
			model.CertifiedDomains = (List<DomainData>)payload[2];

            model.ConnectionTime = System.DateTime.Now;
			ConnectAccept(model);
		}

		public void OnConnectTimeOut(RMessage message)
		{
			ConnectTimeOut(null);
		}

		#endregion
	}
}
