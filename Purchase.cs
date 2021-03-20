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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            ClassBind();
            ClassBind1();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;


        string StrSql = string.Empty;

        public void Clr()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0"; 
            textBox4.Text = "0";
            sgr.Text = "0";
            sga.Text = "0";
            cgr.Text = "0";
            cga.Text = "0";
            igr.Text = "0";
            iga.Text = "0";
            grandtotal.Text = "0";
        
        }

        public void ClassBind()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  Supplier";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "SupplierName" };
                    dt.Rows.InsertAt(dr, 0);

                    comboBox1.ValueMember = "Id";


                    comboBox1.DisplayMember = "SupplierName";
                    comboBox1.DataSource = dt;
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

        public void ClassBind1()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  ProductForm";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "ProductName" };
                    dt.Rows.InsertAt(dr, 0);

                    comboBox2.ValueMember = "Id";


                    comboBox2.DisplayMember = "ProductName";
                    comboBox2.DataSource = dt;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Purchase_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From Supplier where SupplierName='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Address.Text = dr["Address"].ToString();
                        Contact.Text = dr["Contact"].ToString();
                        GSTIN.Text = dr["GSTIN"].ToString();
                       

                      

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

        private void button5_Click(object sender, EventArgs e)
        {
            double v1 = double.Parse(ttamt.Text);
            double v2 = double.Parse(textBox1.Text);
            double v3 = v1 + v2;
           textBox1.Text = v3.ToString();
           try
           {

               StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
               con = new SqlConnection(StrSql);
               con.Open();
               StrSql = "insert into Purchase (SupplierName,Address,ContactNo,GSTIN,Date,ProductName,Type,Qty,Amount,Total) values (@SupplierName,@Address,@ContactNo,@GSTIN,@Date,@ProductName,@Type,@Qty,@Amount,@Total)";
               SqlCommand cmd = new SqlCommand(StrSql, con);
               cmd.Parameters.AddWithValue("@SupplierName", comboBox1.Text);

               cmd.Parameters.AddWithValue("@Address", Address.Text);
               cmd.Parameters.AddWithValue("@ContactNo", Contact.Text);
               cmd.Parameters.AddWithValue("@Date", date.Text);
               cmd.Parameters.AddWithValue("@GSTIN", GSTIN.Text);
               cmd.Parameters.AddWithValue("@ProductName", comboBox2.Text);
               cmd.Parameters.AddWithValue("@Type", Type.Text);
               cmd.Parameters.AddWithValue("@Qty",qty.Text);
               cmd.Parameters.AddWithValue("@Amount", amt.Text);
               cmd.Parameters.AddWithValue("@Total", ttamt.Text);
              // cmd.Parameters.AddWithValue("@LabourName", lbrname.Text);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Material Added into the Stock");
               DataTable dt = new DataTable();
               da = new SqlDataAdapter("select * from Purchase ", con);
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
               comboBox2.Text = "";
               Type.Text = "";
               qty.Text = "0";
               amt.Text = "0";
               ttamt.Text = "0";

           }
            
            
            
        }

        private void amt_TextChanged(object sender, EventArgs e)
        {
            if(amt.Text != String.Empty)
            {
                    double v1 = double.Parse(qty.Text);
                    double v2 = double.Parse(amt.Text);
                    double v3 = v1 * v2;
                     ttamt.Text = v3.ToString();
            }
        }

        private void sgr_TextChanged(object sender, EventArgs e)
        {
            if (sgr.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(sgr.Text);
                double v3 = v1 * v2 / 100;
                sga.Text = v3.ToString();
            }
            if (sgr.Text == String.Empty)
            {
               // double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(sga.Text);
                double v3 = 0 * v2;
                sga.Text = v3.ToString();
            }
        }

        private void cgr_TextChanged(object sender, EventArgs e)
        {
            if (cgr.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(cgr.Text);
                double v3 = v1 * v2 / 100;
               cga.Text = v3.ToString();
            }
            if (cgr.Text == String.Empty)
            {

                double v2 = double.Parse(cga.Text);
                double v3 = 0 * v2;
                cga.Text = v3.ToString();
            }
        }

        private void igr_TextChanged(object sender, EventArgs e)
        {
            if (igr.Text != String.Empty)
            {
               // double v1 = double.Parse(textBox4.Text);
               // double v2 = double.Parse(igr.Text);
               // double v3 = v1 * v2 / 100;
               //iga.Text = v3.ToString();

            }
            if (igr.Text == String.Empty)
            {
               
                //double v2 = double.Parse(iga.Text);
                //double v3 = 0* v2 ;
                //iga.Text = v3.ToString();
                //float v4 = float.Parse(grandtotal.Text);
                //float v5 = v4 * 0;
                //grandtotal.Text = v5.ToString();
            }
        }

        private void iga_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From ProductForm where ProductName='" + comboBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Type.Text = dr["Type"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert into Purchase (SupplierName,Address,ContactNo,GSTIN,Date,Net,SGSTR,CGSTR,IGSTR,SGSTA,CGSTA,IGSTA,GrandTotal,Ptotal,DisR,Dsblns) values (@SupplierName,@Address,@ContactNo,@GSTIN,@Date,@Net,@SGSTR,@CGSTR,@IGSTR,@SGSTA,@CGSTA,@IGSTA,@GrandTotal,@Ptotal,@DisR,@Dsblns)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@SupplierName", comboBox1.Text);

                cmd.Parameters.AddWithValue("@Address", Address.Text);
                cmd.Parameters.AddWithValue("@ContactNo", Contact.Text);
                cmd.Parameters.AddWithValue("@Date", date.Text);
                cmd.Parameters.AddWithValue("@GSTIN", GSTIN.Text);
              //  cmd.Parameters.AddWithValue("@ProductName", comboBox2.Text);
              //  cmd.Parameters.AddWithValue("@Qty", qty.Text);
              //  cmd.Parameters.AddWithValue("@Amount", amt.Text);
              //  cmd.Parameters.AddWithValue("@Total", ttamt.Text);
                // cmd.Parameters.AddWithValue("@LabourName", lbrname.Text);
                cmd.Parameters.AddWithValue("@Net",textBox1.Text);
                cmd.Parameters.AddWithValue("@SGSTR", sgr.Text);
                cmd.Parameters.AddWithValue("@CGSTR", cgr.Text);
                cmd.Parameters.AddWithValue("@IGSTR", igr.Text);
                cmd.Parameters.AddWithValue("@SGSTA", sga.Text);
                cmd.Parameters.AddWithValue("@CGSTA", cga.Text);
                cmd.Parameters.AddWithValue("@IGSTA", iga.Text);
                cmd.Parameters.AddWithValue("@GrandTotal", grandtotal.Text);
                cmd.Parameters.AddWithValue("@DisR", textBox2.Text);
                cmd.Parameters.AddWithValue("@Dsblns", textBox3.Text);
                cmd.Parameters.AddWithValue("@Ptotal", textBox4.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Entry Successfully Genreted");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from Purchase ", con);
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
                comboBox1.Text = "";
                Address.Text = "";
                date.Text = "";
                GSTIN.Text = "";
                
                sgr.Text = "0";
                sga.Text = "0";
                igr.Text = "0";
                iga.Text = "0";
                cgr.Text = "0";
                cga.Text = "0";
                grandtotal.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox1.Text = "0";


                



            }
            
        }
        
        private void grandtotal_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != String.Empty)
            {

                double v1 = double.Parse(textBox1.Text);
                double v2 = double.Parse(textBox2.Text);
                double v3 = v1 * v2 / 100;
                textBox3.Text = v3.ToString();
                double v4 = double.Parse(textBox3.Text);
                double v5 = v1 - v4;
                textBox4.Text = v5.ToString();



            }
            if (textBox2.Text == String.Empty)
            {

              //  double v1 = double.Parse(grandtotal.Text);
                double v2 = double.Parse(textBox3.Text);
                double v3 = v2 * 0;
                textBox3.Text = v3.ToString();
               double v4 = double.Parse(textBox3.Text);
                double v5 = 0 * v4;
               textBox4.Text = v5.ToString();



            }
        }

        private void qty_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (sgr.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(sgr.Text);
                double v3 = v1 * v2 / 100;
                sga.Text = v3.ToString();
            }
            if (sgr.Text == String.Empty)
            {
                // double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(sga.Text);
                double v3 = 0 * v2;
                sga.Text = v3.ToString();
            }
            if (cgr.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(cgr.Text);
                double v3 = v1 * v2 / 100;
                cga.Text = v3.ToString();
            }
            if (cgr.Text == String.Empty)
            {

                double v2 = double.Parse(cga.Text);
                double v3 = 0 * v2;
                cga.Text = v3.ToString();
            }
            if (igr.Text != String.Empty)
            {
                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(igr.Text);
                double v3 = v1 * v2 / 100;
                iga.Text = v3.ToString();
            }
            if (igr.Text == String.Empty)
            {

                double v2 = double.Parse(iga.Text);
                double v3 = 0 * v2;
                iga.Text = v3.ToString();
                float v4 = float.Parse(grandtotal.Text);
                float v5 = v4 * 0;
                grandtotal.Text = v5.ToString();
            }
        }

        private void qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
            if (qty.Text != String.Empty)
            {
                amt.Enabled = true;
            }
        }

        private void Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void amt_KeyPress(object sender, KeyPressEventArgs e)
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
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void sgr_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void cgr_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void igr_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cga_TextChanged(object sender, EventArgs e)
        {
            double v1 = double.Parse(textBox4.Text);
            double v2 = double.Parse(sga.Text);
            double v3 = double.Parse(cga.Text);
            //double v4 = double.Parse(iga.Text);
            double v5 = v1 + v2 + v3;
            grandtotal.Text = v5.ToString();
        }
    }
}
