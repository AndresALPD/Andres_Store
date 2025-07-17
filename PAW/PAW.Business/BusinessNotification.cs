using PAW2.Repositories;
using PAW.Models;
using PAW2.Models.ViewModels;

namespace PAW2.Business
{
    public class BusinessNotification
    {
        private readonly RepositoryNotification _repository;

        public BusinessNotification()
        {
            _repository = new RepositoryNotification();
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> CreateAsync(NotificationViewModel model)
        {
            try
            {
                var entity = new Notification
                {
                    Message = model.Message,
                    CreatedAt = DateTime.Now,
                    IsRead = model.IsRead
                };

                return await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
