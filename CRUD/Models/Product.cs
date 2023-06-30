using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Cost { get; set; }
    }
}
