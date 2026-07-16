using Biblioteca.Repositorios;
using MySqlConnector;
using Repositorios.ConDapper;
namespace TestRepoDappper;

public class TestRepoEstadio
{
    private IRepoEstadio _repo;

    public TestRepoEstadio()
    {
        var cadena = "Server=localhost;Database=bd_Mundial26;Uid=5to_agbd;Pwd=Trigg3rs!;";
        var conexion = new MySqlConnection(cadena);
        _repo = new RepoEstadio(conexion);
    }

    [Fact]
    public void TraerEstadios()
    {
        var estadios = _repo.Obtener();

        Assert.Contains(estadios, e => e.Nombre == "Estadio Azteca");
        Assert.Contains(estadios, e => e.Nombre == "Estadio Akron");
    }
}