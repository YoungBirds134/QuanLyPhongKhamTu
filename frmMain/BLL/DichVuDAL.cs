using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public class DichVuDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataTable loadCBBDV()
        {
            da = new SqlDataAdapter("select * from  DICHVU", cnn);
            da.Fill(ds, "dsDV");

            return ds.Tables["dsDV"];
        }

        public string loadThanhTien( string madv)
        {
            da = new SqlDataAdapter("select * from  DICHVU WHERE MADV='" + madv + "'", cnn);
            da.Fill(ds, "thanhtien");

            string a = "";

            foreach(DataRow dr in ds.Tables["thanhtien"].Rows)
            {
                a = dr["GIASUDUNG"].ToString();
            }
            return a;
        }
    }
}
