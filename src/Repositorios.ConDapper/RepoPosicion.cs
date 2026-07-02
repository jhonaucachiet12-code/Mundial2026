using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;

public class RepoPosicion : RepoDapper , IRepoPosicion
{
    public RepoPosicion(IDbConnection conexion)
        : base(conexion) {}

    public IEnumerable<Posicion> ObtenerPosiciones ()
    {
        var consulta1 = "select * from Posicion ORDER BY posicion ASC";
        var Posiciones = _conexion.Query<Posicion>(consulta1);
        return Posiciones;
    }
    public Posicion? ObtenerPosicion (byte idPosicion)
    {
        var consulta =  @"SELECT *
                        FROM Posicion
                        WHERE idPosicion = @idPosicion
                        ORDER BY posicion ASC";
        var Posiciones = _conexion.QueryFirstOrDefault<Posicion>(consulta, new { idPosicion = idPosicion });
        return Posiciones;
    }
    public void CrearPosicion(Posicion posicion)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unIdPosicion", direction: ParameterDirection.Output);
        parametros.Add("unaPosicion", posicion.posiciones);
        
        _conexion.Execute("altaPosicion", parametros, commandType: CommandType.StoredProcedure);

        posicion.idPosicion = parametros.Get<byte>("unIdPosicion");
    }
}
