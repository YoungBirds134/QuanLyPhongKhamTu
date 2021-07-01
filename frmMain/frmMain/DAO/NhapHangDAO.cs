using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using frmMain.Model;
namespace frmMain.DAO
{
  public  class NhapHangDAO
    {
        Model.NhapHang tp = new Model.NhapHang();
        DataSet ds = new DataSet();

        SqlDataAdapter da;
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        public List<Model.NhapHang> loadBillPay(string maNH)
        {
            List<Model.NhapHang> lstBillPay = new List<Model.NhapHang>();
            string sqlBill = "exec rpNhapHang '" + maNH + "'";
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sqlBill, cnn);
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Model.NhapHang billPay = new Model.NhapHang(item);
                lstBillPay.Add(billPay);

            }
            return lstBillPay;
        }
        public DataTable rpDSNhapHang()
        {
          
            string sqlBill = "exec rpDSNhapHang";
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sqlBill, cnn);
            da.Fill(dt);
           
            return dt; 
        }
    }
}
