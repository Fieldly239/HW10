using Feedback.Models;

namespace Feedback.Services
{
    public interface IFeedbacksService
    {
        IEnumerable<Feedbacks> GetAll();
        Feedbacks GetById(int id);
        int Add(Feedbacks feedbacks);
        int Update(Feedbacks feedbacks);
        int Delete(int id);
    }
}
