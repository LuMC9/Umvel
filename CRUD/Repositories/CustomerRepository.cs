using CRUD.Models;

namespace CRUD.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CRUDDbContext dbContext) : base(dbContext)
        {

        }
    }
}
