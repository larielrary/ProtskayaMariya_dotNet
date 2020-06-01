using BusinessLayer.Models;
using BusinessLayer.ServiceStationService;
using ConsoleApp.Interfaces;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class OwnerConsoleService : IConsoleService, ICrudService<Owner>
    {
        private readonly OwnersService _ownerService;

        public OwnerConsoleService(OwnersService ownerService)
        {
            _ownerService = ownerService;
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
            var items = await _ownerService.GetItems();
            items.ToTable();
        }

        public async Task AddAsync()
        {
            var item = await CreateAsync();
            await _ownerService.Create(item);
        }

        public async Task RemoveAsync()
        {
            Console.WriteLine("Enter Id to delete");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            await _ownerService.Delete(id);
        }

        public async Task EditAsync()
        {
            Console.WriteLine("Enter Id to edit");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var item = await CreateAsync();
            item.Id = id;
            await _ownerService.Update(item);
        }

        public async Task<Owner> CreateAsync()
        {
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
            return createdOwner;
        }
    }
}
