namespace BibliotecaClases
{
    public interface IAdress
    {
        string calle { get; set; }
        string ciudad { get; set; }
        string codigo_postal { get; set; }
        string numero { get; set; }
        string pais { get; set; }
        string provincia { get; set; }
    }
}