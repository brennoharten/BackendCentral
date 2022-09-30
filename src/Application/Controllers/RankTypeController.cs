using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankTypeController : ControllerBase
    {
        private IBaseService<RankType> _baseRankTypeService;

        public RankTypeController(IBaseService<RankType> baseRankTypeService)
        {
            _baseRankTypeService = baseRankTypeService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RankType rankType)
        {
            if (rankType == null)
                return NotFound();

            return Execute(() => _baseRankTypeService.Add<RankTypeValidator>(rankType).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] RankType rankType)
        {
            if (rankType == null)
                return NotFound();

            return Execute(() => _baseRankTypeService.Update<RankTypeValidator>(rankType));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseRankTypeService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseRankTypeService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseRankTypeService.GetById(id));
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