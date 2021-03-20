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
    public partial class WithoutGstBillreport : Form
    {
        public WithoutGstBillreport()
        {
            InitializeComponent();
        }

        private void WithoutGstBillreport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet5.tempbill' table. You can move, or remove it, as needed.
            this.tempbillTableAdapter.Fill(this.gudduDataSet5.tempbill,TextBox1.Text);
            // TODO: This line of code loads data into the 'gudduDataSet4.tempbill' table. You can move, or remove it, as needed.
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // this.tempbillTableAdapter.Fill(this.gudduDataSet4.tempbill, TextBox1.Text);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.tempbillTableAdapter.Fill(this.gudduDataSet5.tempbill, TextBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
