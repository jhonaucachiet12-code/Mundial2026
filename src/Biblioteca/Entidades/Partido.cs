namespace Biblioteca;

public class Partido
{
    public byte IdPartido { get; set; }
    public byte IdTipoPartido { get; set; }
    public byte IdLocal { get; set; }
    public byte IdVisitante { get; set; }
    public byte IdEstadio { get; set; }
    public DateTime Fecha { get; set; }
    public byte GolesLocales { get; set; }
    public byte GolesVisitantes { get; set; }
    public byte? Duracion { get; set; }
    public TipoPartido TipoPartido { get; set; }
    public Pais Local { get; set; }
    public Pais Visitante { get; set; }
    public Estadio Estadio { get; set; }
    public override string ToString()
        => $"{IdPartido} - {Local?.Nombre} vs {Visitante?.Nombre}";
}