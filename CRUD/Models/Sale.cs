using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }
    }
}
