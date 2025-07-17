using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessInventory
    {
        private readonly RepositoryInventory _repository;

        public BusinessInventory()
        {
            _repository = new RepositoryInventory();
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(InventoryViewModel model)
        {
            try
            {
                var entity = new Inventory
                {
                    UnitPrice = model.UnitPrice,
                    DateAdded = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    ModifiedBy = model.ModifiedBy
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
