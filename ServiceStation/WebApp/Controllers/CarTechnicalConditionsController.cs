using BusinessLayer.Models;
using BusinessLayer.Services.ServiceStationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class CarTechnicalConditionsController : Controller
    {
        private readonly CarTechnicalConditionsService _conditionService;
        private readonly ILogger<CarTechnicalConditionsController> _logger;

        public CarTechnicalConditionsController(CarTechnicalConditionsService carService, ILogger<CarTechnicalConditionsController> logger)
        {
            _conditionService = carService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _conditionService.GetItems());
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
                var condition = new CarTechnicalCondition
                {
                    Date = Convert.ToDateTime(collection["Date"]),
                    Milleage = Convert.ToDouble(collection["Milleage"]),
                    BreakSystem = Convert.ToBoolean(collection["BreakSystem"]),
                    Suspension = Convert.ToBoolean(collection["Suspension"]),
                    Wheels = Convert.ToBoolean(collection["Wheels"]),
                    Lighting = Convert.ToBoolean(collection["Lighting"]),
                    CarbonDioxideContent = Convert.ToDouble(collection["CarbonDioxideContent"]),
                    InspectorId = Convert.ToInt32(collection["InspectorId"]),
                    CarId = Convert.ToInt32(collection["CarId"]),
                    InspectionMark = Convert.ToBoolean(collection["InspectionMark"])
                };
                await _conditionService.Create(condition);
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
            return View(await _conditionService.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var condition = new CarTechnicalCondition
                {
                    Id = id,
                    Date = Convert.ToDateTime(collection["Date"]),
                    Milleage = Convert.ToDouble(collection["Milleage"]),
                    BreakSystem = Convert.ToBoolean(collection["BreakSystem"]),
                    Suspension = Convert.ToBoolean(collection["Suspension"]),
                    Wheels = Convert.ToBoolean(collection["Wheels"]),
                    Lighting = Convert.ToBoolean(collection["Lighting"]),
                    CarbonDioxideContent = Convert.ToDouble(collection["CarbonDioxideContent"]),
                    InspectorId = Convert.ToInt32(collection["InspectorId"]),
                    CarId = Convert.ToInt32(collection["CarId"]),
                    InspectionMark = Convert.ToBoolean(collection["InspectionMark"])
                };
                await _conditionService.Update(condition);
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
            return View(await _conditionService.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _conditionService.Delete(id);
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
