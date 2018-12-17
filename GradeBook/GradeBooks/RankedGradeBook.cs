using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

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
            
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var studentThreshold = (int)Math.Ceiling(Students.Count * 0.2);
            var students = Students.OrderByDescending(s => s.AverageGrade).ToArray();
            if (averageGrade >= students[(studentThreshold)-1 ].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade >= students[(studentThreshold*2) -1].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade >= students[(studentThreshold*3)-1].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade >= students[(studentThreshold*4) -1].AverageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
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
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}
