using NUnit.Framework;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class LoginControllerTests
    {
        [Test]
        public async Task AuthenticateAsyncTestAsync()
        {
            var url = "https://localhost:44339/v1/login";

            using (var client = new HttpClient())
            {
                var username = "brennoharten";
                var password = "senha123";
                var data = new
                {
                    username = username,
                    password = password
                };

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(url, content);

                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            }
        }

        [Test]
        public async Task AuthenticateAsync_InvalidUser_ReturnsNotFound()
        {
            // Arrange
            var invalidUsername = "invaliduser";
            var invalidPassword = "invalidpassword";
            var data = new
            {
                username = invalidUsername,
                password = invalidPassword
            };

            using (var httpClient = new HttpClient())
            {
                var url = "https://localhost:44339/v1/login";
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Act
                var response = await httpClient.PostAsync(url, content);

                // Assert
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}