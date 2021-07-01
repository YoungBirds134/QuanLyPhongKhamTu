using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frmMain.Model;
using System.Data.SqlClient;
using System.Data;
namespace frmMain.DAO
{
   public class DichVuDAO
    {
        Model.DichVu tp = new Model.DichVu();
        DataSet ds = new DataSet();

        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        public List<Model.DichVu> loadBillPay(int maToa)
        {
            List<Model.DichVu> lstBillPay = new List<Model.DichVu>();
            string sqlBill = "exec rpDichVu " + maToa;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sqlBill, cnn);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Model.DichVu billPay = new Model.DichVu(item);
                lstBillPay.Add(billPay);

            }
            return lstBillPay;
        }
    }
}
