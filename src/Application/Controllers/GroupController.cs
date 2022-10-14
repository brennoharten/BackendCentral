using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _groupService;

        public GroupController(IGroupService baseGroupService)
        {
            _groupService = baseGroupService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group group)
        {
            if (group == null)
                return NotFound();

            return Execute(() => _groupService.Add<GroupValidator>(group).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Group group)
        {
            if (group == null)
                return NotFound();

            return Execute(() => _groupService.Update<GroupValidator>(group));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _groupService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _groupService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _groupService.GetById(id));
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