-- Inserción de las 4 posiciones principales del fútbol
INSERT INTO posiciones (idposicion, posicion) VALUES
(1, 'Portero'),
(2, 'Defensa'),
(3, 'Centrocampista'),
(4, 'Delantero');

-- Inserción de los 16 estadios del Mundial 2026
INSERT INTO Estadio (idestadio, nombre, descripcion) VALUES
(1, 'Estadio Azteca (Estadio Ciudad de México)', 'Ubicado en la Ciudad de México, México. Un templo histórico del fútbol mundial con capacidad para 80,824 espectadores; albergará el partido inaugural.'),
(2, 'Estadio Akron (Estadio Guadalajara)', 'Ubicado en Zapopan, Jalisco, México. Una de las infraestructuras más modernas del país con capacidad para 45,664 espectadores.'),
(3, 'Estadio BBVA (Estadio Monterrey)', 'Ubicado en Guadalupe, Nuevo León, México. Conocido como el Gigante de Acero, cuenta con capacidad para 51,243 espectadores y vistas espectaculares al Cerro de la Silla.'),
(4, 'BMO Field (Estadio Toronto)', 'Ubicado en Toronto, Canadá. Estadio específico de fútbol que será expandido para recibir a 43,036 espectadores durante la cita mundialista.'),
(5, 'BC Place (Estadio BC Place Vancouver)', 'Ubicado en Vancouver, Canadá. Estadio multipropósito con techo retráctil y capacidad para 52,497 espectadores.'),
(6, 'MetLife Stadium (Estadio Nueva York Nueva Jersey)', 'Ubicado en East Rutherford, Nueva Jersey, Estados Unidos. Cuenta con una imponente capacidad para 80,663 espectadores y será la gran sede de la Final del torneo.'),
(7, 'AT&T Stadium (Estadio Dallas)', 'Ubicado en Arlington, Texas, Estados Unidos. Un coloso tecnológico con techo retráctil y una capacidad de 70,649 espectadores que recibirá la mayor cantidad de partidos del torneo.'),
(8, 'SoFi Stadium (Estadio Los Ángeles)', 'Ubicado en Inglewood, California, Estados Unidos. Una maravilla arquitectónica de reciente construcción con capacidad para 70,492 espectadores.'),
(9, 'Mercedes-Benz Stadium (Estadio Atlanta)', 'Ubicado en Atlanta, Georgia, Estados Unidos. Estadio ultra moderno con techo retráctil geométrico y capacidad para 68,239 espectadores.'),
(10, 'NRG Stadium (Estadio Houston)', 'Ubicado en Houston, Texas, Estados Unidos. Recinto multiusos totalmente climatizado y con techo retráctil, con capacidad para 68,777 espectadores.'),
(11, 'Arrowhead Stadium (Estadio Kansas City)', 'Ubicado en Kansas City, Misuri, Estados Unidos. Famoso por su icónico ambiente ruidoso, cuenta con una capacidad para 69,045 espectadores.'),
(12, 'Hard Rock Stadium (Estadio Miami)', 'Ubicado en Miami Gardens, Florida, Estados Unidos. Estadio multieventos de categoría global con capacidad para 64,478 espectadores; albergará el partido por el tercer puesto.'),
(13, 'Gillette Stadium (Estadio Boston)', 'Ubicado en Foxborough, Massachusetts, Estados Unidos. Histórico recinto deportivo del área de Boston con capacidad para 64,146 espectadores.'),
(14, 'Lincoln Financial Field (Estadio Filadelfia)', 'Ubicado en Filadelfia, Pensilvania, Estados Unidos. Escenario imponente con capacidad para 68,324 espectadores en la costa este norteamericana.'),
(15, 'Levi''s Stadium (Estadio Bahía de San Francisco)', 'Ubicado en Santa Clara, California, Estados Unidos. Uno de los estadios más ecológicos y tecnológicos del mundo, con capacidad para 68,827 espectadores.'),
(16, 'Lumen Field (Estadio Seattle)', 'Ubicado en Seattle, Washington, Estados Unidos. Con una emblemática arquitectura en forma de herradura y capacidad para 66,925 espectadores.');


