using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Project1.Data;


namespace Project1.Tests
{
    public class AdditionTests
    {
        [Fact]
        public void AddCustomerToDBTest()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(databaseName: "AddCustomerToDbTest").Options;
            //Act
            using (var db = new StoreDbContext(options))
            {
                Customer c = new Customer
                {
                    FName = "Test",
                    LName = "Name",
                    Address1 = "123 Cherry",
                    Address2 = "Apt 3",
                    City = "Las Vegas",
                    State = "NV",
                    ZipCode = "66767",
                    Phone = "5557583443",
                    Email = "test@email.com"
                };
                db.AddAsync(c);
                db.SaveChangesAsync();
            }
            //Assert
            using (var context = new StoreDbContext(options))
            {
                Assert.Single(context.Customers);
            }
        }

        [Fact]
        public void AddProductToDBTest()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(databaseName: "AddCustomerToDbTest").Options;
            //Act
            using (var db = new StoreDbContext(options))
            {
                Product p = new Product
                {
                    Name = "Test Product",
                    Description = "Test Description"
                };
                db.AddAsync(p);
                db.SaveChangesAsync();
            }
            using (var context = new StoreDbContext(options))
            {
                Assert.Single(context.Products);
            }
        }
    }
}
