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
    public partial class frmRPNhapHang : DevExpress.XtraEditors.XtraForm
    {
        public frmRPNhapHang()
        {
            InitializeComponent();
        }
        public void printRP(Model.NhapHang bp, List<Model.NhapHang> lstbillpay)
        {
            GUI.rpNhapHang rpBill = new GUI.rpNhapHang();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rpBill.Parameters)
            {
                p.Visible = false;
                rpBill.initData(bp.TenNV,bp.TenNCC,bp.NgayDat,bp.TongTienDat,bp.NgayNhap,bp.TongTienNhap,bp.GiaNhap,bp.HSD,bp.MaCTDH,bp.MaDH,bp.SoLuong,bp.ThanhTienNhap, lstbillpay);
                documentViewer1.DocumentSource = rpBill;
                rpBill.CreateDocument();
            }
        }
        private void frmRPNhapHang_Load(object sender, EventArgs e)
        {

        }
    }
}