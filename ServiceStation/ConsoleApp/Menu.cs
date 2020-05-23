using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using BusinessLayer.ServiceStationService;
using System;
using System.Linq;
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
                    case 1:
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
                            break;
                        }
                    case 2:
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
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Input inspector id:");
                            var id = Convert.ToInt32(Console.ReadLine());
                            await inspector.Delete(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case 4:
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
                            break;
                        }
                    case 5:
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
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Input car id:");
                            var id = Convert.ToInt32(Console.ReadLine());
                            await car.Delete(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 7:
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
                            break;
                        }
                    case 8:
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
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("Input owner id:");
                            var id = Convert.ToInt32(Console.ReadLine());
                            await owner.Delete(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 10:
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
                            break;
                        }
                    case 11:
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
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            Console.WriteLine("Input order id:");
                            var id = Convert.ToInt32(Console.ReadLine());
                            await carCondition.Delete(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 13:
                        {
                            Console.Clear();
                            inspector.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();
                            car.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 15:
                        {
                            Console.Clear();
                            owner.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 16:
                        {
                            Console.Clear();
                            carCondition.GetItems().Result.ToList().ForEach(item => Console.WriteLine(item));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            }
            while (numOfMenu != 0);
            if(numOfMenu == 0)
            {
                Environment.Exit(0);
            }
        }
    }
}
