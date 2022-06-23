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
        public IEnumerable<Applications> GetAll()
        {
            var applications = _applicationsRepository.GetAll();
            var resp = applications.OrderByDescending(m => m.ApplicationName);
            return resp;
        }
        public Applications GetById(int id)
        {
            return _applicationsRepository.GetById(id);
        }
        public int Add(Applications applications)
        {
            return _applicationsRepository.Add(applications);
        }
        public int Update(Applications applications)
        {
            return _applicationsRepository.Update(applications);
        }
        public int Delete(int id)
        {
            return _applicationsRepository.Delete(id);
        }

        

        

        
    }
}
