using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OleDb;

namespace GoogleChartTeste
{
    public class ConectaBanco
    {
        public string mensagem;
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=compServer;database=sisalimentos");
        public DataSet listaProdutos()
        {
            MySqlCommand cmd = new MySqlCommand("lista_produtos", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();// tabela virtual
                da.Fill(ds); //passando os valores consultados para o DataSet 
                mensagem = "Dados ok";
                return ds;

            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}