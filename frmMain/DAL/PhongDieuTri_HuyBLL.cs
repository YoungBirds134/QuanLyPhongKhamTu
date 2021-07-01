using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
  public  class PhongDieuTri_HuyBLL
    {
        PhongDieuTri_HuyDAL pdt = new PhongDieuTri_HuyDAL();
        public DataTable load_cbPhongDieuTri()
        {
            return pdt.load_PhongDieuTri();
        }
    }
}
