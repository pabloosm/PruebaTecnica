using BibliotecaClases;
using Nominatim.API.Models;
using System;

namespace GEODECODIFICADOR.APIs
{
    public class FGRFactory
    {
        public static ForwardGeocodeRequest CreateFowardGeocoderRequest(Request response)
        {
            return new ForwardGeocodeRequest()
            {
                City = response.ciudad,
                Country = response.pais,
                StreetAddress = response.numero,
                PostalCode = response.codigo_postal,
                State = response.provincia,
                

                BreakdownAddressElements = true ,
                ShowExtraTags = true ,
                ShowAlternativeNames = true ,
                ShowGeoJSON = true
            };
        }
    }
}