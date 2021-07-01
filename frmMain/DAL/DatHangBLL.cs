using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class DatHangBLL
    {
        DatHangDAL dathang = new DatHangDAL();
        public DataTable loadGridViewTKMaDH(string madh)
        {
            return dathang.loadGridViewTKMaDH(madh);
        }
        public DataTable loadGridViewTKCTDH(string madh)
        {
            return dathang.loadGridViewTKCTDH(madh);
        }
        public bool suaTrangThai(string madathang)
        {
            return dathang.suaTrangThai(madathang);
        }
        public string kTraTrangThai(string madat)
        {
            return dathang.kTraTrangThai(madat);
        }
        public string loadMaDH()
        {
            return dathang.loadMaDH();
        }
        public bool them(string madathang, string mancc, string manv, string ngaydat, double tongtien, string trangthai)
        {
            return dathang.them(madathang, mancc, manv, ngaydat, tongtien, trangthai);
        }
        public string loadMaCTDH()
        {
            return dathang.loadMaCTDH();
        }
        public bool themDSThuoc(string machitiet, string madathang, string mathuoc, int soluongdat, double gianhap, double thanhtien)
        {
            return dathang.themDSThuoc(machitiet, madathang, mathuoc, soluongdat, gianhap, thanhtien);
        }
        public bool xoa(string macthoadon)
        {
            return dathang.xoa(macthoadon);
        }
        public DataTable loadGridViewDangDatHang(string madathang)
        {
            return dathang.loadGridViewDangDatHang(madathang);
        }
        public bool suaTongThanhTienC(string madathang, double tongtien)
        {
            return dathang.suaTongThanhTienC(madathang, tongtien);
        }
        public bool suaTongThanhTienT(string madathang, double tongtien)
        {
            return dathang.suaTongThanhTienT(madathang, tongtien);
        }
        public bool xoaDH(string mahoadon)
        {
            return dathang.xoaDH(mahoadon);
        }

    }
}
