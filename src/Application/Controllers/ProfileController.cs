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
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;

        public ProfileController(IProfileService baseProfileService)
        {
            _profileService = baseProfileService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Profile profile)
        {
            if (profile == null)
                return NotFound();

            return Execute(() => _profileService.Add<ProfileValidator>(profile).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Profile profile)
        {
            if (profile == null)
                return NotFound();

            return Execute(() => _profileService.Update<ProfileValidator>(profile));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _profileService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _profileService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _profileService.GetById(id));
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