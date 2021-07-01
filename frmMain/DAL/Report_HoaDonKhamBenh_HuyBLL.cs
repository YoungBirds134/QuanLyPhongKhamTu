using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   public class Report_HoaDonKhamBenh_HuyBLL
    {
        Report_HoaDonKhamBenh_HuyDAL hd = new Report_HoaDonKhamBenh_HuyDAL();
        public DataTable loadBillByBillID(string maBN)
        {

            return hd.loadBillByBillID(maBN);
        }
        public DataTable phieuKhamBenh(int maBN)
        {

            return hd.phieuKhamBenh(maBN);
        }
        public DataTable datHang(string maDH)
        {

            return hd.datHang(maDH);
        }
        public DataTable nhapHang(string maNH)
        {

            return hd.nhapHang(maNH);
        }
    }
}
