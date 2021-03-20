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
    public partial class Product_Master : Form
    {
        public Product_Master()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert into ProductForm (ProductName,Type) values (@ProductName,@Type)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                 cmd.Parameters.AddWithValue("@ProductName", textBox1.Text);
                 cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Product Added");
                 DataTable dt = new DataTable();
                 da = new SqlDataAdapter("select * from ProductForm ", con);
                 da.Fill(dt);
                  dataGridView1.DataSource = dt;

            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 con.Close();
                 textBox1.Text = "";
                 comboBox1.Text = "";
                 //Cleare();
             }


        }

        private void Product_Master_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }
    }
}
