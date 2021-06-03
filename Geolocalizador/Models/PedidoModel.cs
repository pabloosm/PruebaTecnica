using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.Models
{
    public class PedidoModel
    {
        public long id { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public string ciudad { get; set; }
        public int codigo_postal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }

    }
}
