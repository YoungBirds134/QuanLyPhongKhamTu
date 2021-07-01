using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace frmMain.Model
{
   public class NhapHang
    {
        private string tenNV, tenNCC, ngayDat, ngayNhap, hSD, maCTDH, maDH;
        private int soLuong;
        private double tongTienDat, tongTienNhap, giaNhap, thanhTienNhap;
        public NhapHang() { }
        public NhapHang(DataRow row)
        {
            this.TenNV = row[0].ToString();
            this.TenNCC = row[1].ToString();
            this.NgayDat = row[2].ToString();
            this.TongTienDat = (double)row[3];
            this.NgayNhap = row[4].ToString();
            this.TongTienNhap = (double)row[5];
            this.GiaNhap = (double)row[6];
            this.HSD = row[7].ToString();
            this.MaCTDH = row[8].ToString();
            this.MaDH = row[9].ToString();
            this.SoLuong = (int)row[10];
            this.ThanhTienNhap = (double)row[11];
        }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string NgayDat { get => ngayDat; set => ngayDat = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string HSD { get => hSD; set => hSD = value; }
        public string MaCTDH { get => maCTDH; set => maCTDH = value; }
        public string MaDH { get => maDH; set => maDH = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double TongTienDat { get => tongTienDat; set => tongTienDat = value; }
        public double TongTienNhap { get => tongTienNhap; set => tongTienNhap = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double ThanhTienNhap { get => thanhTienNhap; set => thanhTienNhap = value; }
    }
}
