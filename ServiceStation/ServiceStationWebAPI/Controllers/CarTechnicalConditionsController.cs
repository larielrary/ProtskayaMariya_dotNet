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
    public class CarTechnicalConditionsController : Controller
    {
        private readonly CarTechnicalConditionsService _conditionService;
        private readonly ILogger<CarTechnicalConditionsController> _logger;

        public CarTechnicalConditionsController(CarTechnicalConditionsService conditionService,
                                ILogger<CarTechnicalConditionsController> logger)
        {
            _conditionService = conditionService;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarTechnicalCondition>>> Get()
        {
            return (await _conditionService.GetItems()).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarTechnicalCondition>> Get(int id)
        {
            try
            {
                var car = await _conditionService.GetItem(id);
                return Ok(car);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<CarTechnicalCondition>> Post(CarTechnicalCondition condition)
        {
            try
            {
                await _conditionService.Create(condition);
                return Ok(condition);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CarTechnicalCondition>> Put(CarTechnicalCondition condition)
        {
            try
            {
                await _conditionService.Update(condition);
                return Ok(condition);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return BadRequest();
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarTechnicalCondition>> Delete(int id)
        {
            try
            {
                await _conditionService.Delete(id);
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
