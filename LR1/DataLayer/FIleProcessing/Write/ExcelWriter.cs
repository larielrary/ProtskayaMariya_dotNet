using LR1.DataLayer;
using OfficeOpenXml;
using System;
using System.IO;

namespace LR1.BusinessLayer.Write
{
    public class ExcelWriter : IWriter
    {
        private const int rowOffset = 2;

        public ExcelWriter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void WriteToFile(GroupAvg information, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (information is null)
            {
                throw new ArgumentNullException(nameof(information));
            }

            var excelFile = new FileInfo(path);

            using ExcelPackage package = new ExcelPackage(excelFile);
            var worksheet = package.Workbook.Worksheets.Add($"{typeof(Marks).Name}{package.Workbook.Worksheets.Count}");

            var range = worksheet.Cells[1, 1];

            range.LoadFromCollection(information.StudentAvegareInfos, true);

            range.AutoFitColumns();

            var lastRow = worksheet.Dimension.End.Row;

            range = worksheet.Cells[lastRow + rowOffset, 1];

            range.LoadFromCollection(information.SummaryMarkInfo.AverageMarks, true);

            package.Save();
        }
    }
}
