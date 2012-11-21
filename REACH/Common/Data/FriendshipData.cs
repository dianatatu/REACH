using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    /**
     * The initiator is the former user
     */
    [Serializable]
    public class FriendshipData
    {
        private UInt32 former;
        private UInt32 latter;
        private Boolean status;

        public FriendshipData(UInt32 _former, UInt32 _latter, Boolean _status)
        {            
            former = _former;
            latter = _latter;
            status = _status;
        }

        public UInt32 Former
        {
            get
            {
                return former;
            }
        }

        public UInt32 Latter
        {
            get
            {
                return latter;
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
    }
}
