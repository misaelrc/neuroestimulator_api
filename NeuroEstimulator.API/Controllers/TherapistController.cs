using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Result;
using NeuroEstimulator.Service.Interfaces;
using NeuroEstimulator.Service.Services;

namespace NeuroEstimulator.API.Controllers
{
    public class TherapistController : ApiBaseController
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

        public TherapistController(IApiContext apiContext, IPatientService patientService, ISessionService sessionService) : base(apiContext)
        {
            _patientService = patientService;
            _sessionService = sessionService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Creates a Patient
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [Route("CreatePatient")]
        [HttpPost]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult CreatePatient(CreatePatientPayload payload)
        {
            var response = this.ServiceInvoke(_patientService.CreatePatient, payload);
            return response;
        }

        // <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPatients")]
        [ProducesDefaultResponseType(typeof(ApiResponse<List<ListPatientViewModel>>))]
        public IActionResult GetAllPatients()
        {
            var response = this.ServiceInvoke(_patientService.GetAllPatients);
            return response;
        }
        [HttpPut("EditPatient")]
        public IActionResult EditPatient(EditPatientPayload payload)
        {
            var response = this.ServiceInvoke(_patientService.EditPatient, payload);
            return response;
        }


        [HttpDelete("DeletePatient/{id}")]
        public IActionResult DeletePatient(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.DeletePatient, id);

            return response;
        }

        [HttpPatch("AllowPatientSessions/{id}")]
        public IActionResult AllowSessionsPatient(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.AllowSessions, id);

            return response;
        }

        [HttpPatch("DisallowPatientSessions/{id}")]
        public IActionResult DisallowSessionsPatient(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.DisallowSessions, id);

            return response;
        }

        #endregion
    }
}
