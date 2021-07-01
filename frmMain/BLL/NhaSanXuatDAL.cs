using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class NhaSanXuatDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from NHASANXUAT", cnn);
            da.Fill(ds, "dsNSX");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsNSX"].Columns[0];
            ds.Tables["dsNSX"].PrimaryKey = khoachinh;
            return ds.Tables["dsNSX"];
        }
    }
}
