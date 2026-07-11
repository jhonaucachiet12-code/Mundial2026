using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoJugadorPartido : RepoDapper, IRepoJugadorPartido
{
    public RepoJugadorPartido(IDbConnection conexion)
        : base(conexion) {}

    private const string ConsultaBase = @"
        SELECT jp.*, j.*, r.*
        FROM JugadorPartido jp
        INNER JOIN Jugador j ON jp.idJugador = j.idJugador
        LEFT JOIN Jugador r ON jp.idReemplazo = r.idJugador";

    public IEnumerable<JugadorPartido> ObtenerJugadorPartidos()
    {
        var jugadoresPartido = _conexion.Query<JugadorPartido, Jugador, Jugador, JugadorPartido>(
            ConsultaBase,
            (jugadorPartido, jugador, reemplazo) =>
            {
                jugadorPartido.Jugador = jugador;
                jugadorPartido.Reemplazo = reemplazo;
                return jugadorPartido;
            },
            splitOn: "idJugador,idJugador"
        );

        return jugadoresPartido;
    }

    public JugadorPartido? ObtenerJugadorPartido(short idJugador, byte idPartido)
    {
        var consulta = ConsultaBase + " WHERE jp.idJugador = @idJugador AND jp.idPartido = @idPartido";

        var jugadoresPartido = _conexion.Query<JugadorPartido, Jugador, Jugador, JugadorPartido>(
            consulta,
            (jugadorPartido, jugador, reemplazo) =>
            {
                jugadorPartido.Jugador = jugador;
                jugadorPartido.Reemplazo = reemplazo;
                return jugadorPartido;
            },
            new { idJugador = idJugador, idPartido = idPartido },
            splitOn: "idJugador,idJugador"
        );

        return jugadoresPartido.FirstOrDefault();
    }

    public void CrearJugadorPartido(JugadorPartido jugadorPartido)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unIdJugador", jugadorPartido.IdJugador);
        parametros.Add("unIdPartido", jugadorPartido.IdPartido);
        parametros.Add("unIdReemplazo", jugadorPartido.IdReemplazo);
        parametros.Add("unIngreso", jugadorPartido.Ingreso);
        parametros.Add("unIngresoAdicionado", jugadorPartido.IngresoAdicionado);
        parametros.Add("unEgreso", jugadorPartido.Egreso);
        parametros.Add("unEgresoAdicionado", jugadorPartido.EgresoAdicionado);

        _conexion.Execute("altaJugadorPartido", parametros, commandType: CommandType.StoredProcedure);
    }
}