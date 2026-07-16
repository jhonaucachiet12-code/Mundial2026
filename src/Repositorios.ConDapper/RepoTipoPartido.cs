using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoTipoPartido : RepoDapper, IrepoTipoPartido
{
    public RepoTipoPartido(IDbConnection conexion)
        : base(conexion) {}

    public IEnumerable<TipoPartido> ObtenerTipoPartidos()
    {
        var consulta = @"SELECT * FROM TipoPartido ORDER BY TipoDePartido ASC";
        var TipoPartido = _conexion.Query<TipoPartido>(consulta);
        return TipoPartido;
    } 

    public  TipoPartido? ObtenerTipoPartido(short idTipoPartido)
    {
        var consulta =  @"SELECT *
                        FROM TipoPartido
                        WHERE idTipoPartido = @idTipoPartido
                        ORDER BY nombre ASC";
        var TipoPartido = _conexion.QueryFirstOrDefault<TipoPartido>(consulta, new { idTipoPartido = idTipoPartido });
        return TipoPartido;
    }

    public void CrearTipoPartido(TipoPartido tipoPartido)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unIdTipoPartido",tipoPartido.idTipoPartido);
        parametros.Add("unTipoDePartido",tipoPartido.TipoDePartido);

         //Ejecutamos el SP del MySQL
        _conexion.Execute("altaTipoPartido", parametros, commandType: CommandType.StoredProcedure);

        //Recuperamos el parametro marcado como OUT y lo asignamos a nuestro objeto C#
        tipoPartido.idTipoPartido = parametros.Get<byte>("unIdTipoPartido");
    }
}