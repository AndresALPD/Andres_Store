using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PAW.Data.Models;

namespace PAW2.Business
{
    public class BusinessUserRole
    {
        private readonly RepositoryUserRole _repository;
        private readonly CatalogDbtask2Context _context;

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
                    Id = model.Id,
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
