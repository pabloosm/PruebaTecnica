namespace BibliotecaClases
{
    public class Coordenadas : ICoordenadas
    {
        public Coordenadas()
        {

        }
        public Coordenadas(string longitud , string latitud)
        {
            this.longitud = longitud;
            this.latitud = latitud;
        }

        public string longitud { get; set; }
        public string latitud { get; set; }
    }
}