using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Password.Application.Dtos;
using Password.Application.Interfaces;

namespace Password.Services_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordSettingsController : Controller
    {
        private readonly IApplicationServiceSettingsPassword _applicationServiceSettingsPassword;
        public PasswordSettingsController(IApplicationServiceSettingsPassword applicationServiceSettingsPassword)
        {
            _applicationServiceSettingsPassword = applicationServiceSettingsPassword;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PasswordSettingsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("GetPasswordSettings")]
        public ActionResult GetPasswordSettings()
        {
            var passwordsSettings = _applicationServiceSettingsPassword.GetSettingsPassword();
            return Ok(passwordsSettings);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PasswordSettingsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("CreatePasswordSettings")]
        public ActionResult CreatePasswordSettings([FromBody] PasswordSettingsDto passwordSettingsDto)
        {
            var result = _applicationServiceSettingsPassword.AddSettingsPassword(passwordSettingsDto);

            if (result.ConfigurationExists)
                return BadRequest(result.Text);

            return Ok(result.Text);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PasswordSettingsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("UpdatePasswordSettings")]
        public ActionResult UpdatePasswordSettings([FromBody] PasswordSettingsDto passwordSettingsDto)
        {
            var result = _applicationServiceSettingsPassword.UpdatePasswordSettings(passwordSettingsDto);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(PasswordSettingsDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [Route("RemovePasswordSettings")]
        public ActionResult RemovePasswordSettings([FromBody] PasswordSettingsDto passwordSettingsDto)
        {
            var result = _applicationServiceSettingsPassword.RemovePasswordSettings(passwordSettingsDto);
            return Ok(result);
        }
    }
}
