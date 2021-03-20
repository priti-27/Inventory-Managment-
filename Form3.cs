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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gudduDataSet2.employee_profile' table. You can move, or remove it, as needed.
            this.employee_profileTableAdapter.Fill(this.gudduDataSet2.employee_profile);

            this.reportViewer1.RefreshReport();
        }
    }
}
