using Feedback.Models;

namespace Feedback.Repositories
{
    public interface IFeedbacksRepository
    {
        IEnumerable<Feedbacks> GetAll();
        Feedbacks GetById(int id);
        int Add(Feedbacks feedbacks);
        int Update(Feedbacks feedbacks);
        int Delete(int id);
    }
}
