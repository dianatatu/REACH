using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class UserConnector : ConnectorBase<UserData>
    {
        public static List<UserData> GetFriendList(UInt32 id)
        {
            String query = "select a.* from user a," +
                "friendship b where (a.id_user = b.id_former_user and b.id_latter_user = " + id + ")" +
                "or (a.id_user = b.id_latter_user and b.id_former_user = " + id + ");";
            return GetAllItems(query);
        }

		// Add a new user
		public static void AddUser(String username, String password, String email, Double rank)
		{
			String query =
				"INSERT INTO user(username_user, password_user, email_user, rank_user) " +
				"VALUES(\"" + username + "\", \"" + password + "\", \"" + email + "\", " + rank.ToString() + ")";
			GetNoItems(query);
		}

		// Fetch user by username
		public static UserData GetUser(String username)
		{
			String query =
				"SELECT * FROM user " +
				"WHERE username_user = '" + username + "'";
            return GetSingleItem(query);
		}

        // Fetch user by id
        public static UserData GetUser(uint userId)
        {
            String query =
                "SELECT * FROM user " +
                "WHERE id_user = '" + userId + "'";
            return GetSingleItem(query);
        }

        public static UserData UpdateUserState(uint id, bool newState)
        {
            String query;
            if(newState)
                query = "update user set status_user=true where id_user="+id+";";
            else
                query = "update user set status_user=false where id_user="+id+";";
            GetNoItems(query);
            query =
                "SELECT * FROM user " +
                "WHERE id_user = '" + id + "'";
            return GetSingleItem(query);
        }

        public static UserData GetUserById(uint id)
        {
            String query = "select * from user where id_user=" + id + ";";
            return GetSingleItem(query);
        }

        public static void UpdateUserRank(uint id, double value)
        {
            UserData user = GetUserById(id);
            double rank = user.Rank;
            rank += value;
            String query = "UPDATE user SET rank_user = @Rank WHERE id_user = " + id + ";";
            MySqlCommand command = GetCommand();
            command.CommandText = query;
            command.Parameters.Add(new MySqlParameter("@Rank", rank));
            GetNoItems(command);
        }

        public static void VoteUser(UserVoteData vote)
        {
            UserVoteData voteReply = UserVoteConnector.CheckUserVote(vote);
            double adjustment;
            if (voteReply != null)
            {
                adjustment =  Adjust(voteReply.Value_user_vote);
                UpdateUserRank(voteReply.Id_votee_user, -adjustment);
                UserVoteConnector.DeleteUserVote(voteReply);
            }

            UserVoteConnector.InsertUserVote(vote);

            adjustment = Adjust(vote.Value_user_vote);
            UpdateUserRank(vote.Id_votee_user, adjustment);
        }

        private static double Adjust(int vote)
        {
            double adjustment = 0;
            switch(vote)
            {
                case 1:
                    adjustment = -0.4;
                    break;
                case 2:
                    adjustment = -0.2;
                    break;
                case 3:
                    adjustment = 0.2;
                    break;
                case 4:
                    adjustment = 0.4;
                    break;
                case 5:
                    adjustment = 1;
                    break;
                default:
                    adjustment = 0;
                    break;
            }

            return adjustment;
        }
    }
}
