using Biblioteca;
using Biblioteca.Repositorios;
using MySql.Data.MySqlClient;
using Repositorios.ConDapper;

namespace TestRepoDappper;

public class TestPartido
{
    private IRepoPartido _repo;

    public TestPartido()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=5to_agbd;Pwd=Trigg3rs!;";
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
          IdLocal = 37,
          IdVisitante = 30,
          IdEstadio =  12,
          Fecha = new DateTime(1993-03-03),
          GolesLocales = 3,
          GolesVisitantes = 2,
          Duracion = 120,   
        };

        

        var partidoNoExiste = _repo.ObtenerPartidos().
                            FirstOrDefault(p => p.IdPartido == 1);

        Assert.Null(partidoNoExiste);

        _repo.CrearPartido(caboVerdeVSArgentina);

        var partidorepo = _repo.ObtenerPartidos().
                            FirstOrDefault(p => p.IdPartido == 1);
        Assert.NotNull(partidorepo);
        // Given

        // When

        // Then
    }
    
}
