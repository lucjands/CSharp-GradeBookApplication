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

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            //Students.Sort(Comparer<Student>.Create((x, y) => x.AverageGrade > y.AverageGrade ? 1 : -1));
            
            int StudentCount = Students.Count;

            int rank = 0;
            foreach (Student student in Students)
            {
                if (student.AverageGrade <= averageGrade)
                    rank++;
            }

            double percentage = (double)rank / (double)StudentCount;

            if (percentage > 0.8)
                return 'A';
            else if (percentage > 0.6)
                return 'B';
            else if (percentage > 0.4)
                return 'C';
            else if (percentage > 0.2)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
