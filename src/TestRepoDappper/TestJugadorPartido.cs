using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;
namespace TestRepoDappper;


public class TestRepoJugadorPartido
{
    private IRepoJugadorPartido _repo;

    public TestRepoJugadorPartido()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoJugadorPartido(conexion);
    }

    [Fact]
    public void obternerunjugador()
    {
        var jugadoenpartido = _repo.ObtenerJugadorPartidos();

        Assert.Contains(jugadoenpartido, p => p.IdPartido == 37);
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void creaUnJugadorpart()
    {

        var salida = new JugadorPartido()
        {
          IdJugador = 332,
          IdPartido = 37,
          IdReemplazo = null,
          Ingreso = null,
          IngresoAdicionado = null,
          EgresoAdicionado = null,
          Egreso = null
        };

        var obtenerAlJugador = _repo.ObtenerJugadorPartidos().FirstOrDefault(p => p.IdJugador == 332);

        Assert.Null(obtenerAlJugador);

        _repo.CrearJugadorPartido(salida);

        var jugaDorPartido = _repo.ObtenerJugadorPartidos().FirstOrDefault(p => p.IdJugador == 332);

        Assert.NotNull(salida);
        // Given
    
        // When
    
        // Then
    }
    
}