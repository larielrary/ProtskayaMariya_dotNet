using System.Collections.Generic;

namespace LR1.DataLayer
{
    public class Student
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public IReadOnlyCollection<Subject> Subjects { get; set; }
    }
}
