using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessUser
    {
        private readonly RepositoryUser _repository;

        public BusinessUser()
        {
            _repository = new RepositoryUser();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(UserViewModel model)
        {
            try
            {
                var entity = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    CreatedAt = DateTime.Now,
                    LastModified = DateTime.Now,
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
