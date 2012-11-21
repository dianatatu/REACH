using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
	[Serializable]
	public class ValidationData
	{
		private UInt32 user_id;
		private UInt32 domain_id;

		public ValidationData(UInt32 user_id, UInt32 domain_id)
		{
			this.user_id = user_id;
			this.domain_id = domain_id;
		}

		public UInt32 UserId
		{
			get { return user_id; }
		}

		public UInt32 DomainId
		{
			get { return domain_id; }
		}
	}
}
