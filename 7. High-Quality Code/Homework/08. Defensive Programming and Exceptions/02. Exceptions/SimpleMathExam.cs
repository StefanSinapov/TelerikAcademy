namespace StudentExamSystem
{
    using System;
    using System.Collections.Generic;

    public class SimpleMathExam : Exam
    {
        private const int MinProblemsCount = 0;
        private const int MaxProblemsCount = 2;
        private const int MinGrade = 2;
        private const int MaxGrade = 6;

        private readonly Dictionary<int, KeyValuePair<int, string>> marksByProblemsSolved =
           new Dictionary<int, KeyValuePair<int, string>>()
            {
                { 0, new KeyValuePair<int, string>(2, "Bad result: nothing done.") },
                { 1, new KeyValuePair<int, string>(4, "Average result: something done.") },
                { 2, new KeyValuePair<int, string>(6, "Excellence result: everything done.") }
            };

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < MinProblemsCount || value > MaxProblemsCount)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Problems count must be in range [{0}-{1}]", MinProblemsCount, MaxProblemsCount));
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            var grade = this.marksByProblemsSolved[this.ProblemsSolved];
            var examResult = new ExamResult(grade.Key, MinGrade, MaxGrade, grade.Value);
            return examResult;
        }
    }
}