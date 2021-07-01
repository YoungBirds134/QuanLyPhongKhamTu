using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class NhapThuocBLL
    {
        NhapThuocDAL nhapthuoc = new NhapThuocDAL();
        public string loadMaDH()
        {
            return nhapthuoc.loadMaDH();
        }
        public bool them(string manhap, string madat, string manv, string ngaynhap, double tongtien)
        {
            return nhapthuoc.them(manhap, madat, manv, ngaynhap, tongtien);
        }
        public bool suaTongThanhTien(string manhap, double tongtien)
        {
            return nhapthuoc.suaTongThanhTien(manhap, tongtien);
        }
        public DataTable loadGridViewDangNhapHang(string manhaphang)
        {
            return nhapthuoc.loadGridViewDangNhapHang(manhaphang);
        }
        public int loadMaCTNH()
        {
            return nhapthuoc.loadMaCTNH();
        }
        public bool themDSCTNhapHang(string manhaphang, string mactdathang, int soluongnhap, double gianhap, double thanhtien, string hsd)
        {
            return nhapthuoc.themDSCTNhapHang(manhaphang, mactdathang, soluongnhap, gianhap, thanhtien, hsd);
        }
    }
}
