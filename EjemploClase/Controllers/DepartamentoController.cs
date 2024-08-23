using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjemploClase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private static List<Departamento> ListaDeto = new List<Departamento>();

        private static int idContador = 0;

        // POST api/<PersonaController>
        [HttpPost]
        public List<Departamento> PostDepartamentos(DepartamentoDTO departamentoDto)
        {
            // Se crea un nuevo departamento a partir de DepartamentoDTO
            // Esto lo hago para que no se pueda asignar el Id_Departamento en el metodo POST ya que tiene que ser unico.
            Departamento departamento = new Departamento
            {
                Nombre = departamentoDto.NombreDTO,
                Descripcion = departamentoDto.DescripcionDTO,
                // Se asigna el Id_Departamento automáticamente con un contador
                Id_Departamento = ++idContador
            };

            // El departamento entra a la lista
            ListaDeto.Add(departamento);
            return ListaDeto;
        }

        [HttpGet]
        public IEnumerable<Departamento> GetDepartamentos()
        {
            return ListaDeto;
        }

        [HttpPut("{id}")]
        public IActionResult PutDepartamento(int id, [FromBody] Departamento departamento)
        {
            
            var existDepartamento = ListaDeto.FirstOrDefault(d => d.Id_Departamento == id);

            if (existDepartamento == null) {
                return NotFound($"El departamento con Id_Departamento = {id} no fue encontrado.");
            }

            // Actualizar las propiedades del departamento
            existDepartamento.Nombre = departamento.Nombre;
            existDepartamento.Descripcion = departamento.Descripcion;
            // Actualizar otras propiedades según sea necesario

            // Retornar NoContent para indicar que la actualización fue exitosa
            return NoContent();
        }
    }

}
