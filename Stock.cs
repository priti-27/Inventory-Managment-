using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Golddi_Industries
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select MachineName, Ltr, ctotal from MachineInfo where Date Between '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select MachineName, Ltr, ctotal from MachineInfo where Date ='" + dateTimePicker1.Text + "' ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Stock_Load(object sender, EventArgs e)
        {

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
    }
}
