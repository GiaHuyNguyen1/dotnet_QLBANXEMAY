using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassTaiKhoan
    {
        ConnectionDB cndb = new ConnectionDB();

        //DataSet
        public DataSet ds_XeMay = new DataSet();
        
        public void LoadACC(DataGridView data)
        {
            string CauLenh = "SELECT * FROM ACCOUNT";
            SqlDataAdapter da_SinhVien = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_SinhVien.Fill(ds_XeMay, "ACCOUNT");
            data.DataSource = ds_XeMay.Tables["ACCOUNT"];

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_XeMay.Tables["ACCOUNT"].Columns[0];
            ds_XeMay.Tables["ACCOUNT"].PrimaryKey = key;

        }

        public void LoadLoaiTK(ComboBox cb)
        {


            string CauLenh = "SELECT * FROM LOAITK";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khoa.Fill(ds_XeMay, "LOAITK");
            cb.DataSource = ds_XeMay.Tables["LOAITK"];
            cb.DisplayMember = "TENLOAI";
            cb.ValueMember = "MALOAI";
        }
        
        
        public bool Load()
        {
            try 
            {
                string CauLenh = "SELECT * FROM ACCOUNT";
                SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);

                da.Update(ds_XeMay, "ACCOUNT");
                return true;
            }
            catch { return false; }

        }
        public void Sua(DataGridView data)
        {
            data.ReadOnly = false;
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                data.Rows[i].ReadOnly = false;
            }
            //data.Columns[0].ReadOnly = true;
            data.AllowUserToAddRows = false;

        }
        public void Them(DataGridView data)
        {
           
            data.AllowUserToAddRows = true;
            data.ReadOnly = false;
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                data.Rows[i].ReadOnly = true;
            }
            data.FirstDisplayedScrollingRowIndex = data.Rows.Count - 1;
        }

        public void Xoa(DataGridView data)
        {
            foreach (DataGridViewRow item in data.SelectedRows)
            {
                data.Rows.RemoveAt(item.Index);
            }


            //if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ACCOUNT WHERE MAACC='" + a + "'", cndb.cnn);
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        MessageBox.Show("Dữ liệu đang được sử dụng không thế xóa");
            //        return;
            //    }
            //    DataRow up = ds_XeMay.Tables["ACCOUNT"].Rows.Find(a);
            //    if (up != null)
            //    {
            //        up.Delete();
            //    }
            //    SqlCommandBuilder bd = new SqlCommandBuilder(da);
            //    da.Update(ds_XeMay, "ACCOUNT");




            //    MessageBox.Show("Thanh cong");
            //}


        }
    }
}
