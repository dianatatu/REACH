using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class ShelfModel : IModel
    {

        // specific model variables
        private String domain_name = null;                     // name of the domain - passed at view init
        private DomainData domain = null;                      // shelf domain
        private List<DomainData> user_domains = null;          // user-certified domains
        private char display = '\0';                           // shelf display mode
        private ResourceData resource = null;                  // currently displayed resource - detailed mode
        private UserData resource_owner = null;                // owner of the currently displayed resource
        private List<ResourceData> resources = null;           // currently displayed resources - list mode
        private List<ResourceData> resources_all = null;       // all domain resources
        private Dictionary<UInt32, Int32> my_votes = null; 
        // private mapping of this user's votes on resources 

        // prevent calling the constructor from outside
        public ShelfModel() {
            my_votes = new Dictionary<UInt32, Int32>();
        }

        public String Domain_Name
        {
            get { return domain_name; }
            set { domain_name = value; }
        }

        public DomainData Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        public List<DomainData> User_Domains
        {
            get { return user_domains; }
            set { user_domains = value; }
        }

        public char Display
        {
            get { return display; }
            set { display = value; }
        }

        public ResourceData Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        public UserData Resource_Owner
        {
            get { return resource_owner; }
            set { resource_owner = value; }
        }

        public List<ResourceData> Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        public List<ResourceData> Resources_All
        {
            get { return resources_all; }
            set { resources_all = value; }
        }

        public Dictionary<UInt32, Int32> My_Votes
        {
            get { return my_votes; }
            set { my_votes = value; }
        }


    }
}
