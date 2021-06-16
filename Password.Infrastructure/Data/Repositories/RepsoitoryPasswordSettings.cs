using Password.Domain;
using Password.Domian.Core.Interfaces.Repositories;
using Password.Infrastructure.Data.Context;

namespace Password.Infrastructure.Data.Repositories
{
    public class RepositoryPasswordSettings : RepositoryBase<PasswordSettings>, IRepositoryPasswordSettings
    {
        public RepositoryPasswordSettings(SqlContext sqlContext)
            : base(sqlContext)
        {
        }
    }
}