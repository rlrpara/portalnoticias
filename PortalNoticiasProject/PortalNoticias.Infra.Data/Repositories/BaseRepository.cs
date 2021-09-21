using Dommel;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;

namespace PortalNoticias.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IDbConnection conexao;

        public BaseRepository()
        {
            conexao = ConnectionConfiguration.ObterConexao();
        }

        public virtual bool Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
                throw new Exception("Registro não encontrado");

            conexao.Open();
            return conexao.Delete(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            conexao.Open();
            return conexao.GetAll<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            conexao.Open();
            return conexao.Get<TEntity>(id);
        }

        public virtual bool Insert(TEntity entity)
        {
            conexao.Open();
            return conexao.Insert(entity) != null;
        }

        public bool Update(TEntity entity)
        {
            conexao.Open();
            return conexao.Update<TEntity>(entity);
        }
    }
}
