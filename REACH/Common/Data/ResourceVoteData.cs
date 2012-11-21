using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
    [Serializable]
    public class ResourceVoteData
    {
        UInt32 id_resource;
        UInt32 id_user;
        Int32 value;

        public ResourceVoteData(UInt32 _id_resource, UInt32 _id_user, Int32 _value)
        {
            id_resource = _id_resource;
            id_user = _id_user;
            value = _value;
        }

        public UInt32 Id_Resource
        {
            get { return id_resource; }
        }

        public UInt32 Id_User
        {
            get { return id_user; }
        }

        public Int32 Value
        {
            get { return value; }
        }
    }
}
