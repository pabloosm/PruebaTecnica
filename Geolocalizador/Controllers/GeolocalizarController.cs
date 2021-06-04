using API_GEO.DB;
using API_GEO.Models;
using API_GEO.Servicios;
using BibliotecaClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_GEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocalizarController : ControllerBase
    {
        private List<Task> _pedidos = new List<Task>();
        //private PedidosDBContext _dBContext;
        private GeodecodificadorApiService _GeodecodificadorApiService;
        private API_DB API_DB;


        public GeolocalizarController(/*PedidosDBContext pedidosDBContext,*/API_DB aPI_DB, IHttpClientFactory httpClient)
        {
            //this._dBContext = pedidosDBContext;
            this._GeodecodificadorApiService = new GeodecodificadorApiService(httpClient);
            this.API_DB = aPI_DB;
        }


        // GET api/<GeolocalizarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get_Async(string sid)
        {
            try
            {
                var ok = long.TryParse(sid , out long lid);
                if ( ok )
                {
                    // busco id en la base
                    //CoordenadasDireccionesModel coordenadasDireccionesModel = await  this._dBContext.COORDENADAS_PEDIDOS.AsNoTracking().FirstOrDefaultAsync(x=>x.id_pedido == lid);
                    //if ( coordenadasDireccionesModel != null )
                    //{

                    //    return StatusCode(StatusCodes.Status200OK , coordenadasDireccionesModel);
                    //}

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
                    var coordenada = new CoordenadasDireccionesModel() { estado = Constantes.PROCESANDO };
                    int res = await this.API_DB.NuevoPedido(pedido , coordenada);

                    //verifico si inserto correctamente en la base el pedido
                    if ( res > 0 )
                    {

                        await Task.Run(()=> _GeodecodificadorApiService.Get_Coordenada_Async(pedido).ContinueWith(x => this.API_DB.Uptdate(x.Result)));

                        return StatusCode(StatusCodes.Status202Accepted , pedido.id);


                    }
                    else
                        return StatusCode(StatusCodes.Status304NotModified);

                }

                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch ( Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //llogueo error
            }
        }


    }
}
