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
    public partial class Admin : Form
    {
        DataTable dta;
        public Admin()
        {
            InitializeComponent();
            dta = new DataTable();
        }

        ThucThi a = new ThucThi();

        ClassTaiKhoan xd= new ClassTaiKhoan();

        ClassSanPham sp = new ClassSanPham();

        ClassKhach kh = new ClassKhach();

        ClassKho kho = new ClassKho();

        ClassDoanhThu dt = new ClassDoanhThu();

        ClassNhapHang nh = new ClassNhapHang();

        private void Form3_Load(object sender, EventArgs e)
        {
           
            xd.LoadACC(dataGridView1);
            loadDataACCOUNT();
            
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            

            //SANPHAM
            sp.LoadSANPHAM(dataGridViewSp);
            sp.LoadMancc(comboBoxMancc);
            
            loadDataSANPHAM();
            dataGridViewSp.ReadOnly = true;
            dataGridViewSp.AllowUserToAddRows = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBoxMancc.Enabled = false;

            toolStripButtonSua.Enabled = false;
            toolStripButtonXoa.Enabled = false;
            toolStripButtonLuu.Enabled = false;

            //KHACH
            kh.LoadKhach(dataGridView2);

      
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;

            


            tooLuuKhach.Enabled = false;
            toolXoaKhach.Enabled = false;
            toolSuaKhach.Enabled = false;

            //KHO
            kho.LoadKho(dataGridView3);
            
            txt_MaKho.Enabled = false;
            //DOANH THu
            dt.LoadDoanhThu(dataGridView4);
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.ReadOnly = true;

            //NHAP HANG
            nh.LoadNhapHang(dataGridView5);
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.ReadOnly = true;


            
        }

        

        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         
           

        }
        
        //void databing(DataTable tb)
        //{
        //    cbx_LoaiTK.DataBindings.Clear();
        //    txt_MaTaiKhoan.DataBindings.Clear();
        //    txt_TenTaiKhoan.DataBindings.Clear();
        //    txt_MatKhau.DataBindings.Clear();
        //    txt_Email.DataBindings.Clear();
        //    txt_SDT.DataBindings.Clear();
        //    txt_DiaChi.DataBindings.Clear();


        //    cbx_LoaiTK.DataBindings.Add("Text", tb, "MALOAI");
        //    txt_MaTaiKhoan.DataBindings.Add("Text", tb, "MAACC");
        //    txt_TenTaiKhoan.DataBindings.Add("Text", tb, "TENACC");
        //    txt_MatKhau.DataBindings.Add("Text", tb, "MATKHAU");
        //    txt_Email.DataBindings.Add("Text", tb, "EMAIL");
        //    txt_SDT.DataBindings.Add("Text", tb, "SDT");
        //    txt_DiaChi.DataBindings.Add("Text", tb, "DIACHI");
            
        //}
        public void loadDataACCOUNT()
        {
            
            //databing(xd.ds_XeMay.Tables["ACCOUNT"]);

            
        }
        public void loadDataSANPHAM()
        {


            databingSP(sp.ds_QLXEMAY.Tables["SANPHAM"]);
        }
        


        //SANPHAM*****************************************************************************************

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            toolStripButtonLuu.Enabled = true;
            sp.Them(dataGridViewSp);
        }

        private void dataGridViewSp_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButtonXoa.Enabled = true;
            toolStripButtonSua.Enabled = true;
        }

        void databingSP(DataTable tb)
        {
            comboBoxMancc.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();


            comboBoxMancc.DataBindings.Add("Text", tb, "MANCC");
            textBox1.DataBindings.Add("Text", tb, "MASP");
            textBox2.DataBindings.Add("Text", tb, "TENSP");
            textBox3.DataBindings.Add("Text", tb, "DVT");
            textBox5.DataBindings.Add("Text", tb, "DONGIABAN");
            textBox6.DataBindings.Add("Text", tb, "GHICHU");

        }

        private void toolStripButtonSua_Click(object sender, EventArgs e)
        {
            toolStripButtonLuu.Enabled = true;
            sp.Sua(dataGridViewSp);
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {
            sp.Load();
            databingSP(sp.ds_QLXEMAY.Tables["SANPHAM"]);
        }

        

        //KHACH*****************************************************************************************

        private void toolThemKhach_Click(object sender, EventArgs e)
        {
            
            toolSuaKhach.Enabled = true;
            kh.Them(dataGridView2);
        }

        private void toolXoaKhach_Click(object sender, EventArgs e)
        {
            kh.Xoa(dataGridView2);
        }

        private void toolLuuKhach_Click(object sender, EventArgs e)
        {
            kh.Load();
           
            
        }

        private void toolSuaKhach_Click(object sender, EventArgs e)
        {
            toolSuaKhach.Enabled = true;
            kh.Load();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            tooLuuKhach.Enabled = true;
            toolXoaKhach.Enabled = true;
            
        }
        //void databingKhach(DataTable tb)
        //{

        //    txt_MaKhach.DataBindings.Clear();
        //    txt_TenKhach.DataBindings.Clear();
        //    txt_DiaChiKhach.DataBindings.Clear();
        //    txt_SDTKhach.DataBindings.Clear();
        //    txt_EmailKhach.DataBindings.Clear();
        //    txt_NguoiTao.DataBindings.Clear();



        //    txt_MaKhach.DataBindings.Add("Text", tb, "MAKHACH");
        //    txt_TenKhach.DataBindings.Add("Text", tb, "TENKHACH");
        //    txt_DiaChiKhach.DataBindings.Add("Text", tb, "DIACHI");
        //    txt_SDTKhach.DataBindings.Add("Text", tb, "SDT");
        //    txt_EmailKhach.DataBindings.Add("Text", tb, "EMAIL");
        //    txt_NguoiTao.DataBindings.Add("Text", tb, "NGUOITAO");

        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            sp.Xoa(dataGridViewSp);
        }

       

        private void btn_ThayDoiNguoiDD_Click(object sender, EventArgs e)
        {
            kho.UpdateNguoiDD(dataGridView3, txt_TenNguoiDaiDien.Text);
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            txt_MaKho.Text = kho.LayMaKho(dataGridView3);
            txt_TenNguoiDaiDien.Text = kho.LayNguoiDD(dataGridView3);
        }

        private void btn_UpdateKho_Click(object sender, EventArgs e)
        {
            
            kho.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            mtxt_TongDoanhThu.Text = dt.DoanhThu(dataGridView4).ToString();
        }

        private void btn_TinhTien_Click(object sender, EventArgs e)
        {
            mtxt_TongTienNhap.Text = nh.NhapHang(dataGridView5).ToString();
        }

        
        HangTrongKho htk = new HangTrongKho();
        private void button1_Click_1(object sender, EventArgs e)
        {
            htk.ShowDialog();
            this.Show();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xd.Them(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (xd.Load())
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
         
            xd.Xoa(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xd.Sua(dataGridView1);
        }
        Report rp = new Report();
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }
    }
}
