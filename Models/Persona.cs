namespace Portafolio.Models;
public class Persona 
{
    public string nombre;
    public string edad;
    public string profesion;

    public Persona(string nombre, string edad, string profesion) 
    {
        this.nombre = nombre;
        this.edad = edad;
        this.profesion = profesion;
    }
}