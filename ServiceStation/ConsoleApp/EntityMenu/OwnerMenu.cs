using BusinessLayer.Models.DTO;
using BusinessLayer.ServiceStationService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class OwnerMenu
    {
        public static async Task CreateAsync(OwnerService owner)
        {
            Console.Clear();
            Console.WriteLine("Input firstname:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Input lastname:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Input middlename:");
            var middleName = Console.ReadLine();
            Console.WriteLine("Input phone number:");
            var phoneNum = Console.ReadLine();
            var createdOwner = new Owner
            {
                Firstname = firstName,
                LastName = lastName,
                MiddleName = middleName,
                PhoneNum = phoneNum,
            };
            await owner.Create(createdOwner);
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task EditAsync(OwnerService owner)
        {
            Console.Clear();
            Console.WriteLine("Input owner id:");
            var id = Convert.ToInt32(Console.ReadLine());
            var updOwner = owner.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
            if (updOwner != null)
            {
                Console.WriteLine("Input firstname:");
                var firstName = Console.ReadLine();
                Console.WriteLine("Input lastname:");
                var lastName = Console.ReadLine();
                Console.WriteLine("Input middlename:");
                var middleName = Console.ReadLine();
                Console.WriteLine("Input phone number:");
                var phoneNum = Console.ReadLine();
                updOwner.Firstname = firstName;
                updOwner.LastName = lastName;
                updOwner.MiddleName = middleName;
                updOwner.PhoneNum = phoneNum;
                await owner.Update(updOwner);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static async Task DeleteAsync(OwnerService owner)
        {
            Console.Clear();
            Console.WriteLine("Input owner id:");
            var id = Convert.ToInt32(Console.ReadLine());
            await owner.Delete(id);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowAll(OwnerService owner)
        {
            Console.Clear();
            owner.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
            Console.Clear();
        }
    }
}
