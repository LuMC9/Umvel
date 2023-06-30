using CRUD.Models;

namespace CRUD.DTO
{
    public class SaleResponseDTO
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }

        public decimal Total { get; set; }
    }
}
