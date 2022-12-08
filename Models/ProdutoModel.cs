using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211074.Models
{
    public class ProdutoModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public int id_categoria { get; set; }
        public int id_marca { get; set; }
        public int estoque { get; set; }
        public double valor_compra { get; set; }
        public double valor_venda { get; set; }
        public string foto { get; set; }
        public string ativo { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("INSERT INTO produtos (descricao, id_categoria, id_marca, estoque," +
                "valor_compra, valor_venda, foto, ativo) VALUES (@descricao, @id_categoria, @id_marca, @estoque, @valor_compra," +
                "@valor_venda, @foto)", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                Banco.comando.Parameters.AddWithValue("@id_marca", id_marca);
                Banco.comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.comando.Parameters.AddWithValue("@valor_compra", valor_compra);
                Banco.comando.Parameters.AddWithValue("@valor_venda", valor_venda);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
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
                Banco.comando = new MySqlCommand("UPDATE produtos SET descricao = @descricao, id_categoria = @id_categoria, " +
                "id_marca = @id_marca, estoque = @estoque, valor_compra = @valor_compra, valor_venda = @valor_venda, foto = @foto " +
                "WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                Banco.comando.Parameters.AddWithValue("@id_marca", id_marca);
                Banco.comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.comando.Parameters.AddWithValue("@valor_compra", valor_compra);
                Banco.comando.Parameters.AddWithValue("@valor_venda", valor_venda);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@id", id);
                Banco.comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
