using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
    public class QuestionListModel : IModel
    {
        public const int QUESTIONLIST = 1;
        public const int DOMAINLIST = 2;
        private int state = DOMAINLIST;

        private List<QuestionData> all_questions = new List<QuestionData>();
        private List<QuestionData> current_my_questions = new List<QuestionData>();
        private List<QuestionData> current_all_questions = new List<QuestionData>();
        private List<DomainData> domains = new List<DomainData>();
        DomainData current_domain = null;        

        public QuestionListModel() {}

        public List<QuestionData> Current_my_questions
        {
            get
            {
                return current_my_questions;
            }
            set
            {
                current_my_questions = value;
            }
        }

        public List<QuestionData> Current_all_questions
        {
            get
            {
                return current_all_questions;
            }
            set
            {
                current_all_questions = value;
            }
        }

        public List<QuestionData> All_questions
        {
            get
            {
                return all_questions;
            }
            set
            {
                all_questions = value;
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

        public DomainData Current_domain
        {
            get
            {
                return current_domain;
            }
            set
            {
                current_domain = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
    }
}
