using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _211074.Models;

namespace _211074.View.modules.Cidades
{
    public partial class FrmCidade : Form
    {
        public FrmCidade()
        {
            InitializeComponent();
            limparControles();
            carregarGrid("");
        }

        public void limparControles()
        {
            txtCodigo.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtPesquisar.Clear();
        }

        public void carregarGrid(string pesquisa)
        {
            CidadeModel model = new CidadeModel()
            {
                nome = pesquisa
            };

            dgvCidades.DataSource = model.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCidade.Text == String.Empty) return;

            CidadeModel model = new CidadeModel()
            {
                nome = txtCidade.Text,
                uf = txtUf.Text
            };

            model.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty) return;

            CidadeModel model = new CidadeModel()
            {
                id = int.Parse(txtCodigo.Text),
                nome = txtCidade.Text,
                uf = txtUf.Text
            };

            model.Alterar();

            limparControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text == String.Empty) return;
            if(MessageBox.Show("Deseja excluir a cidade?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CidadeModel model = new CidadeModel()
                {
                    id = int.Parse(txtCodigo.Text),
                    ativo = "N"
                };

                model.Excluir();

                limparControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtCodigo.Text = dgvCidades.CurrentRow.Cells["ID"].Value.ToString();
                txtCidade.Text = dgvCidades.CurrentRow.Cells["NOME"].Value.ToString();
                txtUf.Text = dgvCidades.CurrentRow.Cells["UF"].Value.ToString();
            }
        }
    }
}
