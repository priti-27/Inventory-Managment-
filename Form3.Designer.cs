namespace Golddi_Industries
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gudduDataSet2 = new Golddi_Industries.gudduDataSet2();
            this.employee_profileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employee_profileTableAdapter = new Golddi_Industries.gudduDataSet2TableAdapters.employee_profileTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gudduDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_profileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.employee_profileBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Golddi_Industries.Report7.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(98, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // gudduDataSet2
            // 
            this.gudduDataSet2.DataSetName = "gudduDataSet2";
            this.gudduDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employee_profileBindingSource
            // 
            this.employee_profileBindingSource.DataMember = "employee_profile";
            this.employee_profileBindingSource.DataSource = this.gudduDataSet2;
            // 
            // employee_profileTableAdapter
            // 
            this.employee_profileTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 329);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gudduDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employee_profileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource employee_profileBindingSource;
        private gudduDataSet2 gudduDataSet2;
        private gudduDataSet2TableAdapters.employee_profileTableAdapter employee_profileTableAdapter;
    }
}