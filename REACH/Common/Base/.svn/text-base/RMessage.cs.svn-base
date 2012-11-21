using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REACH.Common.Base
{
    [Serializable]
    public class RMessage
    {
        private int type;
        private object data;

        public RMessage(int _type, object _data)
        {
            type = _type;
            data = _data;
        }

        public int Type
        {
            get { return type; }
        }

        public object Data
        {
            get { return data; }
        }

        public bool IsRequest()
        {
            return (type & 0xFF00) == 0;
        }

        public bool IsReply()
        {
            return (type & 0xFF00) == 0;
        }
    }
}
