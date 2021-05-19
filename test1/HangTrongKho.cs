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
    public partial class HangTrongKho : Form
    {
        public HangTrongKho()
        {
            InitializeComponent();
        }
        ClassKho kho = new ClassKho();

        private void HangTrongKho_Load(object sender, EventArgs e)
        {
            kho.SOLUONGHANGTRONGKHO(dataGridView1);
            kho.LoadComboKho(comboBox1);   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kho.LoadHangTonKhoTheoCombo(comboBox1,dataGridView1);
        }
    }
}
