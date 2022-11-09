using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211074.Models
{
    public class CategoriaModel
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string ativo { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("INSERT INTO categorias (categoria) VALUES (@categoria)", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("UPDATE categorias SET categoria = @categoria WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("UPDATE categorias SET ativo = @ativo WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@ativo", ativo);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("SELECT * FROM categorias WHERE categoria LIKE @categoria " +
                    "ORDER BY categoria", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@categoria", categoria + "%");
                Banco.adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();
                return Banco.datTabela;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
