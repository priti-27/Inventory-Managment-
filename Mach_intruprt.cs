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
    public partial class Mach_intruprt : Form
    {
        public Mach_intruprt()
        {
            InitializeComponent();
            ClassBind();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string StrSql = string.Empty;

        public void Cleare()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            Date.Text = "";
            Time.Text = "";
        
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


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mach_intruprt_Load(object sender, EventArgs e)
        {

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


        private void button1_Click (object sender, EventArgs e)
        {
            try
            {
                // use to insert data from respected fields to machineInfo table 
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                StrSql = "insert into inrupt (MachineName,Date,Time,Resion) values (@MachineName,@Date,@Time,@Resion)";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                cmd.Parameters.AddWithValue("@MachineName", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", Date.Text);
                cmd.Parameters.AddWithValue("@Time", Time.Text);
                cmd.Parameters.AddWithValue("@Resion", textBox1.Text);

               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Entry Created");
                //DataTable dt = new DataTable();
                //da = new SqlDataAdapter("select * from machineInfo ", con);
                //da.Fill(dt);
                //dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
               Cleare();

            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {


           
        }

        private void Mach_intruprt_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.A && e.Control) 
            //{
            //    try
            //    {
            //        // use to insert data from respected fields to machineInfo table 
            //        StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //        con = new SqlConnection(StrSql);
            //        con.Open();
            //        StrSql = "insert into inrupt (MachineName,Date,Time,Resion) values (@MachineName,@Date,@Time,@Resion)";
            //        SqlCommand cmd = new SqlCommand(StrSql, con);
            //        cmd.Parameters.AddWithValue("@MachineName", comboBox1.Text);
            //        cmd.Parameters.AddWithValue("@Date", Date.Text);
            //        cmd.Parameters.AddWithValue("@Time", Time.Text);
            //        cmd.Parameters.AddWithValue("@Resion", textBox1.Text);


            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Entry Created");
            //        //DataTable dt = new DataTable();
            //        //da = new SqlDataAdapter("select * from machineInfo ", con);
            //        //da.Fill(dt);
            //        //dataGridView1.DataSource = dt;

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //        Cleare();

            //    }
            }
        }
    }

