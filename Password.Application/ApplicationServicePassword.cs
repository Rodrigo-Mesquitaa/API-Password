using System;
using System.Text.RegularExpressions;
using Password.Application.Dtos;
using Password.Application.Interfaces;

namespace Password.Application
{
    public class ApplicationServicePassword : IApplicationServicePassword
    {
        private readonly IApplicationServiceSettingsPassword _applicationServiceSettingsPassword;

        public ApplicationServicePassword(IApplicationServiceSettingsPassword applicationServiceSettingsPassword)
        {
            _applicationServiceSettingsPassword = applicationServiceSettingsPassword;
        }

        public bool PasswordValidation(string password)
        {
            var passwordSettingsDto = _applicationServiceSettingsPassword.GetSettingsPassword();
            var regexPassword = new Regex(GetRegex(passwordSettingsDto), RegexOptions.None, TimeSpan.FromMilliseconds(350));
            var match = regexPassword.Match(password);

            return match.Success;
        }

        /// <summary>
        /// Retorna expressào regular de acordo com parametros informados na configuração da senha
        /// </summary>
        /// <param name="passwordSettingsDto"></param>
        /// <returns></returns>
        private static string GetRegex(PasswordSettingsDto passwordSettingsDto)
        {
            var regex = "^(?=^.{" + passwordSettingsDto.MinimumSize.ToString() + "," +
                        passwordSettingsDto.MaximumSize.ToString() + "}$)";

            if (passwordSettingsDto.StrongPasswordRequired)
            {
                if (passwordSettingsDto.SpecialCharacterRequired)
                {
                    regex += @"(?:([A-Za-z0-9!@#$%^&*()-+])";
                    regex += @"(?!.*\1))*$";
                }

            }
            else
            {
                regex = "^.(?:[A-Za-z0-9])*$";
            }

            return regex;
        }
    }
}