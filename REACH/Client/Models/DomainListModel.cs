using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
	public class DomainListModel : IModel
	{
		private static readonly object mutex = new object();
		private static DomainListModel instance = null;
		private List<DomainData> allDomains = null;
		
		private DomainListModel()
		{}

		// thread-safe implementation of Singleton Pattern
		public static DomainListModel Instance
		{
			get
			{
				lock (mutex)
				{
					if (instance == null)
						instance = new DomainListModel();
					return instance;
				}
			}
		}

		public List<DomainData> AllDomains
		{
			get { return allDomains; }
			set { allDomains = value; }
		}
	}
}
