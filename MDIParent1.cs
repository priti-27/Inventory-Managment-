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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        string StrSql = string.Empty;
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
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

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void supplierFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierForm sf = new SupplierForm();
            sf.ShowDialog();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Master pm = new Product_Master();
            pm.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase();
            p.ShowDialog();
        }

        private void addMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 mm = new Form1();
            mm.ShowDialog();
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MachineInfo mi = new MachineInfo();
            mi.ShowDialog();
        }

        private void orderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm();
            of.ShowDialog();
        }

        private void orderListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OrderList ol = new OrderList();
            ol.ShowDialog();
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sale s = new Sale();
            s.ShowDialog();
        }

        private void forgotPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forget_password fp = new forget_password();
            fp.ShowDialog();
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registration_form rf = new registration_form();
            rf.ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            expences exp = new expences();
            exp.ShowDialog();
        }

        private void employeeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_profile ep = new employee_profile();
            ep.ShowDialog();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_attendace ea = new employee_attendace();
            ea.ShowDialog();
        }

        private void reportFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label1.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From  machineInfo where Ltr ='" + label2.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label3.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox3.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label4.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox4.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label5.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox5.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From  machineInfo where Ltr ='" + label6.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox6.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From  machineInfo where Ltr ='" + label7.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox7.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label8.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox8.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From machineInfo where Ltr ='" + label9.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox9.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From  machineInfo where Ltr ='" + label10.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox10.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }
            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                // StrSql = "update Stock SET Iteam_Name=@Iteam_Name, Category=@Category, PurchasedUnit=@Purchased_Unit,Used_Unit=@Used_Unit,Avalible_Unit=@Avalible_Unit Where Category='"+ cmbcat+"' AND Iteam"
                StrSql = "select * From  machineInfo where Ltr ='" + label11.Text + "'";
                SqlCommand cmd = new SqlCommand(StrSql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox11.Text = dr["AvaliableStock"].ToString();

                        // textBox10.Text = dr["igstr"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { }

            try
            {
                StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                con = new SqlConnection(StrSql);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select Machine,Stock from machine ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            StrSql = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(StrSql);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Machine,Stock from machine ", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCustomer nec = new NewCustomer();
            nec.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Due d = new Due();
            d.ShowDialog();
        }

        private void complitedOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplitedOrder co = new ComplitedOrder();
            co.ShowDialog();

        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReport pr = new PurchaseReport();
            pr.ShowDialog();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReport sr = new SaleReport();
            sr.ShowDialog();
        }

        private void expensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensesReport er = new ExpensesReport();
            er.ShowDialog();
        }

        private void salaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryReport sr = new SalaryReport();
            sr.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.ShowDialog();
        }

        private void machineIntraptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mach_intruprt mc = new Mach_intruprt();
            mc.ShowDialog();
        }

        private void searchByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchStockByProduct spd = new SearchStockByProduct();
            spd.ShowDialog();
        }

        private void productReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnANd_damage rd = new ReturnANd_damage();
            rd.ShowDialog();
        }

        private void creditCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credit cd = new Credit();
            cd.ShowDialog();
        }

        private void productionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionReport pr = new ProductionReport();
            pr.ShowDialog();
        }

        private void withoutGSTBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            withoutgstbill wgb = new withoutgstbill();
            wgb.ShowDialog();

        }

        private void searchByCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCustomar sc = new SearchCustomar();
            sc.ShowDialog();
        }

        private void weightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Weight we = new Weight();
            we.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
