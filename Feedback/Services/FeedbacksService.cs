using Feedback.Models;
using Feedback.Repositories;

namespace Feedback.Services
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IFeedbacksRepository _feedbacksRepository;

        public FeedbacksService(IFeedbacksRepository feedbacksRepository)
        {
            _feedbacksRepository = feedbacksRepository;
        }
        public IEnumerable<Feedbacks> GetAllFeedbacks()
        {
            var feedbacks = _feedbacksRepository.GetAllFeedbacks();
            var resp = feedbacks.OrderByDescending(m => m.FeedbackName);
            return resp;
        }
        public Feedbacks GetByIdFeedbacks(int id)
        {
            return _feedbacksRepository.GetByIdFeedbacks(id);
        }
        public void AddFeedbacks(Feedbacks feedbacks)
        {
            _feedbacksRepository.AddFeedbacks(feedbacks);
        }
        public void UpdateFeedbacks(Feedbacks feedbacks)
        {
            _feedbacksRepository.UpdateFeedbacks(feedbacks);
        }

        public void DeleteFeedbacks(int id)
        {
            _feedbacksRepository.DeleteFeedbacks(id);
        }

        

        

        
    }
}
