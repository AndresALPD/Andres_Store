using PAW.Models;
using PAW2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW2.Business
{
    public class CatalogValidationDecorator : IBusinessCatalog
    {
        private readonly IBusinessCatalog _inner;

        public CatalogValidationDecorator(IBusinessCatalog inner)
        {
            _inner = inner;
        }

        public async Task<IEnumerable<Catalog>> GetAllAsync()
        {
            return await _inner.GetAllAsync();
        }

        public async Task<Catalog> GetByIdAsync(int id)
        {
            return await _inner.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(CatalogViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (model.Rating < 0 || model.Rating > 5)
                throw new ArgumentException("La calificación debe estar entre 0 y 5.");

            return await _inner.CreateAsync(model);
        }
    }
}
