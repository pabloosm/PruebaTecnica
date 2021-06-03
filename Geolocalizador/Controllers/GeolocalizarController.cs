using API_GEO.DB;
using API_GEO.Models;
using Microsoft.AspNetCore.Http;
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

        private AbstractPedidosDBContext _dBContext;
        private List<Task> _pedidos = new List<Task>();

        public GeolocalizarController(AbstractPedidosDBContext pedidosDBContext)
        {
            this._dBContext = pedidosDBContext;
        }

        // GET: api/<GeolocalizarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1" , "value2" };
        }

        // GET api/<GeolocalizarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get_Async(int id)
        {
            try
            {
                if ( id > 0 )
                {
                    // busco id en la base
                    var res = 0;

                    
                    if ( res > 0 )
                    {
                        // _pedidos.Add(); hago reques al otro servicio

                        //return StatusCode(StatusCodes.Status200OK , );
                    }

                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //llogueo error
            }
        }

        // POST api/<GeolocalizarController>
        [HttpPost]
        public async Task<IActionResult> Post_Async([FromBody] PedidoModel pedido)
        {
            try
            {
                if(pedido != null)
                {
                    var res = 0;
                    
                    //verifico si inserto correctamente en la base el pedido
                    if(res > 0 )
                    {
                        // _pedidos.Add(); hago reques al otro servicio

                        return StatusCode(StatusCodes.Status202Accepted , pedido.id);
                    }

                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //llogueo error
            }
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
