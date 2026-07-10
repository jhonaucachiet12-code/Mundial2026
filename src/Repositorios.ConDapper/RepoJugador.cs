using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoJugador : RepoDapper, IRepoJugador
{
    public RepoJugador(IDbConnection conexion)
        : base(conexion) {}

    public IEnumerable<Jugador> ObtenerJugadores()
    {
        var consulta = @"SELECT j.*, pa.*, po.*
                        FROM Jugador j
                        INNER JOIN Pais pa ON j.idPais = pa.idPais
                        INNER JOIN Posicion po ON j.idPosicion = po.idPosicion
                        ORDER BY j.apellido ASC";

        var jugadores = _conexion.Query<Jugador, Pais, Posicion, Jugador>(
            consulta,
            (jugador, pais, posicion) =>
            {
                jugador.Pais = pais;
                jugador.Posicion = posicion;
                return jugador;
            },
            splitOn: "idPais,idPosicion"
        );

        return jugadores;
    }

    public Jugador? ObtenerJugador(short idJugador)
    {
        var consulta = @"SELECT j.*, pa.*, po.*
                        FROM Jugador j
                        INNER JOIN Pais pa ON j.idPais = pa.idPais
                        INNER JOIN Posicion po ON j.idPosicion = po.idPosicion
                        WHERE j.idJugador = @idJugador";

        var jugadores = _conexion.Query<Jugador, Pais, Posicion, Jugador>(
            consulta,
            (jugador, pais, posicion) =>
            {
                jugador.Pais = pais;
                jugador.Posicion = posicion;
                return jugador;
            },
            new { idJugador = idJugador },
            splitOn: "idPais,idPosicion"
        );

        return jugadores.FirstOrDefault();
    }

    public void CrearJugador(Jugador jugador)
    {
        //Creamos la lista de parametros y la asignamos
        var parametros = new DynamicParameters();
        parametros.Add("unIdJugador", direction: ParameterDirection.Output);
        parametros.Add("unIdPais", jugador.IdPais);
        parametros.Add("unIdPosicion", jugador.IdPosicion);
        parametros.Add("unNombre", jugador.Nombre);
        parametros.Add("unApellido", jugador.Apellido);
        parametros.Add("unNacimiento", jugador.Nacimiento);
        parametros.Add("unNumCamiseta", jugador.NumCamiseta);
        parametros.Add("unaAltura", jugador.Altura);
        parametros.Add("unPeso", jugador.Peso);

        //Ejecutamos el SP del MySQL
        _conexion.Execute("altaJugador", parametros, commandType: CommandType.StoredProcedure);

        //Recuperamos el parametro marcado como OUT y lo asignamos a nuestro objeto C#
        jugador.IdJugador = parametros.Get<short>("unIdJugador");
    }
}