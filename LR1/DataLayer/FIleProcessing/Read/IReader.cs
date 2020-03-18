using LR1.DataLayer;
using System.Collections.Generic;

namespace LR1.BusinessLayer.Read
{
    public interface IReader
    {
        IEnumerable<Student> ReadFile(string path);
    }
}
