using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class ToaThuocBLL
    {
        ToaThuocDAL toathuoc = new ToaThuocDAL();

        public bool them(int sophieukham, string mabs, string ngaylaptoa, string tinhtrang, string chuandoan, string huongdieutri, double tongtien)
        {
            return toathuoc.them(sophieukham, mabs, ngaylaptoa, tinhtrang, chuandoan, huongdieutri, tongtien);
        }
        public string loadMaToa()
        {
            return toathuoc.loadMaToa();
        }
        public bool themDSThuoc(int matoa, string mathuoc, int soluong, double giaban, string dvt, string cachdung, double thanhtien)
        {
            return toathuoc.themDSThuoc(matoa, mathuoc, soluong, giaban, dvt, cachdung, thanhtien);
        }
        public bool xoaDSThuoc(int matoa, string mathuoc)
        {
            return toathuoc.xoaDSThuoc(matoa, mathuoc);
        }
        public DataTable loadDS(string matoa)
        {
            return toathuoc.loadDS(matoa);
        }
        public bool capnhatTongThanhTienC(int matoa, double thanhtien)
        {
            return toathuoc.capnhatTongThanhTienC(matoa, thanhtien);
        }
        public bool capnhatTongThanhTienT(int matoa, double thanhtien)
        {
            return toathuoc.capnhatTongThanhTienT(matoa, thanhtien);
        }
        public DataTable rpToaThuoc(int matoa)
        {
            return toathuoc.rpToaThuoc(matoa);
        }
    }
}
