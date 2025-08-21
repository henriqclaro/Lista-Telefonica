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
    public partial class FrmPrincipal : Form
    {
        private ContatoPresenter presenter;
        Contato edicao;
        public FrmPrincipal()
        {
            InitializeComponent();
            presenter = new ContatoPresenter();
            Atualizar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmNovoContato frm = new FrmNovoContato(presenter);
            frm.ShowDialog();
            Atualizar();
        }

        private void Atualizar()
        {
            dgvLista.DataSource = presenter.BuscarContatos(txtBuscar.Text.Trim());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvLista.SelectedCells[0].RowIndex;
            int id = (int)dgvLista.Rows[linha].Cells[0].Value;

            edicao = presenter.SelecionarContato(id);

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

        }

        private void Limpar()
        {
            edicao = null;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarContato frm = new FrmEditarContato(presenter, edicao);
            frm.ShowDialog();
            Atualizar();
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                $"Deseja realmente remover o contato {edicao.Nome}?",
                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
              presenter.RemoverContato(edicao);
                Atualizar();
                Limpar() ;
            }
        }
    }
}
