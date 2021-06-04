using BibliotecaClases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GEODECODIFICADOR.Servicios
{
    public class ApiGeoService : IApiGeoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiGeoService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task Post_Coordenada_Async(ICoordenadas pedido)
        {
            try
            {
                var http = _httpClientFactory.CreateClient("APIGeo");

                var request = new HttpRequestMessage(HttpMethod.Post , "api/Pedidos");
                request.Content = new StringContent(JsonConvert.SerializeObject(pedido) , Encoding.UTF8 , "application/json");

                var resonse = await http.SendAsync(request);

            }
            catch ( Exception ex )
            {
                //logueo error
            }
        }
    }
}
