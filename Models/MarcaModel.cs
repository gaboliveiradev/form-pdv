using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211074.Models
{
    public class MarcaModel
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string ativo { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("INSERT INTO marcas (marca) VALUES (@marca)", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@marca", marca);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("UPDATE marcas SET marca = @marca WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@marca", marca);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("UPDATE marcas SET ativo = @ativo WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@ativo", ativo);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar() 
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("SELECT * FROM marcas WHERE marca LIKE @marca " +
                    "ORDER BY marca", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@marca", marca + "%");
                Banco.adaptador = new MySqlDataAdapter(Banco.comando);
                Banco.datTabela = new DataTable();
                Banco.adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();
                return Banco.datTabela;
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
