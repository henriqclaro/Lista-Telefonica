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

namespace ListaTelefonica
{
    
    public partial class Form1 : Form
    {
        string[,] lista;
        readonly int MAX = 100;
        int itens = 0;
        public Form1()
        {
            InitializeComponent();
            lista = new string[MAX, 2];
        }

        void Atualizar()
        {
            dgvLista.Rows.Clear();
            for (int i = 0; i < itens; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLista);
                for (int j = 0; j < 2; j++)
                {
                    row.Cells[j].Value = lista[i, j];
                }
                dgvLista.Rows.Add(row);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || !txtTel.MaskFull)
            {
                MessageBox.Show("Insira nome e telefone.");
                return;
            }
            
            lista[itens, 0] = txtNome.Text;
            lista[itens, 1] = txtTel.Text;
            itens++;

            Atualizar();
            txtNome.Clear();
            txtTel.Clear();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvLista.SelectedCells[0];
            int indice = cell.RowIndex;
            lista[indice, 0] = null;
            lista[indice, 1] = null;
            for (int i = 0; i <= itens; i++)
            {
                if (lista[i, 0] == null)
                {
                    lista[i, 0] = lista[i + 1, 0];
                    lista[i, 1] = lista[i + 1, 1];
                    lista[i + 1, 0] = null;
                    lista[i + 1, 1] = null;
                }
            }
            itens--;
            Atualizar();
        }
    }
}
