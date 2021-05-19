using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    class ClassDoanhThu
    {
        ConnectionDB cndb = new ConnectionDB();
        public DataSet ds_XeMay = new DataSet();


        public void LoadDoanhThu(DataGridView data)
        {
            string CauLenh = "SELECT * FROM PHIEUBANHANG";
            SqlDataAdapter da_Khach = new SqlDataAdapter(CauLenh, cndb.cnn);
            da_Khach.Fill(ds_XeMay, "PHIEUBANHANG");
            data.DataSource = ds_XeMay.Tables["PHIEUBANHANG"];
        }   

        public int DoanhThu(DataGridView data)
        {
            int doanhthu = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Selected )
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        if (index == 5)
                        {
                            doanhthu = doanhthu + int.Parse(cell.Value.ToString()); 
                            //do what you want with the value
                        }
                        
                    }
                }
            } return doanhthu;
        }
  
    }
}
