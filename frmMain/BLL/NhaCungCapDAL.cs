using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NhaCungCapDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataTable loadCCB()
        {
            da = new SqlDataAdapter("select * from NHACUNGCAP", cnn);
            da.Fill(ds, "dsNCC");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsNCC"].Columns[0];
            ds.Tables["dsNCC"].PrimaryKey = khoachinh;
            return ds.Tables["dsNCC"];
        }
    }
}
