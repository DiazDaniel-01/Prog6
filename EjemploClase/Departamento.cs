using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace EjemploClase
{
    public class Departamento
    {
        public int Id_Departamento { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
