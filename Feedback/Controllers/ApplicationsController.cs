using Feedback.Models;
using Feedback.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsService _applicationsService;

        public ApplicationsController(IApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _applicationsService.GetAll();
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
                var res = await _applicationsService.GetById(id);
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
        public async Task<IActionResult> Add(Applications applications)
        {
            try
            {
                var res = await _applicationsService.Add(applications);
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
        public async Task<IActionResult> Update(int id, Applications applications)
        {
            try
            {
                var res = await _applicationsService.Update(applications);
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
                var res = await _applicationsService.Delete(id);
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
