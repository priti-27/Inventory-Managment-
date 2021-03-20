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
    public partial class ProfitLoss : Form
    {
        public ProfitLoss()
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
            try
            {
                //DataTable dt = new DataTable();
                //da = new SqlDataAdapter("select ctotal from OrderForm where Date Between '" +dateTimePicker1+ "' AND  '" + dateTimePicker1 + "' ", con);
                //da.Fill(dt);
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { /*con.Close();*/ }
        }
    }
}
