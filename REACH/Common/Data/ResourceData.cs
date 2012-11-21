using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class ResourceData
    {
        private UInt32 id;
        private UInt32 owner;
        private UInt32 domain;
        private DateTime timestamp;
        private String title;
        private String description;
        private String links;
        private Int32 category;
        private Double rank;

        public ResourceData(UInt32 _id, UInt32 _owner, UInt32 _domain, DateTime _timestamp, String _title, String _description, String _links, Int32 _category, Double _rank)
        {
            id = _id;
            owner = _owner;
            domain = _domain;
            timestamp = _timestamp;
            title = _title;
            description = _description;
            links = _links;
            category = _category;
            rank = _rank;
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

        public UInt32 Domain
        {
            get
            {
                return domain;
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
        }

        public String Description
        {
            get
            {
                return description;
            }
        }

        public String Links
        {
            get
            {
                return links;
            }
        }

        public Int32 Category
        {
            get
            {
                return category;
            }
        }

        public Double Rank
        {
            get
            {
                return rank;
            }
        }

        public override string ToString()
        {
            String result = "";
            result += String.Format("[{0,6:0.0}] ", rank);
            result += String.Format("{0,-30}", title);
            result += String.Format("{0:dd.MM.yyyy HH:mm}", timestamp);
            return result;
        }

        public String ToSQLString()
        {
            return String.Format("'NULL','{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", id, owner, domain, timestamp, title, description, links, category, rank);
        }
    }
}
