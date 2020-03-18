using LR1.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace LR1.BusinessLayer
{
    public static class StudentExtensions
    {
        public static IEnumerable<StudentAvg> CastToStudentAvegareInfo(this IEnumerable<Student> studentInfos)
        {
            return studentInfos.Select(studentInfo => new StudentAvg
            {
                FirstName = studentInfo.FirstName,
                Surname = studentInfo.Surname,
                MiddleName = studentInfo.MiddleName,
                AverageMark = CalculateAverageMark(studentInfo)
            });
        }

        public static Marks CastToSummaryMarkInfo(this IEnumerable<Student> studentInfos)
        {
            var averageMarks = studentInfos
                .SelectMany(student => student.Subjects)
                .GroupBy(mark => mark.Name)
                .Select(subject => new Subject
                {
                    Name = subject.Key,
                    Mark = subject.Average(subject => subject.Mark)
                }).ToList();

            averageMarks.Add(new Subject
            {
                Name = "TotalAverageMark",
                Mark = averageMarks.Average(item => item.Mark)
            });

            var summaryMarkInfo = new Marks
            {
                AverageMarks = averageMarks.AsReadOnly()
            };

            return summaryMarkInfo;
        }

        private static double CalculateAverageMark(Student studentInfo)
        {
            return studentInfo.Subjects.Sum(subject => subject.Mark) / studentInfo.Subjects.Count;
        }
    }
}
