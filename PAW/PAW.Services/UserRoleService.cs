using APW.Architecture;
using PAW.Architecture.Providers;
using PAW2.Models.ViewModels;

namespace PAW2.Services
{
    public class UserRoleService
    {
        private readonly ClientRestProvider _restProvider;
        private const string ApiUrl = "https://localhost:7285/api/UserRole";

        public UserRoleService()
        {
            _restProvider = new ClientRestProvider();
        }

        public async Task<List<UserRoleViewModel>> GetAllAsync()
        {
            var json = await _restProvider.GetAsync(ApiUrl, null);
            return JsonSerializer.DeserializeSimple<List<UserRoleViewModel>>(json) ?? new();
        }

        public async Task<UserRoleViewModel?> GetByIdAsync(int id)
        {
            var json = await _restProvider.GetAsync(ApiUrl, id.ToString());
            return JsonSerializer.DeserializeSimple<UserRoleViewModel>(json);
        }

        public async Task<bool> CreateAsync(UserRoleViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            await _restProvider.PostAsync(ApiUrl, json);
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UserRoleViewModel model)
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
