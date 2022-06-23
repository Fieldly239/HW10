using Feedback.Models;

namespace Feedback.Services
{
    public interface IFeedbacksService
    {
        IEnumerable<Feedbacks> GetAllFeedbacks();
        Feedbacks GetByIdFeedbacks(int id);
        void AddFeedbacks(Feedbacks feedbacks);
        void UpdateFeedbacks(Feedbacks feedbacks);
        void DeleteFeedbacks(int id);
    }
}
