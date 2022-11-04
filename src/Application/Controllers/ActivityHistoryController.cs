using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Create([FromBody] ActivityHistory activityHistory)
        {
            if (activityHistory == null)
                return NotFound();

            return Execute(() => _activityHistoryService.Add<ActivityHistoryValidator>(activityHistory).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] ActivityHistory activityHistory)
        {
            if (activityHistory == null)
                return NotFound();

            return Execute(() => _activityHistoryService.Update<ActivityHistoryValidator>(activityHistory));
        }

        [HttpDelete("{id}")]
        [Authorize]
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
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _activityHistoryService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
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