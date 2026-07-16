USE bd_Mundial26 ;

DELIMITER $$
DROP FUNCTION IF EXISTS idJugador $$
CREATE FUNCTION idJugador (pais TINYINT, camiseta TINYINT UNSIGNED)
   RETURNS SMALLINT
   READS SQL DATA
BEGIN
   DECLARE id SMALLINT;


   SELECT  idJugador INTO id
   FROM    Jugador
   WHERE   numCamiseta = camiseta
   AND     idPais = pais
   LIMIT   1;


   RETURN id;
END $$

--alta partido
DROP PROCEDURE IF EXISTS altaPartido $$
CREATE PROCEDURE altaPartido (OUT unIdPartido TINYINT,
                              unIdTipoPartido TINYINT,
                              unIdLocal TINYINT, 
                              unIdVisitante TINYINT, 
                              unIdEstadio TINYINT, 
                              unaFecha TIMESTAMP,   
                              unosGolesLocales TINYINT UNSIGNED, 
                              unosGolesVisitantes TINYINT UNSIGNED, 
                              unaDuracion TINYINT UNSIGNED)
BEGIN
   INSERT INTO Partido (idTipoPartido, idLocal, idVisitante, idEstadio, fecha, golesLocales, golesVisitantes, duracion)
      VALUES      (unIdTipoPartido , unIdLocal , unIdVisitante , unIdEstadio , unaFecha, unosGolesLocales, unosGolesVisitantes, unaDuracion);
   SET unIdPartido = LAST_INSERT_ID();
END $$


DROP VIEW IF EXISTS VistaPartido $$
CREATE VIEW VistaPartido AS
   SELECT   fecha,
            L.nombre as Local, V.nombre as Visitante,
            P.`golesLocales`, P.`golesVisitantes`
   FROM     Pais L
   JOIN     `Partido` P ON  L.`idPais` = P.`idLocal`
   JOIN     Pais V ON  V.`idPais` = P.`idVisitante`
   ORDER BY fecha ASC $$

DROP PROCEDURE IF EXISTS VaciarTablas $$
CREATE PROCEDURE VaciarTablas ()
BEGIN
   SET FOREIGN_KEY_CHECKS = 0;
   TRUNCATE TABLE DefinicionPenal;
   TRUNCATE TABLE Gol; 
   TRUNCATE TABLE JugadorPartido;
   TRUNCATE TABLE Jugador;  
   TRUNCATE TABLE Partido;
   TRUNCATE TABLE Pais;
   TRUNCATE TABLE Posicion;
   TRUNCATE TABLE TipoPartido;
   TRUNCATE TABLE Estadio;
   SET FOREIGN_KEY_CHECKS = 1;
END $$


--alta pais
DELIMITER $$
DROP PROCEDURE if EXISTS altaPais
CREATE PROCEDURE altaPais(OUT unIdPais INT,
                           IN nombrePais VARCHAR(100),
                           IN nombreDt VARCHAR(100),
                           IN unGrupo CHAR(1),
                           IN unLenguaje VARCHAR(50),
                           IN unaPoblacion INT,          
                           IN unaCapital VARCHAR(100),
                           IN unHimno VARCHAR(255),      
                           IN unaBandera VARCHAR(255),   
                           IN unaCamisetaOficial VARCHAR(255),
                           IN UnDatoCurioso TEXT,        
                           IN unosPuntos INT
)
BEGIN
    -- 1. Insertar los datos en la tabla (Asegúrate de que los nombres de las columnas coincidan con tu tabla)
    INSERT INTO Pais (
      nombre, 
      nombreEntrenador, 
      grupo, 
      lenguaje, 
      poblacion, 
      capital, 
      himno, 
      bandera, 
      camisetaOficial, 
      datoCurioso, 
      puntosRankingFifa
    ) 
    VALUES (
      nombrePais, 
      nombreDt, 
      unGrupo, 
      unLenguaje, 
      unaPoblacion, 
      unaCapital, 
      unHimno, 
      unaBandera, 
      unaCamisetaOficial, 
      UnDatoCurioso, 
      unosPuntos
    );

    -- 2. Asignar el ID auto-incremental generado a la variable de salida
    SET unIdPais = LAST_INSERT_ID();
    
END$$

DELIMITER $$
--Alta estadio
DROP PROCEDURE IF EXISTS altaEstadio $$
CREATE PROCEDURE altaEstadio  (OUT unIdEstadio TINYINT, nombreEstadio VARCHAR(40),
                           unaInfo VARCHAR(200))
BEGIN
   INSERT INTO Estadio  (nombre, descripcion)
            VALUES   (nombreEstadio, unaInfo);
   SET unIdEstadio = LAST_INSERT_ID();
END $$



--Alta Jugador
DELIMITER $$
DROP PROCEDURE IF EXISTS altaJugador$$
CREATE PROCEDURE altaJugador(
   IN unIdPais TINYINT,
   IN unIdPosicion TINYINT,
   IN unNombre VARCHAR(20),
   IN unApellido VARCHAR(27),
   IN unNacimiento DATE,
   IN unNumCamiseta TINYINT UNSIGNED,
   IN unaAltura float,
   IN unPeso float,
   OUT unIdJugador SMALLINT
)
BEGIN
   INSERT INTO Jugador (idPais, idPosicion, nombre, apellido, nacimiento, numCamiseta)
   VALUES (unIdPais, unIdPosicion, unNombre, unApellido, unNacimiento, unNumCamiseta);

   SET unIdJugador = LAST_INSERT_ID();
END$$


--alta Posicion
DELIMITER $$
DROP PROCEDURE IF EXISTS  altaPosicion $$
CREATE Procedure altaPosicion( out unIdPosicion TINYINT, in unaPosicion string)
BEGIN

   INSERT into Posicion (posiciones)
   VALUES(unaPosicion);

   SET unIdPosicion = last_insert_id

end $$


--alta Tipo de Partido
DELIMITER $$
DROP PROCEDURE IF EXISTS altaTipoPartido $$
CREATE Procedure altaTipoPartido( out unIdTipoPartido TINYINT, in unTipoDePartido string)

begin

   INSERT INTO TipoPartido(idTipoPartido, TipoDePartido)
   VALUES(unidPais, unTipoDePartido);

   SET unIdTipoPartido = last_insert_id;

end $$

--Alta Jugador Partido
DELIMITER $$
DROP PROCEDURE IF EXISTS  altaJugadorPartido $$
CREATE Procedure altaJugadorPartido (out unIdJugador int, 
in unIdPartido int, 
in unIdReemplazo int, 
in unIngreso int, 
in unIngresoAdicionado int , 
in unEgreso int, 
in unEgresoAdicionado int)

begin

INSERT into JugadorPartido (idJugador, idPartido, idReemplazo, ingreso, ingresoAdicionado, egreso,, egresoAdicionado )
 VALUES(unIdJugador, unIdPartido, unIdReemplazo, unIngreso, unIngresoAdicionado, unEgreso, unEgresoAdicionado);
end $$