using ConsoleTables;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class PrintExtensions
    {
        public static void ToTable<T>(this IEnumerable<T> items)
        {
            ConsoleTable.From(items).Write();
        }
    }
}
