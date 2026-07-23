using Biblioteca;
using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;
namespace TestRepoDappper;


public class TestRepoPais
{
    private IRepoPais _repo;

    public TestRepoPais()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=root;Pwd=1001;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoPais(conexion);
    }
    
    [Fact]
    public void TraerPaises()
    {
        var paises = _repo.ObtenerPaises();

        Assert.Contains(paises, p => p.Nombre == "México");
        Assert.Contains(paises, p => p.Nombre == "Sudáfrica");
    }
    [Fact]
    public void CrearBurkinafaso()
    {
        var burkinafaso = new Pais()
        {
            Grupo = 'F',
            Nombre = "Burkinafaso",
            NombreEntrenador = "Caruso Lombardi",
            Lenguaje = "Frances",
            Poblacion = 24100000,
            Capital = "Uagadugú",
            Himno = "himnoargentino",
            Bandera = "vandera",
            CamisetaOficial = "oficial",
            Datocurioso = "Exite",
            puntosRankingFifa = 1200,
            DirecMapa = "mapa"

        };

        var paisNoExiste = _repo.ObtenerPaises().
                            FirstOrDefault(p => p.Nombre == "Burkinafaso");

        Assert.Null(paisNoExiste);

        _repo.CrearPais(burkinafaso);

        var burkinaRepo = _repo.ObtenerPaises().
                            FirstOrDefault(p => p.Nombre == "Burkinafaso");
        Assert.NotNull(burkinaRepo);
        Assert.Equal("Caruso Lombardi", burkinaRepo.NombreEntrenador);
    }
}

