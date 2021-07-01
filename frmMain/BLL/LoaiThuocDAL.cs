using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class LoaiThuocDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from LOAITHUOC", cnn);
            da.Fill(ds, "dsLT");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsLT"].Columns[0];
            ds.Tables["dsLT"].PrimaryKey = khoachinh;
            return ds.Tables["dsLT"];
        }
        public bool them(string maLoai, string tenLoai)
        {
            try
            {
                DataRow dr = ds.Tables["dsLT"].NewRow();
                dr["MALOAI"] = maLoai;
                dr["TENLOAI"] = tenLoai;
                ds.Tables["dsLT"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool xoa(string maLoai)
        {
            try
            {
                DataRow dr = ds.Tables["dsLT"].Rows.Find(maLoai);
                if (dr != null)
                {
                    dr.Delete();
                    luu();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool sua(string maLoai, string tenLoai)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsLT"].Rows.Find(maLoai);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE LOAITHUOC SET TENLOAI=N'" + tenLoai + "' WHERE MALOAI='" + maLoai  + "'", cnn);
                    capnhat.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsLT"]);
        }
    }
}
