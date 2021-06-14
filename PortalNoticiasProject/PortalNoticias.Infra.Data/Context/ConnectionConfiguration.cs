using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PortalNoticias.Infra.Data.Context
{
    public static class ConnectionConfiguration
    {
        public static IDbConnection ObterConexao()
        {
            IDbConnection conexao;

            conexao = new MySqlConnection(Environment.GetEnvironmentVariable("CaminhoBanco"));

            Inicia(conexao);

            return conexao;
        }

        private static void Termina(IDbConnection conexao)
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        public static void Inicia(IDbConnection connection)
        {
            Termina(connection);

            if (connection != null && connection.State == ConnectionState.Closed)
                connection.Open();
        }
    }
}
