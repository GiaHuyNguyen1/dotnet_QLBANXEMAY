using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    class ClassNhapHang
    {
        ConnectionDB cndb = new ConnectionDB();
        public DataSet ds_XeMay = new DataSet();

        public void LoadData()
        {
            string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
            SqlDataAdapter da_Khach = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khach.Fill(ds_XeMay, "PHIEUNHAPHANG");
            
        }
        public void LoadNhapHang(DataGridView data)
        {
            string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
            SqlDataAdapter da_Khach = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khach.Fill(ds_XeMay, "PHIEUNHAPHANG");
            data.DataSource = ds_XeMay.Tables["PHIEUNHAPHANG"];
        }   

        public int NhapHang(DataGridView data)
        {
            int nhaphang = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Selected )
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        if (index == 5)
                        {
                           nhaphang = nhaphang + int.Parse(cell.Value.ToString()); 
                            //do what you want with the value
                        }
                        
                    }
                }
            } return nhaphang;
        }

        public void LoadComBoNhaCungCap(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM NHACUNGCAP";
            SqlDataAdapter da_NhaCungCap = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_NhaCungCap = new DataSet();
            da_NhaCungCap.Fill(ds_NhaCungCap, "NHACUNGCAP");

            cb.DataSource = ds_NhaCungCap.Tables["NHACUNGCAP"];
            cb.DisplayMember = "TENNCC";
            cb.ValueMember = "MANCC";
               
        }
        public void LoadComboPhieuNhap1(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
            SqlDataAdapter da_NhapHang = new SqlDataAdapter(CauLenh, cndb.cnn);
       
            da_NhapHang.Fill(ds_XeMay, "PHIEUNHAPHANG");

            cb.DataSource = ds_XeMay.Tables["PHIEUNHAPHANG"];
            cb.DisplayMember = "MAPHIEUNHAP";
            cb.ValueMember = "MAPHIEUNHAP";
        }


        public void LoadComBoPhieuNhap(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
            SqlDataAdapter da_NhapHang = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_NhapHang = new DataSet();
            da_NhapHang.Fill(ds_NhapHang, "PHIEUNHAPHANG");

            cb.DataSource = ds_NhapHang.Tables["PHIEUNHAPHANG"];
            cb.DisplayMember = "MAPHIEUNHAP";
            cb.ValueMember = "MAPHIEUNHAP";
        }

        public void LoadComBoSanPham(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM SANPHAM";
            SqlDataAdapter da_SanPham = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_SanPham = new DataSet();
            da_SanPham.Fill(ds_SanPham, "SANPHAM");

            cb.DataSource = ds_SanPham.Tables["SANPHAM"];
            cb.DisplayMember = "TENSP";
            cb.ValueMember = "MASP";
 
        }
        public void LoadComBoKho(ComboBox cb)
        {
            string CauLenh = "SELECT * FROM KHO";
            SqlDataAdapter da_Kho = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_Kho = new DataSet();
            da_Kho.Fill(ds_Kho, "KHO");

            cb.DataSource = ds_Kho.Tables["KHO"];
            cb.DisplayMember = "TENKHO";
            cb.ValueMember = "MAKHO";

        }
        public void LoadDataChiTietPhieuNhap(DataGridView data)
        {
            string CauLenh = "SELECT MAPHIEUNHAP AS  N'Mã phiếu nhập',MASP AS N'Mã sản phẩm',DONGIANHAP AS N'Đơn giá nhập',SOLUONG AS N'Số lượng'  FROM CHITIETPHIEUNHAP";
            SqlDataAdapter da_ChiTiet = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_ChiTietPhieuNhap = new DataSet();
            da_ChiTiet.Fill(ds_ChiTietPhieuNhap, "CHITIETPHIEUNHAP");
            data.DataSource = ds_ChiTietPhieuNhap.Tables["CHITIETPHIEUNHAP"];
        }

        public bool TaoPhieuHang(string pMaPhieuNhap,string pNgayNhap,string pMaNCC,string pMaKho)
        {
            try 
            {
                string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
                SqlDataAdapter da_PhieuNhap = new SqlDataAdapter(CauLenh, cndb.cnn);
                DataSet ds_PhieuNhap = new DataSet();
                da_PhieuNhap.Fill(ds_PhieuNhap, "PHIEUNHAPHANG");

                DataRow TPN = ds_PhieuNhap.Tables["PHIEUNHAPHANG"].NewRow();

                TPN["MAPHIEUNHAP"] = pMaPhieuNhap;
                TPN["NGAYNHAP"] = pNgayNhap;
                TPN["MANCC"] = pMaNCC;
                TPN["MAKHO"] = pMaKho;

                ds_PhieuNhap.Tables["PHIEUNHAPHANG"].Rows.Add(TPN);

                SqlCommandBuilder cb = new SqlCommandBuilder(da_PhieuNhap);

                da_PhieuNhap.Update(ds_PhieuNhap, "PHIEUNHAPHANG");

                return true;
            }
            catch { return false; }
        }

        public void Them(ComboBox bx,string MaSanPham,string DonGia,string SoLuong,string MaKho)
        {

            string CauLenh = "SELECT * FROM CHITIETPHIEUNHAP";
            SqlDataAdapter da_ChiTietPhieuNhap = new SqlDataAdapter(CauLenh, cndb.cnn);
            DataSet ds_ChiTietPhieuNhap = new DataSet();
            da_ChiTietPhieuNhap.Fill(ds_ChiTietPhieuNhap, "CHITIETPHIEUNHAP");

            string a = bx.SelectedValue.ToString().Trim();
            DataRow them = ds_ChiTietPhieuNhap.Tables["CHITIETPHIEUNHAP"].NewRow();

            them["MAPHIEUNHAP"] = a;
            them["MASP"] = MaSanPham;
            
            them["DONGIANHAP"] = DonGia;
            them["SOLUONG"] = SoLuong;
            them["MAKHO"] = MaKho;
            ds_ChiTietPhieuNhap.Tables["CHITIETPHIEUNHAP"].Rows.Add(them);

            SqlCommandBuilder cb = new SqlCommandBuilder(da_ChiTietPhieuNhap);

            da_ChiTietPhieuNhap.Update(ds_ChiTietPhieuNhap, "CHITIETPHIEUNHAP");

            
            

           
        }
        public bool LuuPhieuHang(string pMaPhieuNhap,string ThanhTien)
        {
            try 
            {
                string CauLenh = "SELECT * FROM PHIEUNHAPHANG";
                SqlDataAdapter da_PhieuNhap = new SqlDataAdapter(CauLenh, cndb.cnn);
                DataSet ds_PhieuNhap = new DataSet();
                da_PhieuNhap.Fill(ds_PhieuNhap, "PHIEUNHAPHANG");

                DataColumn[] key = new DataColumn[1];
                key[0] = ds_PhieuNhap.Tables["PHIEUNHAPHANG"].Columns[0];
                ds_PhieuNhap.Tables["PHIEUNHAPHANG"].PrimaryKey = key;

                DataRow TPN = ds_PhieuNhap.Tables["PHIEUNHAPHANG"].Rows.Find(pMaPhieuNhap);
                if (TPN != null)
                {
                    TPN["TONGTIENNHAP"] = ThanhTien;
                }





                SqlCommandBuilder cb = new SqlCommandBuilder(da_PhieuNhap);

                da_PhieuNhap.Update(ds_PhieuNhap, "PHIEUNHAPHANG");
                return true;
            }
            catch { return false; }
        }
  
    }
    
}
