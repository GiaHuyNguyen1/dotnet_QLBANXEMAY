using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public class ClassDSHoaDon
    {
        ConnectionDB cndb = new ConnectionDB();

        public DataSet ds_QLXEMAY = new DataSet();

        List<ClassHoaDon> ds_HD = new List<ClassHoaDon>();
        DateTime now = DateTime.Now;
        public ClassDSHoaDon()
        {
            //ClassHoaDon hd1 = new ClassHoaDon();
            //hd1.MaPhieuBan = "123";
            //hd1.NgayXuatPhieu = now.ToString();
            //hd1.MaKhach = "Huy";
            //hd1.TrangThai = "Đã thanh toán đủ";
            //hd1.TongTien = 12000000;
            //hd1.ChuThich = "Giao hàng tại nhà";

            //ds_HD.Add(hd1);

        }
        public ListViewItem[] LoadDL()
        {
            ListViewItem[] kq = new ListViewItem[ds_HD.Count];

            for (int i = 0; i < ds_HD.Count; i++)
            {
                ListViewItem item = new ListViewItem(new[] { ds_HD[i].MaPhieuBan, ds_HD[i].NgayXuatPhieu, ds_HD[i].MaKhach, ds_HD[i].TrangThai, ds_HD[i].TongTien.ToString(), ds_HD[i].ChuThich });
                kq[i] = item;
            }

            return kq;
        }
        
        //Load hóa đơn từ data
        public void Load(ListView list)
        {

            cndb.Open();
            SqlDataAdapter ada = new SqlDataAdapter("SELECT MAPHIEUBAN AS N'Mã phiếu bán',NGAYPHIEUBAN AS N'Ngày xuất phiếu',MAKHACH AS N'Mã khách',TRANGTHAI AS N'Trạng thái',TONGTIEN AS N'Tổng tiền',CHUTHICH AS N'Chú thích' FROM PHIEUBANHANG", cndb.cnn);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["Mã phiếu bán"].ToString());
                listitem.SubItems.Add(dr["Ngày xuất phiếu"].ToString());
                listitem.SubItems.Add(dr["Mã khách"].ToString());
                listitem.SubItems.Add(dr["Trạng thái"].ToString());
                listitem.SubItems.Add(dr["Tổng tiền"].ToString());
                listitem.SubItems.Add(dr["Chú thích"].ToString());
                list.Items.Add(listitem);
            } 
            //Khoa chinh
            //DataColumn[] key = new DataColumn[1];
            //key[0] = ds_QLXEMAY.Tables["PHIEUBANHANG"].Columns[0];
            //ds_QLXEMAY.Tables["PHIEUBANHANG"].PrimaryKey = key;
        }

        public void Them(string pMaPhieuBan, string pMaKhach, string pTrangThai, int pTongTien, string pChuThich)
        {
            ClassHoaDon them = new ClassHoaDon();
            them.MaPhieuBan = pMaPhieuBan;
            them.NgayXuatPhieu = now.ToString();
            them.MaKhach = pMaKhach;
            them.TrangThai = pTrangThai;
            them.TongTien = pTongTien;
            them.ChuThich = pChuThich;
            ds_HD.Add(them);
        }

        public void Xoa(ListView list)
        {
            foreach (ListViewItem l in list.SelectedItems)
            {
                l.Remove();
            }
        }
        
        public void Sua(ListView list,string pMaKhach, string pTrangThai, int pTongTien, string pChuThich)
        {
            if (list.FocusedItem != null && list.FocusedItem.Index >= 0)
            {
                ListViewItem item = list.FocusedItem;

                item.SubItems[2].Text = pMaKhach;
                item.SubItems[3].Text = pTrangThai;
                item.SubItems[4].Text = pTongTien.ToString();
                item.SubItems[5].Text = pChuThich;
                
 
            }
        }

        public void LoadDB()
        {
            string CauLenh = "SELECT * FROM PHIEUBANHANG";
            SqlDataAdapter da = new SqlDataAdapter(CauLenh, cndb.cnn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);

            da.Update(ds_QLXEMAY, "PHIEUBANHANG");

        }
        


        

        
    }
}
