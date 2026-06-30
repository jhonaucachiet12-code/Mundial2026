namespace Biblioteca.Entidades;
public interface IRepoPais
{
    IEnumerable<Pais> ObtenerPaises();
    Pais? ObtenerPais(byte idPais);
    public void CrearPais(Pais pais);
}