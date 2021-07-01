using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
  public  class NhaSanXuatBLL
    {
        NhaSanXuatDAL nsx = new NhaSanXuatDAL();
        public DataTable loadGripView()
        {
            return nsx.loadGridView();
        }
    }
}
