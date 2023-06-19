using Domain.Entities;
using Application.ViewModels;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        private IUserService _userService;
        private readonly HttpClient _httpClient;

        public ActivityController(IActivityService baseActivityService, HttpClient httpClient, IUserService baseUserService)
        {
            _activityService = baseActivityService;
            _httpClient = httpClient;
            _userService = baseUserService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromBody] ActivityViewModel activity)
        {
            Activity newactivity = new Activity{
                Name = activity.Name, 
                Description = activity.Description,
                Deadline = activity.Deadline,
                Status = activity.Status,
                Type = activity.Type,
                Score = activity.Score,
                UserId = activity.UserId,
                DailyActivity = activity.DailyActivity,
                InclusionDate = DateTime.Now,
                AlterationDate = DateTime.Now,
            };

            try
            {
/*                 // Obtenha uma instância do HttpClient da fábrica

                // Configure a URL e o cabeçalho de autorização
                string apiUrl = "https://api.openai.com/v1/completions";
                string apiKey = "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";
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // Crie um objeto de conteúdo JSON com o prompt fornecido
                var model = new ChatGpt(activity.Description);
                var requestBody = JsonSerializer.Serialize(model);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                // Faça a chamada POST para a API do OpenAI
                var response = await _httpClient.PostAsync(apiUrl, content);

                var result = await response.Content.ReadFromJsonAsync<ResponseGpt>();

                var promptResult = result.choices.FirstOrDefault().text.Replace("\n", "").Replace("\t", ""); */
                newactivity.Score = 50;
                var newUser = _userService.GetById(activity.UserId);
                newUser.Score += newactivity.Score;
                _userService.Update<UserValidator>(newUser);
            }
            catch (Exception ex)
            {
                // Lida com quaisquer erros que possam ocorrer
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }

            if (activity == null)
                return NotFound();

            return Execute(() => _activityService.Add<ActivityValidator>(newactivity).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] ActivityViewModel activity)
        {
            Activity newactivity = new Activity
            {
                Name = activity.Name,
                Description = activity.Description,
                Deadline = activity.Deadline,
                Status = activity.Status,
                Type = activity.Type,
                Score = activity.Score,
                DailyActivity = activity.DailyActivity,
                InclusionDate = DateTime.Now,
                AlterationDate = DateTime.Now,
            };

            if (activity == null)
                return NotFound();

            return Execute(() => _activityService.Update<ActivityValidator>(newactivity));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _activityService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _activityService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _activityService.GetByUserId(id));
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