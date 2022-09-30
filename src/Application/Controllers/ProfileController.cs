using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IBaseService<Profile> _baseProfileService;

        public ProfileController(IBaseService<Profile> baseProfileService)
        {
            _baseProfileService = baseProfileService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Profile profile)
        {
            if (profile == null)
                return NotFound();

            return Execute(() => _baseProfileService.Add<ProfileValidator>(profile).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Profile profile)
        {
            if (profile == null)
                return NotFound();

            return Execute(() => _baseProfileService.Update<ProfileValidator>(profile));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProfileService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProfileService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProfileService.GetById(id));
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