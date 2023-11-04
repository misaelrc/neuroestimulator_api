using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Framework.Controllers;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ApiBaseController
    {
        #region Fields
        #endregion

        #region Constructor
        #endregion

        #region Controller Methods
        #endregion


        public TesteController(IApiContext apiContext) : base(apiContext)
        {
        }

        [HttpGet]
        public IActionResult GetNames()
        {
            var names = new List<string>();
            names.Add("Angeli");
            names.Add("Gabriel");
            names.Add("Misael");
            names.Add("Paulo");
            names.Add("Vitor");
            return Ok(names);
        }
    }
}
