using Biblioteca;
using Biblioteca.Repositorios;
using Dapper;
using System.Data;

namespace Repositorios.ConDapper;
public class RepoPais : RepoDapper , IRepoPais
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

    public void CrearPais(Pais pais)
    {
        //Creamos la lista de parametros y la asignamos
        var parametros = new DynamicParameters();
        parametros.Add("unIdPais", direction: ParameterDirection.Output);
        parametros.Add("nombrePais", pais.Nombre);
        parametros.Add("nombreDt", pais.NombreEntrenador);
        parametros.Add("unGrupo", pais.Grupo);
        parametros.Add("unLenguaje", pais.Lenguaje);
        parametros.Add("unaPoblacion",pais.Poblacion);
        parametros.Add("unaCapital ", pais.Capital);
        parametros.Add("unHimno", pais.Himno);
        parametros.Add("unaBandera", pais.Bandera);
        parametros.Add("unaCamisetaOficial", pais.CamisetaOficial);
        parametros.Add("UnDatoCurioso", pais.Datocurioso);
        

        //Ejecutamos el SP del MySQL
        _conexion.Execute("altaPais", parametros, commandType: CommandType.StoredProcedure);

        //Recuperamos el parametro marcado como OUT y lo asignamos a nuestro objeto C#
        pais.IdPais = parametros.Get<byte>("unIdPais");
    }
}
// vanderaPtb.Imaje = Pais.vandera 
