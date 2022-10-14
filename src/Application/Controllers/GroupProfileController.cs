using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupProfileController : ControllerBase
    {
        private IGroupProfileService _groupProfileService;

        public GroupProfileController(IGroupProfileService baseGroupProfileService)
        {
            _groupProfileService = baseGroupProfileService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] GroupProfile groupProfile)
        {
            if (groupProfile == null)
                return NotFound();

            return Execute(() => _groupProfileService.Add<GroupProfileValidator>(groupProfile).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] GroupProfile groupProfile)
        {
            if (groupProfile == null)
                return NotFound();

            return Execute(() => _groupProfileService.Update<GroupProfileValidator>(groupProfile));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _groupProfileService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _groupProfileService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _groupProfileService.GetById(id));
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