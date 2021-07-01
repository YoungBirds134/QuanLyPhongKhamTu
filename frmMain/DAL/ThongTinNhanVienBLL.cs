using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    
    public class ThongTinNhanVienBLL
    {
        ThongTinNhanVienDAL thongtin = new ThongTinNhanVienDAL();
        public void loadProFile(TextBox ma, TextBox ten, TextBox tendn, TextBox matkhau, DateTimePicker ngaysinh, ComboBox gioitinh, TextBox diachi, TextBox gmail, TextBox sdt, TextBox chucvu, TextBox tenkhoa, TextBox luongcb, TextBox hsl, TextBox luong, string tendangnhap)
        {
            thongtin.loadProFile(ma, ten, tendn, matkhau, ngaysinh, gioitinh, diachi, gmail, sdt, chucvu, tenkhoa, luongcb, hsl, luong, tendangnhap);
        }
        public bool sua(string ma, string ten, string tendn, string matkhau, string ngaysinh, string gioitinh, string diachi, string gmail, string sdt)
        {
            return thongtin.sua(ma, ten, tendn, matkhau, ngaysinh, gioitinh, diachi, gmail, sdt);
        }
        public string tenNV(string tendangnhap)
        {
            return thongtin.tenNV(tendangnhap);
        }
        public string maNV(string tendangnhap)
        {
            return thongtin.maNV(tendangnhap);
        }
    }
    
}
