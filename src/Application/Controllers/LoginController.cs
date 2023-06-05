using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Helpers;
using Application.ViewModels;
using Domain.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] Authenticate model)
        {
            //var user = _userRepository.Get("brennoharten", "senha123");
            var user = _userRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usúario ou senha invalidos" });

            var token = TokenService.GenerateToken(user);

            return new
            {
                id = user.Id,
                token = token
            };

        }
    }
}
