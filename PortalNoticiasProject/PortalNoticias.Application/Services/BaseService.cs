using Dapper;
using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace PortalNoticias.Application.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        public readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public int Adicionar(T entidade)
        {
            try
            {
                return _repository.Adicionar(entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public int Atualizar(int id, T entidade)
        {
            try
            {
                return _repository.Atualizar(id, entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public long BuscaMaxItem(string campo, string sqlWhere)
        {
            try
            {
                return _repository.BuscaMaxItem(campo, sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public T BuscarComJoins(string sqlWhere = null, string join = null, params string[] fields)
        {
            try
            {
                return _repository.BuscarComJoins(sqlWhere, join, fields);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public T BuscarPorQuery(string query)
        {
            try
            {
                return _repository.BuscarPorQuery(query);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public T BuscarTodosPorId(int id)
        {
            try
            {
                return _repository.BuscarTodosPorId(id);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public IEnumerable<T> BuscarTodosPorQuery(string query = "")
        {
            try
            {
                return _repository.BuscarTodosPorQuery(query);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public IEnumerable<T> BuscarTodosPorQueryGerador(string sqlWhere = "")
        {
            try
            {
                return _repository.BuscarTodosPorQueryGerador(sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public int Excluir(int id)
        {
            try
            {
                return _repository.Excluir(id);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public void ExecutarComando(string comandoSql)
        {
            _repository.ExecutarComando(comandoSql);
        }

        public void ExecutarComandoDireto(CommandDefinition command)
        {
            _repository.ExecutarComandoDireto(command);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
