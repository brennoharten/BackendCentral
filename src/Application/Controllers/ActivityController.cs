using Domain.Entities;
using Application.ViewModels;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;

        public ActivityController(IActivityService baseActivityService)
        {
            _activityService = baseActivityService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] ActivityViewModel activity)
        {
            Activity newactivity = new Activity{
                Name = activity.Name, 
                Description = activity.Description,
                Deadline = activity.Deadline,
                Status = activity.Status,
                Type = activity.Type,
                Score = activity.Score,
                DailyActivity = activity.DailyActivity,
                InclusionDate = DateTime.Now,
                AlterationDate = DateTime.Now,
            };

            if (activity == null)
                return NotFound();

            return Execute(() => _activityService.Add<ActivityValidator>(newactivity).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] ActivityViewModel activity)
        {
            Activity newactivity = new Activity
            {
                Name = activity.Name,
                Description = activity.Description,
                Deadline = activity.Deadline,
                Status = activity.Status,
                Type = activity.Type,
                Score = activity.Score,
                DailyActivity = activity.DailyActivity,
                InclusionDate = DateTime.Now,
                AlterationDate = DateTime.Now,
            };

            if (activity == null)
                return NotFound();

            return Execute(() => _activityService.Update<ActivityValidator>(newactivity));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _activityService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _activityService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _activityService.GetById(id));
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