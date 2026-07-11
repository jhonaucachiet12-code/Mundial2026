DROP DATABASE IF EXISTS bd_Mundial26 ;
CREATE DATABASE bd_Mundial26 ;
USE bd_Mundial26 ;

CREATE TABLE Pais (
    idPais TINYINT AUTO_INCREMENT,
    nombre VARCHAR(20) NOT NULL,
    nombreEntrenador VARCHAR(30) NOT NULL,
    grupo CHAR(1) NOT NULL,
    poblacion INT NOT NULL,
    Lenguaje VARCHAR(50) NOT NULL,
    bandera VARCHAR(200) NOT NULL, -- Corrección ortográfica
    himno VARCHAR(200) NOT NULL,
    estadopolítico VARCHAR(200) NOT NULL,
    capital VARCHAR(50) NOT NULL,
    Datocurioso VARCHAR(50) NOT NULL,
    puntosRankingFifa DECIMAL(6,2) NOT NULL DEFAULT 0.00, -- NUEVO: Base para la simulación
    CONSTRAINT PK_Pais PRIMARY KEY (idPais),
    CONSTRAINT UQ_Pais_nombre UNIQUE (nombre)
);

CREATE TABLE Estadio(
    idEstadio TINYINT AUTO_INCREMENT,
    nombre VARCHAR(40),
    infoEstadio VARCHAR(200),
    CONSTRAINT PK_Estadio PRIMARY KEY (idEstadio),
    CONSTRAINT UQ_Estadio_nombre UNIQUE (nombre)
);

CREATE TABLE TipoPartido(
    idTipoPartido TINYINT AUTO_INCREMENT,
    TipoDePartido CHAR(13),
    PRIMARY KEY(idTipoPartido),
    CONSTRAINT UQ_TipoDePartido UNIQUE (TipoDePartido)
);

CREATE TABLE Partido(
    idPartido TINYINT AUTO_INCREMENT,
    idTipoPartido TINYINT NOT NULL,
    idLocal TINYINT NOT NULL,
    idVisitante TINYINT NOT NULL,
    idEstadio TINYINT NOT NULL,
    fecha TIMESTAMP NOT NULL,
    golesLocales TINYINT UNSIGNED NOT NULL DEFAULT 0,
    golesVisitantes TINYINT UNSIGNED NOT NULL DEFAULT 0,
    duracion TINYINT UNSIGNED DEFAULT 90,
    PRIMARY KEY (idPartido),
    CONSTRAINT FK_Partido_TipoPartido FOREIGN KEY (idTipoPartido)
        REFERENCES TipoPartido (idTipoPartido),
    CONSTRAINT FK_Partido_Estadio FOREIGN KEY (idEstadio)
        REFERENCES Estadio (idEstadio),
    CONSTRAINT FK_Partido_Pais_Local FOREIGN KEY (idLocal)
        REFERENCES Pais (idPais),
    CONSTRAINT FK_Partido_Pais_Visitante FOREIGN KEY (idVisitante)
        REFERENCES Pais (idPais)
);

CREATE TABLE Posicion(
    idPosicion TINYINT AUTO_INCREMENT,
    nombrePosicion CHAR(13) NOT NULL,
    CONSTRAINT PK_Posicion PRIMARY KEY (idPosicion),
    CONSTRAINT UQ_Posicion_posicion UNIQUE (nombrePosicion)
);

CREATE TABLE Jugador(
    idJugador SMALLINT PRIMARY KEY AUTO_INCREMENT,
    idPais TINYINT NOT NULL,
    idPosicion TINYINT NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    apellido VARCHAR(27) NOT NULL,
    nacimiento DATE NOT NULL,
    numCamiseta TINYINT UNSIGNED NOT NULL,
    CONSTRAINT FK_Jugador_Pais FOREIGN KEY (idPais)
        REFERENCES Pais (idPais),
    CONSTRAINT FK_Jugador_Posicion  FOREIGN KEY (idPosicion)
        REFERENCES Posicion (idPosicion),
    CONSTRAINT UQ_Jugador_CamisetaPais UNIQUE (idPais, numCamiseta)
);

CREATE TABLE JugadorPartido(
    idJugador SMALLINT,
    idPartido TINYINT,
    idReemplazo SMALLINT NULL,
    ingreso TINYINT UNSIGNED NULL,
    ingresoAdicionado TINYINT UNSIGNED NULL,
    egreso TINYINT UNSIGNED NULL,
    egresoAdicionado TINYINT UNSIGNED NULL,
    CONSTRAINT PK_JugadorPartido PRIMARY KEY (idJugador, idPartido),
    CONSTRAINT FK_JugadorPartido_Partido FOREIGN KEY (idPartido)
        REFERENCES Partido (idPartido),
    CONSTRAINT FK_JugadorPartido_Jugador FOREIGN KEY (idJugador)
        REFERENCES Jugador (idJugador),
    CONSTRAINT FK_JugadorPartido_Reemplazo FOREIGN KEY (idReemplazo)
        REFERENCES Jugador (idJugador),
    CONSTRAINT CHK_JugadorPartido CHECK (
        ((idReemplazo IS NULL) AND (ingreso IS NULL) AND (ingresoAdicionado IS NULL)
        AND (egreso IS NULL) AND (egresoAdicionado is NULL))
        OR (((idReemplazo IS NOT NULL) AND (idReemplazo != idJugador))
            AND ((egreso IS NOT NULL)
                OR  (ingreso IS NOT NULL)
            )
        )
    )
);

-- NUEVA TABLA: Guarda el historial y resultado de las simulaciones hechas por el sistema
CREATE TABLE SimulacionResultado (
    idSimulacion INT AUTO_INCREMENT,
    idPais TINYINT NOT NULL,
    fechaSimulacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    puntosSimulados INT NOT NULL DEFAULT 0, -- Puntos obtenidos en la simulación (ej. 3 por victoria)
    faseAlcanzada VARCHAR(30) NOT NULL,    -- Ej: 'Fase de Grupos', 'Cuartos', 'Campeón'
    posicionFinal TINYINT UNSIGNED,         -- Puesto final simulado (1 al 32 o 48)
    PRIMARY KEY (idSimulacion),
    CONSTRAINT FK_Simulacion_Pais FOREIGN KEY (idPais) 
        REFERENCES Pais (idPais)
);