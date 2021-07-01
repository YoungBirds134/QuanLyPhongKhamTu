using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HoaDonThuocDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public void load()
        {
            da = new SqlDataAdapter("select MATOA,NGAYLAPHDKHAM,TONGTIENTIEN from HOADONTHUOC", cnn);
            da.Fill(ds, "dsHoaDon");
        }

        public bool them(int matoa, string ngaylap, double tongtien)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsHoaDon"].NewRow();
                dr["MATOA"] = matoa;
                dr["NGAYLAPHDKHAM"] = ngaylap;
                dr["TONGTIENTIEN"] = tongtien;
                ds.Tables["dsHoaDon"].Rows.Add(dr);
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
            da.Update(ds.Tables["dsHoaDon"]);
        }
    }
}
