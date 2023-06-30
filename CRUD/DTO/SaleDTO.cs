using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.DTO
{
    public class SaleDTO
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }
    }
}
