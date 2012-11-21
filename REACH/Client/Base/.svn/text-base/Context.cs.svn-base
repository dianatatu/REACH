using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using REACH.Client.Core;
using REACH.Client.Models;
using REACH.Common;
using REACH.Common.Base;
using REACH.Client.Controllers;

namespace REACH.Client.Base
{
    public class Context
    {
        public delegate bool TestTriggerCondition(RMessage m);
        public delegate void CallbackFunction(RMessage m);

		private static Form entryPoint;
        private static Dictionary<CallbackFunction, TestTriggerCondition> hash
            = new Dictionary<CallbackFunction, TestTriggerCondition>();
		private static readonly object mutex = new object();
		private static readonly object clb_mutex = new object();

        public static Form EntryPoint
        {
            get { return entryPoint; }
            set { entryPoint = value; }
        }

        public static void RegisterTriggerRule(CallbackFunction c, TestTriggerCondition f)
        {
			lock (mutex)
			{
				if (!hash.ContainsKey(c) || hash[c] != f)
					hash.Add(c, f);
			}
        }

        public static void UnregisterTriggerRule(CallbackFunction c, TestTriggerCondition f)
        {
			lock (mutex)
			{
				if (hash.ContainsKey(c) && hash[c] == f)
					hash.Remove(c);
			}
        }

        public static void FireCallback(RMessage msg)
        {
			lock (clb_mutex)
			{
				Dictionary<CallbackFunction, TestTriggerCondition> copy_hash;
				lock (mutex)
				{
					copy_hash =
						new Dictionary<CallbackFunction, TestTriggerCondition>(hash);
				}
				foreach (KeyValuePair<CallbackFunction, TestTriggerCondition> entry in copy_hash)
					if (entry.Value(msg))
						entry.Key(msg);
			}
        }
    }
}
