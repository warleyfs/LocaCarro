using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LocaCarro.Domain.Services
{
    public class BaseEntityService<TEntity> : IBaseEntityService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseEntityService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }
    }
}