-- Inserción de las 48 selecciones del Mundial 2026
INSERT INTO paises (idPais, nombre, nombreEntrenador, grupo, idioma, poblacion, capital, Himno, bandera, CamisetaOficial, Datocurioso, puntosRankingFifa) VALUES
(1, 'México', 'Javier Aguirre', 'A', 'Español', 129000000, 'Ciudad de México', ' ', ' ', ' ', 'Primer país en albergar tres Copas del Mundo en la historia.', 1687.48),
(2, 'Sudáfrica', 'Hugo Broos', 'A', 'Zulú, Xhosa, Afrikáans, Inglés', 60000000, 'Pretoria', ' ', ' ', ' ', 'Conocida como la nación del arco iris por su diversidad cultural.', 1410.00),
(3, 'Corea del Sur', 'Hong Myung-bo', 'A', 'Coreano', 51000000, 'Seúl', ' ', ' ', ' ', 'Es la selección asiática con más participaciones históricas en los mundiales.', 1540.00),
(4, 'República Checa', 'Ivan Hašek', 'A', 'Checo', 105000000, 'Praga', ' ', ' ', ' ', 'Es el país con el mayor consumo de cerveza per cápita en el mundo.', 1510.00),

(5, 'Canadá', 'Jesse Marsch', 'B', 'Inglés y Francés', 39000000, 'Ottawa', ' ', ' ', ' ', 'Tiene más lagos que el resto del mundo combinado.', 1496.00),
(6, 'Bosnia y Herzegovina', 'Sergej Barbarez', 'B', 'Bosnio, Croata, Serbio', 3200000, 'Sarajevo', ' ', ' ', ' ', 'Su himno nacional oficial no tiene una letra aprobada por motivos políticos.', 1350.00),
(7, 'Catar', 'Tintín Márquez', 'B', 'Árabe', 2700000, 'Doha', ' ', ' ', ' ', 'Es uno de los países más llanos del mundo, sin elevaciones significativas.', 1441.00),
(8, 'Suiza', 'Murat Yakin', 'B', 'Alemán, Francés, Italiano', 8800000, 'Berna', ' ', ' ', ' ', 'No ha recibido goles en fases eliminatorias en varios torneos gracias a su orden táctico.', 1650.06),

(9, 'Brasil', 'Dorival Júnior', 'C', 'Portugués', 214000000, 'Brasilia', ' ', ' ', ' ', 'Única selección que ha disputado todas las ediciones de la Copa del Mundo.', 1765.86),
(10, 'Marruecos', 'Walid Regragui', 'C', 'Árabe y Bereber', 37000000, 'Rabat', ' ', ' ', ' ', 'Primera selección africana en llegar a una semifinal del mundo (en 2022).', 1755.10),
(11, 'Haití', 'Sébastien Migné', 'C', 'Criollo haitiano y Francés', 11500000, 'Puerto Príncipe', ' ', ' ', ' ', 'Fue la primera república negra independiente en el mundo.', 1220.00),
(12, 'Escocia', 'Steve Clarke', 'C', 'Inglés', 5400000, 'Edimburgo', ' ', ' ', ' ', 'Jugó contra Inglaterra el primer partido internacional oficial de la historia en 1872.', 1435.00),

(13, 'Estados Unidos', 'Mauricio Pochettino', 'D', 'Inglés', 333000000, 'Washington D.C.', ' ', ' ', ' ', 'Albergará la mayor cantidad de partidos en este torneo, incluida la gran final.', 1671.23),
(14, 'Paraguay', 'Gustavo Alfaro', 'D', 'Guaraní y Español', 6700000, 'Asunción', ' ', ' ', ' ', 'La gran mayoría de su población es bilingüe y habla activamente el idioma indígena oficial.', 1430.00),
(15, 'Australia', 'Tony Popovic', 'D', 'Inglés', 26000000, 'Canberra', ' ', ' ', ' ', 'Es la única selección que ha clasificado al mundial desde dos confederaciones distintas (Oceanía y Asia).', 1570.00),
(16, 'Turquía', 'Vincenzo Montella', 'D', 'Turco', 85000000, 'Ankara', ' ', ' ', ' ', 'Estambul es la única ciudad metropolitana construida sobre dos continentes.', 1500.00),

