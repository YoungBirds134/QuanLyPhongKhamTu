using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class PhieuDichVuBLL
    {
        PhieuDichVuDAL phieudichvu = new PhieuDichVuDAL();
        public bool them(int sophieukham, string mabs, string ngaylap, string maphong, double tongtien, string trangthai)
        {
            return phieudichvu.them(sophieukham, mabs, ngaylap, maphong, tongtien, trangthai);
        }
        public string loadMaDKDV()
        {
            return phieudichvu.loadMaDKDV();
        }
        public bool themCT(int madkdv, string madv, double thanhtien)
        {
            return phieudichvu.themCT(madkdv, madv, thanhtien);
        }
        public bool xoaCT(int mactdkdv)
        {
            return phieudichvu.xoaCT(mactdkdv);
        }
        public DataTable loadGirdViewCT(int madkdv)
        {
            return phieudichvu.loadGirdViewCT(madkdv);
        }
        public bool capnhatTongTienC(int madkdv, double thanhtien)
        {
            return phieudichvu.capnhatTongTienC(madkdv, thanhtien);
        }
        public bool capnhatTongTienT(int madkdv, double thanhtien)
        {
            return phieudichvu.capnhatTongTienT(madkdv, thanhtien);
        }
        public string tongtien(int madk)
        {
            return phieudichvu.tongtien(madk);
        }
        public DataTable loadChuaXN()
        {
            return phieudichvu.loadChuaXN();
        }
        public DataTable loadGridView(int maphieudk)
        {
            return phieudichvu.loadGridView(maphieudk);
        }
        public bool themKQ(int madkdv, string manv, string ngaylap, string ghichu)
        {
            return phieudichvu.themKQ(madkdv, manv, ngaylap, ghichu);
        }
        public bool suaKQ(int makqdv, int madkdv, string manv, string ngaylap, string ghichu)
        {
            return phieudichvu.suaKQ(makqdv, madkdv, manv, ngaylap, ghichu);
        }
        public DataTable loadGridViewKQ(int ma)
        {
            return phieudichvu.loadGridViewKQ(ma);
        }
        public DataTable loadGridViewKQDV(string makqdv)
        {
            return phieudichvu.loadGridViewKQDV(makqdv);
        }
        public bool themTT(string madkdv, string manv, string ngaylap, double tongtien)
        {
            return phieudichvu.themTT(madkdv, manv, ngaylap, tongtien);
        }
        public DataTable loadThanhToan1(string sohd)
        {
            return phieudichvu.loadThanhToan1(sohd);
        }
        public DataTable loadThanhToan()
        {
            return phieudichvu.loadThanhToan();
        }
        public bool capNhatTrangThaiPhieu(string madkdv)
        {
            return phieudichvu.capNhatTrangThaiPhieu(madkdv);
        }
        public DataTable REPORT1(int makqdv, int madkdv)
        {
            return phieudichvu.REPORT1(makqdv, madkdv);
        }
    }
}
