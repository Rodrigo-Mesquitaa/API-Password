using System.Linq;
using AutoMapper;
using Password.Application.Dtos;
using Password.Application.Interfaces;
using Password.Application.Resources;
using Password.Domain;
using Password.Domian.Core.Interfaces.Services;

namespace Password.Application
{
    public class ApplicationServicePasswordSettings : IApplicationServiceSettingsPassword
    {
        private readonly IServicePasswordSettings _servicePasswordSettings;
        private readonly IMapper _mapper;

        public ApplicationServicePasswordSettings(IServicePasswordSettings servicePasswordSettings,
            IMapper mapper)
        {
            _servicePasswordSettings = servicePasswordSettings;
            _mapper = mapper;
        }

        public ResultDto AddSettingsPassword(PasswordSettingsDto passwordSettingsDto)
        {
            var resultDto = new ResultDto();

            if (CheckExistsConfiguration())
            {
                resultDto.Text = PasswordSettingsResource.ConfigurationExists;
                resultDto.ConfigurationExists = true;
            }
            else
            {
                var passwordSettings = _mapper.Map<PasswordSettings>(passwordSettingsDto);
                _servicePasswordSettings.Add(passwordSettings);
                resultDto.Text = PasswordSettingsResource.ConfigurationAdd;
                resultDto.ConfigurationExists = false;
            }

            return resultDto;
        }

        public string RemovePasswordSettings(PasswordSettingsDto passwordSettingsDto)
        {
            var passwordSettings = _mapper.Map<PasswordSettings>(passwordSettingsDto);
            _servicePasswordSettings.Remove(passwordSettings);
            return PasswordSettingsResource.ConfigurationRemove;
        }

        public string UpdatePasswordSettings(PasswordSettingsDto passwordSettingsDto)
        {
            var passwordSettings = _mapper.Map<PasswordSettings>(passwordSettingsDto);
            _servicePasswordSettings.Update(passwordSettings);
            return PasswordSettingsResource.ConfigurationUpdate;
        }

        public PasswordSettingsDto GetSettingsPassword()
        {
            var passwordSettings = _servicePasswordSettings.GetAll().FirstOrDefault();
            var passwordSettingsDto = _mapper.Map<PasswordSettingsDto>(passwordSettings);

            return passwordSettingsDto;
        }

        private bool CheckExistsConfiguration()
        {
            var passwordSettingsDto = _servicePasswordSettings.GetAll().FirstOrDefault();
            return passwordSettingsDto is not null;
        }
    }
}