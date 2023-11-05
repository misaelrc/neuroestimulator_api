using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Result;
using NeuroEstimulator.Framework.Security.Authorization;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.API.Controllers
{

    public class PatientController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly IPatientService _patientService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor
        /// </summary>

        public PatientController(IApiContext apiContext, IPatientService patientService) : base(apiContext)
        {
            _patientService = patientService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Realiza a autorização (login) de uma conta de usuárioo
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [Route("Create")]
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
        [HttpGet]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult GetAllPatients()
        {
            var response = this.ServiceInvoke(_patientService.GetAllPatients);
            return response;
        }

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

        #endregion
    }
}
