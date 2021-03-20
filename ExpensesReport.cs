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
    public partial class ExpensesReport : Form
    {
        public ExpensesReport()
        {
            InitializeComponent();
        }

        private void ExpensesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet.expences' table. You can move, or remove it, as needed.
           
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
            this.expencesTableAdapter.Fill(this.gudduDataSet.expences, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

            this.reportViewer1.RefreshReport();
        }
    }
}
