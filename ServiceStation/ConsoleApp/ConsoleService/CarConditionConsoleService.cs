using BusinessLayer.Models;
using BusinessLayer.Services.ServiceStationService;
using ConsoleApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CarConditionConsoleService : IConsoleService, ICrudService<CarTechnicalCondition>
    {
        private readonly CarTechnicalConditionsService _carTechnicalConditionService;

        public CarConditionConsoleService(CarTechnicalConditionsService carTechnicalConditionService)
        {
            _carTechnicalConditionService = carTechnicalConditionService;
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
            var items = await _carTechnicalConditionService.GetItems();
            items.ToTable();
        }

        public async Task AddAsync()
        {
            var item = await CreateAsync();
            await _carTechnicalConditionService.Create(item);
        }

        public async Task RemoveAsync()
        {
            Console.WriteLine("Enter Id to delete");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            await _carTechnicalConditionService.Delete(id);
        }

        public async Task EditAsync()
        {
            Console.WriteLine("Enter Id to edit");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var item = await CreateAsync();
            item.Id = id;

            await _carTechnicalConditionService.Update(item);
        }

        public async Task<CarTechnicalCondition> CreateAsync()
        {
            Console.WriteLine("Input date:");
            var date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Input milleage:");
            var milleage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input break system condition:");
            var breakSystem = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Input suspension condition:");
            var suspension = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Input wheels condition:");
            var wheels = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Input lighting condition");
            var lighting = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Input carbon dioxide content:");
            var carbonContext = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input inspector id:");
            var inspector = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input car id:");
            var car = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input inspection mark");
            var inspectionMark = Convert.ToBoolean(Console.ReadLine());
            var createdCondition = new CarTechnicalCondition
            {
                Date = date,
                Milleage = milleage,
                BreakSystem = breakSystem,
                Suspension = suspension,
                Wheels = wheels,
                Lighting = lighting,
                CarbonDioxideContent = carbonContext,
                InspectorId = inspector,
                CarId = car,
                InspectionMark = inspectionMark
            };
            return createdCondition;
        }
    }
}
