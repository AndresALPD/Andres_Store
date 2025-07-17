using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessCategory
    {
        private readonly RepositoryCategory _repository;

        public BusinessCategory()
        {
            _repository = new RepositoryCategory();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllModifiedByNotSystem()
        {
            var categories = await _repository.ReadAsync();
            return categories.Where(c => c.ModifiedBy != null && c.ModifiedBy != "System");
        }

        public async Task<IEnumerable<Category>> GetAllModifiedByAdmin()
        {
            var categories = await _repository.ReadAsync();
            return categories.Where(c => c.ModifiedBy != null && c.ModifiedBy == "Admin");
        }

        public async Task<IEnumerable<Category>> GetAllWithNullLastModifiedAndNotAdmin()
        {
            var categories = await _repository.ReadAsync();
            return categories.Where(c => c.LastModified == null && c.ModifiedBy != "Admin");
        }
        public async Task<bool> CreateAsync(CategoryViewModel model)
        {
            try
            {
                var entity = new Category
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                    LastModified = model.LastModified,
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
