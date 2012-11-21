using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class QuestionData
    {
        private UInt32 id;
        private UInt32 owner;
        private DateTime timestamp;
        private String title;
        private String content;
        private Boolean status;
        public const int TitleTruncate = 53;

        public QuestionData(UInt32 _id, UInt32 _owner, DateTime _timestamp, String _title, String _content, Boolean _status)
        {
            id = _id;
            owner = _owner;
            timestamp = _timestamp;
            title = _title;
            content = _content;
            status = _status;
        }

        public UInt32 Id
        {
            get
            {
                return id;
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

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public String Content
        {
            get
            {
                return content;
            }
        }

        public Boolean Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        override public String ToString()
        {
            return title;
        } 

        public String ToSQLString()
        {
            return String.Format("'NULL','{0}',{1},'{2}','{3}','{4}'", owner, "now()", title, content, status);
        }
    }
}
