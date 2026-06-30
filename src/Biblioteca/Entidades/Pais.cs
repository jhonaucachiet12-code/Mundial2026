namespace Biblioteca;

public class Pais
{
    public byte IdPais { get; set; }
    public string Nombre { get; set; }
    public string NombreEntrenador { get; set; }
    public char Grupo { get; set; }
    public string Lenguaje {get;set;}
    public uint Poblacion {get;set;}
    public string Capital {get;set;}
    public string Himno {get;set;}
    public string Bandera {get;set;}
    public string CamisetaOficial {get;set;}
    public string Datocurioso {get;set;} 
    public override string ToString()
        => $"{IdPais} - {Nombre}";
}