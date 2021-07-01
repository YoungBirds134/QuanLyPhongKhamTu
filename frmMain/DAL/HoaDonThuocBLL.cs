using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class HoaDonThuocBLL
    {
        HoaDonThuocDAL hoadonthuoc = new HoaDonThuocDAL();
        public bool them(int matoa, string ngaylap, double tongtien)
        {
            return hoadonthuoc.them(matoa, ngaylap, tongtien);
        }
    }
}
