using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ScoreController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> GetOpenAIResponse([FromBody] Score score)
        {
            try
            {
                // Obtenha uma instância do HttpClient da fábrica

                // Configure a URL e o cabeçalho de autorização
                string apiUrl = "https://api.openai.com/v1/completions";
                string apiKey = "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";
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // Crie um objeto de conteúdo JSON com o prompt fornecido
                var model = new ChatGpt(score.prompt);
                var requestBody = JsonSerializer.Serialize(model);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                // Faça a chamada POST para a API do OpenAI
                var response = await _httpClient.PostAsync(apiUrl, content);

                var result = await response.Content.ReadFromJsonAsync<ResponseGpt>();

                var promptResult = result.choices.FirstOrDefault().text.Replace("\n", "").Replace("\t", "");

                // Retorne a resposta como um objeto JSON ou processa-a de acordo com suas necessidades
                return Ok(promptResult);
            }
            catch (Exception ex)
            {
                // Lida com quaisquer erros que possam ocorrer
                return BadRequest($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
