using System;
using System.Linq;

namespace LR1.BusinessLayer
{
    public static class ConsoleParser
    {
        private const string inputFileArg = "-i";
        private const string outputFileArg = "-o";
        private const string fileFormatArg = "-f";

        public static void ParseConsoleArguments(this string[] args, out string inputFile, out string outputFile, out FileFormat format)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length < 6)
            {
                throw new ArgumentException("Too little arguments");
            }

            if (!args.Contains(inputFileArg) || !args.Contains(outputFileArg) || !args.Contains(fileFormatArg))
            {
                throw new ArgumentException("Argument don't present");
            }

            var calcArgsCount = args.Where((argument, index) => (index % 2 == 0) && argument != inputFileArg && argument != outputFileArg && argument != fileFormatArg).Count();
            if (calcArgsCount != 0)
            {
                throw new ArgumentException("Invalid order of arguments");
            }

            inputFile = args[Array.IndexOf(args, inputFileArg) + 1];
            string formatName = args[Array.IndexOf(args, fileFormatArg) + 1];

            if (!Enum.TryParse(formatName, true, out format))
            {
                throw new ArgumentException("Invalid format name");
            }
            outputFile = $"{args[Array.IndexOf(args, outputFileArg) + 1]}.{formatName}";
        }
    }
}
