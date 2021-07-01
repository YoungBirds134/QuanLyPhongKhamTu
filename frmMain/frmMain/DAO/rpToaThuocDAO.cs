using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using frmMain.Model;
namespace frmMain.GUI.DAO
{
   public class rpToaThuocDAO
    {
        Model.rpToaThuoc tp = new Model.rpToaThuoc();
        DataSet ds = new DataSet();

        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        public List<Model.rpToaThuoc> loadBillPay(int maToa)
        {
            List<Model.rpToaThuoc> lstBillPay = new List<Model.rpToaThuoc>();
            string sqlBill = "exec procToaThuoc " + maToa;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sqlBill, cnn);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Model.rpToaThuoc billPay = new Model.rpToaThuoc(item);
                lstBillPay.Add(billPay);

            }
            return lstBillPay;
        }
    }
}
