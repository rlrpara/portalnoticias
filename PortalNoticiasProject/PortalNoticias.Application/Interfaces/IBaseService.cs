using PortalNoticias.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PortalNoticias.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Int32 id);
    }
}
