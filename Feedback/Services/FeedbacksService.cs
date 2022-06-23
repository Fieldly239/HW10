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
        public IEnumerable<Feedbacks> GetAll()
        {
            var feedbacks = _feedbacksRepository.GetAll();
            var resp = feedbacks.OrderByDescending(m => m.FeedbackName);
            return resp;
        }
        public Feedbacks GetById(int id)
        {
            return _feedbacksRepository.GetById(id);
        }
        public int Add(Feedbacks feedbacks)
        {
            return _feedbacksRepository.Add(feedbacks);
        }
        public int Update(Feedbacks feedbacks)
        {
            return _feedbacksRepository.Update(feedbacks);
        }

        public int Delete(int id)
        {
            return _feedbacksRepository.Delete(id);
        }

        

        

        
    }
}
