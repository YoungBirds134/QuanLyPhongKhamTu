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
using frmMain.Model;
namespace frmMain.GUI
{
    public partial class frmRPDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmRPDichVu()
        {
            InitializeComponent();
        }
        public void printRP(Model.DichVu bp, List<Model.DichVu> lstbillpay)
        {
            GUI.rpDichVu2 rpBill = new GUI.rpDichVu2();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rpBill.Parameters)
            {
                p.Visible = false;
                rpBill.initData(bp.TenNV, bp.TenBN,bp.MaDKDV,bp.TenDV,bp.TongTien,bp.ThanhTien,bp.GiaSD,bp.NgayLapPhieu, lstbillpay);
                documentViewer1.DocumentSource = rpBill;
                rpBill.CreateDocument();
            }
        }

        private void frmRPDichVu_Load(object sender, EventArgs e)
        {

        }
    }
}