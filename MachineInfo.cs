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
using System.IO;

namespace Golddi_Industries
{
    public partial class MachineInfo : Form
    {
        public MachineInfo()
        {
            InitializeComponent();
            ClassBind();
            ClassBind2();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        string ImgPath = "";
        byte[] Data = null;

        public void Cleare()
        {
            comboBox1.Text = "";
            Id.Text = "";
            mntype.Text = "";
            mnumber.Text = "";
            Date.Text = "";
            Time.Text = "";
            lbrname.Text = "";
            untltr.Text = "";
            unit.Text = "0";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";

        
        }
        // keypress event for: Close Button On Pressing esc
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //bind machine name from machine table
        public void ClassBind()
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  machine";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "Machine" };
                    dt.Rows.InsertAt(dr, 0);

                   comboBox1.ValueMember = "Id";


                   comboBox1.DisplayMember = "Machine";
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
        //selecting name show machine info wher control match the value of combobox and show result
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                DataRow dr;
                StrSql = "select * from  Ltr Where Name ='" + comboBox1.Text + "' ";
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                    cmd = new SqlCommand(StrSql, con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { 0, "Ltr" };
                    dt.Rows.InsertAt(dr, 0);

                    untltr.ValueMember = "Id";


                    untltr.DisplayMember = "Ltr";
                    untltr.DataSource = dt;
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

            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machine where Machine='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // here left side is have field in that right side database value will be featch
                        Id.Text = dr["Id"].ToString();
                        mntype.Text = dr["Type"].ToString();
                        mnumber.Text = dr["MachineNo"].ToString();
                        textBox4.Text = dr["Description"].ToString();
                       // textBox5.Text = dr["Stock"].ToString();
                       // This syntax is used to featch the image 


                        byte[] images = ((byte[])dr[4]);// here dr[4] 4 is a collumn number 
                        if (images == null)
                        {
                            pictureBox1.Image = null;

                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(images);
                            pictureBox1.Image = Image.FromStream(ms);
                        }



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
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select Stock From machine where  Machine='" + comboBox1.Text + "' AND  Date ='" + Date.Text + "' ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // here left side is have field in that right side database value will be featch
                        //Id.Text = dr["Id"].ToString();
                        //mntype.Text = dr["Type"].ToString();
                        //mnumber.Text = dr["MachineNo"].ToString();
                      
                        textBox5.Text = dr["Stock"].ToString();
                        // This syntax is used to featch the image 


                        //byte[] images = ((byte[])dr[4]);// here dr[4] 4 is a collumn number 
                        //if (images == null)
                        //{
                        //    pictureBox1.Image = null;

                        //}
                        //else
                        //{
                        //    MemoryStream ms = new MemoryStream(images);
                        //    pictureBox1.Image = Image.FromStream(ms);
                        //}



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
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        // using this query table machineinfo loded into the  dataGridView1
        private void MachineInfo_Load(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from machineInfo  ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();

            }
            //here we use Logical opretor 'AND' which help yo featch data from machineinfo 
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' AND Ltr='" + untltr.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                       // textBox2.Text = dr["ctotal"].ToString();
                         textBox3.Text = dr["ActualStock"].ToString();



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

        private void unit_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (unit.Text != String.Empty)
            {
                float v1 = float.Parse(unit.Text);
                float v2 = float.Parse(textBox2.Text);
                float v3 = v1 + v2;
                textBox2.Text = v3.ToString();// Show the current day Stock
                float v4 = float.Parse(textBox3.Text);
                float v5 = v1 + v4;
                textBox3.Text = v5.ToString();// Show allover Stock
                float v7 = float.Parse(textBox1.Text);
                float v6 = v1 + v7;
                textBox1.Text = v6.ToString();
                float v9 = float.Parse(unit.Text);
                float v8 = float.Parse(textBox5.Text);
                float v10 = v8 + v9;
                textBox5.Text = v10.ToString();

                // Show stock depending of Can in ltr
                //untltr.Text = "";
                //unit.Text = "0";
                //textBox1.Text = "0";
                //textBox2.Text = "0";
                //textBox3.Text = "0";





            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // use to insert data from respected fields to machineInfo table 
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert into machineInfo (MachineName,MachineNo,Type,Date,Time,Ltr,Unit,Ctotal,ActualStock,LabourName,AvaliableStock,Color,Shape,Weight) values (@MachineName,@MachineNo,@Type,@Date,@Time,@Ltr,@Unit,@Ctotal,@ActualStock,@LabourName,@AvaliableStock,@Color,@Shape,@Weight)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@MachineName", comboBox1.Text);
               
                cmd.Parameters.AddWithValue("@MachineNo", mnumber.Text);
                cmd.Parameters.AddWithValue("@Type", mntype.Text);
                cmd.Parameters.AddWithValue("@Date", Date.Text);
                cmd.Parameters.AddWithValue("@Time", Time.Text);
                cmd.Parameters.AddWithValue("@Ltr", untltr.Text);
                cmd.Parameters.AddWithValue("@Unit", unit.Text);
                cmd.Parameters.AddWithValue("@Ctotal", textBox2.Text);
                cmd.Parameters.AddWithValue("@ActualStock", textBox3.Text);
                cmd.Parameters.AddWithValue("@LabourName", lbrname.Text);
                cmd.Parameters.AddWithValue("@AvaliableStock", textBox1.Text);
                cmd.Parameters.AddWithValue("@Color", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Shape", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Weight", comboBox4.Text);
               // cmd.Parameters.AddWithValue("@MachStock", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("can added into the Stock");
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select * from machineInfo ", con);
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
               // Cleare();
              
            }
            try
            {

                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "insert into machine (Machine,MachineNo,Type,Image,Description) values (@MachineName,@MachineNo,@Type,@Image,@Description)";
                StrSql = "update machine set  Stock=@Stock,Date=@Date Where Machine='" + comboBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
              //  cmd.Parameters.AddWithValue("@Machine", textBox1.Text);
                cmd.Parameters.AddWithValue("@Stock", textBox5.Text);
                cmd.Parameters.AddWithValue("@Date", Date.Text);
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
                // MessageBox.Show("Data Updated");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                // Cleare();
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
               // textBox5.Text = "0";
                untltr.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
                lbrname.Text = "";
                unit.Text = "0";

            }
        }
        //selecting ltr show actual stock and current stock
        private void untltr_SelectedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //    con = new SqlConnection(StrSql);
            //    con.Open();
            //    // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
            //    StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' AND Ltr='" + untltr.Text + "' AND Date='" + Date.Text + "'";
            //    SqlCommand cmd = new SqlCommand(StrSql, con);
            //    dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {

            //            textBox2.Text = dr["ctotal"].ToString();
            //           // textBox3.Text = dr["ActualStock"].ToString();



            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //    con.Close();

            //}
            //try
            //{
            //    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //    con = new SqlConnection(StrSql);
            //    con.Open();
            //    // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
            //    StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' AND Ltr='" + untltr.Text + "'";
            //    SqlCommand cmd = new SqlCommand(StrSql, con);
            //    dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {

            //            // textBox2.Text = dr["ctotal"].ToString();
            //            textBox3.Text = dr["ActualStock"].ToString();



            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //    con.Close();

            //}
            //// show stock depending on can in ltr
            //try
            //{
            //    StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //    con = new SqlConnection(StrSql);
            //    con.Open();
            //    // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
            //    StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "'";
            //    SqlCommand cmd = new SqlCommand(StrSql, con);
            //    dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {

            //            textBox1.Text = dr["AvaliableStock"].ToString();
            //            // textBox3.Text = dr["ActualStock"].ToString();



            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //    con.Close();

            //}
        }
        // validation for non numaric entry [to do this first goto properties then select events and click on keypress event]then write code
        private void lbrname_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }

        // validation for only numaric entry [to do this first goto properties then select events and click on keypress event]then write code
        private void unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;


            if (char.IsDigit(e.KeyChar) == false && Convert.ToInt32(e.KeyChar) != 8)
            {
                MessageBox.Show("Enter Numeric Value Only");
                e.Handled = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == String.Empty)
            {
                textBox5.Text = "0";
            
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' ANd Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "' AND Date='" + Date.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox2.Text = dr["ctotal"].ToString();
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
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' ANd Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "' ";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        //textBox2.Text = dr["ctotal"].ToString();
                        textBox3.Text = dr["ActualStock"].ToString();



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

            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                // StrSql = "select * From machineInfo where  Ltr='" + untltr.Text + "'";
                StrSql = "select * From machineInfo where MachineName='" + comboBox1.Text + "' ANd Ltr='" + untltr.Text + "' AND  Shape ='" + comboBox2.Text + "' AND Color='" + comboBox3.Text + "' AND Weight='" + comboBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        textBox1.Text = dr["AvaliableStock"].ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
