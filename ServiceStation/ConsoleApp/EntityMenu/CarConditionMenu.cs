using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class CarConditionMenu
    {
        public static async Task CreateAsync(CarTechnicalConditionService carCondition)
        {
            Console.Clear();
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
            await carCondition.Create(createdCondition);
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task EditAsync(CarTechnicalConditionService carCondition)
        {
            Console.Clear();
            Console.WriteLine("Input order id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var updCondition = carCondition.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
            if (updCondition != null)
            {
                Console.WriteLine("Input date:");
                var date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Input milleage: ");
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
                Console.WriteLine("Input inspection mark:");
                var inspectionMark = Convert.ToBoolean(Console.ReadLine());
                updCondition.Date = date;
                updCondition.Milleage = milleage;
                updCondition.BreakSystem = breakSystem;
                updCondition.Suspension = suspension;
                updCondition.Wheels = wheels;
                updCondition.Lighting = lighting;
                updCondition.CarbonDioxideContent = carbonContext;
                updCondition.InspectorId = inspector;
                updCondition.CarId = car;
                updCondition.InspectionMark = inspectionMark;
                await carCondition.Update(updCondition);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static async Task DeleteAsync(CarTechnicalConditionService carCondition)
        {
            Console.Clear();
            Console.WriteLine("Input order id:");
            var id = Convert.ToInt32(Console.ReadLine());
            await carCondition.Delete(id);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowAll(CarTechnicalConditionService carCondition)
        {
            Console.Clear();
            carCondition.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
