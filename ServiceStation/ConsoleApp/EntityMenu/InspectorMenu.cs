using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class InspectorMenu
    {
        public static async Task CreateAsync(InspectorService inspector)
        {
            Console.Clear();
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

            await inspector.Create(newInspector);
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task EditAsync(InspectorService inspector)
        {
            Console.Clear();
            Console.WriteLine("Input inspector id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var updInspector = inspector.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();

            if (updInspector != null)
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
                updInspector.Firstname = firstName;
                updInspector.LastName = lastName;
                updInspector.MiddleName = middleName;
                updInspector.Position = position;
                updInspector.Salary = salary;
                await inspector.Update(updInspector);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static async Task DeleteAsync(InspectorService inspector)
        {
            Console.Clear();
            Console.WriteLine("Input inspector id:");
            var id = Convert.ToInt32(Console.ReadLine());
            await inspector.Delete(id);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowAll(InspectorService inspector)
        {
            Console.Clear();
            inspector.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
