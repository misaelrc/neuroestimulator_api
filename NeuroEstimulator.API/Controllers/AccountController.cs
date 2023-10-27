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
    
    public class AccountController : ApiBaseController
    {
        #region Fields

        /// <summary>
        /// Referencia interna ao serviço 
        /// </summary>
        private readonly IAccountService _accountService = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor
        /// </summary>

        public AccountController(IApiContext apiContext, IAccountService accountService) : base(apiContext)
        {
            _accountService = accountService;
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// Realiza a autorização (login) de uma conta de usuárioo
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [Route("Authorization")]
        [HttpPost]
        [ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult Authorization(AuthorizationPayload payload)
        {
            var response = this.ServiceInvoke(_accountService.Authorization, payload);
            return response;
        }

        /// <summary>
        /// Efetua o refresh token de autorização de uma conta de usuário e retorna permissões de acesso de uma aplicação específica
        /// </summary>
        [Route("Authorization/RefreshToken")]
        [Authorize("sub")]
        [HttpGet]
        [ProducesDefaultResponseType(typeof(ApiResponse<AuthorizationViewModel>))]
        public IActionResult RefreshToken()
        {
            var response = this.ServiceInvoke(_accountService.RefreshToken);
            return response;
        }

        /// <summary>
        /// Efetua o refresh token de autorização de uma conta de usuário e retorna permissões de acesso de uma aplicação específica
        /// </summary>
        [Route("Authorization/Encrypt")]
        [HttpPost]
        [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
        public IActionResult Encrypt([FromBody]string pass)
        {
            var response = this.ServiceInvoke(_accountService.Encrypt,pass);
            return response;
        }
        #endregion
    }
}
