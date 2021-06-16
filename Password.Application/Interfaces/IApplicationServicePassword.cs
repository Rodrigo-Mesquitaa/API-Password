namespace Password.Application.Interfaces
{
    public interface IApplicationServicePassword
    {
        bool PasswordValidation(string password);
    }
}