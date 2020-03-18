using LR1.BusinessLayer;
using LR1.BusinessLayer.Report;
using Ninject;
using NLog;
using System;

namespace LR1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var log = LogManager.GetCurrentClassLogger();

            try
            {
                args.ParseConsoleArguments(out var inputFile, out var outputFile, out var format);

                var kernel = new StandardKernel(new Bindings(format));

                var fileProcessor = kernel.Get<ReportService>();

                var studentInfos = fileProcessor.ReadInfoFromFile(inputFile);
                fileProcessor.WriteRecord(outputFile, studentInfos);
            }
            catch (Exception ex)
            {
                log.Error($"Error occured. Message: {ex.Message}");
            }
        }
    }
}
