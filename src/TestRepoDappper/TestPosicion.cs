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
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoPosicion(conexion);
    }

    [Fact]
    public void traerPosicion()
    {
        var paises = _repo.ObtenerPosiciones();

        Assert.Contains(paises, p => p.posiciones == "Defensor");
        Assert.Contains(paises, p => p.posiciones == "Portero");
        // Given
    
        // When
    
        // Then
    }

    [Theory]
    [InlineData("Centrocampista")]
    [InlineData("Delantero")]
    public void creaPosicion(string strPosicion)
    {
        var posicion = new Posicion()
        {
          posiciones = strPosicion  
        };
        var paisNoExiste = _repo.ObtenerPosiciones().
                            FirstOrDefault(p => p.posiciones == strPosicion);

        Assert.Null(paisNoExiste);

        _repo.CrearPosicion(posicion);

        var posicionRepo = _repo.ObtenerPosiciones().
                            FirstOrDefault(p => p.posiciones == strPosicion);
        Assert.NotNull(posicionRepo);
        
        Assert.Equal(strPosicion, posicionRepo.posiciones);

    }
}
