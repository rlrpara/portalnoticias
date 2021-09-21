using PortalNoticias.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PortalNoticias.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Int32 id);
    }
}
