using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;

namespace TestRepoDappper;


public class TestTipoPartido
{
    private IrepoTipoPartido _repo;

    public TestTipoPartido ()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoTipoPartido(conexion);
    }

    [Fact]
    public void TraerTipodePartido ()
    {
        var tipoDPartidos =  _repo.ObtenerTipoPartidos();

        Assert.Contains(tipoDPartidos, p => p.TipoDePartido == "Octavos de final");


        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void crarTipoPartido()
    {
        var crearFinal = new TipoPartido()
        {
            TipoDePartido = "Final"
        };

        var TipoDePartidoNoExiste = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Final");

        
        Assert.Null(TipoDePartidoNoExiste);
        _repo.CrearTipoPartido(crearFinal);

        var obtenerTipoPartido = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Final");
        Assert.NotNull(obtenerTipoPartido);

        Assert.Equal("Final" , crearFinal.TipoDePartido);
        // Given
    
        // When
    
        // Then
    }
}
