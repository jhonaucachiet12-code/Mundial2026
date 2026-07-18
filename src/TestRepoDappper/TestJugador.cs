using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;

namespace TestRepoDappper;

public class TestJugador
{
    private IRepoJugador _repo;

    public TestJugador()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoJugador(conexion);
    }

    [Fact]
    public void traerJugador()
    {

        var jugador = _repo.ObtenerJugadores();

        Assert.Contains(jugador, p =>p.Nombre == "Lionel Andres Messi");
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void crearUnjugador()
    {
        var Dibu = new Jugador()
        {
          IdPais = 30,
          IdPosicion = 1,
          Nombre ="Damián Emiliano",
          Apellido ="Martínez Romero",
          Nacimiento = new DateTime(1992-6-2),
          NumCamiseta = 23
        };

        var obtenerjugador = _repo.ObtenerJugadores().FirstOrDefault(p => p.Nombre == "Damián Emiliano" );

        Assert.Null(obtenerjugador);

        _repo.CrearJugador(Dibu);

        var Partidocreado = _repo.ObtenerJugadores().FirstOrDefault(p => p.Nombre == "Damián Emiliano");

        Assert.NotNull(Partidocreado);
        // Given
    
        // When
    
        // Then
    }

}
