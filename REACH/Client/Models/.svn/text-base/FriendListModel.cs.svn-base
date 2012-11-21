using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using REACH.Client.Models;
using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class FriendListModel : IModel
    {
        private List<UserData> users = new List<UserData>();
        private List<FriendshipData> friendships = new List<FriendshipData>();
        private Boolean styleChoice = true;

        // prevent calling the constructor from outside
        public FriendListModel() { }

        public List<FriendshipData> Friendships {
            get
            {
                return friendships;
            }
            set
            {                
                friendships = value;
            }
        }

        public List<UserData> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }

        public Boolean StyleChoice
        {
            get
            {
                return styleChoice;
            }
            set
            {
                styleChoice = value;
            }
        }

        public FriendshipData GetFriendshipById(uint id)
        {
            uint thisUserId = LoggedInUserModel.Instance.User.Id;
            foreach (FriendshipData friendship in Friendships)
            {
                if ((friendship.Former == id && friendship.Latter == thisUserId) ||
                    (friendship.Latter == id && friendship.Former == thisUserId))
                {
                    return friendship;
                }
            }
            return null;
        }

        public UserData GetFriendById(uint id)
        {
            foreach (UserData user in Users)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }
    }
}
