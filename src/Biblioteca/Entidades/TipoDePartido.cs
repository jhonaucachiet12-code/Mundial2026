namespace Biblioteca;

public class TipoPartido
{
    public byte idTipoPartido {get;set;}
    public string TipoDePartido {get;set;}
    public override string ToString()
        => $"{idTipoPartido} - {TipoDePartido}";
}