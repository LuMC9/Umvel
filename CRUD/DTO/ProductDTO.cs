using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DTO
{
    public class ProductDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Cost { get; set; }
    }
}
