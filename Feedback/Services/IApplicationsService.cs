using Feedback.Models;

namespace Feedback.Services
{
    public interface IApplicationsService
    {
        IEnumerable<Applications> GetAll();
        Applications GetById(int id);
        int Add(Applications applications);
        int Update(Applications applications);
        int Delete(int id);
    }
}
