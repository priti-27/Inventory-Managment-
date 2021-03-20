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
    public partial class DamadgeGoods : Form
    {
        public DamadgeGoods()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;

        private void DamadgeGoods_Load(object sender, EventArgs e)
        {

        }
        // display avalible stock depending on Ltr, color, shape, weight 
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = "0";
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                // StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "'";
                StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox4.Text = dr["AvaliableStock"].ToString();
                        // textBox3.Text = dr["ActualStock"].ToString();



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                double v1 = double.Parse(textBox1.Text);
                double v2 = double.Parse(textBox4.Text);
                double v3 = v2 - v1;
                textBox5.Text = v3.ToString();

            }
        }
        //inser damage gods in to text box which will be replace by new goods an stock will be update.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "insert into Damage(Ltr,DUnit,Color,Shape,Size) values  (@Ltr,@Qty,@Color,@Shape,@Size)";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
              //  cmd.Parameters.AddWithValue("@CustomerName", textBox3.Text);
              //  cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Text));

                cmd.Parameters.AddWithValue("@Ltr", untltr.Text);
                cmd.Parameters.AddWithValue("@Qty", textBox1.Text);
                cmd.Parameters.AddWithValue("@Amount", textBox4.Text);
                cmd.Parameters.AddWithValue("@Total", textBox5.Text);
                // cmd.Parameters.AddWithValue("@HSN", textBox20.Text);
                cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Size", comboBox4.Text);
              //  cmd.Parameters.AddWithValue("@Unit", textBox1.Text);
               // cmd.Parameters.AddWithValue("@OrderNo", textBox2.Text);
                //cmd.Parameters.AddWithValue("@OD", dateTimePicker1.Text);


                cmd.ExecuteNonQuery();
                // MessageBox.Show("can added into the Memo");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                MessageBox.Show("Entry Created");

            }
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                // StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total)";
                StrSql = "update machineinfo Set AvaliableStock=@AvaliableStock where Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "'";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@AvaliableStock", textBox5.Text);


                cmd.ExecuteNonQuery();
                // MessageBox.Show("can added into the Memo");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

                textBox1.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";


            }
        }
    }
}
