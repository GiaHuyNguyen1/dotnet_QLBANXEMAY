using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassBanHang
    {
        ConnectionDB cndb = new ConnectionDB();
        public DataSet ds_XeMay = new DataSet();
        public void LoadComboBoxPhieuBanHang1(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM PHIEUBANHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
           
            da.Fill(ds_XeMay, "PHIEUBANHANG");

            cb.DataSource = ds_XeMay.Tables["PHIEUBANHANG"];
            cb.DisplayMember = "MAPHIEUBAN";
            cb.ValueMember = "MAPHIEUBAN";

        }
        public void LoadComboBoxPhieuBanHang(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM PHIEUBANHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh,cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"PHIEUBANHANG");

            cb.DataSource = ds.Tables["PHIEUBANHANG"];
            cb.DisplayMember = "MAPHIEUBAN";
            cb.ValueMember = "MAPHIEUBAN";

        }

        public void LoadDataChiTietPhieuNhap(DataGridView data)
        {
            string CauLenh = "Select * from CHITIETPHIEUBANHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh,cndb.cnn);
            DataSet ds = new DataSet();
            da.Fill(ds,"CHITIETPHIEUBANHANG");

            data.DataSource = ds.Tables["CHITIETPHIEUBANHANG"];
        }

        public bool TaoPhieuBanHang(string pMaPhieuBan, string pNgayNhap, string pMaKhach)
        {
            try
            {
                string CauLenh = "SELECT * FROM PHIEUBANHANG";
                SqlDataAdapter da_PhieuNhap = new SqlDataAdapter(CauLenh, cndb.cnn);
                DataSet ds_PhieuNhap = new DataSet();
                da_PhieuNhap.Fill(ds_PhieuNhap, "PHIEUBANHANG");

                DataRow TPN = ds_PhieuNhap.Tables["PHIEUBANHANG"].NewRow();

                TPN["MAPHIEUBAN"] = pMaPhieuBan;
                TPN["NGAYPHIEUBAN"] = pNgayNhap;
                TPN["MAKHACH"] = pMaKhach;


                ds_PhieuNhap.Tables["PHIEUBANHANG"].Rows.Add(TPN);

                SqlCommandBuilder cb = new SqlCommandBuilder(da_PhieuNhap);

                da_PhieuNhap.Update(ds_PhieuNhap, "PHIEUBANHANG");

                return true;
            }
            catch { return false; }
        }

        public void Them(ComboBox bx, string MaSP, string DonGia, string SoLuong,string MaKho)
        {

            string CauLenh = "SELECT * FROM CHITIETPHIEUBANHANG";
            SqlDataAdapter da_ChiTietPhieuNhap = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_ChiTietPhieuBan= new DataSet();
            da_ChiTietPhieuNhap.Fill(ds_ChiTietPhieuBan, "CHITIETPHIEUBANHANG");

            string a = bx.SelectedValue.ToString().Trim();
            DataRow them = ds_ChiTietPhieuBan.Tables["CHITIETPHIEUBANHANG"].NewRow();

            them["MAPHIEUBAN"] = a;
            them["MASP"] = MaSP;
            them["SOLUONG"] = SoLuong;
            them["DONGIA"] = DonGia;
            them["MAKHO"] = MaKho;
            ds_ChiTietPhieuBan.Tables["CHITIETPHIEUBANHANG"].Rows.Add(them);

            SqlCommandBuilder cb = new SqlCommandBuilder(da_ChiTietPhieuNhap);

            da_ChiTietPhieuNhap.Update(ds_ChiTietPhieuBan, "CHITIETPHIEUBANHANG");





        }
        public bool LuuPhieuBanHang(string pMaPhieuBan, string ThanhTien)
        {
            try
            {
                string CauLenh = "SELECT * FROM PHIEUBANHANG";
                SqlDataAdapter da_PhieuBan = new SqlDataAdapter(CauLenh, cndb.cnn);
                DataSet ds_PhieuBan = new DataSet();
                da_PhieuBan.Fill(ds_PhieuBan, "PHIEUBANHANG");

                DataColumn[] key = new DataColumn[1];
                key[0] = ds_PhieuBan.Tables["PHIEUBANHANG"].Columns[0];
                ds_PhieuBan.Tables["PHIEUBANHANG"].PrimaryKey = key;

                DataRow TPN = ds_PhieuBan.Tables["PHIEUBANHANG"].Rows.Find(pMaPhieuBan);
                if (TPN != null)
                {
                    TPN["TONGTIEN"] = ThanhTien;
                }





                SqlCommandBuilder cb = new SqlCommandBuilder(da_PhieuBan);

                da_PhieuBan.Update(ds_PhieuBan, "PHIEUBANHANG");
                return true;
            }
            catch { return false; }
        }
    }
}
