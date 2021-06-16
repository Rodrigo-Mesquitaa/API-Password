using Password.Domian.Core.Interfaces.Repositories;
using Password.Domian.Core.Interfaces.Services;

namespace Password.Domain.Services
{
    public class ServicePasswordSettings : ServiceBase<PasswordSettings>, IServicePasswordSettings
    {
        public ServicePasswordSettings(IRepositoryPasswordSettings repositoryPasswordSettings)
            : base(repositoryPasswordSettings)
        {
        }
    }
}