using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL
{
    public class HoaDonKhamBenh_HuyBLL
    {
        HoaDonKhamBenh_HuyDAL hdkb = new HoaDonKhamBenh_HuyDAL();

        public DataTable load_HDKB()
        {
            return hdkb.load_HoaDonKhamBenh();
        }

        public bool them(int maHoaDonKham, int soPhieuKham, string ngayLAPHD, float thanhTien)
        {
            if (hdkb.them(maHoaDonKham, soPhieuKham, ngayLAPHD, thanhTien) == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
