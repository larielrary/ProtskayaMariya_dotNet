using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly CarService _carService;
        private readonly ILogger<CarController> _logger;
        public CarController(CarService carService, ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _carService.GetItems());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                var car = new Car
                {
                    CarNumber = collection["CarNumber"],
                    CarModel = collection["CarModel"],
                    EngineCapacity = Convert.ToDouble(collection["EngineCapacity"]),
                    BodyNubmer = collection["BodyNumber"],
                    YearOfProduction = Convert.ToInt32(collection["YearOfProduction"]),
                    OwnerId = Convert.ToInt32(collection["OwnerId"])
                };
                await _carService.Create(car);
                _logger.LogInformation($"The {nameof(Car)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Car)} creation failed.", ex);
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            await _carService.GetItem(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var car = new Car
                {
                    Id = id,
                    CarNumber = collection["CarNumber"],
                    CarModel = collection["CarModel"],
                    EngineCapacity = Convert.ToDouble(collection["EngineCapacity"]),
                    BodyNubmer = collection["BodyNumber"],
                    YearOfProduction = Convert.ToInt32(collection["YearOfProduction"]),
                    OwnerId = Convert.ToInt32(collection["OwnerId"])
                };
                await _carService.Update(car);
                _logger.LogInformation($"The {nameof(Car)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Car)} editing failed.", ex);
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.GetItem(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _carService.Delete(id);
                _logger.LogInformation($"The {nameof(Car)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Car)} deleting failed.", ex);
                return View();
            }
        }
    }
}
