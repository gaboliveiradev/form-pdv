using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace _211074.Models
{
    public class MarcaModel
    {
        public int id { get; set; }
        public string marca { get; set; }

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
    }
}
