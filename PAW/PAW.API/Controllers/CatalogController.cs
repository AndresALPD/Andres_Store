using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController (IBusinessCatalog businessCatalog): Controller
{
   [HttpGet(Name = "GetCatalog")]
   public async Task<IEnumerable<Catalog>> GetAll()
   {
        return await businessCatalog.GetAllCatalogsAsync();
   }

    /*[HttpGet(Name = "GetCatalogById")]
    public async Task<ActionResult<Catalog>> GetById(int id)
    {
        var catalog = await businessCatalog.GetAllCatalogsAsync(id);
        return catalog;
    }*/

    [HttpGet("{id:int}", Name = "GetCatalogById")]
    public async Task<ActionResult<Catalog>> GetById(int id)
    {
        var catalog = await businessCatalog.GetCatalogAsync(id);
        return catalog;
    }

    [HttpPost]
    public async Task<bool> Save([FromBody] Catalog catalog)
    {
        return await businessCatalog.SaveCatalogAsync(catalog);
    }

    [HttpDelete]
    public async Task<bool> Delete(Catalog catalog)
    {
        return await businessCatalog.DeleteCatalogAsync(catalog);
    }


}