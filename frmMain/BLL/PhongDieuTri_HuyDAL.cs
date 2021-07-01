using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongDieuTri_HuyDAL
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");

        public DataTable load_PhongDieuTri()
        {
            da = new SqlDataAdapter("select * from Phong WHERE LOAIPHONG=N'phòng khám'", cnn);
            da.Fill(ds, "dsP");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsP"].Columns[0];
            ds.Tables["dsP"].PrimaryKey = khoachinh;
            return ds.Tables["dsP"];
        }
    }
}
