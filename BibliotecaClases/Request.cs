using System;

namespace BibliotecaClases
{
    public class Request : IAdress
    {
        public long idRequest { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string ciudad { get; set; }
        public string codigo_postal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public Coordenadas coordenadas { get; set; }
    }
}
