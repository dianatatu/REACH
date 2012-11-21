using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class QuestionModel : IModel
    {
        private QuestionData question = null;
        private UserData questionOwner = null;
        private List<AnswerData> answers = null;
        private List<UserData> answerOwners = null;
        private List<DomainData> domains = null;
        private List<ResourceData> resources = null;
        private List<ResourceData> questionResources = null;
        private List<String> descriptions = new List<String>();
        private Dictionary<UInt32, Int32> my_votes = null;

        public QuestionModel() 
        {
            my_votes = new Dictionary<UInt32, Int32>();
        }

        public QuestionData Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
            }
        }

        public UserData QuestionOwner
        {
            get
            {
                return questionOwner;
            }
            set
            {
                questionOwner = value;
            }
        }

        public List<AnswerData> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }

        public List<UserData> AnswerOwners
        {
            get
            {
                return answerOwners;
            }
            set
            {
                answerOwners = value;
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

        public List<ResourceData> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
            }
        }

        public List<ResourceData> QuestionResources
        {
            get
            {
                return questionResources;
            }
            set
            {
                questionResources = value;
            }
        }

        public List<String> Descriptions
        {
            get
            {
                return descriptions;
            }
            set
            {
                descriptions = value;
            }
        }

        public Dictionary<UInt32, Int32> My_votes
        {
            get
            {
                return my_votes;
            }
            set
            {
                my_votes = value;
            }
        }
    }
}
