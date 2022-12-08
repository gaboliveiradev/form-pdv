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
                "valor_compra, valor_venda, foto) VALUES (@descricao, @id_categoria, @id_marca, @estoque, @valor_compra," +
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

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("UPDATE produtos SET ativo = @ativo WHERE id = @id", Banco.conexao);
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
                Banco.comando = new MySqlCommand("SELECT p.*, m.marca, c.categoria FROM " +
                    "Produtos p INNER JOIN Marcas m ON (m.id = p.id_marca) " +
                    "INNER JOIN Categorias c ON (c.id = p.id_categoria) WHERE p.descricao LIKE @descricao AND p.ativo = \"S\" " +
                    "ORDER BY p.descricao", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@descricao", descricao + "%");
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
