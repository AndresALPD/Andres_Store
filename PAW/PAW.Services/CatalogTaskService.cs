using APW.Architecture;
using PAW.Architecture.Providers;
using PAW2.Models.ViewModels;

namespace PAW2.Services
{
	public class CatalogTaskService
	{
		private readonly ClientRestProvider _restProvider;
		private const string ApiUrl = "https://localhost:7285/api/CatalogTask";

		public CatalogTaskService()
		{
			_restProvider = new ClientRestProvider();
		}

		public async Task<List<CatalogTaskViewModel>> GetAllAsync()
		{
			var json = await _restProvider.GetAsync(ApiUrl, null);
			return JsonSerializer.DeserializeSimple<List<CatalogTaskViewModel>>(json) ?? new();
		}

		public async Task<CatalogTaskViewModel?> GetByIdAsync(int id)
		{
			var json = await _restProvider.GetAsync(ApiUrl, id.ToString());
			return JsonSerializer.DeserializeSimple<CatalogTaskViewModel>(json);
		}

		public async Task<bool> CreateAsync(CatalogTaskViewModel model)
		{
			var json = JsonSerializer.Serialize(model);
			await _restProvider.PostAsync(ApiUrl, json);
			return true;
		}

		public async Task<bool> UpdateAsync(int id, CatalogTaskViewModel model)
		{
			var json = JsonSerializer.Serialize(model);
			await _restProvider.PutAsync(ApiUrl, id.ToString(), json);
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			await _restProvider.DeleteAsync(ApiUrl, id.ToString());
			return true;
		}
	}
}
