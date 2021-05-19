using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassKho
    {
        ConnectionDB cndb = new ConnectionDB();
        public DataSet ds_XeMay = new DataSet();
        public void LoadKho(DataGridView data)
        {
            string CauLenh = "SELECT * FROM KHO";
            SqlDataAdapter da_Khach = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khach.Fill(ds_XeMay, "KHO");
            data.DataSource = ds_XeMay.Tables["KHO"];
        }
        public void Load()
        {
            string CauLenh = "SELECT * FROM KHO";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);

            da.Update(ds_XeMay, "KHO");

        }
        public bool ThayNguoiDaiDien(string pMaKho,string pNguoiDaiDien)
        {
            try 
            {
                cndb.Open();
                string CauLenh = "SP_CAPNHATKHO '" + pMaKho + "','" + pNguoiDaiDien + "'";
                SqlCommand cmd = new SqlCommand(CauLenh, cndb.cnn);
                cmd.ExecuteNonQuery();
                cndb.Close();
                return true;
            }
            catch { return false; }

        }
        public string LayNguoiDD(DataGridView data)
        {

            
            string nguoidd = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;                      
                        if (index == 3)
                        {
                            nguoidd = cell.Value.ToString();
                            //do what you want with the value
                        }
                        
                    }
                }
            } return nguoidd;
        }
        public void UpdateNguoiDD(DataGridView data,string nguoidd)
        {
       
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        if (index == 3)
                        {
                            cell.Value =nguoidd ;
                            //do what you want with the value
                        }

                    }
                }
            } 
        }
        public string LayMaKho(DataGridView data)
        {

            string makho = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        if (index == 0)
                        {
                            makho = cell.Value.ToString();
                            //do what you want with the value
                        }
                    }
                }
            } return makho;
        }

        public void SOLUONGHANGTRONGKHO(DataGridView data)
        {
            string CauLenh = "SELECT SANPHAM.MASP AS N'Mã sản phẩm',TENSP AS N'Tên sản phẩm',DVT AS N'Đơn vị tính' ,GHICHU AS N'Ghi chú',MAKHO AS N'Mã kho',SOLUONGTON AS N'Số lượng tồn' FROM SANPHAM,CHITIETKHO WHERE SANPHAM.MASP = CHITIETKHO.MASP";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh,cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"SANPHAM,CHITIETKHO");
            data.DataSource = ds.Tables["SANPHAM,CHITIETKHO"];
        }

        public void LoadComboKho(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM KHO";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh,cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"KHO");
            cb.DataSource = ds.Tables["KHO"];
            cb.DisplayMember = "TENKHO";
            cb.ValueMember = "MAKHO";
        }

        public void LoadHangTonKhoTheoCombo(ComboBox cb,DataGridView data)
        {
            string a= cb.SelectedValue.ToString();
            string CauLenh = "SELECT SANPHAM.MASP AS N'Mã sản phẩm',TENSP AS N'Tên sản phẩm',DVT AS N'Đơn vị tính',DONGIABAN AS N'Đơn giá bán',DONGIAMUA AS N'Đơn giá mua',GHICHU AS N'Ghi chú',MAKHO AS N'Mã kho',SOLUONGTON AS N'Số lượng tồn' FROM SANPHAM,CHITIETKHO WHERE SANPHAM.MASP = CHITIETKHO.MASP AND MAKHO ='"+a+"'";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SANPHAM,CHITIETKHO");
            data.DataSource = ds.Tables["SANPHAM,CHITIETKHO"];
        }
    }
}
