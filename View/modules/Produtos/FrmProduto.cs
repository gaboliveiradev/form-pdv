using System;
using System.Data;
using System.Windows.Forms;

using _211074.Models;

namespace _211074.View.modules.Produtos
{
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        public void limparControles()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValorCompra.Clear();
            txtValorVenda.Clear();
            txtEstoque.Clear();
            picFoto.ImageLocation = "";
        }

        public void carregarGrid(string pesquisa)
        {
            ProdutoModel model = new ProdutoModel()
            {
                descricao = pesquisa
            };

            dgvProdutos.DataSource = model.Consultar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CategoriaModel c = new CategoriaModel();
            MarcaModel m = new MarcaModel();

            cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            cboMarca.DataSource = m.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            limparControles();
            carregarGrid("");

            dgvProdutos.Columns["id_categoria"].Visible = false;
            dgvProdutos.Columns["id_marca"].Visible = false;
            dgvProdutos.Columns["foto"].Visible = false;
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "C:/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void picFotoImagem_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "C:/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            ProdutoModel model = new ProdutoModel()
            {
                descricao = txtDescricao.Text,
                id_categoria = (int)cboCategoria.SelectedValue,
                id_marca = (int)cboMarca.SelectedValue,
                estoque = int.Parse(txtEstoque.Text),
                valor_compra = double.Parse(txtValorCompra.Text),
                valor_venda = double.Parse(txtValorVenda.Text),
                foto = picFoto.ImageLocation
            };

            model.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.Rows.Count > 0)
            {
                txtCodigo.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarca.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtValorCompra.Text = dgvProdutos.CurrentRow.Cells["valor_compra"].Value.ToString();
                txtValorVenda.Text = dgvProdutos.CurrentRow.Cells["valor_venda"].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") return;

            ProdutoModel model = new ProdutoModel()
            {
                id = int.Parse(txtCodigo.Text),
                descricao = txtDescricao.Text,
                id_categoria = (int)cboCategoria.SelectedValue,
                id_marca = (int)cboMarca.SelectedValue,
                estoque = int.Parse(txtEstoque.Text),
                valor_compra = double.Parse(txtValorCompra.Text),
                valor_venda = double.Parse(txtValorVenda.Text),
                foto = picFoto.ImageLocation
            };

            model.Alterar();

            limparControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == String.Empty) return;
            if (MessageBox.Show("Deseja excluir o produto?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProdutoModel model = new ProdutoModel()
                {
                    id = int.Parse(txtCodigo.Text),
                    ativo = "N"
                };

                model.Excluir();

                limparControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }
    }
}
