using ConsoleApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleService
{
    public class StartMenuConsoleService : IConsoleService
    {
        private readonly CarConsoleService _carConsoleService;
        private readonly CarConditionConsoleService _conditionConsoleService;
        private readonly OwnerConsoleService _ownerConsoleService;
        private readonly InspectorConsoleService _inspectorConsoleService;

        public StartMenuConsoleService(CarConsoleService carConsoleService, OwnerConsoleService ownerConsoleService,
            CarConditionConsoleService conditionConsoleService, InspectorConsoleService inspectorConsoleService)
        {
            _inspectorConsoleService = inspectorConsoleService;
            _ownerConsoleService = ownerConsoleService;
            _carConsoleService = carConsoleService;
            _conditionConsoleService = conditionConsoleService;
        }

        public async Task StartMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    PrintMenu();

                    var menuItemSelection = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                    switch (menuItemSelection)
                    {
                        case 1:
                            await _carConsoleService.StartMenu();
                            break;
                        case 2:
                            await _ownerConsoleService.StartMenu();
                            break;
                        case 3:
                            await _inspectorConsoleService.StartMenu();
                            break;
                        case 4:
                            await _conditionConsoleService.StartMenu();
                            break;
                        case 5:
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Owner");
            Console.WriteLine("3. Inspector");
            Console.WriteLine("4. Car techical condition");
            Console.WriteLine("5. Exit");
        }

        public Task PrintItems()
        {
            throw new NotImplementedException();
        }
    }
}
