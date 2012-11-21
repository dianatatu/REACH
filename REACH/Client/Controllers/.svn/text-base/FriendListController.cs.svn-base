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
    public class FriendListController : ControllerBase<FriendListModel>
    {

        // prevent calling the constructor from outside
        public FriendListController()
        {
            model = new FriendListModel();
        }

        public void RegisterHandlers()
        {
            Context.RegisterTriggerRule(OnGetAllFriendships, OnGetAllFriendshipsRule);
            Context.RegisterTriggerRule(OnGetAllFriends, OnGetAllFriendsRule);
            Context.RegisterTriggerRule(OnThisUserStateChanged, OnThisUserStateChangedRule);
            Context.RegisterTriggerRule(OnUserStateChanged, OnUserStateChangedRule);
            Context.RegisterTriggerRule(OnFriendshipConfirmed, OnFriendshipConfirmedRule);
            Context.RegisterTriggerRule(OnFriendshipDenied, OnFriendshipDeniedRule);
            Context.RegisterTriggerRule(OnAddFriendship, OnAddFriendshipRule);
            Context.RegisterTriggerRule(OnAddFriend, OnAddFriendRule);
            Context.RegisterTriggerRule(OnAddSay, OnAddSayRule);
        }

        public void UnregisterHandlers()
        {
            Context.UnregisterTriggerRule(OnGetAllFriendships, OnGetAllFriendshipsRule);
            Context.UnregisterTriggerRule(OnGetAllFriends, OnGetAllFriendsRule);
            Context.UnregisterTriggerRule(OnThisUserStateChanged, OnThisUserStateChangedRule);
            Context.UnregisterTriggerRule(OnUserStateChanged, OnUserStateChangedRule);
            Context.UnregisterTriggerRule(OnFriendshipConfirmed, OnFriendshipConfirmedRule);
            Context.UnregisterTriggerRule(OnFriendshipDenied, OnFriendshipDeniedRule);
            Context.UnregisterTriggerRule(OnAddFriendship, OnAddFriendshipRule);
            Context.UnregisterTriggerRule(OnAddFriend, OnAddFriendRule);
            Context.UnregisterTriggerRule(OnAddSay, OnAddSayRule);
        }

        /*
         * Events section
         */
        #region events

        public event ExternalEventHandler ThisUserStateChanged;
        public event ExternalEventHandler FriendListStateChanged;

        #endregion

        /* 
		 * Commands section 
		 */
        #region commands

        public void PopulateFriendList()
        {

            // Create a new request
            RMessage msg2 = new RMessage(MessageType.GET_ALL_FRIENDS_REQUEST, null);
            // Handle the request to the service
            Service.Instance.AddMessage(msg2);
            // Create a new request
            RMessage msg = new RMessage(MessageType.GET_ALL_FRIENDSHIPS_REQUEST, null);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void AddFriend(String userName)
        {
            RMessage msg = new RMessage(MessageType.ADD_FRIEND_REQUEST, userName);
            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void StyleChoiceChanged(Boolean newChoice)
        {
            model.StyleChoice = newChoice;
        }

        public void OpenConversation(uint id)
        {
            if (model.GetFriendshipById(id).Status)
            {
                System.Windows.Forms.Form conversationView = null;
                foreach (System.Windows.Forms.Form child in Context.EntryPoint.MdiChildren)
                    if ((child is ConversationView) && !(((ConversationView)child).IsDisposed) && ((ConversationView)child).Id == id)
                        conversationView = child;
                if (conversationView == null)
                    new ConversationView(id, model.StyleChoice);
                else
                    conversationView.Focus();
            }
        }

        public void UpdateUserState(Boolean newState)
        {
            // Create a new request
            RMessage msg = new RMessage(MessageType.CHANGE_USER_STATE_REQUEST, newState);

            // Handle the request to the service
            Service.Instance.AddMessage(msg);
        }

        public void ResponseFriendRequest(uint id, bool newState)
        {
            // Create a new request
            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            FriendshipData friendship = model.GetFriendshipById(id);
            if (!(friendship.Status) && (friendship.Latter == thisUserId))
            {
                friendship.Status = newState;
                RMessage msg = new RMessage(MessageType.UPDATE_FRIENDSHIP_REQ, friendship);

                // Handle the request to the service
                Service.Instance.AddMessage(msg);
            }
        }

        public void refreshFriendList()
        {
            FriendListStateChanged(model);
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
            SayData sayData = (SayData)message.Data;
            foreach (System.Windows.Forms.Form child in Context.EntryPoint.MdiChildren)
                if ((child is ConversationView) && !(((ConversationView)child).IsDisposed) && ((ConversationView)child).Id == sayData.Id)
                    return false;
            if (!(LoggedInUserModel.Instance.User.Status))
                return false;
            return true;
        }

        public bool OnGetAllFriendshipsRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.GET_ALL_FRIENDSHIPS_REPLY)
                return false;
            return true;
        }

        public bool OnGetAllFriendsRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.GET_ALL_FRIENDS_REPLY)
                return false;

            return true;
        }

        public bool OnThisUserStateChangedRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.CHANGE_USER_STATE_REPLY)
                return false;

            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            if (((UserData)message.Data).Id != thisUserId)
                return false;

            return true;
        }

        public bool OnUserStateChangedRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.CHANGE_USER_STATE_REPLY)
                return false;

            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            if (((UserData)message.Data).Id == thisUserId)
                return false;

            // Don't have to check if we have this user in the friend list
            // This check is done by the Server.Commander

            return true;
        }

        public bool OnFriendshipConfirmedRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.CONFIRM_FRIENDSHIP_REPLY)
                return false;

            // Don't have to check if we have this friendship in 
            // the friendship list.
            // This check is done by the Server.Commander

            return true;
        }

        public bool OnFriendshipDeniedRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.DENY_FRIENDSHIP_REPLY)
                return false;

            // Don't have to check if we have this friendship in 
            // the friendship list.
            // This check is done by the Server.Commander

            return true;
        }

        public bool OnAddFriendRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.ADD_FRIEND_REPLY)
                return false;

            // Don't have to check if we have this friend in 
            // the friend list.
            // This check is done by the Server.Commander

            return true;
        }

        public bool OnAddFriendshipRule(RMessage message)
        {
            // Check the type of the message
            if (message.Type != MessageType.ADD_FRIENDSHIP_REPLY)
                return false;

            // Don't have to check if we have this friend in 
            // the friend list.
            // This check is done by the Server.Commander

            return true;
        }

        #endregion

        /* 
		 * Callback functions section (for asynchronous actions).
		 * These methods will be triggered by the Context. 
		 */
        #region callbacks

        public void OnAddSay(RMessage message)
        {
            ConversationView newConversation;
            SayData sayData = (SayData)message.Data;
            newConversation = new ConversationView(sayData.Id, model.StyleChoice);
            Context.FireCallback(message);
        }

        public void OnGetAllFriends(RMessage message)
        {
            model.Users = (List<UserData>)message.Data;
        }

        public void OnGetAllFriendships(RMessage message)
        {
            model.Friendships = (List<FriendshipData>)message.Data;
            FriendListStateChanged(model);
        }

        private delegate void CloseViewFunction(ConversationView view);

        private void CloseView(ConversationView view)
        {
            if (view.InvokeRequired)
            {
                view.Invoke((CloseViewFunction)
                    CloseView, view);
                return;
            }

            view.Close();
        }

        public void OnThisUserStateChanged(RMessage message)
        {
            LoggedInUserModel.Instance.User.Status = ((UserData)message.Data).Status;
            ThisUserStateChanged(model);
            if (!(LoggedInUserModel.Instance.User.Status))
                foreach (System.Windows.Forms.Form child in Context.EntryPoint.MdiChildren)
                    if ((child is ConversationView) && !(((ConversationView)child).IsDisposed))
                        CloseView((ConversationView)child);

        }

        public void OnUserStateChanged(RMessage message)
        {
            model.GetFriendById(((UserData)message.Data).Id).Status = ((UserData)message.Data).Status;
            FriendListStateChanged(model);
        }

        public void OnFriendshipConfirmed(RMessage message)
        {
            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            model.GetFriendshipById((uint)(message.Data)).Status = true;
            FriendListStateChanged(model);
        }

        public void OnFriendshipDenied(RMessage message)
        {
            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            model.Friendships.Remove(model.GetFriendshipById((uint)(message.Data)));
            model.Users.Remove(model.GetFriendById((uint)(message.Data)));
            FriendListStateChanged(model);
        }

        public void OnAddFriend(RMessage message)
        {
            model.Users.Add((UserData)message.Data);
        }

        public void OnAddFriendship(RMessage message)
        {
            model.Friendships.Add((FriendshipData)message.Data);
            FriendListStateChanged(model);
        }

        #endregion
    }
}
