using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class BenhNhan_HuyDAL
    {
        DataSet ds = new DataSet();
       
        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from BENHNHAN", cnn);
            da.Fill(ds, "dsBN");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsBN"].Columns[0];
            ds.Tables["dsBN"].PrimaryKey = khoachinh;
            return ds.Tables["dsBN"];
        }


        public bool them(int maBN, string tenBN, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {

            try
            {
                DataRow dr = ds.Tables["dsBN"].NewRow();

                dr["MABN"] = maBN;
                dr["TENBN"] = tenBN;
                dr["NGAYSINH"] = ngaySinh;
                dr["GIOITINH"] = gioiTinh;
                dr["DIACHI"] = diaChi;
                dr["SDT"] = sDT;
                ds.Tables["dsBN"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsBN"]);
        }


        public int layMaBenhNhan(string ten, string diachi)
        {
            string id = "";

            SqlCommand cmd = new SqlCommand("SELECT * FROM BenhNhan WHERE tenbn = N'" + ten + "' and diachi = N'" + diachi + "'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    id = dr["MaBN"].ToString();
                }
            }

            int idd = int.Parse(id);
            return idd;
        }
    }
}
