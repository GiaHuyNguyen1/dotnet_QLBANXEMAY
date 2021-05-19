using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public partial class NhanVien : Form
    {
        DataTable dta;
        public NhanVien()
        {
            InitializeComponent();
            dta = new DataTable();
        }


        ThucThi a = new ThucThi();

        ClassTaiKhoan xd = new ClassTaiKhoan();

        ClassSanPham sp = new ClassSanPham();

        ClassKhach kh = new ClassKhach();

        ClassDSHoaDon dshd = new ClassDSHoaDon();

        ClassNhapHang xlnh = new ClassNhapHang();

        private void NhanVien_Load(object sender, EventArgs e)
        {
            sp.LoadSANPHAM(dataGridView1);
            sp.LoadMancc(cbx_manhacungcap);

            loadDataSANPHAM();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;


            txt_tensp.Enabled = false;
            txt_masp.Enabled = false;
            txt_dvt.Enabled = false;
            txt_dongiaban.Enabled = false;
            txt_dongiamua.Enabled = false;
            txt_ghichu.Enabled = false;
            cbx_manhacungcap.Enabled = false;

            btn_suasp.Enabled = false;
            btn_xoasp.Enabled = false;
            btn_luusp.Enabled = false;

            //KHACH************************************************

            kh.LoadKhach(dataGridView2);

            loadDataKHACH();
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            txt_makhach.Enabled = false;
            txt_tenkhach.Enabled = false;
            txt_diachi.Enabled = false;
            txt_sodienthoai.Enabled = false;
            txt_email.Enabled = false;
            txt_nguoitao.Enabled = false;


            btn_xoakhach.Enabled = false;
            btn_suakhach.Enabled = false;
            btn_luukhach.Enabled = false;
           
        

            //NHAP HANG
            
            
            xlnh.LoadComboPhieuNhap1(cbx_MaPhieuNhapNV);
            LoadDataPhieuNhap();
            
            
            
            xlnh.LoadComBoNhaCungCap(cbx_NhaCungCapNV);
            
            xlnh.LoadComBoKho(cbx_KhoNV);

            

            xlnh.LoadComBoSanPham(cbx_MaSanPhamNV);
            xlnh.LoadDataChiTietPhieuNhap(dataGridView3);

            //Ban hang
            BanHang bh = new BanHang { TopLevel=false,Parent=tabPage2,Dock=DockStyle.Fill};
            bh.Show();

        }

        public void loadDataSANPHAM()
        {


            databingSP(sp.ds_QLXEMAY.Tables["SANPHAM"]);
        }

        void databingSP(DataTable tb)
        {
            cbx_manhacungcap.DataBindings.Clear();
            txt_tensp.DataBindings.Clear();
            txt_masp.DataBindings.Clear();
            txt_dvt.DataBindings.Clear();
            txt_dongiaban.DataBindings.Clear();
            txt_dongiamua.DataBindings.Clear();
            txt_ghichu.DataBindings.Clear();


            cbx_manhacungcap.DataBindings.Add("Text", tb, "MANCC");
            txt_tensp.DataBindings.Add("Text", tb, "TENSP");
            txt_masp.DataBindings.Add("Text", tb, "MASP");
            txt_dvt.DataBindings.Add("Text", tb, "DVT");
            txt_dongiaban.DataBindings.Add("Text", tb, "DONGIABAN");
            txt_dongiamua.DataBindings.Add("Text", tb, "DONGIAMUA");
            txt_ghichu.DataBindings.Add("Text", tb, "GHICHU");

            

        }

        private void dataGridViewSp_SelectionChanged(object sender, EventArgs e)
        {
            btn_xoasp.Enabled = true;
            btn_suasp.Enabled = true;
        }

        private void btn_themsp_Click(object sender, EventArgs e)
        {
            btn_luusp.Enabled = true;
            sp.Them(dataGridView1);
            MessageBox.Show("Hãy nhập thông tin chính xác vào bảng.");

        }

        private void btn_suasp_Click(object sender, EventArgs e)
        {
            btn_luusp.Enabled = true;
            sp.Sua(dataGridView1);
            MessageBox.Show("Hãy bắt đầu chỉnh sửa thông tin của bảng");
        }

        private void btn_luusp_Click(object sender, EventArgs e)
        {
            sp.Load();
            databingSP(sp.ds_QLXEMAY.Tables["SANPHAM"]);
            MessageBox.Show("Lưu thành công");
            btn_xoasp.Enabled = false;
        }

        //KHACH**************************************************************************

        void databingKhach(DataTable tb)
        {

            txt_makhach.DataBindings.Clear();
            txt_tenkhach.DataBindings.Clear();
            txt_diachi.DataBindings.Clear();
            txt_sodienthoai.DataBindings.Clear();
            txt_email.DataBindings.Clear();
            txt_nguoitao.DataBindings.Clear();



            txt_makhach.DataBindings.Add("Text", tb, "MAKHACH");
            txt_tenkhach.DataBindings.Add("Text", tb, "TENKHACH");
            txt_diachi.DataBindings.Add("Text", tb, "DIACHI");
            txt_sodienthoai.DataBindings.Add("Text", tb, "SDT");
            txt_email.DataBindings.Add("Text", tb, "EMAIL");
            txt_nguoitao.DataBindings.Add("Text", tb, "NGUOITAO");

        }
        public void loadDataKHACH()
        {


            databingKhach(kh.ds_XeMay.Tables["KHACHHANG"]);
        }
        //Phieu nhap hang
        void DatabingdingPhieuNhap(DataTable tb)
        {
            txt_MaPhieuNhapNV.DataBindings.Clear();
            txt_NgayNhapNV.DataBindings.Clear();
            cbx_KhoNV.DataBindings.Clear();
            cbx_NhaCungCapNV.DataBindings.Clear();

            txt_MaPhieuNhapNV.DataBindings.Add("Text", tb, "MAPHIEUNHAP");
            txt_NgayNhapNV.DataBindings.Add("Text", tb, "NGAYNHAP");
            cbx_KhoNV.DataBindings.Add("Text", tb, "MAKHO");
            cbx_NhaCungCapNV.DataBindings.Add("Text", tb, "MANCC");


        }
        public void LoadDataPhieuNhap()
        {
            DatabingdingPhieuNhap(xlnh.ds_XeMay.Tables["PHIEUNHAPHANG"]);
        }
        

        private void btn_themkhach_Click(object sender, EventArgs e)
        {
            btn_luukhach.Enabled = true;
            kh.Them(dataGridView2);
        }

        private void btn_luukhach_Click(object sender, EventArgs e)
        {
            kh.Load();
            databingKhach(kh.ds_XeMay.Tables["KHACHHANG"]);
            MessageBox.Show("Lưu thành công");
        }

        private void btn_suakhach_Click(object sender, EventArgs e)
        {
            btn_luukhach.Enabled = true;
            kh.Sua(dataGridView2);
            MessageBox.Show("Hãy sửa thông tin trong bảng");
        }

        

            private void btn_taoacckhach_Click(object sender, EventArgs e)
            {
                string khach = "KH";
                a.ThemAcc(txt_makhach.Text,txt_tenkhach.Text,txt_diachi.Text,txt_sodienthoai.Text,txt_email.Text,khach );
                MessageBox.Show("Tạo thành công");
            }

            private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
            {
                btn_suakhach.Enabled = true;
                btn_xoakhach.Enabled = true;
            }

            private void btn_xoakhach_Click(object sender, EventArgs e)
            {
                kh.Xoa(dataGridView2);
                btn_luukhach.Enabled = true;
                
            }

            private void btn_xoasp_Click(object sender, EventArgs e)
            {
                sp.Xoa(dataGridView1);
                btn_luusp.Enabled = true;
            }

            

           

           

            

            private void btn_LoadHD_Click(object sender, EventArgs e)
            {
                dshd.LoadDB();
            }

            private void btn_TaoPhieuNhapNV_Click(object sender, EventArgs e)
            {


                if (xlnh.TaoPhieuHang(txt_MaPhieuNhapNV.Text, txt_NgayNhapNV.Text, (cbx_NhaCungCapNV.SelectedValue).ToString(), (cbx_KhoNV.SelectedValue).ToString()))
                {
                    MessageBox.Show("Đã tạo thành công");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi vui lòng kiểm tra lại mã phiếu nhập");
                }

                  
                xlnh.LoadComBoPhieuNhap(cbx_MaPhieuNhapNV);
            }

            private void btn_LuuPhieuNhap_Click(object sender, EventArgs e)
            {
                if (xlnh.LuuPhieuHang(txt_MaPhieuNhapNV.Text, txt_ThanhTienNV.Text))
                {
                    MessageBox.Show("Lưu thành công phiếu nhập");
                }
                else
                {
                    MessageBox.Show("Lưu thất bại. Đã xảy ra lỗi, vui lòng kiểm tra lại thông tin.");
                }
                   
            }

            private void btn_ThemSPNV_Click(object sender, EventArgs e)
            {
                if (txt_DonGiaNV.Text.Trim().Length == 0 || txt_SoLuongNV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu, không được để trống!");                    
                }
                else if (!Char.IsDigit(txt_DonGiaNV.Text[txt_DonGiaNV.Text.Length - 1]) || !Char.IsDigit(txt_SoLuongNV.Text[txt_SoLuongNV.Text.Length - 1]))
                {
                    MessageBox.Show("Dữ liệu nhập vào phải là số!");
                }
                else
                {
                    int kq = int.Parse(txt_SoLuongNV.Text) * int.Parse(txt_DonGiaNV.Text);
                    txt_ThanhTienNV.Text = kq.ToString();
                    xlnh.Them(cbx_MaPhieuNhapNV, (cbx_MaSanPhamNV.SelectedValue).ToString(), txt_DonGiaNV.Text, txt_SoLuongNV.Text,cbx_KhoNV.SelectedValue.ToString());
                    xlnh.LoadDataChiTietPhieuNhap(dataGridView3);
                }
                
            }

            private void button1_Click(object sender, EventArgs e)
            {
                txt_MaPhieuNhapNV.Text = "";
                DateTime now = DateTime.Now;
                txt_NgayNhapNV.Text = now.ToString();
                txt_MaPhieuNhapNV.Focus();
            }

            HangTrongKho kho = new HangTrongKho();
            private void button2_Click(object sender, EventArgs e)
            {
                kho.ShowDialog();
                this.Show();
            }
            BanHang bh = new BanHang();
            
            private void tabPage2_Click_1(object sender, EventArgs e)
            {             
                bh.ShowDialog();
                this.Show();
            }

            private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (r == DialogResult.No)
                {
                    e.Cancel = true;

                }
            }
            Report rp = new Report();
            private void InPhieuNhapNV_Click(object sender, EventArgs e)
            {
                this.Hide();
                rp.ShowDialog();
                this.Show();

            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                btn_xoasp.Enabled = true;
                btn_suasp.Enabled = true;
            }

            

            

           

      








        

       
    }
}
