using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_Handson_1.Controllers
{
    [ApiController]
    [Route("[controller]")]     //Path is /values
    public class ValuesController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"value {id}";
        }

        // POST
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return value;
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] string value)
        {
            return $"id: {id} value: {value}";
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok($"Id: {id} deleted successfully.");
        }
    }
}
