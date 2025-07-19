using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW2.Business;
using PAW2.Repositories;
using PAW2.Models;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.BusinessTests;

[TestClass]
public class ProductTests
{
    [TestMethod]
    public async Task ProductBusiness_GetAllAsync_ShouldNotThrow()
    {
        try
        {
            // Arrange
            var repository = new RepositoryProduct();
            var business = new BusinessProduct();

            // Act
            var products = await business.GetAllAsync();

            // Assert
            Assert.IsNotNull(products, "The product list should not be null.");
            Assert.IsInstanceOfType(products, typeof(IEnumerable<Product>));
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
    }

    [TestMethod]
    public async Task ProductBusiness_CreateAsync_ShouldCreateSuccessfully()
    {
        try
        {
            // Arrange
            var business = new BusinessProduct();
            var model = new ProductViewModel
            {
                ProductName = "Test Product",
                Description = "Test Description",
                CategoryId = 1,
                SupplierId = 1,
                InventoryId = 1,
                Rating = 4,
                ModifiedBy = "TestUser"
            };

            // Act
            var result = await business.CreateAsync(model);

            // Assert
            Assert.IsTrue(result, "The product should have been created successfully.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception during product creation: " + ex.Message);
        }
    }

}
