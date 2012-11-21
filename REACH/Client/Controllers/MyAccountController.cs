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
	public class MyAccountController : ControllerBase<NewAccountModel>
	{
		/* Constructor */
		public MyAccountController()
		{
			model = NewAccountModel.Instance;
		}

		public void RegisterHandlers()
		{
			Context.RegisterTriggerRule(OnStartTest, OnStartTestRule);
		}

		public void UnregisterHandlers()
		{
			Context.UnregisterTriggerRule(OnStartTest, OnStartTestRule);
		}

		/*
		 * Events section
		 */
		#region events

		public event ExternalEventHandler QuizReceivedFromServer;

		#endregion

		/* 
		 * Commands section 
		 */
		#region commands

		public void StartTest(DomainData domain)
		{
			List<DomainData> list = new List<DomainData>();
			list.Add(domain);
			RMessage msg = new RMessage(
						MessageType.START_TEST_REQUEST,
						list);
			Service.Instance.AddMessage(msg);
		}

		#endregion

		/* 
		 * Trigger rules for callback functions 
		 */
		#region rules

		public bool OnStartTestRule(RMessage message)
		{
			if (message.Type != MessageType.START_TEST_REPLY)
				return false;
			return true;
		}

		#endregion

		/* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
		#region callbacks
   
    	public void OnStartTest(RMessage message)
		{
			model.QuizSet = (List<QuizSetData>)message.Data;
			QuizReceivedFromServer(model);
		}

		#endregion
	}
}
