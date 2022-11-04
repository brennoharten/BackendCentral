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
    public class RankTypeController : ControllerBase
    {
        private IRankTypeService _rankTypeService;

        public RankTypeController(IRankTypeService baseRankTypeService)
        {
            _rankTypeService = baseRankTypeService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] RankType rankType)
        {
            if (rankType == null)
                return NotFound();

            return Execute(() => _rankTypeService.Add<RankTypeValidator>(rankType).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] RankType rankType)
        {
            if (rankType == null)
                return NotFound();

            return Execute(() => _rankTypeService.Update<RankTypeValidator>(rankType));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _rankTypeService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _rankTypeService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _rankTypeService.GetById(id));
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