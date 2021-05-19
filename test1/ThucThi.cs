using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ThucThi
    {
        ConnectionDB cndb = new ConnectionDB();
        public bool ThemAcc(string MaKhach, string TenKhach, string DiaChi, string SDT, string Email, string MaLoai)
        {
            try
            {
                cndb.Open();
                string CauLenh = "INSERT INTO ACCOUNT VALUES ('" + MaKhach + "','" + TenKhach + "','" + MaKhach + "','" + Email + "','" + SDT + "','" + DiaChi + "','" + MaLoai + "')";
                SqlCommand cmd = new SqlCommand(CauLenh, cndb.cnn);


                cmd.ExecuteNonQuery();
                cndb.Close();
                return true;
            }
            catch {return false; }
        }

        public void LayThongTin(DataGridView data)
        {
            
        }
    }
}
