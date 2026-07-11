namespace Biblioteca;

public class JugadorPartido
{
    public short IdJugador { get; set; }
    public byte IdPartido { get; set; }
    public short? IdReemplazo { get; set; }
    public byte? Ingreso { get; set; }
    public byte? IngresoAdicionado { get; set; }
    public byte? Egreso { get; set; }
    public byte? EgresoAdicionado { get; set; }
    public Jugador Jugador { get; set; }
    public Partido Partido { get; set; }
    public Jugador Reemplazo { get; set; }
    public override string ToString()
        => $"{Jugador?.Apellido} en Partido {IdPartido}";
}