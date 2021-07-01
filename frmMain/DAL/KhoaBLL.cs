using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
    public class KhoaBLL
    {
        KhoaDAL k = new KhoaDAL();
        public DataTable loadGripview()
        {
            return k.loadGridView();
        }
    }
}
