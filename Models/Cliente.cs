using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackCustomerWithRelations.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Nombre { get; set; }

        [MaxLength(100)]
        public required string Apellido { get; set; }

        [ForeignKey("MstPais")]
        public int IdPais { get; set; }
        
        [ForeignKey("MstCiudad")]
        public int IdCiudad { get; set; }

        [MaxLength(250)]
        public required string Direccion { get; set; }

        [MaxLength(15)]
        public string? Telefono { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        public bool Active { get; set; }

        public string? Status { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual MstPais? MstPais { get; set; }
        public virtual MstCiudad? MstCiudad { get; set; }

    }
}
