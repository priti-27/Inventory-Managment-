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
    public partial class Credit : Form
    {
        public Credit()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;

        // Show the list of credit customer 
        private void Credit_Load(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Close();
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id,OrderNo,CustomerName,Contact,GrandTotal,Advance,Balance,Paid,Bal,Date,SaleDate from MyOrder Where bal!=0 AND GrandTotal !=0 ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;





        }
        // Select row to show the information in text box respecting each collum of table.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button1.Enabled = true;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(textBox3.Text);
                double v3 = v2 - v1;
                textBox5.Text = v3.ToString();




            }
            if (textBox4.Text == String.Empty)
            {
               // double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(textBox5.Text);
                double v3 = v2 *0;
                textBox5.Text = v3.ToString();




            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            //   float v1 = float.Parse(textBox4.Text);
            //   float v2 = float.Parse(textBox3.Text);
            //   // double v3 = v2 - v1;
            //   // textBox5.Text = v3.ToString();
            //   if (v1>=v2)
            //{

            //    MessageBox.Show("Amount is Greter then balance");
            //}




        
        }
        // Up date myorders Bal field using Id 
        private void button1_Click(object sender, EventArgs e)
        {
            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            // StrSql = "insert into machine (Machine,MachineNo,Type,Image,Description) values (@MachineName,@MachineNo,@Type,@Image,@Description)";
            StrSql = "update MyOrder set  Bal= @Bal Where Id='" + textBox1.Text + "' ";
            SqlCommand cmd = new SqlCommand(StrSql, con);
            cmd.Parameters.AddWithValue("@Bal", textBox5.Text);
          
            //if (ImgPath.Trim().Length == 0 && Data == null)
            //{
            //    cmd.Parameters.AddWithValue("@Image", DBNull.Value);
            //    cmd.Parameters["@Image"].SqlDbType = SqlDbType.Image;

            //}
            //else if (ImgPath.Trim().Length > 0)
            //{
            //    Data = File.ReadAllBytes(ImgPath);
            //    cmd.Parameters.AddWithValue("@Image", Data);

            //}


            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id,OrderNo,CustomerName,Contact,GrandTotal,Advance,Balance,Paid,Bal,Date,SaleDate from MyOrder Where bal!=0 AND GrandTotal !=0 ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

        }
    }
}