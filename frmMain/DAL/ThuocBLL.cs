using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class ThuocBLL
    {
        ThuocDAL t = new ThuocDAL();
        public DataTable loadGripView()
        {
            return t.loadGridView();
        }
        public bool them(string maThuoc, string tenThuoc, string maLoai, string maNSX, string congDung, string hamLuong, string HSD, string donViCB, double giaCB, double soLuongCB, string donViBan, double giaBan, double soLuongBan, double giaTriQuyDoi, string quyCachDongGoi, string maViTri, string moTa)
        {
            if (t.them(maThuoc, tenThuoc,maLoai,maNSX,congDung,hamLuong,HSD,donViCB,giaCB,soLuongCB,donViBan,giaBan,soLuongBan,giaTriQuyDoi,quyCachDongGoi,maViTri,moTa) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoa(string maLoai)
        {
            if (t.xoa(maLoai) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool sua(string maThuoc, string tenThuoc, string maLoai, string maNSX, string congDung, string hamLuong, string HSD, string donViCB, double giaCB, double soLuongCB, string donViBan, double giaBan, double soLuongBan, double giaTriQuyDoi, string quyCachDongGoi, string maViTri, string moTa)
        {
            if (t.sua(maThuoc, tenThuoc, maLoai, maNSX, congDung, hamLuong, HSD, donViCB, giaCB, soLuongCB, donViBan, giaBan, soLuongBan, giaTriQuyDoi, quyCachDongGoi, maViTri, moTa) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string maThuoc(string tenthuoc)
        {
            return t.maThuoc(tenthuoc);
        }

        public bool suaNhapThuoc(string ma, int soluongban, string hsd)
        {
            return t.suaNhapThuoc(ma, soluongban, hsd);
        }

        public DataTable loadThuocHetHanHetHang()
        {
            return t.loadThuocHetHanHetHang();
        }

        public string tenThuoc(string mathuoc)
        {
            return t.tenThuoc(mathuoc);
        }

        public void loadDVTTheoThuoc(string mathuoc, ComboBox com)
        {
            t.loadDVTTheoThuoc(mathuoc, com);
        }

        public string loadGiaTheoDVT(string mathuoc, ComboBox com, int trangthai)
        {
            return t.loadGiaTheoDVT(mathuoc, com, trangthai);
        }

        public bool capnhatSLThuocThem(string ma, int soluongmua, int kieumua)
        {
            return t.capnhatSLThuocThem(ma, soluongmua, kieumua);
        }
        public bool capnhatSLThuocXoa(string ma, int soluongmua, int kieumua)
        {
            return t.capnhatSLThuocXoa(ma, soluongmua, kieumua);
        }
        public int sLTon(string mathuoc, int trangthai)
        {
            return t.sLTon(mathuoc, trangthai);
        }
        public double giaBan(string mathuoc)
        {
            return t.giaBan(mathuoc);
        }
    }
}
