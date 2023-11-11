using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Service.Interfaces;
using NeuroEstimulator.Service.Services;

namespace NeuroEstimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ApiBaseController
    {
        #region Fields
        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly ISessionService _sessionService = null;
        #endregion

        #region Constructor

        public SessionController(IApiContext apiContext, ISessionService sessionService) : base(apiContext)
        {
            _sessionService = sessionService;
        }
        #endregion

        #region Controller Methods

        [HttpGet("{id}")]
        public IActionResult GetSession(Guid id)
        {
            var response = this.ServiceInvoke(_sessionService.GetSessionById, id);
            return response;
        }

        [HttpGet("/patient/{id}")]
        public IActionResult GetSessionsByPatientId(Guid patientId)
        {
            var response = this.ServiceInvoke(_sessionService.GetSessionsByPatientId, patientId);
            return response;
        }

        [HttpPost("CreateSession")]
        public IActionResult CreateSession(CreateSessionPayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.CreateSession, payload);
            return response;
        }

        [HttpPost("Start")]
        public IActionResult StartSession(WristAmplitudePayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.Start, payload);
            return response;
        }

        [HttpPost("Finish")]
        public IActionResult FinishSession(WristAmplitudePayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.Finish, payload);
            return response;
        }

        [HttpGet("Parameters/{id}")]
        public IActionResult GetParameters(Guid id)
        {
            var response = this.ServiceInvoke(_sessionService.GetParameters, id);
            return response;
        }

        [HttpGet("SendUsedParameters")]
        public IActionResult SendUsedParameters(SessionSegmentPayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.AddSessionSegment, payload);
            return response;
        }

        [HttpGet("UploadPhotos")]
        public IActionResult UploadPhotos(SessionPhotoPayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.AddPhoto, payload);
            return response;
        }

        [HttpGet("Photos/{sessionId}")]
        public IActionResult GetPhotos(Guid sessionId)
        {
            var response = this.ServiceInvoke(_sessionService.GetPhotos, sessionId);
            return response;
        }
        #endregion


    }
}
