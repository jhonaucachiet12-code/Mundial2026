namespace Biblioteca;

public class Jugador
{
    public short IdJugador { get; set; }
    public byte IdPais { get; set; }
    public byte IdPosicion { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime Nacimiento { get; set; }
    public byte NumCamiseta { get; set; }
    public double Altura {get;set;}
    public double Peso {get;set;}
    public Pais Pais {get;set;}
    public Posicion Posicion{get;set;}
    public override string ToString()
        => $"{IdJugador} - {Nombre} {Apellido}";
}