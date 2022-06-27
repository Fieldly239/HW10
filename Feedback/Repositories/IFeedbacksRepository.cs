using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IFeedbacksRepository
    {
        Task<IEnumerable<Feedbacks>> GetAll();
        Task<Feedbacks> GetById(int id);
        Task<int> Add(Feedbacks feedbacks);
        Task<int> Update(Feedbacks feedbacks);
        Task<int> Delete(int id);
    }
}
