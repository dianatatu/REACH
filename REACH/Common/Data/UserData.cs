using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class UserData
    {
        private UInt32 id = 0;
        private String username = "";
        private String password = "";
        private String email = "";
        private Boolean status = false;
        private Double rank = 0;

        public UserData(UInt32 _id, String _username, String _password, String _email, Boolean _status, Double _rank)
        {
            id = _id;
            username = _username;
            password = _password;
            email = _email;
            status = _status;
            rank = _rank;
        }

		public UserData(String _username, String _password, String _email)
		{
			username = _username;
			password = _password;
			email = _email;
		}

		public UserData(String _username, String _password)
		{
			username = _username;
			password = _password;
		}

        public UInt32 Id
        {
            get
            {
                return id;
            }
        }

        public String Username
        {
            get
            {
                return username;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
        }

        public String Email
        {
            get
            {
                return email;
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

        public Double Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }
    }
}
