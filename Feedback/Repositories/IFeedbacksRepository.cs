using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IFeedbacksRepository
    {
        IEnumerable<Feedbacks> GetAllFeedbacks();
        Feedbacks GetByIdFeedbacks(int id);
        int AddFeedbacks(Feedbacks feedbacks);
        int UpdateFeedbacks(Feedbacks feedbacks);
        int DeleteFeedbacks(int id);
    }
}
