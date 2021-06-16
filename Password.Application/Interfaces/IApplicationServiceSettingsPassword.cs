using Password.Application.Dtos;

namespace Password.Application.Interfaces
{
    public interface IApplicationServiceSettingsPassword
    {
        ResultDto AddSettingsPassword(PasswordSettingsDto passwordSettingsDto);
        string RemovePasswordSettings(PasswordSettingsDto passwordSettingsDto);
        string UpdatePasswordSettings(PasswordSettingsDto passwordSettingsDto);
        PasswordSettingsDto GetSettingsPassword();
    }
}