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
    public partial class SearchCustomar : Form
    {
        public SearchCustomar()
        {
            InitializeComponent();
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
        private void SearchCustomar_Load(object sender, EventArgs e)
        {
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 2;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 80;
            //  pg.Margins.Right = 0;
            pg.Landscape = true;
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
            // size.RawKind = (int)PaperKind.A5;
            // pg.PaperSize = size;
            reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
            // TODO: This line of code loads data into the 'gudduDataSet3.MyOrder' table. You can move, or remove it, as needed.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.MyOrderTableAdapter.Fill(this.gudduDataSet3.MyOrder, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(),textBox1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
