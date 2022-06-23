using Feedback.Models;
using Feedback.Repositories;

namespace Feedback.Services
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public ApplicationsService(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }
        public IEnumerable<Applications> GetAllApplications()
        {
            var applications = _applicationsRepository.GetAllApplications();
            var resp = applications.OrderByDescending(m => m.ApplicationName);
            return resp;
        }
        public Applications GetByIdApplications(int id)
        {
            return _applicationsRepository.GetByIdApplications(id);
        }
        public void AddApplications(Applications applications)
        {
            _applicationsRepository.AddApplications(applications);
        }
        public void UpdateApplications(Applications applications)
        {
            _applicationsRepository.UpdateApplications(applications);
        }
        public void DeleteApplications(int id)
        {
            _applicationsRepository.DeleteApplications(id);
        }

        

        

        
    }
}
