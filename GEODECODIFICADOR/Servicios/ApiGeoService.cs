using BibliotecaClases;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
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

        public async Task Put_Coordenada_Async(ICoordenadas pedido)
        {
            try
            {
  

                using ( var http = _httpClientFactory.CreateClient("APIGeo") )
                {

                    using ( var request = new HttpRequestMessage(HttpMethod.Put , "api/pedidos") )
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(pedido) , Encoding.UTF8 , "application/json");

                        using ( var resonse = await http.SendAsync(request) )
                        {

                        }
                    }
                }

            }
            catch ( Exception ex )
            {
                //logueo error
            }
        }
    }
}
