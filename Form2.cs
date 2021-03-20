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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select CustomerName,Date,Contact,ProductName,Can,Color,Shape,Weight,Qty,Amount,Total,GSTIN,Contact from MyOrder where OrderNo='" + textBox1.Text + "' ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }


            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From MyOrder where OrderNo ='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr["CustomerName"].ToString();
                        textBox19.Text = dr["GSTIN"].ToString();
                        textBox35.Text = dr["Contact"].ToString();
                        textBox39.Text = dr["CustomerName"].ToString();
                        textBox40.Text = dr["Nettotal"].ToString();
                        textBox7.Text = dr["Nettotal"].ToString();
                        textBox8.Text = dr["sgstr"].ToString();
                        textBox9.Text = dr["cgstr"].ToString();
                        textBox10.Text = dr["igstr"].ToString();
                        textBox11.Text = dr["GrandTotal"].ToString();
                        textBox12.Text = dr["sgsta"].ToString();
                        textBox13.Text = dr["cgsta"].ToString();
                        textBox14.Text = dr["igsta"].ToString();
                        textBox15.Text = dr["Advance"].ToString();
                        textBox16.Text = dr["Balance"].ToString();
                        date.Text = dr["Date"].ToString();




                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

                        textBox17.Text = dr["AvaliableStock"].ToString();
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

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            int v = int.Parse(textBox17.Text);

            if (v <= 0)
            {
                MessageBox.Show("Stock NoT Avalible");
                int v1 = v * 0;
                textBox17.Text = v1.ToString();



            }

            if (textBox30.Text != String.Empty)
            {

                double v1 = double.Parse(textBox17.Text);
                double v2 = double.Parse(textBox30.Text);
                double v3 = v1 - v2;
                textBox18.Text = v3.ToString();

            }
            if (textBox17.Text == String.Empty)
            {
                double v2 = double.Parse(textBox18.Text);
                double v3 = v2 * 0;
                textBox14.Text = v3.ToString();
            }
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text != String.Empty)
            {
                double v1 = double.Parse(textBox28.Text);
                double v2 = double.Parse(textBox30.Text);
                double v3 = v1 * v2;
                textBox6.Text = v3.ToString();
            }
            else
            {
                double v1 = double.Parse(textBox3.Text);
                double v2 = v1 * 0;
                textBox6.Text = v2.ToString();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            double v1 = double.Parse(textBox6.Text);
            double v2 = double.Parse(textBox40.Text);
            double v3 = v1 + v2;
            textBox40.Text = v3.ToString();

            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "insert into MyOrder(CustomerName,Date,Contact,ProductName,Can,Qty,Amount,Total,HSN, Color,Shape,Weight,OrderNo,OD) values  (@CustomerName,@Date,@Contact,@ProductName,@Can,@Qty,@Amount,@Total,@HSN,@Color,@Shape,@Weight,@OrderNo,@OD)";
                // StrSql = "insert into order values";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@CustomerName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(date.Text));
                cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
                cmd.Parameters.AddWithValue("@ProductName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Can", untltr.Text);
                cmd.Parameters.AddWithValue("@Qty", textBox3.Text);
                cmd.Parameters.AddWithValue("@Amount", textBox4.Text);
                cmd.Parameters.AddWithValue("@Total", textBox5.Text);
                cmd.Parameters.AddWithValue("@HSN", textBox20.Text);
                cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Weight", comboBox4.Text);
                cmd.Parameters.AddWithValue("@OrderNo", textBox1.Text);
                cmd.Parameters.AddWithValue("@OD", dateTimePicker1.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("can added into the Memo");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

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
                cmd.Parameters.AddWithValue("@AvaliableStock", textBox18.Text);


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
                textBox20.Text = "";
                textBox2.Text = "";
                textBox3.Text = "0";
                textBox28.Text = "0";
                untltr.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";





            }

        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }

            if (textBox17.Text != String.Empty)
            {
                textBox28.Enabled = true;
            }
            if (textBox17.Text == String.Empty)
            {
                textBox28.Enabled = false;
            }
        }
    }
}
