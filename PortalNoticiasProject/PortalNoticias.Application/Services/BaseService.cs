﻿using Dapper;
using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;

namespace PortalNoticias.Application.Services
{
    public class BaseService : IBaseService
    {
        public readonly IBaseRepository _baseRepository;
        public BaseService(IBaseRepository repositorio)
        {
            _baseRepository = repositorio;
        }
        public int Adicionar<T>(T entidade) where T : class
        {
            try
            {
                return _baseRepository.Adicionar(entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public int Atualizar<T>(int id, T entidade) where T : class
        {
            try
            {
                return _baseRepository.Atualizar(id, entidade);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public long BuscaMaxItemAsync<T>(string campo, string sqlWhere) where T : class
        {
            try
            {
                return _baseRepository.BuscaMaxItemAsync<T>(campo, sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }

        }
        public T BuscarComJoins<T>(string sqlWhere = null, string join = null, params string[] fields)
        {
            try
            {
                return _baseRepository.BuscarComJoins<T>(sqlWhere, join, fields);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public T BuscarPorQuery<T>(string query)
        {
            try
            {
                return _baseRepository.BuscarPorQuery<T>(query);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public T BuscarTodosPorId<T>(int id) where T : class
        {
            try
            {
                return _baseRepository.BuscarTodosPorId<T>(id);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public IEnumerable<T> BuscarTodosPorQuery<T>(string query = "") where T : class
        {
            try
            {
                return _baseRepository.BuscarTodosPorQuery<T>(query);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public IEnumerable<T> BuscarTodosPorQueryGerador<T>(string sqlWhere = "") where T : class
        {
            try
            {
                return _baseRepository.BuscarTodosPorQueryGerador<T>(sqlWhere);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public int Excluir<T>(int id) where T : class
        {
            try
            {
                return _baseRepository.Excluir<T>(id);
            }
            catch
            {
                return default(dynamic);
            }
        }
        public void ExecutarComando(string comandoSql)
        {
            _baseRepository.ExecutarComando(comandoSql);
        }
        public void ExecutarComandoDireto(CommandDefinition command)
        {
            _baseRepository.ExecutarComandoDireto(command);
        }
    }
}
