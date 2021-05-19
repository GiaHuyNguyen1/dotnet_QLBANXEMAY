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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        ConnectionDB cn = new ConnectionDB();
        KhachHang f1 = new KhachHang();
        NhanVien f2 = new NhanVien();
        Admin f3 = new Admin();
        XuLy xl = new XuLy();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!cn.KetNoi(textBox4.Text, textBox3.Text))
            {
                MessageBox.Show("Vui lòng kiểm tra lại Server name hoặc tên database");
            }

            else if (cn.KetNoi(textBox4.Text, textBox3.Text))
            {
                if (xl.DangNhap(textBox1.Text, textBox2.Text))
                {
                    if (xl.KT_TKNV(textBox1.Text))
                    {
                        MessageBox.Show("Kết nối thành công");
                        this.Hide();
                        f2.ShowDialog();
                        this.Show();
                    }
                    else if (xl.KT_TKKH(textBox1.Text))
                    {
                        MessageBox.Show("Kết nối thành công");
                        this.Hide();
                        f1.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kết nối thành công");
                        this.Hide();
                        f3.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại. Kiểm tra lại Account và password");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát chương trình ?","Đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!cn.KetNoi(textBox4.Text, textBox3.Text))
                {
                    MessageBox.Show("Vui lòng kiểm tra lại Server name hoặc tên database");
                }

                else if (cn.KetNoi(textBox4.Text, textBox3.Text))
                {
                    if (xl.DangNhap(textBox1.Text, textBox2.Text))
                    {
                        if (xl.KT_TKNV(textBox1.Text))
                        {
                            MessageBox.Show("Kết nối thành công");
                            this.Hide();
                            f2.ShowDialog();
                            this.Show();
                        }
                        else if (xl.KT_TKKH(textBox1.Text))
                        {
                            MessageBox.Show("Kết nối thành công");
                            this.Hide();
                            f1.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kết nối thành công");
                            this.Hide();
                            f3.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kết nối thất bại. Kiểm tra lại Account và password");
                    }


                }
            }      
        }
    }
}
