using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class QuestionAddModel : IModel
    {
        private List<DomainData> domains = new List<DomainData>();

        private static QuestionAddModel instance = null;
        private static readonly object mutex = new object();
        
        // thread-Safe implementation of Singleton Pattern
        public static QuestionAddModel Instance
        {
            get
            {
                lock (mutex)
                {
                    if (instance == null)
                        instance = new QuestionAddModel();
                    return instance;
                }
            }
        }
        
        public List<DomainData> Domains
        {
            get
            {
                return domains;
            }
            set
            {
                domains = value;
            }
        }
    }
}
