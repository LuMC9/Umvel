using CRUD.Models;
using CRUD.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CRUD.Tests.Repositories
{
    public class SalesRepositoryTest
    {
        private readonly DbContextOptions<CRUDDbContext> _dbOptions;

        public SalesRepositoryTest()
        {
            _dbOptions = new DbContextOptionsBuilder<CRUDDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task CreateAsync_AddsEntityToDatabase()
        {
            var fromDate = new DateTime(2023, 1, 1);
            var toDate = new DateTime(2023, 12, 31);

            var sales = new List<Sale>
        {
            new Sale { Date = new DateTime(2023, 2, 2), Customer = new Customer() { Name = "Richard" } },
            new Sale { Date = new DateTime(2023, 5, 5), Customer = new Customer() { Name = "John" } },
            new Sale { Date = new DateTime(2023, 12, 30), Customer = new Customer() { Name = "Paul" } },
            new Sale { Date = new DateTime(2024, 1, 1), Customer = new Customer() { Name = "George" } }, 
        };

            await using (var context = new CRUDDbContext(_dbOptions))
            {
                await context.Sales.AddRangeAsync(sales);
                await context.SaveChangesAsync();

                var repository = new SalesRepository(context);
                var resutSales = await repository.GetByDateRange(fromDate, toDate);

                Assert.Equal(3, resutSales.Count());
            }
        }
    }
}
