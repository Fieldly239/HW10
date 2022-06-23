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
        public IEnumerable<Feedbacks> GetAll()
        {
            return _feedbacksService.GetAll();
            
        }
        [HttpGet("{id}")]
        public Feedbacks GetById(int id)
        {
            return _feedbacksService.GetById(id);
        }

        [HttpPost]
        public int Add(Feedbacks feedbacks)
        {
            return _feedbacksService.Add(feedbacks);
        }

        [HttpPut("{id}")]
        public int Update(int id, Feedbacks feedbacks)
        {
            return _feedbacksService.Update(feedbacks);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _feedbacksService.Delete(id);
        }
    }
}
