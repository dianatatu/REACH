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
    public class ShelfController : ControllerBase<ShelfModel>
    {
        /* Constructors */
        public ShelfController(String domain)
        {
            model = new ShelfModel();
            model.Domain_Name = domain;
            model.Display = 'l';
        }

        public ShelfController(String domain_name, ResourceData resource)
        {
            model = new ShelfModel();
            model.Domain_Name = domain_name;
            model.Display = 'd';
            model.Resource = resource;
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnGetDomainByName, OnGetDomainByNameRule);
            Context.RegisterTriggerRule(OnGetDomainResources, OnGetDomainResourcesRule);
            Context.RegisterTriggerRule(OnCheckUserDomainValidation, OnCheckUserDomainValidationRule);
            Context.RegisterTriggerRule(OnGetResourceOwner, OnGetResourceOwnerRule);
            Context.RegisterTriggerRule(OnResourcePosted, OnResourcePostedRule);
            Context.RegisterTriggerRule(OnResourceEdited, OnResourceEditedRule);
            Context.RegisterTriggerRule(OnResourceDeleted, OnResourceDeletedRule);
            Context.RegisterTriggerRule(OnCheckResourceVote, OnCheckResourceVoteRule);
        }

        public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnGetDomainByName, OnGetDomainByNameRule);
            Context.UnregisterTriggerRule(OnGetDomainResources, OnGetDomainResourcesRule);
            Context.UnregisterTriggerRule(OnCheckUserDomainValidation, OnCheckUserDomainValidationRule);
            Context.UnregisterTriggerRule(OnGetResourceOwner, OnGetResourceOwnerRule);
            Context.UnregisterTriggerRule(OnResourcePosted, OnResourcePostedRule);
            Context.UnregisterTriggerRule(OnResourceEdited, OnResourceEditedRule);
            Context.UnregisterTriggerRule(OnResourceDeleted, OnResourceDeletedRule);
            Context.UnregisterTriggerRule(OnCheckResourceVote, OnCheckResourceVoteRule);
        }

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler ShelfResourceList;
        public event ExternalEventHandler SearchListUpdated;
        public event ExternalEventHandler UserDomainValidationChecked;
        public event ExternalEventHandler DisplayModeChanged;
        public event ExternalEventHandler ResourcePosted;
        public event ExternalEventHandler ResourceEdited;
        public event ExternalEventHandler ResourceDeleted;
        public event ExternalEventHandler ResourceVoteChecked;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void PopulateDomainListByName()
        {
            // Create a new Request
            RMessage msg = new RMessage(MessageType.GET_DOMAIN_BY_NAME_REQUEST, model.Domain_Name);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void PopulateDomainList()
        {
            // Create a new Request
            RMessage msg = new RMessage(MessageType.GET_DOMAIN_RESOURCES_REQUEST, model.Domain);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void CheckUserDomainValidation(DomainData domain)
        {
            RMessage msg = new RMessage(MessageType.GET_USER_CERTIFIED_DOMAINS_REQUEST, LoggedInUserModel.Instance.User);
            Service.Instance.AddMessage(msg);
        }

        public void SearchResourceList(String pattern)
        {
            model.Resources = new List<ResourceData>();
            foreach (ResourceData res in model.Resources_All)
            {
                String res_title = res.Title.ToLower();
                if(res_title.ToLower().Contains(pattern.ToLower()))
                    model.Resources.Add(res);
            }
            SearchListUpdated(model);
        }

        public void ChangeToDetailedMode(ResourceData resource)
        {
            model.Resource = resource;
            model.Display = 'd'; // detailed mode
            List<Object> requestContent = new List<Object>();
            requestContent.Add(model.Domain);
            requestContent.Add(resource);
            RMessage msg = new RMessage(MessageType.GET_RESOURCE_OWNER_REQUEST, requestContent);
            Service.Instance.AddMessage(msg);
            msg = new RMessage(MessageType.RANK_RESOURCE_ACCESSED_REQUEST, resource);
            Service.Instance.AddMessage(msg);
        }

        public void ChangeToDetailedMode()
        {
            model.Display = 'd';
            DisplayModeChanged(model);
        }

        public void ChangeToListMode()
        {
            model.Display = 'l';
            model.Resource_Owner = null;
            model.Resource = null;            
            DisplayModeChanged(model);
        }

        public void ChangeToPostMode()
        {
            model.Display = 'p';
            DisplayModeChanged(model);
        }

        public void ChangeToEditMode()
        {
            model.Display = 'e';
            DisplayModeChanged(model);
        }

        public void AddResource(String _Title, String _Description, String _Links, Int32 _Category)
        {
            ResourceData reqContent = new ResourceData(0,
                LoggedInUserModel.Instance.User.Id,
                model.Domain.ID,
                DateTime.Now,
                _Title,
                _Description,
                _Links,
                _Category,
                0.0);
            RMessage msg = new RMessage(MessageType.ADD_RESOURCE_REQUEST, reqContent);
            Service.Instance.AddMessage(msg);
        }

        public void EditResource(String _Description, String _Links)
        {
            ResourceData reqContent = new ResourceData(model.Resource.Id,
                                                            model.Resource.Owner,
                                                            model.Resource.Domain,
                                                            model.Resource.Timestamp,
                                                            model.Resource.Title,
                                                            _Description,
                                                            _Links,
                                                            model.Resource.Category,
                                                            model.Resource.Rank);
            RMessage msg = new RMessage(MessageType.EDIT_RESOURCE_REQUEST, reqContent);
            Service.Instance.AddMessage(msg);
        }

        public void DeleteResource()
        {
            ResourceData reqContent = model.Resource;
            RMessage msg = new RMessage(MessageType.DELETE_RESOURCE_REQUEST, reqContent);
            Service.Instance.AddMessage(msg);
        }

        public void CheckResourceVote(ResourceData resource)
        {
            List<Object> reqContent = new List<Object>();
            reqContent.Add(LoggedInUserModel.Instance.User);
            reqContent.Add(resource);
            RMessage msg = new RMessage(MessageType.RANK_CHECK_RESOURCE_VOTE_REQUEST, reqContent);
            Service.Instance.AddMessage(msg);
        }

        public void VoteResource(int value)
        {
            model.My_Votes[model.Resource.Id] = value;
            ResourceVoteData resVote = new ResourceVoteData(model.Resource.Id, LoggedInUserModel.Instance.User.Id, value);
            RMessage msg = new RMessage(MessageType.VOTE_RESOURCE_REQUEST, resVote);
            Service.Instance.AddMessage(msg);
            CheckResourceVote(model.Resource);
        }

        public void VoteResource(ResourceData resource, int value)
        {
            model.My_Votes[resource.Id] = value;
            ResourceVoteData resVote = new ResourceVoteData(resource.Id, LoggedInUserModel.Instance.User.Id, value);
            RMessage msg = new RMessage(MessageType.VOTE_RESOURCE_REQUEST, resVote);
            Service.Instance.AddMessage(msg);
            CheckResourceVote(resource);
        }

        public void SortCriteriaUpdated()
        {
            ShelfResourceList(model);
        }

        #endregion

        /* 
		 * Trigger rules for callback functions 
		 */
        #region rules

        public bool OnGetDomainByNameRule(RMessage message)
        {
			if (message.Type != MessageType.GET_DOMAIN_BY_NAME_REPLY)
				return false;
			if (model.Domain_Name == null)
				return false;
            DomainData dom = (DomainData)message.Data;
            if (!model.Domain_Name.Equals(dom.Name))
                return false;
			return true;
		}

        public bool OnGetDomainResourcesRule(RMessage message)
        {
            if (message.Type != MessageType.GET_DOMAIN_RESOURCES_REPLY)
                return false;
            DomainData reply_domain = (DomainData)(((List<Object>)message.Data)[0]);
            if (String.Equals(reply_domain.Name, model.Domain_Name) == false)
                return false;
            return true;
        }

        public bool OnCheckUserDomainValidationRule(RMessage message)
        {
            if (message.Type != MessageType.GET_USER_CERTIFIED_DOMAINS_REPLY)
                return false;
            UserData replyUser = (UserData)(((List<Object>) message.Data)[0]);
            if (replyUser.Id != LoggedInUserModel.Instance.User.Id)
                return false;
            return true;
        }

        public bool OnResourcePostedRule(RMessage message)
        {
            if (message.Type != MessageType.ADD_RESOURCE_REPLY)
                return false;
            ResourceData res = (ResourceData)message.Data;
            if (res.Domain != model.Domain.ID)
                return false;
            return true;
        }

        public bool OnResourceEditedRule(RMessage message)
        {
            if (message.Type != MessageType.EDIT_RESOURCE_REPLY)
                return false;
			if (model.Domain == null)
				return false;
            ResourceData res = (ResourceData)message.Data;
            if (res.Domain != model.Domain.ID)
                return false;
            return true;
        }

        public bool OnResourceDeletedRule(RMessage message)
        {
            if (message.Type != MessageType.DELETE_RESOURCE_REPLY)
                return false;
			if (model.Domain == null)
				return false;
            ResourceData res = (ResourceData)message.Data;
            if (res.Domain != model.Domain.ID)
                return false;
            return true;
        }

        public bool OnCheckResourceVoteRule(RMessage message)
        {
            if (message.Type != MessageType.RANK_CHECK_RESOURCE_VOTE_REPLY)
                return false;
            UserData usr = (UserData)(((List<Object>)message.Data)[0]);
            if (usr.Id != LoggedInUserModel.Instance.User.Id)
                return false;
            return true;
        }

        #endregion

        /* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
        #region callbacks

    	public void OnGetDomainByName(RMessage message)
		{
            model.Domain = (DomainData)message.Data;
            this.CheckUserDomainValidation(model.Domain);
            this.PopulateDomainList();
            if (model.Display == 'd' && model.Resource_Owner == null)
                ChangeToDetailedMode(model.Resource);
		}

    	public void OnGetDomainResources(RMessage message)
		{
            model.Resources_All = (List<ResourceData>)(((List<Object>)message.Data)[1]);
            model.Resources = new List<ResourceData>();
            foreach (ResourceData res in model.Resources_All)
                model.Resources.Add(res);
            ShelfResourceList(model);
		}

        public void OnCheckUserDomainValidation(RMessage message)
        {
            model.User_Domains = (List<DomainData>)(((List<Object>) message.Data)[1]);
            UserDomainValidationChecked(model);
        }

		public bool OnGetResourceOwnerRule(RMessage message)
		{
			if (message.Type != MessageType.GET_RESOURCE_OWNER_REPLY)
				return false;
			DomainData dom = (DomainData)(((List<Object>)message.Data)[0]);
            if (model.Domain != null && dom.ID != model.Domain.ID)
                return false;
            ResourceData res = (ResourceData)(((List<Object>)message.Data)[1]);
            try
            {
                if (res.Id != model.Resource.Id)
                    return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
			return true;
		}
    
    	public void OnGetResourceOwner(RMessage message)
		{
            model.Resource_Owner = (UserData)(((List<Object>)message.Data)[2]);
            DisplayModeChanged(model);
		}

    	public void OnResourcePosted(RMessage message)
		{
            ResourceData resource = (ResourceData)message.Data;
            model.Resources_All.Add(resource);
            model.Resources.Add(resource);
            ResourcePosted(model);
            ShelfResourceList(model);
		}

    	public void OnResourceEdited(RMessage message)
		{
            ResourceData resource = (ResourceData)message.Data;
            ResourceData local_resource;

            // remove existing model reference of this resource
            local_resource = null;
            foreach (ResourceData res in model.Resources)
                if (res.Id == resource.Id)
                    local_resource = res;
            if (local_resource != null)
                model.Resources.Remove(local_resource);

            local_resource = null;
            foreach (ResourceData res in model.Resources_All)
                if (res.Id == resource.Id)
                    local_resource = res;
            if (local_resource != null)
                model.Resources_All.Remove(local_resource);

            model.Resources_All.Add(resource);
            model.Resources.Add(resource);

            if (model.Resource != null && model.Resource.Id == resource.Id)
            {
                model.Resource = resource;
            }

            ShelfResourceList(model);
            ResourceEdited(model);
		}

    	public void OnResourceDeleted(RMessage message)
		{
            // remove deleted resource from model
            ResourceData delResource = (ResourceData)message.Data;
            ResourceData localResource;

            localResource = null;
            foreach (ResourceData res in model.Resources)
                if (res.Id == delResource.Id)
                    localResource = res;
            model.Resources.Remove(localResource);

            localResource = null;
            foreach (ResourceData res in model.Resources_All)
                if (res.Id == delResource.Id)
                    localResource = res;
            model.Resources_All.Remove(localResource);

            ResourceDeleted(model);
            ShelfResourceList(model);

		}

        public void OnCheckResourceVote(RMessage message)
        {
            ResourceData res = (ResourceData)(((List<Object>)message.Data)[1]);
            ResourceVoteData resVote = (ResourceVoteData)(((List<Object>)message.Data)[2]);
            if (model.My_Votes.ContainsKey(res.Id))
                model.My_Votes[res.Id] = resVote.Value;
            else
                model.My_Votes.Add(res.Id, resVote.Value);

            ResourceVoteChecked(model);

        }

        #endregion

    }
}
