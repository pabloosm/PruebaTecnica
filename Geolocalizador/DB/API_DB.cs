using API_GEO.Models;
using BibliotecaClases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.DB
{
    public class API_DB
    {
        PedidosDBContext db;

        public API_DB(PedidosDBContext pedidos)
        {
            this.db = pedidos;
        }
        public async Task<int> NuevoPedido(PedidoModel pedido , CoordenadasDireccionesModel coordenada)
        {
            await this.db.PEDIDOS.AddAsync(pedido);
            var res = await this.db.SaveChangesAsync();
            coordenada.id_pedido = pedido.id;
            await this.db.COORDENADAS_PEDIDOS.AddAsync(coordenada);
            res = await this.db.SaveChangesAsync();
            return res;
        }
        public async Task Uptdate(Request req)
        {
            try
            {
                var coordenadas = req?.coordenadas;
                if ( coordenadas != null )
                {

                        var registro = await db.COORDENADAS_PEDIDOS.FirstOrDefaultAsync(x=>x.id_pedido == req.idRequest);

                        registro.latitud = coordenadas.latitud;
                        registro.longitud = coordenadas.longitud;
                        registro.estado = Constantes.TERMINADO;

                        var res = await db.SaveChangesAsync();

                        if ( res > 0 )
                        {

                            return;
                        }
                        else
                            return;
                    }


                return;

            }
            catch ( Exception ex )
            {
                return;
                //llogueo error
            }
        }
    }
}
