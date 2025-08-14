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
    public partial class FrmNovoContato : Form
    {
        private ContatoPresenter presenter;
        public FrmNovoContato(ContatoPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string tel = txtTel.Text;

            if (nome.Length == 0 || !txtTel.MaskCompleted) 
            {
                MessageBox.Show("Preencha todos os campos corretamente!",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contato novo = new Contato() { Nome = nome , Telefone = tel};

            if (presenter.AdicionarContato(novo))
            {
                this.Close();
            }
            else 
            {
                MessageBox.Show("Erro ao salvar o contato!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
