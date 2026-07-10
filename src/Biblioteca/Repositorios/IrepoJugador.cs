namespace Biblioteca.Repositorios;
public interface IRepoJugador
{
    IEnumerable<Jugador> ObtenerJugadores();
    Jugador? ObtenerJugador(short idJugador);
    public void CrearJugador(Jugador jugador);
}