using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int highAvStudents =
                Students
                .Select(a => a)
                .Where(a => a.AverageGrade >= averageGrade)
                .Count();
            var highAvStudentsPercentage = Decimal.Divide(highAvStudents, Students.Count) * 100;
            var percentToGrade = (100 - highAvStudentsPercentage);
            switch (percentToGrade)
            {
                case decimal percentage when (percentToGrade >= 80):
                    return 'A';
                case decimal percentage when (percentToGrade < 80 && percentToGrade >= 60):
                    return 'B';
                case decimal percentage when (percentToGrade < 60 && percentToGrade >= 40):
                    return 'C';
                case decimal percentage when (percentToGrade < 40 && percentToGrade >= 20):
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}
