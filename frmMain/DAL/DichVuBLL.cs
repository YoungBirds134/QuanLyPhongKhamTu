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
    public class DichVuBLL
    {
        DichVuDAL dichvu = new DichVuDAL();
        public DataTable loadCBBDV()
        {
            return dichvu.loadCBBDV();
        }
        public string loadThanhTien(string madv)
        {
            return dichvu.loadThanhTien(madv);
        }
    }
}
