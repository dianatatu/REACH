using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REACH.Common.Data
{
    [Serializable]
    public class AnswerData
    {
        private UInt32 id;
        private UInt32 question;
        private UInt32 owner;
        private DateTime timestamp;
        private String content;

        public AnswerData(UInt32 _id, UInt32 _question, UInt32 _owner, DateTime _timestamp, String _content)
        {
            id = _id;
            question = _question;
            owner = _owner;
            timestamp = _timestamp;
            content = _content;
        }

        public UInt32 Id
        {
            get
            {
                return id;
            }
        }

        public UInt32 Question
        {
            get
            {
                return question;
            }
        }

        public UInt32 Owner
        {
            get
            {
                return owner;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        public String Content
        {
            get
            {
                return content;
            }
        }

        public String ToSQLString()
        {
            return String.Format("'NULL','{0}',{1},'{2}','{3}'", question, owner, "now()", content);
        }
    }
}