using API_GEO.Models;
using System.Threading.Tasks;

namespace API_GEO.Servicios
{
    public interface IGeodecodificadorApiService
    {
        Task Get_Coordenada_Async(PedidoModel pedido);
    }
}