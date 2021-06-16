using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Password.Application.Interfaces;

namespace Password.Services_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : Controller
    {
        private readonly IApplicationServicePassword _applicationServicePassword;

        public PasswordController(IApplicationServicePassword applicationServiceSettingsPassword)
        {
            _applicationServicePassword = applicationServiceSettingsPassword;
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("ValidationPasswordSettings/{password}")]
        public ActionResult ValidationPasswordSettings(string password)
        {
            var passwordIsValidate = _applicationServicePassword.PasswordValidation(password);
            return Ok(passwordIsValidate);
        }
    }
}