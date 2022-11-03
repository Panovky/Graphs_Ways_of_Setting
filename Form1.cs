using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discretka_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int N; // количество вершин графа

        private void buttonOK_Click(object sender, EventArgs e)
        {
            labelOK.Visible = false; 
            textBoxOK.Visible = false; 
            buttonOK.Visible = false;

            labelExe.Visible = true;
            buttonExe.Visible = true;

            createMatrixSmejnosti();
        }

        private void buttonExe_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();

            labelExe.Visible = false;
            buttonExe.Visible = false;

            labelClear.Visible = true;
            buttonClear.Visible = true;

            fillListsSmejnosti();
            fillMatrixIncidenciy();
            fillListsIncidenciy();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = false;

            label2.Visible = false;
            listBox1.Items.Clear();

            label3.Visible = false;
            dataGridView2.Columns.Clear();

            label4.Visible = false;
            listBox2.Items.Clear();

            labelClear.Visible = false;
            buttonClear.Visible = false;

            labelOK.Visible = true;
            textBoxOK.Clear();
            textBoxOK.Visible = true;
            buttonOK.Visible = true;
        }

        public void createMatrixSmejnosti()
        {
            N = Convert.ToInt32(textBoxOK.Text);
            dataGridView1.RowCount = N;
            dataGridView1.ColumnCount = N;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < N; i++)
            {
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
            }

            label1.Visible = true;
        }

        public void fillListsSmejnosti()
        {
            List<string> row = new List<string>();

            for (int r = 0; r < N; r++)
            {
                row.Clear();

                for (int c = 0; c < N; c++)
                {

                    if (Convert.ToInt32(dataGridView1[c, r].Value) == 1)
                    {
                        row.Add(Convert.ToString(c + 1));
                    }
                }

                listBox1.Items.Add(Convert.ToString(r + 1) + ": " + String.Join(", ", row));
            }

            label2.Visible = true;
        }

        public void fillMatrixIncidenciy()
        {
            dataGridView2.ColumnCount = N;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < N; i++)
            {
                dataGridView2.Columns[i].HeaderText = Convert.ToString(i + 1);
            }

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    if (Convert.ToInt32(dataGridView1[c, r].Value) == 1 && c > r)
                    {
                        dataGridView2.RowCount += 1;

                        for (int i = 0; i < N; i++) {

                            if (i == r || i == c)
                            {
                                dataGridView2[i, dataGridView2.RowCount - 1].Value = 1;
                            }
                            else 
                            {
                                dataGridView2[i, dataGridView2.RowCount - 1].Value = 0;
                            } 
                        }  
                    }
                }
            }

            label3.Visible = true;
        }

        public void fillListsIncidenciy() 
        {
            List<string> row = new List<string>();

            for (int r = 0; r < dataGridView2.RowCount; r++)
            {
                row.Clear();

                for (int c = 0; c < N; c++)
                {

                    if (Convert.ToInt32(dataGridView2[c, r].Value) == 1)
                    {
                        row.Add(Convert.ToString(c + 1));
                    }
                }

                listBox2.Items.Add("[" + String.Join(", ", row) + "]");
            }

            label4.Visible = true;
        }
    }
}
