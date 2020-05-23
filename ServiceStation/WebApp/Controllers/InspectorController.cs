using BusinessLayer.Models.DTO;
using BusinessLayer.Services.ServiceStationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class InspectorController : Controller
    {
        private readonly InspectorService _inspectorService;
        private readonly ILogger<InspectorController> _logger;
        public InspectorController(InspectorService inspectorService, ILogger<InspectorController> logger)
        {
            _inspectorService = inspectorService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _inspectorService.GetItems());
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
                var inspector = new Inspector
                {
                    Firstname = collection["Firstname"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    Position = collection["Position"],
                    Salary = Convert.ToDouble(collection["Salary"])
                };
                await _inspectorService.Create(inspector);
                _logger.LogInformation($"The {nameof(Inspector)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Inspector)} creation failed.", ex);
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            await _inspectorService.GetItem(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var owner = new Inspector
                {
                    Id = id,
                    Firstname = collection["Firstname"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    Position = collection["Position"],
                    Salary = Convert.ToDouble(collection["Salary"])
                };
                await _inspectorService.Update(owner);
                _logger.LogInformation($"The {nameof(Inspector)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Inspector)} editing failed.", ex);
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _inspectorService.GetItem(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _inspectorService.Delete(id);
                _logger.LogInformation($"The {nameof(Inspector)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Inspector)} deleting failed.", ex);
                return View();
            }
        }
    }
}
