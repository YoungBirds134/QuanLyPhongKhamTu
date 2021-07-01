using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
  public  class BenhNhan_HuyBLL
    {
        BenhNhan_HuyDAL bn = new BenhNhan_HuyDAL();
        public DataTable loadGripView()
        {
            return bn.loadGridView();
        }

        public bool them(int maBN, string tenBN, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            if (bn.them(maBN, tenBN, ngaySinh, gioiTinh, diaChi, sDT) == true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public int layMaBenhNhan(string ten, string diachi)
        {
            return bn.layMaBenhNhan(ten, diachi);
        }
    }
}
