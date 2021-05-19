using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassSanPham
    {
        ConnectionDB cndb = new ConnectionDB();

        public DataSet ds_QLXEMAY = new DataSet();


        public void LoadSANPHAM(DataGridView data)
        {
            string CauLenh = "SELECT * FROM SANPHAM";
            SqlDataAdapter da_SANPHAM = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_SANPHAM.Fill(ds_QLXEMAY, "SANPHAM");
            data.DataSource = ds_QLXEMAY.Tables["SANPHAM"];

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_QLXEMAY.Tables["SANPHAM"].Columns[0];
            ds_QLXEMAY.Tables["SANPHAM"].PrimaryKey = key;
        }
        //Load san phẩm giao diện khách hàng
        public void LoadSANPHAMKHACH(DataGridView data)
        {
            string CauLenh = "SELECT MASP AS N'Mã xe', TENSP AS N'Tên xe',DVT AS N'Đơn vị tính',DONGIABAN N'Giá bán' FROM SANPHAM";
            SqlDataAdapter da_SANPHAM = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_SANPHAM.Fill(ds_QLXEMAY, "SANPHAM");
            data.DataSource = ds_QLXEMAY.Tables["SANPHAM"];
        }
        public void LoadMancc(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM NHACUNGCAP";
            SqlDataAdapter da_SANPHAM = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_SANPHAM.Fill(ds_QLXEMAY, "NHACUNGCAP");
            cb.DataSource = ds_QLXEMAY.Tables["NHACUNGCAP"];
            cb.DisplayMember = "TENNCC";
            cb.ValueMember = "MANCC";
        }
        public void LoadComboMaSanPham(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM SANPHAM";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SANPHAM");

            cb.DataSource = ds.Tables["SANPHAM"];
            cb.DisplayMember = "TENSP";
            cb.ValueMember = "MASP";
        }
        public string GiaBanCuaSanPham(ComboBox cb)
        {
            cndb.Open();
            string a = "";
            string CauLenh = "SELECT DONGIABAN FROM SANPHAM WHERE MASP='" + cb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(CauLenh, cndb.cnn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a = rd["DONGIABAN"].ToString();
            } rd.Close();
            cndb.Close();
            return a;

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
        public bool Xoa(DataGridView data)
        {
            try
            {
                cndb.Open();
                string CauLenh = "SELECT COUNT(*) FROM SANPHAM WHERE MASP='" + data.CurrentRow.Cells[0].ToString() + "'";

                SqlCommand cmd = new SqlCommand(CauLenh, cndb.cnn);

                int count = (int)cmd.ExecuteScalar();

                cndb.Close();

                if (count >= 1)
                {
                    return false;
                }
                else
                {
                    foreach (DataGridViewRow item in data.SelectedRows)
                    {
                        data.Rows.RemoveAt(item.Index);
                    }
                    return true;
                }

            }
            catch
            {
                return false;
            }







        }
        //public void LayDuLieu(TextBox txt)
        //{
        //    DataRow i = ds_QLXEMAY.Tables["SANPHAM"].Rows.Find(txt);
        //    if (i != null)
        //    {
        //        string a = i.ToString();
        //        MessageBox.Show(a);
        //    }
        //}

        public void Load()
        {
            string CauLenh = "SELECT * FROM SANPHAM";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);

            da.Update(ds_QLXEMAY, "SANPHAM");

        }

        public void TimKiemSP(DataGridView data, string tenxe)
        {

            string CauLenh = "SELECT * FROM SANPHAM WHERE TENSP = '" + tenxe + "'";

            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);

            DataSet ds = new DataSet();
            da.Fill(ds, "SANPHAM");

            data.DataSource = ds.Tables["SANPHAM"];

        }
    }
}
