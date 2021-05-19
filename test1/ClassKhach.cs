using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassKhach
    {
        ConnectionDB cndb = new ConnectionDB();

        public DataSet ds_XeMay = new DataSet();

        public void LoadKhach(DataGridView data)
        {
            string CauLenh = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da_Khach = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khach.Fill(ds_XeMay, "KHACHHANG");
            data.DataSource = ds_XeMay.Tables["KHACHHANG"];
        }

        public void LoadKhachCombo(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh,cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"KHACHHANG");
            cb.DataSource = ds.Tables["KHACHHANG"];
            cb.DisplayMember = "TENKHACH";
            cb.ValueMember = "MAKHACH";
        }


        public void Load()
        {
            string CauLenh = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);

            da.Update(ds_XeMay, "KHACHHANG");

        }
        public void Sua(DataGridView data)
        {
            data.ReadOnly = false;
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                data.Rows[i].ReadOnly = false;
            }
            data.Columns[0].ReadOnly = true;
            data.AllowUserToAddRows = false;

        }
        public void Them(DataGridView data)
        {
            data.Columns[0].ReadOnly = false;
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
        }

        

       

        
    }
}
