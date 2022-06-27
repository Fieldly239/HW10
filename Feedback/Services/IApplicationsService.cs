using Feedback.Models;

namespace Feedback.Services
{
    public interface IApplicationsService
    {
        Task<IEnumerable<Applications>> GetAll();
        Task<Applications> GetById(int id);
        Task<bool> Add(Applications applications);
        Task<bool> Update(Applications applications);
        Task<bool> Delete(int id);
    }
}
