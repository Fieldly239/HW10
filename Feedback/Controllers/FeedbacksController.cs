using Feedback.Models;
using Feedback.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbacksService _feedbacksService;

        public FeedbacksController(IFeedbacksService feedbacksService)
        {
            _feedbacksService = feedbacksService;
        }
        [HttpGet]
        public IEnumerable<Feedbacks> GetAllFeedbacks()
        {
            return _feedbacksService.GetAllFeedbacks();
            
        }
        [HttpGet("{id}")]
        public Feedbacks GetByIdFeedbacks(int id)
        {
            return _feedbacksService.GetByIdFeedbacks(id);
        }

        [HttpPost]
        public void AddFeedbacks(Feedbacks feedbacks)
        {
            _feedbacksService.AddFeedbacks(feedbacks);
        }

        [HttpPut("{id}")]
        public void UpdateFeedbacks(int id, Feedbacks feedbacks)
        {
            _feedbacksService.UpdateFeedbacks(feedbacks);
        }
        [HttpDelete("{id}")]
        public void DeleteFeedbacks(int id)
        {
            _feedbacksService.DeleteFeedbacks(id);
        }
    }
}
