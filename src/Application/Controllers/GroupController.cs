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
        private IBaseService<Group> _baseGroupService;

        public GroupController(IBaseService<Group> baseGroupService)
        {
            _baseGroupService = baseGroupService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group group)
        {
            if (group == null)
                return NotFound();

            return Execute(() => _baseGroupService.Add<GroupValidator>(group).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Group group)
        {
            if (group == null)
                return NotFound();

            return Execute(() => _baseGroupService.Update<GroupValidator>(group));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseGroupService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseGroupService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseGroupService.GetById(id));
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