using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class KhoaDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from KHOA", cnn);
            da.Fill(ds, "dsKhoa");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsKhoa"].Columns[0];
            ds.Tables["dsKhoa"].PrimaryKey = khoachinh;
            return ds.Tables["dsKhoa"];
        }
        public bool them( string maKhoa, string tenKhoa, string chucNang)
        {
            try
            {
                DataRow dr = ds.Tables["dsKhoa"].NewRow();
                dr["MAKHOA"] = maKhoa;
                dr["TENKHOA"] = tenKhoa;
                dr["CHUCNANG"] = chucNang;

                ds.Tables["dsKhoa"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool xoa(string maNV)
        {
            try
            {
                DataRow dr = ds.Tables["dsKhoa"].Rows.Find(maNV);
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

        public bool sua(string maKhoa, string tenKhoa, string chucNang)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsKhoa"].Rows.Find(maKhoa);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE KHOA SET TENKHOA=N'" + tenKhoa + "',CHUCVU = N'" + chucNang+ "' WHERE MAKHOA='" + maKhoa+ "'", cnn);
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
            da.Update(ds.Tables["dsKhoa"]);
        }

        public string tenKhoa(string makhoa)
        {
            da = new SqlDataAdapter("select * from KHOA where MAKHOA='" + makhoa + "'", cnn);
            da.Fill(ds, "dsKhoa1");

            DataRow dr = ds.Tables["dsKhoa1"].Rows[0];
            return dr["TENKHOA"].ToString();
        }
    }
}
