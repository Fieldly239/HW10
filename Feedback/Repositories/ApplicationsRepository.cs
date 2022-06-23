using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly FeedbackMgmtContext _feedbackMgmtContext;

        public ApplicationsRepository(FeedbackMgmtContext feedbackMgmtContext)
        {
            _feedbackMgmtContext = feedbackMgmtContext;
        }
        public IEnumerable<Applications> GetAllApplications()
        {
            return _feedbackMgmtContext.Applications.ToList();
        }
        public Applications GetByIdApplications(int id)
        {
            return _feedbackMgmtContext.Applications.Find(id);
        }

        public void AddApplications(Applications applications)
        {
            _feedbackMgmtContext.Applications.Add(applications);
            _feedbackMgmtContext.SaveChanges();
        }
        public void UpdateApplications(Applications applications)
        {
            _feedbackMgmtContext.Entry(applications).State = EntityState.Modified;
            _feedbackMgmtContext.SaveChanges();
        }

        public void DeleteApplications(int id)
        {
            var application = _feedbackMgmtContext.Applications.Find(id);
            _feedbackMgmtContext.Applications.Remove(application);
            _feedbackMgmtContext.SaveChanges();
        }

        

        

        
    }
}
