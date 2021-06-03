using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_GEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocalizarController : ControllerBase
    {
        public GeolocalizarController()
        {

        }

        // GET: api/<GeolocalizarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1" , "value2" };
        }

        // GET api/<GeolocalizarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GeolocalizarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GeolocalizarController>/5
        [HttpPut("{id}")]
        public void Put(int id , [FromBody] string value)
        {
        }

        // DELETE api/<GeolocalizarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
