using System;
using System.Collections.Generic;

using REACH.Client.Core;
using REACH.Common.Data;

namespace REACH.Client.Models
{
	public class NewAccountModel : IModel
	{
		private static readonly object mutex = new object();
		private static NewAccountModel instance = null;

		public const int MINUTES_PER_QUIZ = 5;
		public const int MIN_PASSING_SCORE = 3;
		private int remainingTime;

		private string username;
		private string password;
		private string email;
		private List<DomainData> domains;
		private List<DomainData> allDomains;
		private Dictionary<String, String> errors;
		private List<QuizSetData> quizSet;
		private List<int> testScore;

		private int crtSetIndex;
		private int crtQuestionIndex;

		private NewAccountModel()
		{
			domains = new List<DomainData>();
			allDomains = new List<DomainData>();
			quizSet = new List<QuizSetData>();
		}

		// thread-safe implementation of Singleton Pattern
		public static NewAccountModel Instance
		{
			get
			{
				lock (mutex)
				{
					if (instance == null)
						instance = new NewAccountModel();
					return instance;
				}
			}
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public List<DomainData> AllDomains
		{
			get { return allDomains; }
			set { allDomains = value; }
		}

		public List<DomainData> CertifiedDomains
		{
			get { return domains; }
			set { domains = value; }
		}

		public Dictionary<String, String> Errors
		{
			get { return errors; }
			set { errors = value; }
		}

		public List<QuizSetData> QuizSet
		{
			get { return quizSet; }
			set { quizSet = value; }
		}

		public void InitTest()
		{
			crtSetIndex = 0;
			testScore = new List<int>();
			for (int i = 0; i < quizSet.Count; ++i)
				testScore.Add(0);
			remainingTime = MINUTES_PER_QUIZ * 60;
		}

		public void InitSet()
		{
			crtQuestionIndex = 0;
		}

		public QuizSetData CurrentQuiz
		{
			get { return quizSet[crtSetIndex]; }
		}

		public int CurrentQuizIndex
		{
			get { return crtSetIndex; }
		}

		public int CurrentQuestionIndex
		{
			get { return crtQuestionIndex; }
		}

		public int RemainingTime
		{
			get { return remainingTime; }
		}

		public void Tick()
		{
			--remainingTime;
		}

		public QuizItemData CurrentQuestion
		{
			get { return quizSet[crtSetIndex].Question[crtQuestionIndex]; }
		}

		public Boolean IsFirstQuestionInSet()
		{
			return crtQuestionIndex == 0;
		}

		public Boolean IsLastQuestionInSet()
		{
			return crtQuestionIndex + 1 == quizSet[crtSetIndex].Question.Count;
		}

		public void AnswerCurrentQuestion(int answer)
		{
			quizSet[crtSetIndex].Question[crtQuestionIndex].Answer = answer;
		}

		public void SetScoreForCurrentTest(int score)
		{
			testScore[crtSetIndex] = score;
		}

		public int GetScoreForTest(int index)
		{
			if (index < 0 || index >= testScore.Count)
				return 0;
			return testScore[index];
		}

		public Boolean IsLastSet()
		{
			return crtSetIndex + 1 == quizSet.Count;
		}

		public void GetNextSet()
		{
			if (crtSetIndex < 0 || crtSetIndex >= quizSet.Count)
				return ;
			++crtSetIndex;
			InitSet();
		}

		public void GetNextQuestion()
		{
			if (crtQuestionIndex + 1 < quizSet[crtSetIndex].Question.Count)
				++crtQuestionIndex;
		}

		public void GetPreviousQuestion()
		{
			if (crtQuestionIndex > 0)
				--crtQuestionIndex;
		}

	}
}
