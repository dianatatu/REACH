using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class SayData
    {
        private uint _id;
        private string _richSay;
        private string _normalSay;
        public SayData(uint id, string richSay, string normalSay )
        {
            _id = id;
            _richSay = richSay;
            _normalSay = normalSay;
        }

        public uint Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string RichSay
        {
            get
            {
                return _richSay;
            }
            set
            {
                _richSay = value;
            }
        }

        public string NormalSay
        {
            get
            {
                return _normalSay;
            }
            set
            {
                _normalSay = value;
            }
        }
    }
}
