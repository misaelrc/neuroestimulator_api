using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Result;
using NeuroEstimulator.Framework.Security.Authorization;
using NeuroEstimulator.Service.Interfaces;
using NeuroEstimulator.Service.Services;

namespace NeuroEstimulator.API.Controllers
{

    public class PatientController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly IPatientService _patientService = null;
        private readonly ISessionService _sessionService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor
        /// </summary>

        public PatientController(IApiContext apiContext, IPatientService patientService, ISessionService sessionService) : base(apiContext)
        {
            _patientService = patientService;
            _sessionService = sessionService;
        }

        #endregion

        #region Controller Methods

        
        // <summary>
        /// Obtém paciente por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult GetPatientById(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.GetPatientById, id);
            return response;
        }

        // <summary>
        /// Obtém parâmetros setados para o paciente
        /// </summary>
        /// <returns></returns>
        [HttpGet("Parameters")]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult GetParameters(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.GetParameters, id);
            return response;
        }

        // <summary>
        /// Setar paramêtros para o paciente
        /// </summary>
        /// <returns></returns>
        [HttpPost("Parameters")]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult SetParameters(SetPatientParametersPayload payload)
        {
            var response = this.ServiceInvoke(_patientService.SetParameters, payload);
            return response;
        }

        [HttpPost("CreateSession")]
        public IActionResult CreateSession([FromForm]PatientCreateSessionPayload payload)
        {
            var response = this.ServiceInvoke(_sessionService.PatientCreateSession, payload);
            return response;
        }

        [HttpGet("GetPatient/{accountId}")]
        public IActionResult GetPatientId(Guid accountId)
        {
            var response = this.ServiceInvoke(_patientService.GetPatientByAccountId, accountId);
            return response;
        }

        [HttpGet("{id}/Sessions")]
        public IActionResult GetSessionsByPatientId(Guid id)
        {
            var response = this.ServiceInvoke(_sessionService.GetSessionsByPatientId, id);
            return response;
        }
        #endregion
    }
}
