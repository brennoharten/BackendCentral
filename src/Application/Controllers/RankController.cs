/* using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private IRankService _rankService;

        public RankController(IRankService baseRankService)
        {
            _rankService = baseRankService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Rank rank)
        {
            if (rank == null)
                return NotFound();

            return Execute(() => _rankService.Add<RankValidator>(rank).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Rank rank)
        {
            if (rank == null)
                return NotFound();

            return Execute(() => _rankService.Update<RankValidator>(rank));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _rankService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _rankService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _rankService.GetById(id));
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
} */