using Domain.Entities;
using Domain.Interfaces;
using Application.ViewModels;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService baseUserService)
        {
            _userService = baseUserService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Create([FromBody] UserViewModel user)
        {
            if (user == null)
                return NotFound();

            User newuser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                InclusionDate = DateTime.Now,
                AlterationDate = DateTime.Now,
                Role = "admin",
                Score = 0
            };


            var okResult = Execute(() => _userService.Add<UserValidator>(newuser).Id) as OkObjectResult;

            var UserId = okResult.Value;

            return new
            {
                Id = UserId,
                Username = user.Username,
                Email = user.Email
            };
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _userService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _userService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Execute(() => _userService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> Get(int id)
        {
            if (id == 0)
                return NotFound(new { message = "Usúario não encontrado" });

            var users = _userService.Get().OrderByDescending(u => u.Score).ToList();

            // Encontrar o índice do usuário na lista classificada (o índice + 1 representa o rank)
            int rank = users.FindIndex(u => u.Id == id) + 1;
            var user =  _userService.GetById(id);
            
            return new
            {
                rank,
                user
            };
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