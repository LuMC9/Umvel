using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Concept
    {
        public int ConceptId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Quantity { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

    }
}
