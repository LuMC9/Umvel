using CRUD.Models;

namespace CRUD.Repositories
{
    public class ProductsRepository : GenericRepository<Product> , IProductsRepository
    {
        public ProductsRepository(CRUDDbContext dbContext) : base(dbContext)
        {

        }
    }
}
