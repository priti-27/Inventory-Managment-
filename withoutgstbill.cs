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
    public partial class withoutgstbill : Form
    {
        public withoutgstbill()
        {
            InitializeComponent();
            ClassBind2();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string StrSql = string.Empty;

        public void Cleare()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            untltr.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox2.Text = "";
        
        }
        public void CleareA()
        {
            //textBox1.Text = "";
           // textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
          //  textBox7.Text = "";
          //  textBox8.Text = "";
         //   textBox9.Text = "";
         //   textBox10.Text = "";
            untltr.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox2.Text = "";

        }

        public void ClassBind2()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  grm";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "grm" };
                    dt.Rows.InsertAt(dr, 0);

                    comboBox4.ValueMember = "Id";


                    comboBox4.DisplayMember = "grm";
                    comboBox4.DataSource = dt;
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

        private void withoutgstbill_Load(object sender, EventArgs e)
        {

            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From tempbill where id=(SELECT max(id) FROM tempbill)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox23.Text = dr["OrderNo"].ToString();
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
                try
                {
                    int A = int.Parse(textBox23.Text);
                    int B = int.Parse(textBox22.Text);
                    int C = A + B;
                    textBox21.Text = C.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "insert into tempbill (Name,Address,date,OrderNo,HSN,Ltr,Color,Shape,Weight,qty,amt ,Total,Nettotal,dis,disa,GrandTotal) values(@Name,@Address,@date,@OrderNo,@HSN,@Ltr,@Color,@Shape,@Weight,@qty,@amt,@Total,@Nettotal,@dis,@disa,@GrandTotal)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                cmd.Parameters.AddWithValue("@HSN", textBox3.Text);
                cmd.Parameters.AddWithValue("@qty", textBox4.Text);
                cmd.Parameters.AddWithValue("@amt", textBox5.Text);
                cmd.Parameters.AddWithValue("@Total", textBox6.Text);
                cmd.Parameters.AddWithValue("@Nettotal", textBox7.Text);
                cmd.Parameters.AddWithValue("@dis", textBox8.Text);
                cmd.Parameters.AddWithValue("@disa", textBox9.Text);
                cmd.Parameters.AddWithValue("@GrandTotal", textBox10.Text);
               // cmd.Parameters.AddWithValue("@word", textBox10.Text);
                cmd.Parameters.AddWithValue("@OrderNo", textBox21.Text);
                cmd.Parameters.AddWithValue("@Ltr", untltr.Text);
                cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Weight", comboBox4.Text);
                cmd.Parameters.AddWithValue("@date", dtp.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Memo Created");
            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            finally {

                con.Close();
                Cleare();
                WithoutGstBillreport we = new WithoutGstBillreport();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != String.Empty){

                double v1 = double.Parse(textBox4.Text);
                double v2 = double.Parse(textBox5.Text);
                double v3 = v1 * v2;
                textBox6.Text = v3.ToString();
            }

            if (textBox5.Text == String.Empty)
            {
                double v4 = double.Parse(textBox6.Text);
                double v5 = v4 * 0;
                textBox6.Text = v5.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox6.Text != String.Empty){

                double v1 = double.Parse(textBox6.Text);
                double v2 = double.Parse(textBox7.Text);
                double v3 = v1 + v2;
                textBox7.Text = v3.ToString();
            }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Close();
                con.Open();
                StrSql = "insert into tempbill (Name,Address,date,OrderNo,HSN,Ltr,Color,Shape,Weight,qty,amt ,Total) values(@Name,@Address,@date,@OrderNo,@HSN,@Ltr,@Color,@Shape,@Weight,@qty,@amt,@Total)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                cmd.Parameters.AddWithValue("@HSN", textBox3.Text);
                cmd.Parameters.AddWithValue("@qty", textBox4.Text);
                cmd.Parameters.AddWithValue("@amt", textBox5.Text);
                cmd.Parameters.AddWithValue("@Total", textBox6.Text);
               // cmd.Parameters.AddWithValue("@Nettotal", textBox6.Text);
               // cmd.Parameters.AddWithValue("@dis", textBox7.Text);
               // cmd.Parameters.AddWithValue("@disa", textBox8.Text);
                //cmd.Parameters.AddWithValue("@GrandTotal", textBox9.Text);
               // cmd.Parameters.AddWithValue("@word", textBox10.Text);
                cmd.Parameters.AddWithValue("@OrderNo", textBox21.Text);
                cmd.Parameters.AddWithValue("@Ltr", untltr.Text);
                cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Weight", comboBox4.Text);
                cmd.Parameters.AddWithValue("@date", dtp.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Can added into the Memo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
                CleareA();
            }
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != String.Empty)
            {

                double v1 = double.Parse(textBox7.Text);
                double v2 = double.Parse(textBox8.Text);
                double v3 = v1 * v2/100;
                textBox9.Text = v3.ToString();
                double v4 = double.Parse(textBox9.Text);
                double v5 = v1 - v4;
                textBox10.Text = v5.ToString();
            }
            if (textBox8.Text == String.Empty)
            {
                double v4 = double.Parse(textBox9.Text);
                double v5 = v4 * 0;
                textBox9.Text = v5.ToString();
                
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}