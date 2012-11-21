using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REACH.Server
{
    public class Ranking
    {
        // rank values
        public const double RESOURCE_VOTE_POINT_VALUE = 1.3;
        public const double RESOURCE_ACCESSED_VALUE = 0.1;
        public const double ADD_FRIEND = 1.1;
        public const double ADD_SAY = 0.01;
        public const double USER_POSTED_RESOURCE_VALUE = 3.7;
        public const double USER_VOTED_RESOURCE_VALUE = 0.2;
        public const double ADD_QUESTION = 0.1;
        public const double ADD_ANSWER = 0.2;
        public const double VOTE_USER = 0.1;

        public const double USER_UP_TIME_POINT_VALUE = 0.001;
        public const double USER_INITIAL_RANK_BEGINNER = 20.0;
        public const double USER_INITIAL_RANK_INTERMEDIATE = 30.0;
        public const double USER_INITIAL_RANK_ADVANCED = 40.0;
        
    }
}
