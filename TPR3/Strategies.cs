using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPR3
{
    public partial class Strategies : Form
    {
        public Strategies()
        {
            InitializeComponent();

        }

        public void filltable(string str1, string str2, decimal val)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Rows[0].Cells[0].Value = str1;
            dataGridView1.Rows[1].Cells[0].Value = str2;
            dataGridView1.Rows[2].Cells[0].Value = val;
            dataGridView1.Rows[0].HeaderCell.Value  = "Смешанные стратегии первого игрока";
            dataGridView1.Rows[1].HeaderCell.Value = "Смешанные стратегии второго игрока";
            dataGridView1.Rows[2].HeaderCell.Value = "Цена игры";
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = (dataGridView1.ClientRectangle.Height - dataGridView1.ColumnHeadersHeight) / dataGridView1.Rows.Count;
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.Width = (dataGridView1.ClientRectangle.Width - dataGridView1.ColumnHeadersHeight) /
                            dataGridView1.Columns.Count;
            }
        }
        
    }
}
