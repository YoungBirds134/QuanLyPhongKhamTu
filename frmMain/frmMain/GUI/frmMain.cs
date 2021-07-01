using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmMain.GUI;
using BLL;
using DevExpress.XtraReports.UI;
using frmMain.DAO;

namespace frmMain
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

        }
        private static string chucVu;

        public static string ChucVu { get => chucVu; set => chucVu = value; }

        public frmMain(string cv)
        {
            InitializeComponent();
            ChucVu = cv;
            if (ChucVu == "Bác sĩ")
            {

                btnDSDH.Enabled = btnDSNH.Enabled = btnTiepNhan2.Enabled = btnThongKeDSBenhNhan.Enabled = btnXetNghiem.Enabled = btnViTri.Enabled = btnNhanVien.Enabled = btnNhaCC.Enabled = btnLoaiThuoc.Enabled = btnThuoc.Enabled = btnDatHang.Enabled = btnBanThuoc.Enabled = btnNhapHang.Enabled = btnThongKeDSBenhNhan.Enabled = false;
            }
            else if (ChucVu == "Dịch vụ")
            {
                btnDSDH.Enabled = btnDSNH.Enabled = btnTiepNhan2.Enabled = btnThongKeDSBenhNhan.Enabled = btnDaKhoa2.Enabled = btnKhamBenh.Enabled = btnViTri.Enabled = btnNhanVien.Enabled = btnNhaCC.Enabled = btnLoaiThuoc.Enabled = btnThuoc.Enabled = btnDatHang.Enabled = btnBanThuoc.Enabled = btnNhapHang.Enabled = btnThongKeDSBenhNhan.Enabled = false;

            }

            else if (ChucVu == "Quản lý")
            {
                btnKhamBenh.Enabled = btnXetNghiem.Enabled = btnDaKhoa2.Enabled = btnTiepNhan2.Enabled = false;
            }
            else if (ChucVu == "Tiếp nhận")
            {
                btnDSDH.Enabled = btnDSNH.Enabled = btnXetNghiem.Enabled = btnThongKeDSBenhNhan.Enabled = btnDaKhoa2.Enabled = btnKhamBenh.Enabled = btnViTri.Enabled = btnNhanVien.Enabled = btnNhaCC.Enabled = btnLoaiThuoc.Enabled = btnThuoc.Enabled = btnDatHang.Enabled = btnBanThuoc.Enabled = btnNhapHang.Enabled = btnThongKeDSBenhNhan.Enabled = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Visual Studio 2013 Light";

            //Form frm = this.checkExit(typeof(frmMedical));
            //if (frm != null)
            //{
            //    frm.Activate();
            //}
            //else
            //{
            //    frmMedical staff = new frmMedical();
            //    staff.MdiParent = this;
            //    staff.Show();
            //}
        }
        private Form checkExit(Type type)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() == type)
                {
                    return item;
                }
            }
            return null;
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmStaff2));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmStaff2 staff = new frmStaff2();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnNhaCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmSupplier));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmSupplier staff = new frmSupplier();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnLoaiThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmCategory));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmCategory staff = new frmCategory();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmMedicine));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmMedicine staff = new frmMedicine();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnViTri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmLocation));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmLocation staff = new frmLocation();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmOrder));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmOrder staff = new frmOrder();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnKhamBenh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpBenhNhan a = new rpBenhNhan();
            ReportPrintTool tool = new ReportPrintTool(a);
            a.ShowPreviewDialog();


        }

        private void btnDaKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmPolyclinic));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmPolyclinic staff = new frmPolyclinic();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnThuNgan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmCashier));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmCashier staff = new frmCashier();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnXetNghiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmTest));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmTest staff = new frmTest();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnLayThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmDrugDelivery));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmDrugDelivery staff = new frmDrugDelivery();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmImportMedicine));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmImportMedicine staff = new frmImportMedicine();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Program.frmDN.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frnAcount));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frnAcount staff = new frnAcount();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Program.frmDN.Show();

        }

        private void btnTiepNhan2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmStaffNursing));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmStaffNursing staff = new frmStaffNursing();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnDaKhoa2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frmPolyclinic));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                Program.frmKhamBenh = new frmPolyclinic();
                Program.frmKhamBenh.MdiParent = this;
                Program.frmKhamBenh.Show();
            }
        }

        private void btnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExit(typeof(frnAcount));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frnAcount staff = new frnAcount();
                staff.MdiParent = this;
                staff.Show();
            }
        }

        private void btnDangXUat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Program.frmDN.Show();
        }

        private void btnDSDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpDatHang a = new rpDatHang();

            ReportPrintTool tool = new ReportPrintTool(a);
            tool.ShowPreviewDialog();
        }
        NhapHangDAO z = new NhapHangDAO();
        private void btnRPDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpNhapHang2 a = new rpNhapHang2();
            //a.DataSource = z.rpDSNhapHang();
            ReportPrintTool tool = new ReportPrintTool(a);
            tool.ShowPreviewDialog();
        }
    }
}
