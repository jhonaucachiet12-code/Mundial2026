namespace Biblioteca.Repositorios;

public interface IrepoTipoPartido
{
    IEnumerable<TipoPartido> ObtenerTipoPartidos();
    TipoPartido? ObtenerTipoPartido(short idTipoPartido);
    public void CrearTipoPartido(TipoPartido tipoPartido);
}