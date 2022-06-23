using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IApplicationsRepository
    {
        IEnumerable<Applications> GetAll();
        Applications GetById(int id);
        int Add(Applications applications);
        int Update(Applications applications);
        int Delete(int id);
    }
}
