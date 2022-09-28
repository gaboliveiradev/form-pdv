using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211074
{
    public class connMySql
    {
        public static MySqlConnection conexao;
        public static MySqlCommand comando;
        public static MySqlDataAdapter adaptador;
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                string server = "localhost";
                string porta = "3307";
                string uid = "root";
                string pwd = "etecjau";

                conexao = new MySqlConnection($"server={server};port={porta};uid={uid};pwd={pwd}");
                conexao.Open();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro - Abrir Conexão [connMySql.cs]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                conexao.Close();
            }catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro - Fechar Conexão [connMySql.cs]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
