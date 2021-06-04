using API_GEO.Models;
using BibliotecaClases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API_GEO.Servicios
{


    public class GeodecodificadorApiService : IGeodecodificadorApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GeodecodificadorApiService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<Request> Get_Coordenada_Async(PedidoModel pedido)
        {
            try
            {
                using ( var http = _httpClientFactory.CreateClient("GeolocalizadorAPI") )
                {

                    using ( var request = new HttpRequestMessage(HttpMethod.Get , "Decodificar") )
                    {
                        var req = new Request()
                        {
                            idRequest = pedido.id ,
                            calle = pedido.calle ,
                            ciudad = pedido.ciudad ,
                            codigo_postal = pedido.codigo_postal ,
                            provincia = pedido.provincia ,
                            pais = pedido.pais ,
                            numero = pedido.numero
                        };

                        request.Content = new StringContent(JsonConvert.SerializeObject(req) , Encoding.UTF8 , "application/json");

                        using ( var resonse = await http.SendAsync(request) )
                        {
                            return JsonConvert.DeserializeObject<Request>(await resonse.Content.ReadAsStringAsync());
                        }
                    }
                }

            }
            catch ( Exception ex )
            {
                return null;
                //logueo error
            }
        }
    }
}
