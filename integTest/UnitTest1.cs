using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_1.Controllers;
using test_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test_1
{
    [TestClass]
    public class ItemControllerTests
    {
        [TestMethod]
        public async Task Index_ReturnsViewResult_WithListOfItems()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                // Populate the in-memory database with test data
                var items = new List<Item>
                {
                    new Item { Id = 1, Name = "TestItem1", Price = 10.0m },
                    new Item { Id = 2, Name = "TestItem2", Price = 20.0m }
                };
                context.Items.AddRange(items);
                await context.SaveChangesAsync();
            }

            using (var context = new AppDbContext(options))
            {
                // Act
                var controller = new ItemController(context);
                var result = await controller.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result.Model, typeof(List<Item>));
                var model = result.Model as List<Item>;
                Assert.AreEqual(4, model.Count); // Assuming we added 4 items during integration testing
            }
        }

        [TestMethod]
        public async Task Create_ReturnsRedirectToActionResult_AfterAddingItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                // Act
                var controller = new ItemController(context);
                var itemToAdd = new Item { Id = 3, Name = "TestItem", Price = 30.0m };
                var result = await controller.Create(itemToAdd) as RedirectToActionResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.ActionName);          
            }
        }

        [TestMethod]
        public async Task Edit_IncreasesPriceByOne()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var item = new Item { Id = 4, Name = "TestItem", Price = 40.0m };
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }

            using (var context = new AppDbContext(options))
            {
                // Act
                var controller = new ItemController(context);
                var itemToUpdate = new Item { Id = 4, Name = "TestItem", Price = 41.0m }; // Increase price by 1.0
                await controller.Edit(itemToUpdate);

                // Assert
                var updatedItem = await context.Items.FindAsync(4);
                Assert.IsNotNull(updatedItem);
                Assert.AreEqual(41.0m, updatedItem.Price); // Check if the price has increased by 1.0
                
            }
        }

        [TestMethod]
        public async Task Delete_ReturnsRedirectToActionResult_AfterDeletingItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var item = new Item { Id = 1, Name = "TestItem", Price = 10.0m };
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }

            using (var context = new AppDbContext(options))
            {
                // Act
                var controller = new ItemController(context);
                var result = await controller.DeleteConfirmed(1) as RedirectToActionResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.ActionName);
                
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }
    }
}
