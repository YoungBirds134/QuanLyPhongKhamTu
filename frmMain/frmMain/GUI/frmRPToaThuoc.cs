using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace frmMain.GUI
{
    public partial class frmRPToaThuoc : DevExpress.XtraEditors.XtraForm
    {
        public frmRPToaThuoc()
        {
            InitializeComponent();
        }
        public void printRP(Model.rpToaThuoc bp, List<Model.rpToaThuoc> lstbillpay)
        {
            GUI.rpToaThuocTest rpBill = new GUI.rpToaThuocTest();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rpBill.Parameters)
            {
                p.Visible = false;
                rpBill.initData(bp.TenNV,bp.TenBN,bp.NgayLap,bp.TongTien,bp.DVT,bp.DonGia,bp.TenThuoc,bp.MaToa,bp.SoLuong,bp.ThanhTien, lstbillpay);
                documentViewer1.DocumentSource = rpBill;
                rpBill.CreateDocument();
            }
        }
        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }
    }
}