using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
namespace BLL
{
    public class ViTriBLL
    {
        ViTriDAL vt = new ViTriDAL();
        public DataTable loadGripView()
        {
            return vt.loadGridView();
        }
    }
}
