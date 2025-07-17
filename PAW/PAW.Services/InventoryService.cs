using APW.Architecture;
using PAW.Architecture.Providers;
using PAW2.Models.ViewModels;

namespace PAW2.Services
{
	public class InventoryService
	{
		private readonly ClientRestProvider _restProvider;
		private const string ApiUrl = "https://localhost:7285/api/Inventory";

		public InventoryService()
		{
			_restProvider = new ClientRestProvider();
		}

		public async Task<List<InventoryViewModel>> GetAllAsync()
		{
			var json = await _restProvider.GetAsync(ApiUrl, null);
			return JsonSerializer.DeserializeSimple<List<InventoryViewModel>>(json) ?? new();
		}

		public async Task<InventoryViewModel?> GetByIdAsync(int id)
		{
			var json = await _restProvider.GetAsync(ApiUrl, id.ToString());
			return JsonSerializer.DeserializeSimple<InventoryViewModel>(json);
		}

		public async Task<bool> CreateAsync(InventoryViewModel model)
		{
			var json = JsonSerializer.Serialize(model);
			await _restProvider.PostAsync(ApiUrl, json);
			return true;
		}

		public async Task<bool> UpdateAsync(int id, InventoryViewModel model)
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
