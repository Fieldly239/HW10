using Feedback.Models;

namespace Feedback.Services
{
    public interface IApplicationsService
    {
        IEnumerable<Applications> GetAllApplications();
        Applications GetByIdApplications(int id);
        void AddApplications(Applications applications);
        void UpdateApplications(Applications applications);
        void DeleteApplications(int id);
    }
}
