using System;
using System.Collections.Generic;

using REACH.Common.Data;
using REACH.Server.Base;

namespace REACH.Server.Connectors
{
    public class UserVoteConnector : ConnectorBase<UserVoteData>
    {

        public static UserVoteData CheckUserVote(UserVoteData userVote)
        {
            String query = "SELECT * " +
                            "FROM user_vote " +
                            "WHERE id_voter_user=" + userVote.Id_voter_user +
                            " AND id_votee_user=" + userVote.Id_votee_user +
                            " AND id_question=" + userVote.Id_question + ";";

            UserVoteData vote = GetSingleItem(query);

            return vote;
        }

        public static void DeleteUserVote(UserVoteData voteReply)
        {
            String query = "DELETE FROM user_vote WHERE id_voter_user=" + voteReply.Id_voter_user +
                    " AND id_votee_user=" + voteReply.Id_votee_user +
                    " AND id_question=" + voteReply.Id_question + ";";
            GetNoItems(query);
        }

        public static void InsertUserVote(UserVoteData vote)
        {
            String query =
				"INSERT INTO user_vote(id_voter_user, id_votee_user, id_question, value_user_vote) " +
				"VALUES(\"" + vote.Id_voter_user + "\", \"" + vote.Id_votee_user + "\", \"" + vote.Id_question + "\", \"" + vote.Value_user_vote + "\")";
			GetNoItems(query);
        }
    }
}
