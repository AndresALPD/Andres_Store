using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessCatalogTask
    {
        private readonly RepositoryCatalogTask _repository;

        public BusinessCatalogTask()
        {
            _repository = new RepositoryCatalogTask();
        }

        public async Task<IEnumerable<CatalogTask>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<CatalogTask> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(CatalogTaskViewModel model)
        {
            try
            {
                var entity = new CatalogTask
                {
                    Name = model.Name ?? string.Empty,
                    Description = model.Description ?? string.Empty,
                    TaskId = model.TaskId ?? 0, 
                    Status = model.Status ?? 0,
                    TaskType = model.TaskType,
                    CreatedBy = model.CreatedBy ?? "system",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = model.ModifiedBy ?? "system",
                    ModifiedDate = DateTime.Now
                };

                return await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CatalogTask.CreateAsync: {ex.Message}");
                throw;
            }
        }
    }
}
