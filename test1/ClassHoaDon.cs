using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace test1
{
    public class ClassHoaDon
    {
        string _MaPhieuBan;

        public string MaPhieuBan
        {
            get { return _MaPhieuBan; }
            set { _MaPhieuBan = value; }
        }
        string _NgayXuatPhieu;

        public string NgayXuatPhieu
        {
            get { return _NgayXuatPhieu; }
            set { _NgayXuatPhieu = value; }
        }
        string _MaKhach;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }
        string _TrangThai;

        public string TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        int _TongTien;

        public int TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }

        
        string _ChuThich;

        public string ChuThich
        {
            get { return _ChuThich; }
            set { _ChuThich = value; }
        }

    }
}
