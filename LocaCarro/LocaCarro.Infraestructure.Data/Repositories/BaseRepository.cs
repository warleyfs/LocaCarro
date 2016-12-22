using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LocaCarro.Infraestructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ILocaCarroDBContext _db;

        public BaseRepository(ILocaCarroDBContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }
    }
}
