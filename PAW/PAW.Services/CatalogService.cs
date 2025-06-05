using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models;
using System.Text.Json;

namespace PAW.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogAsync(int id);
        Task<IEnumerable<Catalog>> GetCatalogsAsync();
    }

    public class CatalogService(IRestProvider restProvider) : ICatalogService
    {
        public async Task<Catalog> GetCatalogAsync(int id)
        {
            var result = await restProvider.GetAsync("https://localhost:7285/Catalog/1", "1");
            var catalog = await JsonProvider.DeserializeAsync<Catalog>(result);
            return catalog;
        }

        public async Task<IEnumerable<Catalog>> GetCatalogsAsync()
        {
            var result = await restProvider.GetAsync("https://localhost:7285/Catalog/1", null);
            var catalogs = await JsonProvider.DeserializeAsync<IEnumerable<Catalog>>(result);
            return catalogs;
        }
    }
}
