using BibliotecaClases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.Models
{
    public class CoordenadasDireccionesModel:ICoordenadas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long  id { get; set; }
        [ForeignKey(nameof(PedidoModel))]
        public long id_pedido { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string estado { get; set; }
    }
}
