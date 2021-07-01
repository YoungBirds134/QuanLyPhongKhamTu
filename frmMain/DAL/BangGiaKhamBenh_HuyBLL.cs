using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   public class BangGiaKhamBenh_HuyBLL
    {
        BangGiaKhamBenh_HuyDAL bgkb = new BangGiaKhamBenh_HuyDAL();

        public DataTable load_BangGiaKhamBenh()
        {
            return bgkb.load_BangGiaKham();
        }
        public float layGiaKhamBenh(string maGiaKham)
        {
            return bgkb.layGiaTienKham(maGiaKham);
        }
    }
}
