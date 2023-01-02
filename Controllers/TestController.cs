using Microsoft.AspNetCore.Mvc;

namespace PlannerScheduler.Controllers
{
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
        public string Get(int id)
        {
            return "value";
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
