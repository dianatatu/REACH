using System.Collections.Generic;
using System.Net.Sockets;
using REACH.Common;
using REACH.Common.Base;
using REACH.Common.Data;
using REACH.Server.Connectors;

namespace REACH.Server.Base
{
    class Commander
    {
        public delegate bool TestTriggerCondition(RMessage message);
        public delegate void MessageHandler(RMessage message, TcpClient connection);
        public delegate void CrashAction(TcpClient connection);
        private static readonly object hashMutex = new object();
        private static readonly object crashMutex = new object();
        private static Dictionary<MessageHandler, TestTriggerCondition> hash
          = new Dictionary<MessageHandler, TestTriggerCondition>();
        private static List<CrashAction> crashActions = new List<CrashAction>();

        public static void RegisterTriggerRule(MessageHandler c, TestTriggerCondition f)
        {
            lock (hashMutex)
            {
                hash.Add(c, f);
            }
        }

        public static void UnregisterTriggerRule(MessageHandler c, TestTriggerCondition f)
        {
            lock (hashMutex)
            {
                if (hash.ContainsKey(c) && hash[c] == f)
                    hash.Remove(c);
            }
        }

        public static void RegisterCrashAction(CrashAction h)
        {
            lock (crashMutex)
            {
                crashActions.Add(h);
            }
        }

        public static void UnregisterCrashAction(CrashAction h)
        {
            lock (crashMutex)
            {
                if (crashActions.Contains(h))
                    crashActions.Remove(h);
            }
        }

        public static void OnNewMessage(RMessage msg, TcpClient connection)
        {
            Dictionary<MessageHandler, TestTriggerCondition> copy_hash;
            lock (hashMutex)
            {
                copy_hash =
                    new Dictionary<MessageHandler, TestTriggerCondition>(hash);
            }
            foreach (KeyValuePair<MessageHandler, TestTriggerCondition> entry in copy_hash)
                if (entry.Value(msg))
                    entry.Key(msg,connection);
        }

        public static void OnCrash(TcpClient connection)
        {
            List<CrashAction> copy_hash;
            lock (hashMutex)
            {
                copy_hash =
                    new List<CrashAction>(crashActions);
            }
            foreach (CrashAction entry in copy_hash)
                    entry(connection);
        }
    }
}
