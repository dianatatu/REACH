using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
	[Serializable]
	public class QuizSetData
	{
		private List<QuizItemData> q;
		private String domain;

		public QuizSetData(String domain)
		{
			this.q = new List<QuizItemData>();
			this.domain = domain;
		}

		public void AddQuestion(QuizItemData item)
		{
			q.Add(item);
		}

		public List<QuizItemData> Question
		{
			get { return q; }
		}

		public String Domain
		{
			get { return domain; }
		}
	}
}
