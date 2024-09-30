using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BackCustomerWithRelations.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;
        public string Pais {  get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Telefono { get; set; }
        public DateOnly FechaNacimiento { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
        public bool Active { get; set; }
    }
}
