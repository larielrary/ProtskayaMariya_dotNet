using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CarMenu
    {
        public static async Task CreateAsync(CarService car)
        {
            Console.Clear();
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
            await car.Create(createdCar);
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task EditAsync(CarService car)
        {
            Console.Clear();
            Console.WriteLine("Input car id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var updCar = car.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
            if (updCar != null)
            {
                Console.WriteLine("Input number:");
                var carNumber = Console.ReadLine();
                Console.WriteLine("Input model:");
                var carModel = Console.ReadLine();
                Console.WriteLine("Input engine capacity:");
                var engine = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input body number:");
                var bodyNumber = Console.ReadLine();
                Console.WriteLine("Input year of production:");
                var year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input owner id:");
                var owner = Convert.ToInt32(Console.ReadLine());
                updCar.CarNumber = carNumber;
                updCar.CarModel = carModel;
                updCar.EngineCapacity = engine;
                updCar.BodyNubmer = bodyNumber;
                updCar.YearOfProduction = year;
                updCar.OwnerId = owner;
                await car.Update(updCar);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task DeleteAsync(CarService car)
        {
            Console.Clear();
            Console.WriteLine("Input car id:");
            var id = Convert.ToInt32(Console.ReadLine());
            await car.Delete(id);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowAll(CarService car)
        {
            Console.Clear();
            car.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
