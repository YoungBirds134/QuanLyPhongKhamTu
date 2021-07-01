using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
   public class LoaiThuocBLL
    {
       LoaiThuocDAL lt = new LoaiThuocDAL();
       public DataTable loadGripView()
       {
           return lt.loadGridView();
       }
       public bool them(string maLoai, string tenLoai)
       {
           if (lt.them(maLoai,tenLoai)== true)
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
           if (lt.xoa(maLoai) == true)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool sua(string maLoai, string tenLoai)
       {
           if (lt.sua(maLoai, tenLoai) == true)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
