using API_GEO.DB;
using BibliotecaClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private PedidosDBContext _dBContext;

        public PedidosController(PedidosDBContext dBContext)
        {
            this._dBContext = dBContext;
        }

        [HttpPut]
        public async Task<IActionResult> Put_Async([FromBody] ICoordenadas coordenadas)
        {
            try
            {
                if ( coordenadas != null )
                {
                    var registro = await this._dBContext.COORDENADAS_PEDIDOS.FirstOrDefaultAsync();

                    registro.latitud = coordenadas.latitud;
                    registro.longitud = coordenadas.longitud;
                    registro.estado = Constantes.TERMINADO;

                    var res = await this._dBContext.SaveChangesAsync();

                    if ( res > 0 )
                    {

                        return StatusCode(StatusCodes.Status202Accepted);
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
