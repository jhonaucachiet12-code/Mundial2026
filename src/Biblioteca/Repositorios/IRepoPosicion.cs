
namespace Biblioteca.Repositorios;

public interface IRepoPosicion
{
    IEnumerable<Posicion> ObtenerPosiciones();
    Posicion? ObtenerPosicion(byte idPosicion);
    public void CrearPosicion(Posicion posicion); 
}
