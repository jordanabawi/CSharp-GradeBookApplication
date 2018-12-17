using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook: BaseGradeBook
    {

        StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char grade;
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var studentThreshold = (int) Math.Ceiling(this.Students.Count * 0.2);
            var students = Students.OrderBy(s => s.AverageGrade).ToList();
            if (averageGrade >= students.ElementAt(studentThreshold * 4).AverageGrade)
            {
                grade= 'A';
            }
            else if (averageGrade >= students.ElementAt(studentThreshold * 3).AverageGrade)
            {
                grade = 'B';
            }
            else if (averageGrade >= students.ElementAt(studentThreshold * 2).AverageGrade)
            {
                grade = 'C';
            }
            else if (averageGrade >= students.ElementAt(studentThreshold ).AverageGrade)
            {
                grade = 'D';
            }
            else
            {
                grade = 'F';
            }

            return grade;
        }
    }
}
