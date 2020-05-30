using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using ConsoleApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class InspectorConsoleService : IConsoleService, ICrudService<Inspector>
    {
        private readonly InspectorService _inspectorService;

        public InspectorConsoleService(InspectorService inspectorService)
        {
            _inspectorService = inspectorService;
        }

        public async Task StartMenu()
        {
            try
            {
                Console.Clear();
                PrintMenu();
                await PrintItems();

                var choice = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

                switch (choice)
                {
                    case 1:
                        await AddAsync();
                        break;
                    case 2:
                        await RemoveAsync();
                        break;
                    case 3:
                        await EditAsync();
                        break;
                    case 4:
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Back");
        }

        public async Task PrintItems()
        {
            var items = await _inspectorService.GetItems();
            items.ToTable();
        }

        public async Task AddAsync()
        {
            var item = await CreateAsync();
            await _inspectorService.Create(item);
        }

        public async Task RemoveAsync()
        {
            Console.WriteLine("Enter Id to delete");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            await _inspectorService.Delete(id);
        }

        public async Task EditAsync()
        {
            Console.WriteLine("Enter Id to edit");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var item = await CreateAsync();
            item.Id = id;
            await _inspectorService.Update(item);
        }

        public async Task<Inspector> CreateAsync()
        {
            Console.WriteLine("Input firstname:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Input lastname:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Input middlename:");
            var middleName = Console.ReadLine();
            Console.WriteLine("Input position:");
            var position = Console.ReadLine();
            Console.WriteLine("Input salary:");
            var salary = Convert.ToDouble(Console.ReadLine());
            var newInspector = new Inspector
            {
                Firstname = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Position = position,
                Salary = salary,

            };
            return newInspector;
        }
    }
}
