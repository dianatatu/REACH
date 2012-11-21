using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
	[Serializable]
	public class DomainData
	{
		private UInt32 id;
		private String name;

		public DomainData(UInt32 id, String name)
		{
			this.id = id;
			this.name = name;
		}

        public DomainData(UInt32 id)
        {
            this.id = id;
        }

		public UInt32 ID
		{
			get { return id; }
		}

		public String Name
		{
			get { return name; }
		}

		override public String ToString()
		{
			return name;
		}
	}
}
