using Biblioteca;
using Biblioteca.Entidades;
using MySql.Data.MySqlClient;
using Repositorios.ConDapper;
namespace TestRepoDappper;


public class TestRepoPais
{
    private IRepoPais _repo;

    public TestRepoPais()
    {
        var cadena = "Server=localhost;Database=bd_Mundial22;Uid=5to_agbd;Pwd=Trigg3rs!;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoPais(conexion);
    }
    
    [Fact]
    public void TraerPaises()
    {
        var paises = _repo.ObtenerPaises();

        Assert.Contains(paises, p => p.Nombre == "Argentina");
        Assert.Contains(paises, p => p.Nombre == "Francia");
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
            Himno =  null,
            Bandera = null,
            CamisetaOficial = null,
            Datocurioso = "Exite"

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

