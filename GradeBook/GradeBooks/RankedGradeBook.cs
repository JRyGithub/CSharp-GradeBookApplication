using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            }

            //Get the minium amount of students allowed for top 20% convert to integer. For example if 20 students, then 4 will the answer.
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            //Orders list by descending, and the creates a list of just grades for students
            var grades = Students.OrderByDescending(g => g.AverageGrade).Select(g => g.AverageGrade).ToList();

            if(averageGrade > grades[threshold - 1])
            {
                return 'A';
            }else if (averageGrade >= grades[(threshold*2)-1]){
                return 'B';
            }else if (averageGrade >= grades[(threshold * 3) - 1]){
                return 'C';
            }else if (averageGrade >= grades[(threshold * 4) - 1]) {
                return 'D';
            }
            return 'F';
        }
    }
}