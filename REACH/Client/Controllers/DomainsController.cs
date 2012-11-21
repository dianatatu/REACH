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
	public class DomainsController : ControllerBase<DomainListModel>
	{
		/* Constructor */
		public DomainsController()
		{
			model = DomainListModel.Instance;
		}

		public void RegisterHandlers()
		{
			Context.RegisterTriggerRule(OnGetAllDomains, OnGetAllDomainsRule);
		}

		public void UnregisterHandlers()
		{
			Context.UnregisterTriggerRule(OnGetAllDomains, OnGetAllDomainsRule);
		}

		/*
		 * Events section
		 */
		#region events

		public event ExternalEventHandler DomainsReceived;

		#endregion

		/* 
		 * Commands section 
		 */
		#region commands

		public void GetAllDomains()
		{
			// Handle a request to the server only for the first time
			if (model.AllDomains == null)
			{
				RMessage msg = new RMessage(MessageType.GET_ALL_DOMAINS_REQUEST, null);
				Service.Instance.AddMessage(msg);
			}
			else
				DomainsReceived(model);
		}

		#endregion

		/* 
		 * Trigger rules for callback functions 
		 */
		#region rules

		public bool OnGetAllDomainsRule(RMessage message)
		{
			if (message.Type != MessageType.GET_ALL_DOMAINS_REPLY)
				return false;
			return true;
		}

		#endregion

		/* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
		#region callbacks

		public void OnGetAllDomains(RMessage message)
		{
			model.AllDomains = (List<DomainData>)message.Data;
			DomainsReceived(model);
		}

		#endregion
	}
}
