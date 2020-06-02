using BusinessLayer.Models;
using BusinessLayer.ServiceStationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OwnersController : Controller
    {
        private readonly OwnersService _ownerService;
        private readonly ILogger<OwnersController> _logger;

        public OwnersController(OwnersService ownerService,
                                ILogger<OwnersController> logger)
        {
            _ownerService = ownerService;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> Get()
        {
            return (await _ownerService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> Get(int id)
        {
            try
            {
                var owner = await _ownerService.GetItem(id);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Owner>> Post(Owner owner)
        {
            try
            {
                await _ownerService.Create(owner);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Owner>> Put(Owner owner)
        {
            try
            {
                await _ownerService.Update(owner);
                return Ok(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> Delete(int id)
        {
            try
            {
                await _ownerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
