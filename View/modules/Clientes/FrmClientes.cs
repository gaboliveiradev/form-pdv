using System;
using System.Data;
using System.Windows.Forms;

using _211074.Models;

namespace _211074.View.modules.Clientes
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        public void limparControles()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            cboCidade.SelectedIndex = -1;
            txtUF.Clear();
            mskCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            picFoto.ImageLocation = "";
            chkVenda.Checked = false;
        }

        public void carregarGrid(string pesquisa)
        {
            ClienteModel model = new ClienteModel()
            {
                nome = pesquisa
            };

            dgvClientes.DataSource = model.Consultar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CidadeModel ci = new CidadeModel();

            cboCidade.DataSource = ci.Consultar();
            cboCidade.DisplayMember = "nome";
            cboCidade.ValueMember = "id";

            limparControles();
            carregarGrid("");

            dgvClientes.Columns["id_cidade"].Visible = false;
            dgvClientes.Columns["foto"].Visible = false;
        }

        private void cboCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCidade.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidade.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "C:/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;

            ClienteModel model = new ClienteModel()
            {
                nome = txtNome.Text,
                id_cidade = (int)cboCidade.SelectedValue,
                data_nasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };

            model.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvClientes.Rows.Count > 0)
            {
                txtCodigo.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells["nome"].Value.ToString();
                cboCidade.Text = dgvClientes.CurrentRow.Cells["cidade"].Value.ToString();
                txtUF.Text = dgvClientes.CurrentRow.Cells["uf"].Value.ToString();
                chkVenda.Checked = (bool)dgvClientes.CurrentRow.Cells["venda"].Value;
                mskCPF.Text = dgvClientes.CurrentRow.Cells["cpf"].Value.ToString();
                dtpDataNasc.Text = dgvClientes.CurrentRow.Cells["data_nasc"].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells["renda"].Value.ToString();
                picFoto.ImageLocation = dgvClientes.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") return;

            ClienteModel model = new ClienteModel()
            {
                id = int.Parse(txtCodigo.Text),
                nome = txtNome.Text,
                id_cidade = (int)cboCidade.SelectedValue,
                data_nasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked
            };

            model.Alterar();

            limparControles();
            carregarGrid("");
        }
    }
}
