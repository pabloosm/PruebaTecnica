using BibliotecaClases;
using System.Threading.Tasks;

namespace GEODECODIFICADOR.APIs
{
    public interface IAPI_OnStreetMaps
    {
        Task<Request> GetCoordenadas_Async(Request response);
    }
}