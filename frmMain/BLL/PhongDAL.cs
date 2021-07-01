using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhongDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataTable loadPhongXetNghiem()
        {
            da = new SqlDataAdapter("select * from  PHONG where LOAIPHONG=N'phòng dịch vụ'", cnn);
            da.Fill(ds, "dsPhongDV");

            return ds.Tables["dsPhongDV"];
        }
    }
}
