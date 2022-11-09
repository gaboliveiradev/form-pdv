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

namespace _211074.View.modules.Marcas
{
    public partial class FrmMarca : Form
    {

        public FrmMarca()
        {
            InitializeComponent();
            limparControles();
            carregarGrid("");
        }

        public void limparControles()
        {
            txtCodigo.Clear();
            txtMarca.Clear();
            txtPesquisar.Clear();
        }

        public void carregarGrid(string pesquisa)
        {
            MarcaModel model = new MarcaModel()
            {
                marca = pesquisa
            };

            dgvMarcas.DataSource = model.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            MarcaModel model = new MarcaModel()
            {
                marca = txtMarca.Text.ToUpper(),
            };

            model.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty) return;

            MarcaModel model = new MarcaModel()
            {
                id = int.Parse(txtCodigo.Text),
                marca = txtMarca.Text.ToUpper(),
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
            if (txtCodigo.Text == String.Empty) return;
            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MarcaModel model = new MarcaModel()
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

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtCodigo.Text = dgvMarcas.CurrentRow.Cells["ID"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["MARCA"].Value.ToString();
            }
        }
    }
}
