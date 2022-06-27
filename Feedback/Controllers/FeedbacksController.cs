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
        public async Task<IActionResult> GetAll()
        {
            try
            { 
                var res = await _feedbacksService.GetAll();
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _feedbacksService.GetById(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Feedbacks feedbacks)
        {
            try
            {
                var res = await _feedbacksService.Add(feedbacks);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feedbacks feedbacks)
        {
            try
            { 
                var res = await _feedbacksService.Update(feedbacks);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _feedbacksService.Delete(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    status = 500,
                    message = ex.Message
                });
            }
        }
    }
}