(17, 'Alemania', 'Julian Nagelsmann', 'E', 'Alemán', 84000000, 'Berlín', ' ', ' ', ' ', 'Es uno de los países más exitosos con 4 títulos mundiales y 8 finales disputadas.', 1735.77),
(18, 'Curazao', 'Dick Advocaat', 'E', 'Papiamento, Neerlandés, Inglés', 150000, 'Willemstad', ' ', ' ', ' ', 'Es una pequeña isla del Caribe que debuta en una fase final bajo la dirección de un técnico histórico.', 1150.00),
(19, 'Costa de Marfil', 'Emerse Faé', 'E', 'Francés', 28000000, 'Yamusukro', ' ', ' ', ' ', 'Son apodados Los Elefantes y vigentes gigantes del fútbol africano.', 1425.00),
(20, 'Ecuador', 'Sebastián Beccacece', 'E', 'Español', 18000000, 'Quito', ' ', ' ', ' ', 'Su capital, Quito, es la capital constitucional más alta del mundo.', 1535.00),

(21, 'Países Bajos', 'Ronald Koeman', 'F', 'Neerlandés', 17800000, 'Ámsterdam', ' ', ' ', ' ', 'Conocidos por inventar el concepto del Fútbol Total en los años 70.', 1753.57),
(22, 'Japón', 'Hajime Moriyasu', 'F', 'Japonés', 125000000, 'Tokio', ' ', ' ', ' ', 'Sus aficionados e integrantes son mundialmente famosos por limpiar los camerinos y gradas después de cada juego.', 1661.58),
(23, 'Suecia', 'Jon Dahl Tomasson', 'F', 'Sueco', 10500000, 'Estocolmo', ' ', ' ', ' ', 'El país introdujo el concepto del buffet que hoy se conoce mundialmente como Smörgåsbord.', 1545.00),
(24, 'Túnez', 'Faouzi Benzarti', 'F', 'Árabe', 12000000, 'Túnez', ' ', ' ', ' ', 'Fueron el primer equipo africano en ganar un partido en un Mundial (en 1978).', 1432.00),

(25, 'Bélgica', 'Domenico Tedesco', 'G', 'Neerlandés, Francés, Alemán', 11700000, 'Bruselas', ' ', ' ', ' ', 'Bruselas es considerada la capital de facto de la Unión Europea.', 1742.24),
(26, 'Egipto', 'Hossam Hassan', 'G', 'Árabe', 110000000, 'El Cairo', ' ', ' ', ' ', 'País hogar de una de las civilizaciones más antiguas del planeta y las pirámides de Guiza.', 1515.00),
(27, 'Irán', 'Amir Ghalenoei', 'G', 'Persa', 88000000, 'Teherán', ' ', ' ', ' ', 'Es el hogar histórico de la antigua Persia y de los gatos persas.', 1619.58),
(28, 'Nueva Zelanda', 'Darren Bazeley', 'G', 'Inglés y Maorí', 5100000, 'Wellington', ' ', ' ', ' ', 'Fue el primer país del mundo en otorgar el derecho al voto a las mujeres en 1893.', 1210.00),

(29, 'España', 'Luis de la Fuente', 'H', 'Español', 48000000, 'Madrid', ' ', ' ', ' ', 'Su himno nacional es uno de los pocos en el mundo que no tiene letra oficial.', 1874.71),
(30, 'Cabo Verde', 'Pedro Leitão Brito', 'H', 'Portugués', 590000, 'Praia', ' ', ' ', ' ', 'Es un archipiélago volcánico de diez islas frente a la costa de África Occidental.', 1390.00),
(31, 'Arabia Saudita', 'Roberto Mancini', 'H', 'Árabe', 36000000, 'Riad', ' ', ' ', ' ', 'Es el país más grande del mundo que no cuenta con un solo río permanente.', 1445.00),
(32, 'Uruguay', 'Marcelo Bielsa', 'H', 'Español', 3400000, 'Montevideo', ' ', ' ', ' ', 'Es el país que organizó y ganó la primera Copa Mundial de la historia en 1930.', 1673.07),

