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
    public partial class Due : Form
    {
        public Due()
        {
            InitializeComponent();
        }
        //due order list is use order no to display order of perticular customer 
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        private void date_ValueChanged(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select* from MyOrder where OD >='" + date.Text + "' AND Balance != 0 ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select CustomerName,Date,Contact,ProductName,Can,Color,Shape,Weight,Qty,Amount,Total from MyOrder where OrderNo='" + textBox1.Text + "' ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
            if (textBox1.Text == String.Empty)
            { 
                   StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select* from MyOrder where OD >='" + date.Text + "' AND Balance != 0 ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
            
            }
        

        private void Due_Load(object sender, EventArgs e)
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
