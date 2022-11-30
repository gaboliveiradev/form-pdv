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

        }
    }
}
