using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;

namespace TestRepoDappper;

public class TestRepoPosicion
{
    private IRepoPosicion _repo;

    public TestRepoPosicion()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=5to_agbd;Pwd=Trigg3rs!;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoPosicion(conexion);
    }

    [Fact]
    public void traerPosicion()
    {
        var paises = _repo.ObtenerPosiciones();

        Assert.Contains(paises, p => p.posiciones == "Delantero");
        Assert.Contains(paises, p => p.posiciones == "Portero");
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void creaPosicion()
    {
        var Porteros1 = new Posicion()
        {
          posiciones = "Portero"  
        };
        var paisNoExiste = _repo.ObtenerPosiciones().
                            FirstOrDefault(p => p.posiciones == "Portero");

        Assert.Null(paisNoExiste);

        _repo.CrearPosicion(Porteros1);

        var porterorepo = _repo.ObtenerPosiciones().
                            FirstOrDefault(p => p.posiciones == "Portero");
        Assert.NotNull(porterorepo);
        
        // Given
    
        // When
    
        // Then
    }
}
