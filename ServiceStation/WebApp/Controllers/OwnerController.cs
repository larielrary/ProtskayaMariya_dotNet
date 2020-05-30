using BusinessLayer.Models.DTO;
using BusinessLayer.ServiceStationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class OwnerController : Controller
    {
        private readonly OwnerService _ownerService;
        private readonly ILogger<OwnerController> _logger;
        
        public OwnerController(OwnerService inspectorService, ILogger<OwnerController> logger)
        {
            _ownerService = inspectorService;
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _ownerService.GetItems());
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
                var owner = new Owner
                {
                    Firstname = collection["Firstname"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    PhoneNum = collection["PhoneNum"]
                };
                await _ownerService.Create(owner);
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
            return View(await _ownerService.GetItem(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var owner = new Owner
                {
                    Id = id,
                    Firstname = collection["Firstname"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    PhoneNum = collection["PhoneNum"]
                };
                await _ownerService.Update(owner);
                _logger.LogInformation("Eediting was successful.");
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
            return View(await _ownerService.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _ownerService.Delete(id);
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
 
