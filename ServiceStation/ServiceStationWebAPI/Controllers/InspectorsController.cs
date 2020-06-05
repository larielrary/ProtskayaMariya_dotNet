using BusinessLayer.Models;
using BusinessLayer.Services.ServiceStationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStationWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class InspectorsController : Controller
    {
        private readonly InspectorsService _inspectorService;
        private readonly ILogger<InspectorsController> _logger;

        public InspectorsController(InspectorsService inspectorService,
                                ILogger<InspectorsController> logger)
        {
            _inspectorService = inspectorService;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspector>>> Get()
        {
            return (await _inspectorService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspector>> Get(int id)
        {
            try
            {
                var inspector = await _inspectorService.GetItem(id);
                return Ok(inspector);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Inspector>> Post(Inspector inspector)
        {
            try
            {
                await _inspectorService.Create(inspector);
                return Ok(inspector);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Inspector>> Put(Inspector inspector)
        {
            try
            {
                await _inspectorService.Update(inspector);
                return Ok(inspector);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inspector>> Delete(int id)
        {
            try
            {
                await _inspectorService.Delete(id);
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
