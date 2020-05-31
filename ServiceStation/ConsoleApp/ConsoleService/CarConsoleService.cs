using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using ConsoleApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CarConsoleService : IConsoleService, ICrudService<Car>
    {
        private readonly CarsService _carService;

        public CarConsoleService(CarsService carService)
        {
            _carService = carService;
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
            var items = await _carService.GetItems();
            items.ToTable();
        }

        public async Task AddAsync()
        {
            var item = await CreateAsync();
            await _carService.Create(item);
        }

        public async Task RemoveAsync()
        {
            Console.WriteLine("Enter Id to delete");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            await _carService.Delete(id);
        }

        public async Task EditAsync()
        {
            Console.WriteLine("Enter Id to edit");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var item = await CreateAsync();
            item.Id = id;
            await _carService.Update(item);
        }

        public async Task<Car> CreateAsync()
        {
            Console.WriteLine("Input number:");
            var carNumber = Console.ReadLine();
            Console.WriteLine("Input model:");
            var carModel = Console.ReadLine();
            Console.WriteLine("Input engine capacity:");
            var engine = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input body number: ");
            var bodyNumber = Console.ReadLine();
            Console.WriteLine("Input year of production:");
            var year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input owner id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var createdCar = new Car
            {
                CarNumber = carNumber,
                CarModel = carModel,
                EngineCapacity = engine,
                BodyNubmer = bodyNumber,
                YearOfProduction = year,
                OwnerId = id
            };
            return createdCar;
        }
    }
}
