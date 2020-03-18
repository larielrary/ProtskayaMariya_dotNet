using LR1.DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LR1.BusinessLayer.Read
{
    public class CsvReader : IReader
    {
        public IEnumerable<Student> ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException();

            var records = new List<Student>();

            using var reader = new StreamReader(path);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            var subjectNames = csv.Context.HeaderRecord.Skip(3).ToList();

            while (csv.Read())
            {
                if (csv.Context.Record.Length != csv.Context.HeaderRecord.Length)
                {
                    throw new InvalidDataException("The number of record items and header items doesn't match");
                }

                var studentInfo = new Student
                {
                    FirstName = csv.GetField<string>(0),
                    Surname = csv.GetField<string>(1),
                    MiddleName = csv.GetField<string>(2)
                };

                List<Subject> subjects = new List<Subject>();

                subjectNames.ForEach(
                    name => subjects.Add(
                        new Subject()
                        {
                            Name = name,
                            Mark = csv.GetField<int>(name)
                        }));

                studentInfo.Subjects = subjects.AsReadOnly();

                records.Add(studentInfo);
            }
            return records;
        }
    }
}
