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
        public IEnumerable<Applications> GetAllApplications()
        {
            return _applicationsService.GetAllApplications();
        }
        [HttpGet("{id}")]
        public Applications GetByIdApplications(int id)
        {
            return _applicationsService.GetByIdApplications(id);
        }

        [HttpPost]
        public void AddApplications(Applications applications)
        {
            _applicationsService.AddApplications(applications);
        }

        [HttpPut("{id}")]
        public void UpdateApplications(int id, Applications applications)
        {
            _applicationsService.UpdateApplications(applications);
        }
        [HttpDelete("{id}")]
        public void DeleteApplications(int id)
        {
            _applicationsService.DeleteApplications(id);
        }
    }
}
