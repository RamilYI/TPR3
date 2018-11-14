using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TPR3
{
    public partial class ProgrMenu : Form
    {
        List<Tuple<int, decimal, decimal, int, int, decimal>> result = new List<Tuple<int, decimal, decimal, int, int, decimal>>();
        private int accuracy, iter, n, m;

        public ProgrMenu()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            accuracy = Int32.Parse(numericUpDown4.Text);
            iter = Int32.Parse(numericUpDown3.Text);
            n = Int32.Parse(numericUpDown1.Text);
            m = Int32.Parse(numericUpDown2.Text);
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = m;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            result.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] a = new int[n,m];
            decimal[] g = new decimal[n];
            decimal[] h = new decimal[m];
            int[] kIter = new int[iter];
            decimal[] M = new decimal[iter];
            decimal[] V = new decimal[iter];
            int iMin = 0;
            int jMax = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int i = row.Index;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    int j = col.Index;
                    a[i, j] = Int32.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
            
            for (int k = 0; k < iter; k++)
            {
                kIter[k] = k + 1;
                for (int i = 0; i < n; i++)
                {
                    g[i] += a[jMax, i];
                }
                for (int j = 0; j < m; j++)
                {
                    h[j] += a[j, iMin];
                }

                M[k] = Math.Round(g.Min()/(k + 1), Int32.Parse(numericUpDown4.Text));
                iMin = g.ToList().IndexOf(g.Min());
                V[k] = Math.Round(h.Max()/(k + 1), Int32.Parse(numericUpDown4.Text));
                jMax = h.ToList().IndexOf(h.Max());
                result.Add(new Tuple<int, decimal, decimal, int, int, decimal>(kIter[k], M[k], V[k], iMin+1, jMax+1, (M[k] + V[k]) / 2));
            }
            
            Table table = new Table(result, iter, n);
            table.fillTable(result);
            table.ShowDialog();
        }
    }
}
