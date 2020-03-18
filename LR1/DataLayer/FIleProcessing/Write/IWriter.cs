using LR1.DataLayer;

namespace LR1.BusinessLayer.Write
{
    public interface IWriter
    {
        void WriteToFile(GroupAvg info, string path);
    }
}
