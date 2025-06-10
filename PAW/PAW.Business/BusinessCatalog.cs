using PAW.Models;
using PAW.Repositories;
using PAW.Core.Extensions;

namespace PAW.Business;

public interface IBusinessCatalog
{
    Task<IEnumerable<Catalog>> GetAllCatalogsAsync();
    Task<bool> SaveCatalogAsync(Catalog catalog);
    Task<bool> DeleteCatalogAsync(Catalog catalog);
    Task<Catalog> GetCatalogAsync(int id);
}

public class BusinessCatalog(IRepositoryCatalog reporitoryCatalog) : IBusinessCatalog
{
    public async Task<IEnumerable<Catalog>> GetAllCatalogsAsync()
    {
        // Business Rules
        // Revisar que sea entre las 7am y 7pm
        // Tener permisos para leer en el usuario
        return await reporitoryCatalog.ReadAsync();
    }

    public async Task<bool> SaveCatalogAsync(Catalog catalog)
    {
        var user = "";//Identity
        catalog.AddAudit(user);
        catalog.AddLogging(catalog.Identifier <= 0 ? Models.Enums.LoggingType.Create : Models.Enums.LoggingType.Update);
        var exists = await reporitoryCatalog.ExistsAsync(catalog);
        return await reporitoryCatalog.UpsertAsync(catalog, exists);
    }

    public async Task<bool> DeleteCatalogAsync(Catalog catalog)
    {
        return await reporitoryCatalog.DeleteAsync(catalog);
    }

    public async Task<Catalog> GetCatalogAsync(int id)
    {
        return await reporitoryCatalog.FindAsync(id);
    }
}
