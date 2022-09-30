using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IBaseService<Activity> _baseActivityService;

        public ActivityController(IBaseService<Activity> baseActivityService)
        {
            _baseActivityService = baseActivityService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Activity activity)
        {
            if (activity == null)
                return NotFound();

            return Execute(() => _baseActivityService.Add<ActivityValidator>(activity).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Activity activity)
        {
            if (activity == null)
                return NotFound();

            return Execute(() => _baseActivityService.Update<ActivityValidator>(activity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseActivityService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseActivityService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseActivityService.GetById(id));
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