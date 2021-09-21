using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;

namespace PortalNoticias.Services.Services
{
    public abstract class BaseService<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        public readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual bool Delete(int id)
        {
            return _baseRepository.Delete(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual bool Insert(TEntity entity)
        {
            return _baseRepository.Insert(entity);
        }

        public virtual bool Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}
