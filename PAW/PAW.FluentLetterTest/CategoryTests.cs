using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAW2.Business;
using PAW2.Repositories;
using PAW2.Models;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.BusinessTests;

[TestClass]
public class CategoryTests
{
    [TestMethod]
    public async Task CategoryBusiness_GetAllAsync_ShouldNotThrow()
    {
        try
        {
            // Arrange
            var repository = new RepositoryCategory();
            var business = new BusinessCategory();

            // Act
            var categories = await business.GetAllAsync();

            // Assert
            Assert.IsNotNull(categories, "The category list should not be null.");
            Assert.IsInstanceOfType(categories, typeof(IEnumerable<Category>));
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
    }
    [TestMethod]
    public async Task CategoryBusiness_CreateAsync_ShouldCreateSuccessfully()
    {
        try
        {
            // Arrange
            var business = new BusinessCategory();
            var model = new CategoryViewModel
            {
                CategoryName = "Test Category",
                Description = "Test Description",
                LastModified = DateTime.Now,
                ModifiedBy = "TestUser"
            };

            // Act
            var result = await business.CreateAsync(model);

            // Assert
            Assert.IsTrue(result, "The category should have been created successfully.");
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception during category creation: " + ex.Message);
        }
    }

}
