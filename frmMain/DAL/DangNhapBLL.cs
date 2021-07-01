using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
   public class DangNhapBLL
    {
       DangNhapDAL dn = new DangNhapDAL();
       public bool dangNhap(string tendangnhap, string matkhau)
       {
           return dn.login(tendangnhap, matkhau);
       }
       public string layCHucVu(string tendangnhap, string matkhau)
       {
           return dn.layChucVu(tendangnhap, matkhau).ToString();          
       }
    }
}
