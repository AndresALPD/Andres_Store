using PAW.Models;
using PAW2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW2.Business
{
    public interface IBusinessCatalog
    {
        Task<IEnumerable<Catalog>> GetAllAsync();
        Task<Catalog> GetByIdAsync(int id);
        Task<bool> CreateAsync(CatalogViewModel model);
    }
}
