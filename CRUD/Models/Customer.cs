using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
