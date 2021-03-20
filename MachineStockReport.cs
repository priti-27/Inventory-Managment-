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
    public partial class MachineStockReport : Form
    {
        public MachineStockReport()
        {
            InitializeComponent();
        }

        private void MachineStockReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet2.machine' table. You can move, or remove it, as needed.
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.machineTableAdapter.Fill(this.gudduDataSet2.machine, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());

            this.reportViewer1.RefreshReport();
        }
    }
}
