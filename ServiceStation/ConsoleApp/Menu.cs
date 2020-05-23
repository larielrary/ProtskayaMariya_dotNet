using BusinessLayer.Services.ServiceStationService;
using BusinessLayer.ServiceStationService;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Menu
    {
        private readonly CarService car;

        private readonly CarTechnicalConditionService carCondition;

        private readonly OwnerService owner;

        private readonly InspectorService inspector;

        public Menu(CarService car, CarTechnicalConditionService carCondition,
                                OwnerService owner, InspectorService inspector)
        {
            this.car = car;
            this.carCondition = carCondition;
            this.owner = owner;
            this.inspector = inspector;
        }

        public async Task Start()
        {
            int numOfMenu;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add inspector");
                Console.WriteLine("2. Update inspector");
                Console.WriteLine("3. Delete inspector");
                Console.WriteLine();
                Console.WriteLine("4. Add car");
                Console.WriteLine("5. Update car");
                Console.WriteLine("6. Delete car");
                Console.WriteLine();
                Console.WriteLine("7. Add owner");
                Console.WriteLine("8. Update owner");
                Console.WriteLine("9. Delete owner");
                Console.WriteLine();
                Console.WriteLine("10. Create order");
                Console.WriteLine("11. Update order");
                Console.WriteLine("12. Delete order");
                Console.WriteLine();
                Console.WriteLine("13. Show inspectors");
                Console.WriteLine("14. Show cars");
                Console.WriteLine("15. Show owners");
                Console.WriteLine("16. Show orders");
                Console.WriteLine();
                Console.WriteLine("0. Exit");

                numOfMenu = Convert.ToInt32(Console.ReadLine());

                switch (numOfMenu)
                {
                    //Inspector
                    case 1:
                        {
                            await InspectorMenu.CreateAsync(inspector);
                            break;
                        }
                    case 2:
                        {
                            await InspectorMenu.EditAsync(inspector);
                            break;
                        }
                    case 3:
                        {
                            await InspectorMenu.DeleteAsync(inspector);
                            break;
                        }
                    //Car
                    case 4:
                        {
                            await CarMenu.CreateAsync(car);
                            break;
                        }
                    case 5:
                        {
                            await CarMenu.EditAsync(car);
                            break;
                        }
                    case 6:
                        {
                            await CarMenu.DeleteAsync(car);
                            break;
                        }
                    //Owner
                    case 7:
                        {
                            await OwnerMenu.CreateAsync(owner);
                            break;
                        }
                    case 8:
                        {
                            await OwnerMenu.EditAsync(owner);
                            break;
                        }
                    case 9:
                        {
                            await OwnerMenu.DeleteAsync(owner);
                            break;
                        }
                    //Car technical condition
                    case 10:
                        {
                            await CarConditionMenu.CreateAsync(carCondition);
                            break;
                        }
                    case 11:
                        {
                            await CarConditionMenu.EditAsync(carCondition);
                            break;
                        }
                    case 12:
                        {
                            await CarConditionMenu.DeleteAsync(carCondition);
                            break;
                        }
                    //Show all items
                    case 13:
                        {
                            InspectorMenu.ShowAll(inspector);
                            break;
                        }
                    case 14:
                        {
                            CarMenu.ShowAll(car);
                            break;
                        }
                    case 15:
                        {
                            OwnerMenu.ShowAll(owner);
                            break;
                        }
                    case 16:
                        {
                            CarConditionMenu.ShowAll(carCondition);
                            break;
                        }
                }
            }
            while (numOfMenu != 0);
            if (numOfMenu == 0)
            {
                Environment.Exit(0);
            }
        }
    }
}
