using Biblioteca.Repositorios;
using Biblioteca.Entidades;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoPais : RepoDapper
{
    public RepoPais(IDbConnection conexion)
        : base(conexion) {}

    public IEnumerable<Pais> ObtenerPaises()
    {
        var consulta = @"SELECT * FROM Pais ORDER BY nombre ASC";
        var paises = _conexion.Query<Pais>(consulta);
        return paises;
    }

    public Pais? ObtenerPais(byte idPais)
    {
        var consulta =  @"SELECT *
                        FROM Pais
                        WHERE idPais = @idPais
                        ORDER BY nombre ASC";
        var pais = _conexion.QueryFirstOrDefault<Pais>(consulta, new { idPais = idPais });
        return pais;
    }
}
