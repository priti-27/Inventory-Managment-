using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golddi_Industries
{
    public partial class SalaryReport : Form
    {
        public SalaryReport()
        {
            InitializeComponent();
        }

        private void SalaryReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet1.Salary' table. You can move, or remove it, as needed.
           ;
            //// TODO: This line of code loads data into the 'gudduDataSet.MyOrder' table. You can move, or remove it, as needed.
            //this.MyOrderTableAdapter.Fill(this.gudduDataSet.MyOrder);

            //this.reportViewer1.RefreshReport();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.SalaryTableAdapter.Fill(this.gudduDataSet1.Salary, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

            this.reportViewer1.RefreshReport(); 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 2;
            pg.Margins.Bottom = 0;
           // pg.Margins.Left = 80;
            //  pg.Margins.Right = 0;
          //  pg.Landscape = true;
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
            // size.RawKind = (int)PaperKind.A5;
            // pg.PaperSize = size;
            reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }

        private void MyOrderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
