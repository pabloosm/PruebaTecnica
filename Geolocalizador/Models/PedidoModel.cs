using BibliotecaClases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.Models
{
    public class PedidoModel : IAdress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string ciudad { get; set; }
        public string codigo_postal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }


    }
}
