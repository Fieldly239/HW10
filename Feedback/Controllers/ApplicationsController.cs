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
        public IEnumerable<Applications> GetAll()
        {
            return _applicationsService.GetAll();
        }
        [HttpGet("{id}")]
        public Applications GetById(int id)
        {
            return _applicationsService.GetById(id);
        }

        [HttpPost]
        public int Add(Applications applications)
        {
            return _applicationsService.Add(applications);
        }

        [HttpPut("{id}")]
        public int Update(int id, Applications applications)
        {
            return _applicationsService.Update(applications);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _applicationsService.Delete(id);
        }
    }
}
