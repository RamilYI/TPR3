using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace TPR3
{
    public partial class Table : Form
    {
        List<Tuple<int, decimal, decimal, int, int, decimal>> table = new List<Tuple<int, decimal, decimal, int, int, decimal>>();
        private int iter, n;
        public Table(List<Tuple<int, decimal, decimal, int, int, decimal>> table, int iter, int n)
        {
            InitializeComponent();
            this.table = table;
            this.iter = iter;
            this.n = n;
        }

        public void fillTable(List<Tuple<int, decimal, decimal, int, int, decimal>> table)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "шаг";
            dataGridView1.Columns[1].HeaderText = "M";
            dataGridView1.Columns[2].HeaderText = "V";
            dataGridView1.Columns[3].HeaderText = "iMin";
            dataGridView1.Columns[4].HeaderText = "jMax";
            dataGridView1.Columns[5].HeaderText = "Цена игры";
        }

        private void результатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] table1 = new int[iter];
            int[] table2 = new int[iter];
            List<Tuple<int, decimal, decimal>> strategy = new List<Tuple<int, decimal, decimal>>();
            for (int i = 0; i < iter; i++) table1[i] = table[i].Item4;
            for (int i = 0; i < iter; i++) table2[i] = table[i].Item5;
            decimal k, k1;
            for (int i = 1; i < n + 1; i++)
            {
                k = (from s in table1 where s == i select s).Count() / (decimal)iter;
                k1 = (from s in table2 where s == i select s).Count() / (decimal)iter;
                strategy.Add(new Tuple<int, decimal, decimal>(i, k, k1));
            }

            string strategy1 = "(";
            string strategy2 = "(";
            foreach (var i in strategy)
            {
                strategy1 += i.Item2 + "; ";
                strategy2 += i.Item3 + "; ";
            }

            strategy1 += ")";
            strategy2 += ")";
            decimal valuegame = (table[iter - 1].Item2 + table[iter - 1].Item3) / 2;

            

            Strategies ss = new Strategies();
            ss.filltable(strategy1, strategy2, valuegame);
            ss.Show();
        }
    }
}
