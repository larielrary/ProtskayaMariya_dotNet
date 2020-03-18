using LR1.BusinessLayer.Read;
using LR1.BusinessLayer.Write;
using LR1.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LR1.BusinessLayer.Report
{
    public class ReportService:IReportService
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public ReportService(IWriter writer, IReader reader)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public IEnumerable<Student> ReadInfoFromFile(string inputFile)
        {
            if (string.IsNullOrEmpty(inputFile))
            {
                throw new ArgumentNullException(nameof(inputFile));
            }
            return reader.ReadFile(inputFile);

        }

        public void WriteRecord(string outputFile, IEnumerable<Student> studentInfos)
        {
            if (string.IsNullOrEmpty(outputFile))
            {
                throw new ArgumentNullException(nameof(outputFile));
            }

            if (studentInfos == null)
            {
                throw new ArgumentNullException(nameof(studentInfos));
            }

            var studentTotals = studentInfos.CastToStudentAvegareInfo();
            var summaryMarkInfo = studentInfos.CastToSummaryMarkInfo();

            var groupReport = new GroupAvg
            {
                SummaryMarkInfo = summaryMarkInfo,
                StudentAvegareInfos = studentTotals.ToList().AsReadOnly()
            };
            writer.WriteToFile(groupReport, outputFile);
        }
    }
}
