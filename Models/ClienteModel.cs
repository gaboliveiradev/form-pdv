﻿using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211074.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int id_cidade { get; set; }
        public DateTime data_nasc { get; set; }
        public double renda { get; set; }
        public string cpf { get; set; }
        public string foto { get; set; }
        public bool venda { get; set; }
        public string ativo { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.comando = new MySqlCommand("INSERT INTO clientes (nome, id_cidade, data_nasc, " +
                "renda, cpf, foto, venda) VALUES (@nome, @id_cidade, @data_nasc, @renda, @cpf," +
                "@foto, @venda)", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@id_cidade", id_cidade);
                Banco.comando.Parameters.AddWithValue("@data_nasc", data_nasc);
                Banco.comando.Parameters.AddWithValue("@renda", renda);
                Banco.comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@venda", venda);
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
                Banco.comando = new MySqlCommand("UPDATE clientes SET nome = @nome, id_cidade = @id_cidade, " +
                "data_nasc = @data_nasc, renda = @renda, cpf = @cpf, foto = @foto, venda = @venda " +
                "WHERE id = @id", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome);
                Banco.comando.Parameters.AddWithValue("@id_cidade", id_cidade);
                Banco.comando.Parameters.AddWithValue("@data_nasc", data_nasc);
                Banco.comando.Parameters.AddWithValue("@renda", renda);
                Banco.comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.comando.Parameters.AddWithValue("@foto", foto);
                Banco.comando.Parameters.AddWithValue("@venda", venda);
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
                Banco.comando = new MySqlCommand("UPDATE clientes SET ativo = @ativo WHERE id = @id", Banco.conexao);
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
                Banco.comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, " +
                "ci.uf FROM clientes cl INNER JOIN cidades ci ON (ci.id = cl.id_cidade) " +
                "WHERE cl.nome LIKE @nome AND cl.ativo = \"S\" ORDER BY cl.nome", Banco.conexao);

                Banco.comando.Parameters.AddWithValue("@nome", nome + "%");
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
