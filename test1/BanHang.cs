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
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }
        ClassSanPham sp = new ClassSanPham();
        ClassBanHang bh = new ClassBanHang();
        ClassKhach khach = new ClassKhach();
        ClassKho kho = new ClassKho();
        private void BanHang_Load(object sender, EventArgs e)
        {
            bh.LoadComboBoxPhieuBanHang1(comboBox1);
            LoadDataPhieuNhap();
            
            
            sp.LoadComboMaSanPham(comboBox2);
            DateTime now = DateTime.Now;
            textBox2.Text = now.ToString();
            bh.LoadDataChiTietPhieuNhap(dataGridView4);
            khach.LoadKhachCombo(comboBox3);

            kho.LoadComboKho(comboBox4);
            
        }

        void DatabingdingPhieuBan(DataTable tb)
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            comboBox3.DataBindings.Clear();


            textBox1.DataBindings.Add("Text", tb, "MAPHIEUBAN");
            textBox2.DataBindings.Add("Text", tb, "NGAYPHIEUBAN");
            comboBox3.DataBindings.Add("Text", tb, "MAKHACH");
          

        }
        public void LoadDataPhieuNhap()
        {
            DatabingdingPhieuBan(bh.ds_XeMay.Tables["PHIEUBANHANG"]);
        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = sp.GiaBanCuaSanPham(comboBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nhập mã phiếu bán!");
            }
            else
            {
                if (bh.TaoPhieuBanHang(textBox1.Text, textBox2.Text, comboBox3.SelectedValue.ToString()))
                {
                    MessageBox.Show("Tạo phiếu bán thành công");
                }
                else
                    MessageBox.Show("Kiểm tra lại mã phiếu bán!");
            } bh.LoadComboBoxPhieuBanHang(comboBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bh.LuuPhieuBanHang(textBox1.Text, textBox3.Text))
            {
                MessageBox.Show("Lưu thành công phiếu nhập");
            }
            else
            {
                MessageBox.Show("Lưu thất bại. Đã xảy ra lỗi, vui lòng kiểm tra lại thông tin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu, không được để trống!");
            }
            else if (!Char.IsDigit(textBox5.Text[textBox5.Text.Length - 1]) || !Char.IsDigit(textBox4.Text[textBox4.Text.Length - 1]))
            {
                MessageBox.Show("Dữ liệu nhập vào phải là số!");
            }
            else
            {
                int kq = int.Parse(textBox4.Text) * int.Parse(textBox5.Text);
                textBox3.Text = kq.ToString();
                bh.Them(comboBox1, (comboBox2.SelectedValue).ToString(), textBox5.Text, textBox4.Text,comboBox4.SelectedValue.ToString());
                bh.LoadDataChiTietPhieuNhap(dataGridView4);
            }
        }
        Report rp = new Report();
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }


    }
}
