namespace Biblioteca.Repositorios;
public interface IRepoPartido
{
    IEnumerable<Partido> ObtenerPartidos();
    Partido? ObtenerPartido(byte idPartido);
    public void CrearPartido(Partido partido);
}