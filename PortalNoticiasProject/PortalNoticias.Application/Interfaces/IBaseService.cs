using Dapper;
using System.Collections.Generic;

namespace PortalNoticias.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        T BuscarComJoins(string sqlWhere = null, string join = null, params string[] fields);
        T BuscarTodosPorId(int id);
        T BuscarPorQuery(string query);
        IEnumerable<T> BuscarTodosPorQuery(string query = "");
        IEnumerable<T> BuscarTodosPorQueryGerador(string sqlWhere = "");
        int Adicionar(T entidade);
        int Atualizar(int id, T entidade);
        int Excluir(int id);
        void ExecutarComando(string comandoSql);
        void ExecutarComandoDireto(CommandDefinition command);
        long BuscaMaxItem(string campo, string sqlWhere);
    }
}
