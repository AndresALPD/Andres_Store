using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessComponent
    {
        private readonly RepositoryComponent _repository;

        public BusinessComponent()
        {
            _repository = new RepositoryComponent();
        }

        public async Task<IEnumerable<Component>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Component> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }
        public async Task<bool> CreateAsync(ComponentViewModel model)
        {
            try
            {
                var entity = new Component
                {
                    Name = model.Name,
                    Content = model.Content
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
