using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IConsoleService
    {
        Task StartMenu();

        void PrintMenu();

        Task PrintItems();
    }
}
