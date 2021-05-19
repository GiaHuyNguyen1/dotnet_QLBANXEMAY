using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace test1
{
    class XuLy
    {
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-3JOF3O8\\SQLEXPRESS;Initial Catalog=QLXEMAY2;User ID=sa;Password=sa2012");

        DataSet ds_QLXEMAY= new DataSet();
        SqlDataAdapter da_XeMay;

        //Load data bang SqlDataAdapter
        public DataTable LoadTK()
        {
            //B1
            string CauLenh = "select * from ACCOUNT";
            //B2
            SqlDataAdapter da_Khoa = new SqlDataAdapter(CauLenh, cnn);
            //Dien du lieu len ds_QLSINHVIEN
            //B3
            da_Khoa.Fill(ds_QLXEMAY, "ACCOUNT");
            //B4
            return ds_QLXEMAY.Tables["ACCOUNT"];
        }

        //Load data bang SqlDataAdapter
        public DataTable LoadLoaiTK()
        {
            //B1
            string CauLenh = "select * from LOAITK";
            //B2
            SqlDataAdapter da_Khoa = new SqlDataAdapter(CauLenh, cnn);
            //Dien du lieu len ds_QLSINHVIEN
            //B3
            da_Khoa.Fill(ds_QLXEMAY, "LOAITK");
            //B4
            return ds_QLXEMAY.Tables["LOAITK"];
        }

        //Load data len ListView
        public void LoadLopVaKhoa()
        {
            string CauLenh = "Select MaLop,TenLop,Khoa.MaKhoa,TenKhoa From Lop,Khoa Where Lop.MaKhoa = Khoa.MaKhoa";

            SqlDataAdapter da_LopKhoa = new SqlDataAdapter(CauLenh, cnn);

            da_LopKhoa.Fill(ds_QLXEMAY, "Lop_Khoa");
            //return ds_QLSINHVIEN.Tables["Lop_Khoa"];
        }
        //public XuLy()
        //{

        //    //LoadLop();
            

        //}
        
        ////Load data bang SqlDataAdapter nhung theo cach khac
        //public void LoadLop()
        //{
        //    //B1
        //    string CauLenh = "select * from Lop";
        //    //B2
        //    da_XeMay = new SqlDataAdapter(CauLenh, cnn);
        //    //Dien du lieu len ds_QLSINHVIEN
        //    //B3
        //    da_XeMay.Fill(ds_QLXEMAY, "Lop");
        //    //B4
        //    //return ds_QLSINHVIEN.Tables["Lop"];
        //}

        public bool LoadAcc(string pMaAcc, string pTenAcc, string pMatKhau, string pEmail, string pSDT, string pDiaChi, string pMaLoai)
        {
            try
            {
                
                //B4
                string CauLenh = "INSERT INTO ACCOUNT VALUES('"+pMaAcc+"','"+pTenAcc+"','"+pMatKhau+"','"+pEmail+"','"+pSDT+"','"+pDiaChi+"','"+pMaLoai+"')";

                da_XeMay = new SqlDataAdapter(CauLenh, cnn);
                SqlCommandBuilder buil = new SqlCommandBuilder(da_XeMay);

                ds_QLXEMAY = new DataSet();
                da_XeMay.Fill(ds_QLXEMAY, "ACCOUNT");


                da_XeMay.Update(ds_QLXEMAY, "ACCOUNT");
                
                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool Them(string pMaAcc, string pTenAcc, string pMatKhau,string pEmail,string pSDT,string pDiaChi,string pMaLoai)
        {
            try
            {
                //B1
                DataRow drThem = ds_QLXEMAY.Tables["ACCOUNT"].NewRow();
                //B2
                drThem["MAACC"] = pMaAcc;
                drThem["TENACC"] = pTenAcc;
                drThem["MATKHAU"] = pMatKhau;
                drThem["EMAIL"] = pEmail;
                drThem["SDT"] = pSDT;
                drThem["DIACHI"] = pDiaChi;
                drThem["MALOAI"] = pMaLoai;
                //B3
                ds_QLXEMAY.Tables["ACCOUNT"].Rows.Add(drThem);

                

                //Xac dinh khoa chinh
                DataColumn[] KhoaChinh = new DataColumn[1];
                KhoaChinh[0] = ds_QLXEMAY.Tables["ACCOUNT"].Columns[0];
                ds_QLXEMAY.Tables["ACCOUNT"].PrimaryKey = KhoaChinh;
      
                return true;
                //
            }
            catch
            {
                return false;
            }
        }

        public bool Them2(string pMaAcc, string pTenAcc, string pMatKhau, string pEmail, string pSDT, string pDiaChi, string pMaLoai)
        {
            try
            {
                DataRow drThem = ds_QLXEMAY.Tables["ACCOUNT"].NewRow();
                //B2
                drThem["MAACC"] = pMaAcc;
                drThem["TENACC"] = pTenAcc;
                drThem["MATKHAU"] = pMatKhau;
                drThem["EMAIL"] = pEmail;
                drThem["SDT"] = pSDT;
                drThem["DIACHI"] = pDiaChi;
                drThem["MALOAI"] = pMaLoai;
                //B3
                ds_QLXEMAY.Tables["ACCOUNT"].Rows.Add(drThem);

                SqlCommandBuilder cmb = new SqlCommandBuilder(da_XeMay);
                da_XeMay.Update(ds_QLXEMAY, "ACCOUNT");

                return true;
            }
            catch 
            {
                return false;
            }
        }


        public string XuatTenLoai(string v)
        {
            try
            {
                cnn.Open();
                string CauLenh = "SELECT TENLOAI FROM LOAITK WHERE MALOAI = '" + v + "'";
                SqlCommand cmd = new SqlCommand(CauLenh, cnn);
                string kq = cmd.ExecuteScalar().ToString();
                cnn.Close();
                return kq;
            }
            catch { return null; }
            
        }



        public bool Xoa(string pMaLop)
        {
            try
            {
                DataRow drXoa = ds_QLXEMAY.Tables["ACCOUNT"].Rows.Find(pMaLop);
                drXoa.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(string pMaLop, string pTenLop)
        {
            try
            {
                DataRow drSua = ds_QLXEMAY.Tables["Lop"].Rows.Find(pMaLop);
                if (drSua != null)
                {
                    drSua["TenLop"] = pTenLop;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DangNhap(string pTenAcc,string pMatKhau)
        {
            try 
            {
                cnn.Open();
                string CauLenh = "SELECT COUNT(*) FROM ACCOUNT WHERE TENACC='"+pTenAcc+"' AND MATKHAU='"+pMatKhau+"'";

                SqlCommand cmd = new SqlCommand(CauLenh,cnn);

                int count = (int)cmd.ExecuteScalar();

                cnn.Close();

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
           
        }

        public bool KT_TKNV(string pTenAcc)
        {
            try
            {
                cnn.Open();
                string CauLenh = "SELECT COUNT(*) FROM ACCOUNT WHERE TENACC='"+pTenAcc+"' AND MALOAI LIKE 'NV%'";

                SqlCommand cmd = new SqlCommand(CauLenh, cnn);

                int count = (int)cmd.ExecuteScalar();

                cnn.Close();

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
        public bool KT_TKNVNK(string pTenAcc)
        {
            try
            {
                cnn.Open();
                string CauLenh = "SELECT COUNT(*) FROM ACCOUNT WHERE TENACC='" + pTenAcc + "' AND MAACC LIKE 'NVNH%'";

                SqlCommand cmd = new SqlCommand(CauLenh, cnn);

                int count = (int)cmd.ExecuteScalar();

                cnn.Close();

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
        public bool KT_TKKH(string pTenAcc)
        {
            try
            {
                cnn.Open();
                string CauLenh = "SELECT COUNT(*) FROM ACCOUNT WHERE TENACC='" + pTenAcc + "' AND MALOAI LIKE 'KH%'";

                SqlCommand cmd = new SqlCommand(CauLenh, cnn);

                int count = (int)cmd.ExecuteScalar();

                cnn.Close();

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }   

            }
            catch
            {
                return false;
            }

        }  
    }
}
