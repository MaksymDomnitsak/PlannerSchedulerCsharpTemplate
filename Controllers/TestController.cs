using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace PlannerScheduler.Controllers
{
    // Test controller for connecting to Railway platform
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: <TestController>
        [HttpGet]
        public string Get()
        {
            return "Hello to your server!";
        }

        // GET <TestController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var json = await client.GetStringAsync("https://leeon.up.railway.app/api/test");

            return json;
        }

        // POST <TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE /<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
