using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IApplicationsRepository
    {
        Task<IEnumerable<Applications>> GetAll();
        Task<Applications> GetById(int id);
        Task<int> Add(Applications applications);
        Task<int> Update(Applications applications);
        Task<int> Delete(int id);
    }
}
