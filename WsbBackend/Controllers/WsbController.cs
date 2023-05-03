using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WsbApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WsbApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetExternalData()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            // Replace this URL with the endpoint you want to call
            string apiUrl = $"https://tradestie.com/api/v1/apps/reddit?date={today}";

            // Make the GET request and receive the response
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // Read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Return the response content as a JSON object
            return new JsonResult(responseContent);
        }
    }
}
