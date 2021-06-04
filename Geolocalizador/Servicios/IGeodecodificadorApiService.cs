using API_GEO.Models;
using BibliotecaClases;
using System.Threading.Tasks;

namespace API_GEO.Servicios
{
    public interface IGeodecodificadorApiService
    {
        Task<Request> Get_Coordenada_Async(PedidoModel pedido);
    }
}