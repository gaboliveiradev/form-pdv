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
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCidade.Text == String.Empty) return;

            CidadeModel c = new CidadeModel()
            {
                nome = txtCidade.Text,
                uf = txtUf.Text
            };

            c.Incluir();

            //limparControler();
            //carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
