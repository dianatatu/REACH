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
    public class QuestionAddController : ControllerBase<QuestionAddModel>
    {
        /* Constructor */
        public QuestionAddController()
        {
            model = new QuestionAddModel();
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnListDomains, OnListDomainsRule);
        }

        public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnListDomains, OnListDomainsRule);
        }

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler DomainsUpdated;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void ListDomains()
        {
            // Create a new request
            RMessage msg = new RMessage(MessageType.GET_ALL_DOMAINS_REQUEST, null);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void SubmitQuestion(UInt32 id_user, string title, string content, List<DomainData> domains)
        {
            //Create a new QuestionData
            QuestionData question = new QuestionData( 0, id_user, DateTime.Now, title, content, false);

            // Create a new QuestionAndDomainsData
            List<Object> info = new List<Object>();
            info.Add(question);
            info.Add(domains);

            // Create a new request
            RMessage msg = new RMessage(MessageType.ADD_QUESTION_REQUEST, info);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        #endregion

        /* 
		 * Trigger rules for callback functions 
		 */
        #region rules

        public bool OnListDomainsRule(RMessage message)
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

        public void OnListDomains(RMessage message)
        {
            List<DomainData> domains = (List<DomainData>)message.Data;
            model.Domains = domains;
            DomainsUpdated(model);
        }
      
        #endregion
    }
}
