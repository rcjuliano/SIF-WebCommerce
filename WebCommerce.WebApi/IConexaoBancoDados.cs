using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCommerce.WebApi
{
    public interface IConexaoBancoDados
    {
        bool testarConexao();
    }


    public class SqlServer : IConexaoBancoDados
    {
        public bool testarConexao()
        {
            try
            {
                new SqlConnection("conexao").Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class MySql : IConexaoBancoDados
    {
        public bool testarConexao()
        {
            try
            {
                new MySqlConnection("conexao").Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class PostgreSql : IConexaoBancoDados
    {
        public bool testarConexao()
        {
            try
            {
                new PostgreSql("conexao").Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public static class Teste
    {
        public static bool Executar()
        {
            IConexaoBancoDados banco;

            banco = new PostgreSql();

            return banco.testarConexao();
        }
    }
}
