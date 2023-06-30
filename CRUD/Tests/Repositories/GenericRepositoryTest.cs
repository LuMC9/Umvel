using CRUD.Models;
using CRUD.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CRUD.Tests.Repositories
{
    public class GenericRepositoryTest
    {
        private readonly DbContextOptions<CRUDDbContext> _dbOptions;

        public GenericRepositoryTest()
        {
            _dbOptions = new DbContextOptionsBuilder<CRUDDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task CreateAsync_AddsEntityToDatabase()
        {
            var entity = new Customer()
            {
                Name = "Julio"
            }; 
            using var context = new CRUDDbContext(_dbOptions);
            var repository = new GenericRepository<Customer>(context);

            var createdEntity = await repository.CreateAsync(entity);

            Assert.NotNull(createdEntity);
        }
    }
}
