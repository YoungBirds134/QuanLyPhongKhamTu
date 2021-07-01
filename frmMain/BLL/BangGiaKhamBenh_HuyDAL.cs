using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BangGiaKhamBenh_HuyDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        //SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-R95F3JA;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=taquangtrung");
        SqlDataAdapter da;

        public DataTable load_BangGiaKham()
        {
            da = new SqlDataAdapter("select * from BangGiaKhamBenh", cnn);
            da.Fill(ds, "dsBGKB");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsBGKB"].Columns[0];
            ds.Tables["dsBGKB"].PrimaryKey = khoachinh;
            return ds.Tables["dsBGKB"];
        }

        public float layGiaTienKham(string maGiaKham)
        {
            string id = "";

            SqlCommand cmd = new SqlCommand("select * from BANGGIAKHAMBENH where MAGIAKHAM= '" + maGiaKham + "'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    id = dr["TIENKHAM"].ToString();
                }
            }

            float idd = float.Parse(id);
            return idd;
        }
    }
}
