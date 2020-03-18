using CsvHelper;
using LR1.DataLayer;
using System.Collections.Generic;

namespace LR1.BusinessLayer.Report
{
    interface IReportService
    {
        public IEnumerable<Student> ReadInfoFromFile(string inputFile);
        public void WriteRecord(string outputFile, IEnumerable<Student> studentInfos);
    }
}
