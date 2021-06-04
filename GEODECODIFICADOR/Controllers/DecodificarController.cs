using BibliotecaClases;
using GEODECODIFICADOR.APIs;
using GEODECODIFICADOR.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GEODECODIFICADOR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DecodificarController : Controller
    {
        private IAPI_OnStreetMaps _streetMaps;
        private ApiGeoService _ApiGeoService;
        private List<Task> _pedidos = new List<Task>();

        public DecodificarController(IAPI_OnStreetMaps  aPI_OnStreet, IHttpClientFactory httpClient)
        {
            this._streetMaps = aPI_OnStreet;
            this._ApiGeoService = new ApiGeoService(httpClient);
        }

        [HttpGet]
        public async Task<IActionResult> Get_Async([FromBody] Request request)
        {
            try
            {
                if ( request != null && IsValidRequest(request) )
                {
                    //this._pedidos.Add(
                    //     await Task.Factory.StartNew(async () =>
                    //    {
                            var task =  await this._streetMaps.GetCoordenadas_Async(request);
                        //    await this._ApiGeoService.Put_Coordenada_Async(task.coordenadas);
                        //},TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent));
                    return StatusCode(StatusCodes.Status202Accepted,task);
                }


                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch ( Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool IsValidRequest(Request request)
        {
            return true;
        }
    }
}
