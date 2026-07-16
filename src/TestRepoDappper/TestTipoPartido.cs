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
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=5to_agbd;Pwd=Trigg3rs!;";
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

        var PosicionnoExiste = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Defensor");

        
        Assert.Null(crearFinal);
        _repo.CrearTipoPartido(crearFinal);

        var obtenerDefensor = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Defensor");
        Assert.NotNull(crearFinal);

        Assert.Equal("Defensor" , crearFinal.TipoDePartido);
        // Given
    
        // When
    
        // Then
    }
}
