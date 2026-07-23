using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;

namespace TestRepoDappper;

public class TestPartido
{
    private IRepoPartido _repo;

    public TestPartido()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoPartido(conexion);
    }

    [Fact]
    public void MexvsSudA()
    {

        var partido = _repo.ObtenerPartidos();

        Assert.Contains(partido, P => P.IdPartido == 1);
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void crearPartio()
    {

        var caboVerdeVSArgentina = new Partido()
        {
          IdTipoPartido = 2,
          IdLocal = 3,
          IdVisitante = 4,
          IdEstadio =  2,
          Fecha = new DateTime(2026,06,11),
          GolesLocales = 2,
          GolesVisitantes = 1,
          Duracion = 98,   
        };

        

        var partidoNoExiste = _repo.ObtenerPartidos().
                            FirstOrDefault(p => p.Duracion == 98);

        Assert.Null(partidoNoExiste);

        _repo.CrearPartido(caboVerdeVSArgentina);

        var partidorepo = _repo.ObtenerPartidos().
                            FirstOrDefault(p => p.Duracion == 98);
        Assert.NotNull(partidorepo);
        // Given

        // When

        // Then
    }
    
}
