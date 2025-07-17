using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessUserRole
    {
        private readonly RepositoryUserRole _repository;

        public BusinessUserRole()
        {
            _repository = new RepositoryUserRole();
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(UserRoleViewModel model)
        {
            try
            {
                var entity = new UserRole
                {
                    RoldId = model.RoldId,
                    UserId = model.UserId
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
