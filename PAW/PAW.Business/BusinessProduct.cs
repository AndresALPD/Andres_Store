using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessProduct
    {
        private readonly RepositoryProduct _repository;

        public BusinessProduct()
        {
            _repository = new RepositoryProduct();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        // Productos cuyo SupplierID no existe
        public async Task<IEnumerable<Product>> GetWithMissingSupplierAsync()
        {
            var products = await _repository.ReadAsync();
            return products.Where(p => p.SupplierId == null);
        }

        // Productos cuyo InventoryID no existe
        public async Task<IEnumerable<Product>> GetWithMissingInventoryAsync()
        {
            var products = await _repository.ReadAsync();
            return products.Where(p => p.InventoryId == null);
        }

        // Producto con mayor rating
        public async Task<Product?> GetTopRatedProductAsync()
        {
            var products = await _repository.ReadAsync();
            return products.OrderByDescending(p => p.Rating).FirstOrDefault();
        }

        // Producto con menor rating
        public async Task<Product?> GetLowestRatedProductAsync()
        {
            var products = await _repository.ReadAsync();
            return products.OrderBy(p => p.Rating).FirstOrDefault();
        }

        // Productos cuyo rating es el que más se repite
        public async Task<IEnumerable<Product>> GetMostCommonRatingProductsAsync()
        {
            var products = await _repository.ReadAsync();
            var mostCommonRating = products
                .GroupBy(p => p.Rating)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()?.Key;

            return products.Where(p => p.Rating == mostCommonRating);
        }

        public async Task<bool> CreateAsync(ProductViewModel model)
        {
            try
            {
                var entity = new Product
                {
                    ProductName = model.ProductName,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    SupplierId = model.SupplierId,
                    InventoryId = model.InventoryId,
                    Rating = model.Rating,
                    LastModified = DateTime.Now,
                    ModifiedBy = model.ModifiedBy
                };

                return await _repository.CreateAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
