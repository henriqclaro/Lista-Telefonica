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
        string[][] lista;
        readonly int MAX = 100;
        public Form1()
        {
            InitializeComponent();
            lista = new string[MAX][];
        }

        int Length(string[][] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    itens++;
                }
            }
            return itens;
        }

        int Length(string[] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    itens++;
                }
            }
            return itens;
        }

        void Atualizar()
        {
            dgvLista.Rows.Clear();
            for (int i = 0; i < Length(lista); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLista);
                for (int j = 0; j < Length(lista[i]); j++)
                {
                    row.Cells[j].Value = lista[i][j];
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

            if (Length(lista) == MAX)
            {
                MessageBox.Show("Lista cheia.");
                return;
            }

            int id = 1;
            if (Length(lista) > 0)
            {
                id = int.Parse(lista[Length(lista) - 1][0]) + 1;
            }

            lista[Length(lista)] = new string[] { id.ToString(), txtNome.Text, txtTel.Text };

            Atualizar();
            txtNome.Clear();
            txtTel.Clear();
        }
        
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedCells.Count == 0)
            {
                MessageBox.Show("Seleciona uma célula.");
                return;
            }

            DataGridViewCell cell = dgvLista.SelectedCells[0];
            int linha = cell.RowIndex;
            string id = dgvLista.Rows[linha].Cells[0].Value.ToString();

            int indice = 0;
            for (indice = 0; indice < Length(lista) && lista[indice][0] != id; indice++) ;

            DialogResult r = MessageBox.Show($"Deseja remover {lista[indice][1]}?", "Remover", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                for (int i = indice; i <= Length(lista) - 1; i++)
                {
                    lista[i] = lista[i + 1];
                }
                lista[Length(lista)] = null;

                Atualizar();
            }
        }
    }
}
