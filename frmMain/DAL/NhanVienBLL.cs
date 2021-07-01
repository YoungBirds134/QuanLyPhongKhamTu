using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nv = new NhanVienDAL(); 
        public DataTable loadGripView()
        {
            return nv.loadGridView();
        }
        public bool them(string maNV, string tenNV, string tenDN, string matKhau, string ngaySinh, string gioiTinh, string diaChi, string gmail, string sDT, string chucVu, double luongCB, double hSL, double luong, string maKhoa)
        {
            if (nv.them(maNV,tenDN,tenDN,matKhau,ngaySinh,gioiTinh,diaChi,gmail,sDT,chucVu,luongCB,hSL,luong,maKhoa) == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool xoa(string manv)
        {
            if (nv.xoa(manv) == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool sua(string maNV, string tenNV, string tenDN, string matKhau, string ngaySinh, string gioiTinh, string diaChi, string gmail, string sDT, string chucVu, double luongCB, double hSL, double luong, string maKhoa)
        {
            if (nv.sua(maNV,tenDN,tenDN,matKhau,ngaySinh,gioiTinh,diaChi,gmail,sDT,chucVu,luongCB,hSL,luong,maKhoa) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public DataTable findNV(string tenNV)
        //{
        //    return nv.findGridView(tenNV);
        //}
        public DataTable layTTNhanVien(string tenDangNhap)
        {
            return nv.layThongTinNhanVien(tenDangNhap);
        }
    }
}
