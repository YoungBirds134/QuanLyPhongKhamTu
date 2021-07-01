using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace frmMain.Model
{
  public  class DichVu
    {
        private string tenNV, tenBN, tenDV, ngayLapPhieu;
        private int maDKDV;
        private double tongTien, thanhTien, giaSD;
        public DichVu() { }
        public DichVu(DataRow row)
        {
            this.TenNV = row[0].ToString();
            this.TenBN = row[1].ToString();
            this.MaDKDV = (int)row[2];
            this.TenDV = row[3].ToString();
            this.TongTien = (double)row[4];
            this.ThanhTien = (double)row[5];
            this.GiaSD = (double)row[6];
            this.NgayLapPhieu = row[7].ToString();
        }

        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public string NgayLapPhieu { get => ngayLapPhieu; set => ngayLapPhieu = value; }
        public int MaDKDV { get => maDKDV; set => maDKDV = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public double GiaSD { get => giaSD; set => giaSD = value; }
    }
}
