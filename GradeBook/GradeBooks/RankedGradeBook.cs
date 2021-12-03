using GradeBook.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public virtual char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            Students.Sort(Comparer<Student>.Create((x, y) => x.AverageGrade > y.AverageGrade ? 1 : -1));
            int StudentCount = Students.Count;

            int rank = StudentCount;
            while (averageGrade < Students[rank-1].AverageGrade)
                rank--;

            double percentage = (double)rank / (double)StudentCount;

            if (percentage >= 0.8)
                return 'A';
            else if (percentage >= 0.6)
                return 'B';
            else if (percentage >= 0.4)
                return 'C';
            else if (percentage >= 0.2)
                return 'D';
            else
                return 'F';
        }
    }
}
