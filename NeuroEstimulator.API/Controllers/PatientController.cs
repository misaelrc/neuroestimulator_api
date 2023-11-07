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
        [HttpGet("{id}/Parameters")]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult GetParameters(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.GetPatientById, id);
            return response;
        }

        // <summary>
        /// Setar paramêtros para o paciente
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/Parameters")]
        //[ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult SetParameters(Guid id)
        {
            var response = this.ServiceInvoke(_patientService.GetPatientById, id);
            return response;
        }
        #endregion
    }
}
