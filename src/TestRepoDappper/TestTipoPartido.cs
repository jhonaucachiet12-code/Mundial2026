using Biblioteca;
using Biblioteca.Repositorios;
using MySql.Data.MySqlClient;
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
    public void TraerPosicion()
    {
        var tipoDPartidos =  _repo.ObtenerTipoPartidos();

        Assert.Contains(tipoDPartidos, p => p.TipoDePartido == "8tavos de final");


        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void TestName()
    {
        var Defensor = new TipoPartido()
        {
            TipoDePartido = "Defensor"
        };

        var PosicionnoExiste = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Defensor");

        
        Assert.Null(Defensor);
        _repo.CrearTipoPartido(Defensor);

        var obtenerDefensor = _repo.ObtenerTipoPartidos().FirstOrDefault(P => P.TipoDePartido == "Defensor");
        Assert.NotNull(Defensor);

        Assert.Equal("Defensor" , Defensor.TipoDePartido);
        // Given
    
        // When
    
        // Then
    }
}
