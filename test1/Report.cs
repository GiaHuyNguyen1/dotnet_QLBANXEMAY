using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        ConnectionDB cnn = new ConnectionDB();
        ClassKho kho = new ClassKho();
        private void Report_Load(object sender, EventArgs e)
        {
            kho.LoadComboKho(comboBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 rp = new CrystalReport1();
            crystalReportViewer1.ReportSource = rp;

            rp.SetDatabaseLogon("sa","sa2012","DESKTOP-3JOF3O8\\SQLEXPRESS","QLXEMAY2");

            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrystalReport2 rp = new CrystalReport2();
            crystalReportViewer1.ReportSource = rp;

            rp.SetDatabaseLogon("sa", "sa2012", "DESKTOP-3JOF3O8\\SQLEXPRESS", "QLXEMAY2");

            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
        public DataTable layBang(string CauLenh)
        {
            DataTable bang = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(CauLenh, cnn.cnn);
                DataSet ds = new DataSet();
                da.Fill(bang);
            }
            catch(System.Exception)
            {
                bang = null;
            }
            finally {
                cnn.Close();
            } return bang;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = layBang("SELECT * FROM CHITIETKHO WHERE MaKho='"+comboBox1.SelectedValue.ToString()+"'");

             CrystalReport3 rp = new CrystalReport3();

             rp.SetDataSource(tb);
             crystalReportViewer1.ReportSource = rp;
        }
    }
}
