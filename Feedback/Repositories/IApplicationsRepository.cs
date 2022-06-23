using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IApplicationsRepository
    {
        IEnumerable<Applications> GetAllApplications();
        Applications GetByIdApplications(int id);
        void AddApplications(Applications applications);
        void UpdateApplications(Applications applications);
        void DeleteApplications(int id);
    }
}