(33, 'Francia', 'Didier Deschamps', 'I', 'Francés', 68000000, 'París', ' ', ' ', ' ', 'Es el país más visitado del mundo por turistas internacionales al año.', 1870.70),
(34, 'Senegal', 'Aliou Cissé', 'I', 'Francés y Wolof', 17000000, 'Dakar', ' ', ' ', ' ', 'Su capital dio nombre al famoso e histórico Rally Dakar de motores.', 1684.07),
(35, 'Irak', 'Jesús Casas', 'I', 'Árabe y Kurdo', 44000000, 'Bagdad', ' ', ' ', ' ', 'Su territorio ocupa la región histórica conocida como Mesopotamia, la cuna de la civilización.', 1420.00),
(36, 'Noruega', 'Ståle Solbakken', 'I', 'Noruego', 550000, 'Oslo', ' ', ' ', ' ', 'Es el país que introdujo el sushi de salmón a la cultura de Japón en los años 80.', 1525.00),

(37, 'Argentina', 'Lionel Scaloni', 'J', 'Español', 46000000, 'Buenos Aires', ' ', ' ', ' ', 'Llegó al inicio del torneo ocupando el puesto número 1 del ranking mundial.', 1877.27),
(38, 'Argelia', 'Vladimir Petković', 'J', 'Árabe y Bereber', 45000000, 'Argel', ' ', ' ', ' ', 'Es el país geográficamente más grande de todo el continente africano.', 1505.00),
(39, 'Austria', 'Ralf Rangnick', 'J', 'Alemán', 9000000, 'Viena', ' ', ' ', ' ', 'Viena ha sido elegida múltiples veces como la ciudad con mejor calidad de vida del mundo.', 1560.00),
(40, 'Jordania', 'Jamal Sellami', 'J', 'Árabe', 11000000, 'Amán', ' ', ' ', ' ', 'Hogar de la antigua e icónica ciudad de Petra esculpida en piedra.', 1380.00),

(41, 'Portugal', 'Roberto Martínez', 'K', 'Portugués', 10300000, 'Lisboa', ' ', ' ', ' ', 'Es el mayor productor mundial de corcho natural.', 1767.85),
(42, 'República Democrática del Congo', 'Sébastien Desabre', 'K', 'Francés y Lingala', 99000000, 'Kinshasa', ' ', ' ', ' ', 'Posee la segunda selva tropical continua más grande del mundo tras el Amazonas.', 1412.00),
(43, 'Uzbekistán', 'Srečko Katanec', 'K', 'Uzbeko', 36000000, 'Taskent', ' ', ' ', ' ', 'Es uno de los dos únicos países en el mundo doblemente aislados del mar.', 1365.00),
(44, 'Colombia', 'Néstor Lorenzo', 'K', 'Español', 52000000, 'Bogotá', ' ', ' ', ' ', 'Es el segundo país más biodiverso del planeta y el mayor productor de esmeraldas.', 1698.35),

(45, 'Inglaterra', 'Thomas Tuchel', 'L', 'Inglés', 56000000, 'Londres', ' ', ' ', ' ', 'Es la cuna del fútbol moderno al redactar sus primeras reglas oficiales en 1863.', 1828.02),
(46, 'Croacia', 'Zlatko Dalić', 'L', 'Croata', 3800000, 'Zagreb', ' ', ' ', ' ', 'Se les atribuye la invención y popularización de la corbata moderna.', 1714.87),
(47, 'Ghana', 'Otto Addo', 'L', 'Inglés', 33000000, 'Acra', ' ', ' ', ' ', 'Fue el primer país del África subsahariana en obtener su independencia colonial en 1957.', 1395.00),
(48, 'Panamá', 'Thomas Christiansen', 'L', 'Español', 4400000, 'Ciudad de Panamá', ' ', ' ', ' ', 'Es el único lugar del mundo donde se puede ver el amanecer sobre el Pacífico y el atardecer sobre el Atlántico.', 1485.00);

INSERT INTO TipoPartido (idPartido, tipoPartido) VALUES
(1, 'Fase de grupos'),
(2, 'Dieciseisavos de final'),
(3, 'Octavos de final'),
(4, 'Cuartos de final'),
(5, 'Semifinal'),
(6, 'Partido por el tercer puesto'),
(7, 'Final');