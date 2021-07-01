using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace frmMain.Model
{
  public  class rpToaThuoc
    {
        private int maToa;
        private int soLuong;
        private string tenNV, tenBN, ngayLap,dVT,tenThuoc;
        private double tongTien, thanhTien, donGia;
        public rpToaThuoc() {  }
        public rpToaThuoc(DataRow row)
        {
            this.TenNV = row[0].ToString();
            this.tenBN = row[1].ToString();
            this.ngayLap = row[2].ToString();
            this.TongTien = (double)row[3];
            this.DVT = row[4].ToString();
            this.DonGia = (double)row[5];
            this.TenThuoc = row[6].ToString();
            this.MaToa = (int)row[7];
            this.SoLuong = (int)row[8];
            this.ThanhTien = (double)row[9];
        }
        public int MaToa { get => maToa; set => maToa = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public string DVT { get => dVT; set => dVT = value; }
        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
