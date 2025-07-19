using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessCatalog : IBusinessCatalog
    {
        private readonly RepositoryCatalog _repository;

        public BusinessCatalog()
        {
            _repository = new RepositoryCatalog();
        }

        public async Task<IEnumerable<Catalog>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Catalog> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(CatalogViewModel model)
        {
            try
            {
                var entity = new Catalog
                {
                    Identifier = model.Identifier,
                    Name = model.Name,
                    Description = model.Description,
                    Rating = model.Rating,
                    Sku = model.Sku,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate
                };

                return await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
