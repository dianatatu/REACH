using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class UserVoteData
    {
        UInt32 id_voter_user;
        UInt32 id_votee_user;
        UInt32 id_question;
        int value_user_vote;

        public UserVoteData(UInt32 _id_voter_user, UInt32 _id_votee_user, UInt32 _id_question, int _value_user)
        {
            id_voter_user = _id_voter_user;
            id_votee_user = _id_votee_user;
            id_question = _id_question;
            value_user_vote = _value_user;
        }

        public UInt32 Id_voter_user
        {
            get
            {
                return id_voter_user;
            }
        }

        public UInt32 Id_votee_user
        {
            get
            {
                return id_votee_user;
            }
        }

        public UInt32 Id_question
        {
            get
            {
                return id_question;
            }
        }

        public int Value_user_vote
        {
            get
            {
                return value_user_vote;
            }
        }
    }
}
