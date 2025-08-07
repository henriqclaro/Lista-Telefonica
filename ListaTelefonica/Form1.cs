using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ListaTelefonica.Models;

namespace ListaTelefonica
{

    public partial class Form1 : Form
    {
        List<Contato> lista;
        Contato edicao;
        string selectedId;
        public Form1()
        {
            InitializeComponent();
            lista = new List<Contato>();
            edicao = null;
        }

        void Atualizar()
        {
            dgvLista.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                dgvLista.Rows.Add(lista[i].Id, lista[i].Nome, lista[i].Telefone);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || !txtTel.MaskFull)
            {
                MessageBox.Show("Insira nome e telefone completos.");
                return;
            }

            if (edicao != null)
            {
                edicao.Nome = txtNome.Text;
                edicao.Telefone = txtTel.Text;
                edicao = null;
                btnAdicionar.Text = "&Adicionar";
                btnRemover.Enabled = false;
            }
            
            /*
            if (!String.IsNullOrEmpty(selectedId))
            {
                int indice = 0;
                for (indice = 0; indice < lista.Count && lista[indice].Id+"" != selectedId; indice++);
                lista[indice].Nome = txtNome.Text;
                lista[indice].Telefone = txtTel.Text;
            }
            */

            else
            {
                int id = 1;
                if (lista.Count > 0)
                {
                    id = lista.Max(c => c.Id) + 1;
                }

                Contato novo = new Contato();
                novo.Id = id;
                novo.Nome = txtNome.Text;
                novo.Telefone = txtTel.Text;

                lista.Add(novo);
            }

            Atualizar();
            Limpar();
        }
        
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (edicao == null)
            {
                MessageBox.Show("Seleciona uma célula.");
                return;
            }

            

            DialogResult r = MessageBox.Show($"Deseja remover {edicao.Nome}?", "Remover", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                lista.Remove(edicao);

                Limpar();
                Atualizar();
            }
        }

        void Limpar()
        {
            selectedId = null;
            txtNome.Clear();
            txtTel.Clear();
            btnAdicionar.Text = "&Adicionar";
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celula = dgvLista.SelectedCells[0];
            int linha = celula.RowIndex;
            int id = (int)dgvLista.Rows[linha].Cells[0].Value;

            edicao = lista.Find(c => c.Id == id);

            txtNome.Text = edicao.Nome;
            txtTel.Text = edicao.Telefone;


            btnAdicionar.Text = "&Atualizar";
            btnRemover.Enabled = true;

            /*
            if (e.RowIndex < 0)
            {
                return;
            }
            if (selectedId == dgvLista.Rows[e.RowIndex].Cells[0].Value.ToString())
            {
                Limpar();
                return; 
            }
            btnAdicionar.Text = "&Atualizar";
            selectedId = dgvLista.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = dgvLista.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTel.Text = dgvLista.Rows[e.RowIndex].Cells[2].Value.ToString();
            */
        }

        private void dgvLista_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
