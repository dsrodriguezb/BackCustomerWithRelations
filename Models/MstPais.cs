using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackCustomerWithRelations.Models
{
    public class MstPais
    {
        [Key]
        public int Id { get; set; }

        
        [MaxLength(100)]
        public required string Pais { get; set; }


    }
}
