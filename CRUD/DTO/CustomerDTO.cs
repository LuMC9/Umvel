using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class CustomerDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
