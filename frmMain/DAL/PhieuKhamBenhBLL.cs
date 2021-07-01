using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class PhieuKhamBenhBLL
    {
        PhieuKhamBenhDAL phieukham = new PhieuKhamBenhDAL();
        public DataTable loadChoKham()
        {
            return phieukham.loadChoKham();
        }
        public DataTable loadChoXetNghiem()
        {
            return phieukham.loadChoXetNghiem();
        }
        public bool suaTrangThaiDaKham(int sopk)
        {
            return phieukham.suaTrangThaiDaKham(sopk);
        }
        public bool suaTrangThaiChoXetNghiem(int sopk)
        {
            return phieukham.suaTrangThaiChoXetNghiem(sopk);
        }
        public DataTable load_PhieuKhamBenh()
        {
            return phieukham.load_PhieuKhamBenh();
        }
        public DataTable loadPhieuKhamBenh(int tenBN)
        {
            return phieukham.loadPhieuKhamBenh(tenBN);
        }


        public bool them(int maPhieu, int maBN, string maNV, string ngayLapPhieu, string maPhong, string tinhTrangSucKhoe, string deNghiKham, string maGiaKham, string trangThaiPhieu)
        {
            if (phieukham.them(maPhieu, maBN, maNV, ngayLapPhieu, maPhong, tinhTrangSucKhoe, deNghiKham, maGiaKham, trangThaiPhieu) == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public int laySoPhieuKham(int maBN)
        {
            return phieukham.layMaPhieuKhamBenh(maBN);
        }

        public string TrangThaiBN(int sophieukham)
        {
            return phieukham.TrangThaiBN(sophieukham);
        }
    }
}
