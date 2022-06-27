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
        public async Task<IEnumerable<Feedbacks>> GetAll()
        {
            var feedbacks = await _feedbacksRepository.GetAll();
            var resp = feedbacks.OrderByDescending(m => m.FeedbackName);
            return resp;
        }
        public async Task<Feedbacks> GetById(int id)
        {
            return await _feedbacksRepository.GetById(id);
        }
        public async Task<bool> Add(Feedbacks feedbacks)
        {
            //validate dupicate
            var feedbackList = await _feedbacksRepository.GetAll();
            var isDuplicate = feedbackList.Where(m => m.FeedbackName == feedbacks.FeedbackName);
            if(isDuplicate.Count() > 0)
            {
                throw new Exception("Error! Feedbacks is duplicate");
            }
            return await _feedbacksRepository.Add(feedbacks) > 0;
        }
        public async Task<bool> Update(Feedbacks feedbacks)
        {
            var feedbackList = await _feedbacksRepository.GetAll();
            var isDuplicate = feedbackList.Where(m => m.FeedbackName == feedbacks.FeedbackName && m.Id != feedbacks.Id);
            if (isDuplicate.Count() > 0)
            {
                throw new Exception("Error! Feedbacks is duplicate");
            }
            return await _feedbacksRepository.Update(feedbacks) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var feedback = await _feedbacksRepository.GetById(id);
            if (feedback == null)
            {
                throw new Exception("Error! Feedback not exist");
            }
            return await _feedbacksRepository.Delete(id) > 0;
        }

        

        

        
    }
}
