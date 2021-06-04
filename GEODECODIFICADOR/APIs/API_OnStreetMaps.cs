using BibliotecaClases;
using Nominatim.API.Geocoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEODECODIFICADOR.APIs
{
    public class API_OnStreetMaps : IAPI_OnStreetMaps
    {

        public async Task<Request> GetCoordenadas_Async(Request response)
        {
            try
            {
                var fowardGeocoder = new ForwardGeocoder();

                var fgRequest = FGRFactory.CreateFowardGeocoderRequest(response);
                var coordenadas = await fowardGeocoder.Geocode(fgRequest);

                response.coordenadas = new Coordenadas(coordenadas[0].Longitude.ToString() , coordenadas[0].Latitude.ToString());

                return response;


            }
            catch ( Exception ex )
            {

                //logueo error
                return null;

            }
        }
    }
}
