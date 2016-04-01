using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StorageIO
{
    public partial class TableTestPage : Form
    {
        public TableTestPage()
        {
            InitializeComponent();

            testProcress();
        }

        void testProcress()
        {
            //设置只读
            tableTest.ReadOnly = true;

            //移除空行
            tableTest.AllowUserToAddRows = false;

            //添加事件监听器
            tableTest.CellDoubleClick += TableTest_CellDoubleClick;

            //添加列
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "testCol";
            col.HeaderText = "testCol";

            tableTest.Columns.Add(col);

            //添加行
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(tableTest);
            row.Cells[0].Value = "Hi";
            tableTest.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(tableTest);
            row.Cells[0].Value = "Hi22";
            tableTest.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(tableTest);
            row.Cells[0].Value = "Hi33";
            tableTest.Rows.Add(row);
        }

        private void TableTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (e.RowIndex < 0) return;
            MessageBox.Show(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }
    }
}
