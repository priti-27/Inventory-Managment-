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
    public partial class ProductUpdate : Form
    {
        public ProductUpdate()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            mnumber.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mntype.Text=dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Time.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Date.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

           untltr.Text =dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
           unit.Text =dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
           textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
           textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
           lbrname.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

             
        }

        private void ProductUpdate_Load(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from machineInfo  ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
