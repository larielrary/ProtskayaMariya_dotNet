<<<<<<< HEAD:ServiceStation/WebApp/Controllers/CarsController.cs
﻿using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsService _carService;
        private readonly ILogger<CarsController> _logger;
        
        public CarsController(CarsService carService, ILogger<CarsController> logger)
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
                _logger.LogInformation("Creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Creation failed.", ex);
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
                _logger.LogInformation("Editing was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Editing failed.", ex);
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _carService.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _carService.Delete(id);
                _logger.LogInformation("Delete was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete failed.", ex);
                return View();
            }
        }
    }
}
=======
﻿using BusinessLayer.Models.DTO;
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
                _logger.LogInformation("Creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Creation failed.", ex);
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
                _logger.LogInformation("Editing was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Editing failed.", ex);
                return View();
            }
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _carService.GetItem(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _carService.Delete(id);
                _logger.LogInformation("Delete was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete failed.", ex);
                return View();
            }
        }
    }
}
>>>>>>> c32c29b2864514de1a8b802a2d240f2a27a02096:ServiceStation/WebApp/Controllers/CarController.cs
