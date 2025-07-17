using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessSupplier
    {
        private readonly RepositorySupplier _repository;

        public BusinessSupplier()
        {
            _repository = new RepositorySupplier();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(SupplierViewModel model)
        {
            try
            {
                var entity = new Supplier
                {
                    SupplierName = model.SupplierName,
                    ContactName = model.ContactName,
                    ContactTitle = model.ContactTitle,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Phone = model.Phone,
                    LastModified = model.LastModified,
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
