using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoPartido : RepoDapper, IRepoPartido
{
    public RepoPartido(IDbConnection conexion)
        : base(conexion) {}

    private const string ConsultaBase = @"
        SELECT
            p.*, tp.*, paL.*, paV.*, e.*

        FROM Partido p
        INNER JOIN TipoPartido tp ON p.idTipoPartido = tp.idTipoPartido
        INNER JOIN Pais paL ON p.idLocal = paL.idPais
        INNER JOIN Pais paV ON p.idVisitante = paV.idPais
        INNER JOIN Estadio e ON p.idEstadio = e.idEstadio";

    public IEnumerable<Partido> ObtenerPartidos()
    {
        var consulta = ConsultaBase + " ORDER BY p.fecha DESC";

        var partidos = _conexion.Query<Partido, TipoPartido, Pais, Pais, Estadio, Partido>(
            consulta,
            (partido, tipoPartido, local, visitante, estadio) =>
            {
                partido.TipoPartido = tipoPartido;
                partido.Local = local;
                partido.Visitante = visitante;
                partido.Estadio = estadio;
                return partido;
            },
            splitOn: "idTipoPartido,idPais,idPais,idEstadio"
        );

        return partidos;
    }

    public Partido? ObtenerPartido(byte idPartido)
    {
        var consulta = ConsultaBase + " WHERE p.idPartido = @idPartido";

        var partidos = _conexion.Query<Partido, TipoPartido, Pais, Pais, Estadio, Partido>(
            consulta,
            (partido, tipoPartido, local, visitante, estadio) =>
            {
                partido.TipoPartido = tipoPartido;
                partido.Local = local;
                partido.Visitante = visitante;
                partido.Estadio = estadio;
                return partido;
            },
            new { idPartido = idPartido },
            splitOn: "idTipoPartido,idPais,idPais,idEstadio"
        );

        return partidos.FirstOrDefault();
    }

    public void CrearPartido(Partido partido)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unIdPartido", direction: ParameterDirection.Output);
        parametros.Add("unIdTipoPartido", partido.IdTipoPartido);
        parametros.Add("unIdLocal", partido.IdLocal);
        parametros.Add("unIdVisitante", partido.IdVisitante);
        parametros.Add("unIdEstadio", partido.IdEstadio);
        parametros.Add("unaFecha", partido.Fecha);
        parametros.Add("unosGolesLocales", partido.GolesLocales);
        parametros.Add("unosGolesVisitantes", partido.GolesVisitantes);
        parametros.Add("unaDuracion", partido.Duracion);

        _conexion.Execute("altaPartido", parametros, commandType: CommandType.StoredProcedure);

        partido.IdPartido = parametros.Get<byte>("unIdPartido");
    }
}