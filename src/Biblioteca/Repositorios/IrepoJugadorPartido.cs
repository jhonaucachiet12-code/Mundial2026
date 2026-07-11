namespace Biblioteca.Repositorios;
public interface IRepoJugadorPartido
{
    IEnumerable<JugadorPartido> ObtenerJugadorPartidos();
    JugadorPartido? ObtenerJugadorPartido(short idJugador, byte idPartido);
    public void CrearJugadorPartido(JugadorPartido jugadorPartido);
}