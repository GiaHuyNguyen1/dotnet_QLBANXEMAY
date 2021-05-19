using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace test1
{
    public class ConnectionDB
    {
        public SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-3JOF3O8\\SQLEXPRESS;Initial Catalog=QLXEMAY2;User ID=sa;Password=sa2012");

        public void Open()
        {
            cnn.Open();
        }
        public void Close()
        {
            cnn.Close();
        }
        string _TenMay;

        public string TenMay
        {
            get { return _TenMay; }
            set { _TenMay = value; }
        }
        string _TenSQL;

        public string TenSQL
        {
            get { return _TenSQL; }
            set { _TenSQL = value; }
        }
        
        public void KhoiTao()
        {
            cnn = new SqlConnection("Data Source=" + TenMay + ";Initial Catalog=" + TenSQL + ";Integrated Security=True");
        }

        public bool KetNoi(string TM, string TS)
        {
            _TenMay = TM;
            _TenSQL = TS;
           
            KhoiTao();

            try
            {
                cnn.Open();
                cnn.Close();
                return true;

            }
            catch { return false; }


        }
        
    }
}
