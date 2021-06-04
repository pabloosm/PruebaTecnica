using BibliotecaClases;
using System.Threading.Tasks;

namespace GEODECODIFICADOR.Servicios
{
    public interface IApiGeoService
    {
        Task Put_Coordenada_Async(ICoordenadas pedido);
    }
}