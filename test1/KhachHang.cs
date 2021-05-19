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
    public partial class KhachHang : Form
    {
        DataTable dta;
        public KhachHang()
        {
            
            InitializeComponent();
            dta = new DataTable();
        }
        ClassSanPham sp = new ClassSanPham();
        ClassKhach kh = new ClassKhach();
        ClassBanHang bh = new ClassBanHang();
        private void KhachHang_Load(object sender, EventArgs e)
        {
            sp.LoadSANPHAMKHACH(dataGridView1);
            loadDataSANPHAM();
        }
        public void loadDataSANPHAM()
        {
            databingSP(sp.ds_QLXEMAY.Tables["SANPHAM"]);
        }
        void databingSP(DataTable tb)
        {
            txt_TENSP.DataBindings.Clear();

            txt_TENSP.DataBindings.Add("Text", tb, "Mã xe");

        }
        public string SanPhamMoiMua;
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r =MessageBox.Show("Bạn có muốn mua " + value2,"Không",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);

            if (r == DialogResult.Yes)
            {

                SanPhamMoiMua="Mã xe: "+value1+"Tên xe: "+value2+"Giá: "+value3;
                MessageBox.Show("Mua thành công");
            }


        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mọi thông tin về sản phẩm và cách thức mua hàng, xin liên hệ sđt: 0961801665" +"\n" + "Xin cảm on quý khách." , "Liên hệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        public string value1;
        public string value2;
        public string value3;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                 value1 = row.Cells[0].Value.ToString();
                 value2 = row.Cells[1].Value.ToString();
                 value3 = row.Cells[3].Value.ToString();
            }
        }


        
        
        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult r;
            r = MessageBox.Show("Mã xe: " + value1 + "\n" + "Tên xe: " + value2 +"\n" + "Giá: " + value3,"Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (r == DialogResult.OK)
            {
                
                MessageBox.Show("Quý khách tới trung tâm để được tư vấn hoàn thành thủ tục mua xe.");
            }

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            
            sp.TimKiemSP(dataGridView2,txt_TENSP.Text);
        }

        private void KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
            {
                e.Cancel = true;

            }
        }
    }
}
