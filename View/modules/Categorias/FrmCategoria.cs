using System;
using System.Windows.Forms;
using _211074.Models;

namespace _211074.View.modules.Categorias
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
            limparControles();
            carregarGrid("");
        }

        public void limparControles()
        {
            txtCodigo.Clear();
            txtCategoria.Clear();
            txtPesquisar.Clear();
        }

        public void carregarGrid(string pesquisa)
        {
            MarcaModel model = new MarcaModel()
            {
                marca = pesquisa
            };

            dgvCategoria.DataSource = model.Consultar();
        }


        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;

            CategoriaModel model = new CategoriaModel()
            {
                categoria = txtCategoria.Text.ToUpper(),
            };

            model.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty) return;

            CategoriaModel model = new CategoriaModel()
            {
                id = int.Parse(txtCodigo.Text),
                categoria = txtCategoria.Text.ToUpper(),
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
                CategoriaModel model = new CategoriaModel()
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

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtCodigo.Text = dgvCategoria.CurrentRow.Cells["ID"].Value.ToString();
                txtCategoria.Text = dgvCategoria.CurrentRow.Cells["CATEGORIA"].Value.ToString();
            }
        }
    }
}
