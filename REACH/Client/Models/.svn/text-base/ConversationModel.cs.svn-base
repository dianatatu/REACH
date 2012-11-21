using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class ConversationModel : IModel
    {
        private List<SayData> _says = new List<SayData>();
        private UserData _partner = null;

        public List<SayData> Says
        {
            get
            {
                return _says;
            }
            set
            {
                _says = value;
            }
        }

        public UserData Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                _partner = value;
            }
        }
    }
}
