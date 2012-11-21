using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REACH.Common
{
    public class MessageType
    {
        /*
         * Define request types
         */

        // Sign-up & Sign-in - 0x001? and 0x002?        
        public const int END_IT_ALL_REQUEST = 0x0000;
		public const int SIGN_IN_REQUEST = 0x0001;
		public const int SIGN_OUT_REQUEST = 0x0002;
		public const int START_TEST_REQUEST = 0x0003;
		public const int USERNAME_TAKEN_REQUEST = 0x0004;
		public const int CREATE_NEW_USER_REQUEST = 0x0005;
		public const int TAKE_NEW_CERT_REQUEST = 0x0006;
        public const int GET_USER_INFO_REQUEST = 0x0007;

        // QuestionList and Question - 0x002? and 0x003?
        public const int ADD_QUESTION_REQUEST = 0x0020;
        public const int GET_QUESTION_REQUEST = 0x0021;
        public const int GET_ALL_QUESTIONS_REQUEST = 0x0022;
        public const int ADD_ANSWER_REQUEST = 0x0023;
        public const int GET_QUESTION_DOMAINS_REQUEST = 0x0024;
        public const int GET_QUESTION_ANSWERS_REQUEST = 0x0025;
        public const int GET_ANSWER_OWNER_REQUEST = 0x0026;
        public const int GET_USER_BY_ID_REQUEST = 0x0027;
        public const int CHANGE_QUESTION_STATUS_REQUEST = 0x0028;
        public const int GET_QUESTION_DOMAINS_RESOURCES_REQUEST = 0x0029;
        public const int GET_QUESTION_RESOURCES_REQUEST = 0x0030;
        public const int ADD_QUESTION_REFERENCE_REQUEST = 0X0031;
        public const int ADD_USER_VOTE_REQUEST = 0x0032;
        public const int CHECK_USER_VOTE_REQUEST = 0x0033;

        // FriendList and Conversation - 0x004? and 0x005?
        public const int GET_ALL_FRIENDSHIPS_REQUEST = 0x0040;
        public const int GET_ALL_FRIENDS_REQUEST = 0x0041;
        public const int UPDATE_FRIENDSHIP_REQ = 0x0042;
        public const int ADD_FRIEND_REQUEST = 0x0043;
        public const int CHANGE_USER_STATE_REQUEST = 0x0044;
        public const int ADD_SAY_REQUEST = 0x0045;
        public const int PARTNER_INFO_REQUEST = 0x0046;

        // Shelf - 0x006? and 0x007?
        public const int GET_DOMAIN_RESOURCES_REQUEST = 0x0061;
        public const int GET_USER_CERTIFIED_DOMAINS_REQUEST = 0x0062;
        public const int ADD_RESOURCE_REQUEST = 0x0063;
        public const int EDIT_RESOURCE_REQUEST = 0x0064;
        public const int DELETE_RESOURCE_REQUEST = 0x0065;
        public const int VOTE_RESOURCE_REQUEST = 0x0066;
        public const int GET_DOMAIN_BY_NAME_REQUEST = 0x0067;
        public const int GET_RESOURCE_OWNER_REQUEST = 0x0068;

        // Rank - 0x008? and 0x009?
        public const int RANK_CHECK_RESOURCE_VOTE_REQUEST = 0x0080;
        public const int RANK_RESOURCE_ACCESSED_REQUEST = 0x0081;
        public const int RANK_USER_POSTED_LINE_REQUEST = 0x0082;
        public const int RANK_USER_POSTED_LOG_REQUEST = 0x0083;
        public const int RANK_USER_POSTED_QUESTION_REQUEST = 0x0084;
        public const int RANK_USER_ADDED_CONTACT_REQUEST = 0x0085;
        public const int RANK_USER_POSTED_RESOURCE_REQUEST = 0x0086;
        public const int RANK_USER_LOGGED_TIME_REQUEST = 0x0087;
        public const int RANK_USER_UPDATED = 0x0088;

		// Domains - 0x00A? and 0x00B?
		public const int GET_ALL_DOMAINS_REQUEST = 0x00A0;
        public const int GET_DOMAIN_QUESTIONS_REQUEST = 0x00A1;
        public const int GET_ALL_DOMAINS_ORDERED_REQUEST = 0x00A2;
        /*
         * Define reply types
         */

        // Sign-up & Sign-in - 0xFF1? and 0xFF2?
		public const int SIGN_IN_REPLY = 0xFF11;
		public const int SIGN_OUT_REPLY = 0xFF12;
		public const int START_TEST_REPLY = 0xFF13;
		public const int USERNAME_TAKEN_REPLY = 0xFF14;
        public const int GET_USER_INFO_REPLY = 0xFF15;

        // QuestionList and Question - 0xFF2? and 0xFF3?
        public const int GET_ALL_QUESTIONS_REPLY = 0xFF20;
        public const int GET_QUESTION_REPLY = 0xFF21;
        public const int ADD_QUESTION_REPLY = 0xFF22;
        public const int ADD_ANSWER_REPLY = 0xFF23;
        public const int GET_QUESTION_DOMAINS_REPLY = 0xFF24;
        public const int GET_QUESTION_ANSWERS_REPLY = 0xFF25;
        public const int GET_ANSWER_OWNER_REPLY = 0xFF26;
        public const int GET_USER_BY_ID_REPLY = 0xFF27;
        public const int CHANGE_QUESTION_STATUS_REPLY = 0xFF28;
        public const int GET_QUESTION_DOMAINS_RESOURCES_REPLY = 0xFF29;
        public const int GET_QUESTION_RESOURCES_REPLY = 0xFF30;
        public const int ADD_QUESTION_REFERENCE_REPLY = 0XFF31;
        public const int ADD_USER_VOTE_REPLY = 0xFF32;
        public const int CHECK_USER_VOTE_REPLY = 0xFF33;

        // FriendList and Conversation - 0xFF4? and 0xFF5?
        public const int GET_ALL_FRIENDSHIPS_REPLY = 0xFF40;
        public const int GET_ALL_FRIENDS_REPLY = 0xFF41;
        public const int CONFIRM_FRIENDSHIP_REPLY = 0xFF42;
        public const int DENY_FRIENDSHIP_REPLY = 0xFF43;
        public const int ADD_FRIENDSHIP_REPLY = 0xFF44;
        public const int CHANGE_USER_STATE_REPLY = 0xFF45;
        public const int ADD_SAY_REPLY = 0xFF46;
        public const int ADD_FRIEND_REPLY = 0xFF47;
        public const int PARTNER_INFO_REPLY = 0xFF48;

        // Shelf - 0xFF6? and 0xFF7?
        public const int GET_DOMAIN_RESOURCES_REPLY = 0xFF61;
        public const int GET_USER_CERTIFIED_DOMAINS_REPLY = 0xFF62;
        public const int ADD_RESOURCE_REPLY = 0xFF63;
        public const int EDIT_RESOURCE_REPLY = 0xFF64;
        public const int DELETE_RESOURCE_REPLY = 0xFF65;
        public const int GET_DOMAIN_BY_NAME_REPLY = 0xFF67;
        public const int GET_RESOURCE_OWNER_REPLY = 0xFF68;

        // Rank - 0xFF8? and 0xFF9?
        public const int RANK_CHECK_RESOURCE_VOTE_REPLY = 0xFF80;

		// Domains - 0xFFA? and 0xFFB?
		public const int GET_ALL_DOMAINS_REPLY = 0xFFA0;
        public const int GET_DOMAIN_QUESTIONS_REPLY = 0xFFA1;
        public const int GET_ALL_DOMAINS_ORDERED_REPLY = 0xFFA2;
        /*
         * Define event types
         */

        public const int SERVER_OFFLINE_EVENT = 0xFFFF;

        
    }
}
