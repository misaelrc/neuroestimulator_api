using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ApiBaseController
    {
        private readonly ISessionSegmentService _sessionSegmentService;

        public SegmentController(IApiContext apiContext, ISessionSegmentService sessionSegmentService) : base(apiContext)
        {
            _sessionSegmentService = sessionSegmentService;
        }

        [HttpPost("{id}/Emergency")]
        public IActionResult SetEmergency(Guid id)
        {
            var response = this.ServiceInvoke(_sessionSegmentService.SetEmergency, id);
            return response;
        }

        [HttpPost("{id}/SmgDetected")]
        public IActionResult SetSmgDetected(Guid id)
        {
            var response = this.ServiceInvoke(_sessionSegmentService.SetSmgDetected, id);
            return response;
        }
    }
}
