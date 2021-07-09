using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PortalNoticias.Infra.Data.Context
{
    public static class GeradorDapper
    {
        #region Métodos Privados
        private static bool EhBrancoNulo(string valor) => string.IsNullOrWhiteSpace(valor.ToString().Trim());
        private static object ObterCamposInsert<T>() where T : class
        {
            var retorno = new StringBuilder();

            foreach (var field in typeof(T).GetProperties())
            {
                var campo = field.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";

                if (field.GetCustomAttribute<KeyAttribute>() == null)
                {
                    if (EhBrancoNulo(retorno.ToString().Trim()) && !EhBrancoNulo(campo))
                        retorno.Append($"{campo}");
                    else if (!EhBrancoNulo(campo.Trim()))
                        retorno.Append($", {campo}");
                }
            }
            return retorno.ToString().Trim();
        }
        private static string ObterCampoSelect<T>() where T : class
        {
            var retorno = new StringBuilder();

            foreach (var field in typeof(T).GetProperties())
            {
                var campo = field.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";
                var alias = field?.Name ?? "";

                if (EhBrancoNulo(retorno.ToString().Trim()) && !EhBrancoNulo(campo))
                    retorno.AppendLine($"{campo} as {alias} ");
                else if (!EhBrancoNulo(campo.Trim()))
                    retorno.AppendLine($"{(campo.Length == 0 ? campo : new string(' ', 5)) + ", " + campo} as {alias} ");
            }
            return retorno.ToString().Trim();
        }
        private static string ObterNomeTabela<T>() where T : class
        {
            dynamic tableattr = typeof(T).GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            return (tableattr != null ? tableattr.Name : "");
        }
        public static DynamicParameters ObterParametros<T>(T entidade)
        {
            var listaParametros = new DynamicParameters();
            foreach (var field in entidade.GetType().GetProperties())
                listaParametros.AddDynamicParams(RetornaListaParametros(field.GetCustomAttribute<ColumnAttribute>(), field.GetValue(entidade), field.Name));

            return listaParametros;
        }

        private static DynamicParameters RetornaListaParametros(ColumnAttribute atributo, object valor, string nome)
        {
            var listaParametros = new DynamicParameters();

            if (!EhBrancoNulo(atributo?.Name ?? "") && (valor != null) && !valor.ToString().Contains("01/01/0001 12:00:00 AM") && !valor.ToString().Equals("0"))
            {
                if (valor is DateTime)
                    listaParametros.Add($"@{nome}", Convert.ToDateTime(valor.ToString()).ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime);

                else if (valor is bool)
                    listaParametros.Add($"@{nome}", Convert.ToBoolean(valor), DbType.Boolean);

                else if (valor is Int32)
                    listaParametros.Add($"@{nome}", Convert.ToInt32(valor), DbType.Int32);

                else if (valor is string)
                    listaParametros.Add($"@{nome}", EhBrancoNulo(valor.ToString()) ? null : valor?.ToString(), DbType.String);
            }
            return listaParametros;
        }

        private static string ObterValoresInsert<T>() where T : class
        {
            var retorno = new StringBuilder();

            foreach (var field in typeof(T).GetProperties())
            {
                var campo = field.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";
                var chave = field?.Name ?? "";

                if (field.GetCustomAttribute<KeyAttribute>() == null)
                {
                    if (EhBrancoNulo(retorno.ToString().Trim()) && !EhBrancoNulo(campo))
                        retorno.Append($"@{chave}");
                    else if (!EhBrancoNulo(campo.Trim()))
                        retorno.Append($", @{chave}");
                }
            }
            return retorno.ToString().Trim();
        }
        private static string ObterSetUpdate<T>(T entidade) where T : class
        {
            var retorno = new StringBuilder();

            foreach (var field in entidade.GetType().GetProperties())
            {
                var campo = field.GetCustomAttribute<ColumnAttribute>()?.Name ?? "";
                var chave = field?.Name ?? "";

                if (field.GetCustomAttribute<KeyAttribute>() == null)
                {
                    if (EhBrancoNulo(retorno.ToString().Trim()) && !EhBrancoNulo(campo))
                        retorno.AppendLine($"   SET {campo} = @{chave}");
                    else if (!EhBrancoNulo(campo.Trim()))
                        retorno.AppendLine($"     , {campo} = @{chave}");
                }
            }
            return retorno.ToString();
        }

        #endregion

        #region Métodos Públicos
        public static string RetornaSelect<T>() where T : class
        {
            var sqlPesquisa = new StringBuilder();

            sqlPesquisa.AppendLine($"SELECT {ObterCampoSelect<T>()}");
            sqlPesquisa.AppendLine($"  FROM {ObterNomeTabela<T>()}");

            return sqlPesquisa.ToString();
        }
        public static string RetornaInsert<T>() where T : class
        {
            var sqlInsert = new StringBuilder();
            sqlInsert.AppendLine($"INSERT INTO {ObterNomeTabela<T>()} ({ObterCamposInsert<T>()})");
            sqlInsert.AppendLine($"            VALUES ({ObterValoresInsert<T>()});");

            return sqlInsert.ToString();
        }
        public static string RetornaUpdate<T>(int id, T entidade) where T : class
        {
            var sqlAtualizar = new StringBuilder();

            sqlAtualizar.AppendLine($"UPDATE {ObterNomeTabela<T>()}");
            sqlAtualizar.AppendLine($"{ObterSetUpdate(entidade)}");
            sqlAtualizar.AppendLine($"{ObterId<T>(id)}");

            return sqlAtualizar.ToString();
        }
        public static string RetornaDelete<T>() where T : class
        {
            var sqlInsert = new StringBuilder();
            sqlInsert.AppendLine($"DELETE FROM {ObterNomeTabela<T>()} ");

            return sqlInsert.ToString();
        }
        public static string ObterId<T>(int id)
        {
            var retorno = new StringBuilder();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                KeyAttribute attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute)) as KeyAttribute;
                if (attribute != null)
                    retorno.AppendLine($" WHERE {property.GetCustomAttribute<ColumnAttribute>()?.Name ?? ""} = {id}");
            }
            return retorno.ToString();
        }
        #endregion
    }
}
