using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListaTelefonica.Models;
using ListaTelefonica.Presenters;

namespace ListaTelefonica.Views
{
    public partial class FrmEditarContato : Form
    {
        ContatoPresenter presenter;
        Contato edicao; 

        public FrmEditarContato(ContatoPresenter presenter, Contato edicao)
        {
            InitializeComponent();

            this.presenter = presenter;
            this.edicao = edicao;

            txtNome.Text = edicao.Nome;
            txtTel.Text = edicao.Telefone;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string telefone = txtTel.Text;

            if (nome.Length == 0 || !txtTel.MaskCompleted)
            {
                MessageBox.Show("Preencha os campos corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            edicao.Nome = nome;
            edicao.Telefone = telefone;
            presenter.EditarContato(edicao);
            this.Close();
        }
    }
}
