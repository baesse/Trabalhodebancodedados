using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDBD.Models
{
    public static class Banco
    {


        public static MySqlConnection GetConexao()
        {

            try
            {
                MySqlConnection Conexao = new MySqlConnection("Server=127.0.0.1;Database=teste1;Uid=root;Pwd=75395146;");
                Conexao.Open();
                return Conexao;
            }
            catch (Exception)
            {
                return null;

            }

        }

        public static MySqlCommand GetComando(MySqlConnection Conexao)
        {
            try
            {
                MySqlCommand Comando = Conexao.CreateCommand();
                return Comando;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static MySqlDataReader GetReader(MySqlCommand Comando)
        {
            MySqlDataReader Reader = Comando.ExecuteReader();
            return Reader;

        }
    }
}