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

        public async Task Get_Coordenada_Async(PedidoModel pedido)
        {
            try
            {
                var http = _httpClientFactory.CreateClient("GeolocalizadorAPI");

                var request = new HttpRequestMessage(HttpMethod.Get , "Decodificar");
                request.Content = new StringContent( JsonConvert.SerializeObject(pedido), Encoding.UTF8 , "application/json");

                var resonse = await  http.SendAsync(request);

            }
            catch ( Exception ex )
            {
                //logueo error
            }
        }
    }
}
