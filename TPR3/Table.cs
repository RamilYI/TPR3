using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPR3
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }

        public void fillTable(List<Tuple<int, decimal, decimal>> table)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "шаг";
            dataGridView1.Columns[1].HeaderText = "M";
            dataGridView1.Columns[2].HeaderText = "V";
        }
    }
}
