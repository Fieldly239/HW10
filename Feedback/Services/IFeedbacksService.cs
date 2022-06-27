using Feedback.Models;

namespace Feedback.Services
{
    public interface IFeedbacksService
    {
        Task<IEnumerable<Feedbacks>> GetAll();
        Task<Feedbacks> GetById(int id);
        Task<bool> Add(Feedbacks feedbacks);
        Task<bool> Update(Feedbacks feedbacks);
        Task<bool> Delete(int id);
    }
}
