using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackCustomerWithRelations.Models
{
    public class MstCiudad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MstPais")]
        public int IdPais { get; set; }
        [MaxLength(100)]
        public required string Ciudad { get; set; }

        public virtual MstPais MstPais { get; set; }

    }
}
