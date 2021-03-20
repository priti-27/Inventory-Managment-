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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
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
                StrSql = "insert into Supplier (SupplierName,Address,Contact,GSTIN) values (@SupplierName,@Address,@Contact,@GSTIN)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@SupplierName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@GSTIN", textBox4.Text);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supplier Added");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from Supplier ", con);
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
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
