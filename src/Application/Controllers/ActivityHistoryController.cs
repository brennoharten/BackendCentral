using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityHistoryController : ControllerBase
    {
        private IActivityHistoryService _activityHistoryService;

        public ActivityHistoryController(IActivityHistoryService baseActivityHistoryService)
        {
            _activityHistoryService = baseActivityHistoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActivityHistory activityHistory)
        {
            if (activityHistory == null)
                return NotFound();

            return Execute(() => _activityHistoryService.Add<ActivityHistoryValidator>(activityHistory).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ActivityHistory activityHistory)
        {
            if (activityHistory == null)
                return NotFound();

            return Execute(() => _activityHistoryService.Update<ActivityHistoryValidator>(activityHistory));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _activityHistoryService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _activityHistoryService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _activityHistoryService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}