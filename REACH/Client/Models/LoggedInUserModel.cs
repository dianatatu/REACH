using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
	public class LoggedInUserModel : IModel
	{
		private static readonly object mutex = new object();
		private static LoggedInUserModel instance = null;

		// the connected user
		private UserData user;

		// the list of domains and the domains for which the user is certificated
		private List<DomainData> allDomains;
		private List<DomainData> certDomains;

        // the moment the user connected
        private DateTime connectionTime;

		private LoggedInUserModel()
		{}

		// thread-safe implementation of Singleton Pattern
		public static LoggedInUserModel Instance
		{
			get
			{
				lock (mutex)
				{
					if (instance == null)
						instance = new LoggedInUserModel();
					return instance;
				}
			}
		}

		public UserData User
		{
			get { return user; }
			set { user = value; }
		}

		public List<DomainData> AllDomains
		{
			get { return allDomains; }
			set { allDomains = value; }
		}

		public List<DomainData> CertifiedDomains
		{
			get { return certDomains; }
			set { certDomains = value; }
		}

        public DateTime ConnectionTime
        {
            get { return connectionTime; }
            set { connectionTime = value; }
        }
	}
}
