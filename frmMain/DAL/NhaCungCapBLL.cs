using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAL ncc = new NhaCungCapDAL();
        public DataTable loadCCB()
        {
            return ncc.loadCCB();
        }
    }
}
