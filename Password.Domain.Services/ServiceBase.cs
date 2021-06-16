using Password.Domian.Core.Interfaces.Repositories;
using Password.Domian.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Password.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryPassword;

        public ServiceBase(IRepositoryBase<TEntity> repositoryPassword)
        {
            this._repositoryPassword = repositoryPassword;
        }

        public void Add(TEntity obj)
        {
            _repositoryPassword.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryPassword.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repositoryPassword.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repositoryPassword.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repositoryPassword.Update(obj);
        }
    }
}