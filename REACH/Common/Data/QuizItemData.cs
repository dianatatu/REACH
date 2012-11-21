using System;
using System.Collections.Generic;

namespace REACH.Common.Data
{
	[Serializable]
	public class QuizItemData
	{
		private UInt32 id;
		private String title;
		private String varA;
		private String varB;
		private String varC;
		private String varD;
		private int correct;
		private int answer;

		public QuizItemData(
			UInt32 id, 
			String title, 
			String varA, 
			String varB, 
			String varC, 
			String varD, 
			int correct)
		{
			this.id = id;
			this.title = title;
			this.varA = varA;
			this.varB = varB;
			this.varC = varC;
			this.varD = varD;
			this.correct = correct;
			this.answer = -1;
		}

		public UInt32 Id
		{ 
			get { return id; } 
		}

		public String Title
		{
			get { return title; }
		}

		public String VarA
		{
			get { return varA; }
		}

		public String VarB
		{
			get { return varB; }
		}

		public String VarC
		{
			get { return varC; }
		}

		public String VarD
		{
			get { return varD; }
		}

		public int Correct
		{
			get { return correct; }
		}

		public int Answer
		{
			get { return answer; }
			set { answer = value; }
		}
	}
}
