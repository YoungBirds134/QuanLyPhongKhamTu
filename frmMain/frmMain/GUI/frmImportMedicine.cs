using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using frmMain.DAO;
namespace frmMain.GUI
{
    public partial class frmImportMedicine : DevExpress.XtraEditors.XtraForm
    {
        DatHangBLL dathang = new DatHangBLL();
        XuLyGirdViewBLL xuly = new XuLyGirdViewBLL();
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();
        NhapThuocBLL nhapthuoc = new NhapThuocBLL();
        ThuocBLL thuoc = new ThuocBLL();
        double tongtien = 0;

        public frmImportMedicine()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadGridViewDH();
            LoadGridViewCTDH();
            if (dathang.kTraTrangThai(txtTim.Text).Trim().Length == 7) 
            {
                //dgvCTDH.Enabled = false;
            }
        }


        public void LoadGridViewDH()
        {
            xuly.xoaSource(dathang.loadGridViewTKMaDH(txtTim.Text));
            dgvDatHang.DataSource = dathang.loadGridViewTKMaDH(txtTim.Text);
        }

        public void LoadGridViewCTDH()
        {
            xuly.xoaSource(dathang.loadGridViewTKCTDH(txtTim.Text));
            dgvCTDH.DataSource = dathang.loadGridViewTKCTDH(txtTim.Text);
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            txtMaDH.Text = gridView3.GetFocusedRowCellValue("MADATHANG").ToString();
            txtSLNhap.Text = gridView3.GetFocusedRowCellValue("SOLUONGDAT").ToString();
            txtGiaNhap.Text = gridView3.GetFocusedRowCellValue("GIANHAP").ToString();
            txtThanhTienNhap.Text = gridView3.GetFocusedRowCellValue("THANHTIENDAT").ToString() + " VNĐ";
            txtTenThuoc.Text = gridView3.GetFocusedRowCellValue("TENTHUOC").ToString();
            btnThem.Enabled = true;
        }

        private void frmImportMedicine_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            txtMaCTNH.Text = nhapthuoc.loadMaDH();
            txtNhanVien.Text = thongtin.tenNV(Program.frmDN.txtUsername.Text);
            txtNgayDat.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            nhapthuoc.them(txtMaCTNH.Text, txtMaDH.Text, thongtin.maNV(Program.frmDN.txtUsername.Text), DateTime.Now.ToShortDateString(), 0);
            TimeSpan Time = DateTime.Parse(dateHSD.Text) - DateTime.Now;
            int TongSoNgay = Time.Days;
            if (TongSoNgay >= 0)
            {
                if (nhapthuoc.themDSCTNhapHang(txtMaCTNH.Text, gridView3.GetFocusedRowCellValue("MACTDATHANG").ToString(), int.Parse(txtSLNhap.Text), double.Parse(txtGiaNhap.Text), double.Parse(txtThanhTienNhap.Text.Trim().Substring(0, txtThanhTienNhap.Text.Length - 4)), dateHSD.Text))
                {
                    MessageBox.Show("Thêm loại thuốc này vào trong danh sách nhập hàng thành công");
                    nhapthuoc.suaTongThanhTien(txtMaCTNH.Text, double.Parse(txtThanhTienNhap.Text.Trim().Substring(0, txtThanhTienNhap.Text.Length - 4)));
                    thuoc.suaNhapThuoc(thuoc.maThuoc(txtTenThuoc.Text), int.Parse(txtSLNhap.Text), dateHSD.Text);
                    LoadGridViewCTNH();
                    gridView3.DeleteSelectedRows();
                    if (gridView3.RowCount == 0)
                    {
                        dathang.suaTrangThai(txtMaDH.Text);
                        LoadGridViewDH();
                        btnThem.Enabled = false;
                    }
                    tongtien = tongtien + double.Parse(txtThanhTienNhap.Text.Trim().Substring(0, txtThanhTienNhap.Text.Length - 4));
                    txtTongTien.Text = tongtien + " VNĐ";
                }
                else
                {
                    MessageBox.Show("Loại thuốc này đã có trong danh sách nhập hàng");
                }
            }
            else
            {
                MessageBox.Show(" Hạn sử dụng không được bé hơn ngày hiện tại");
            }
        }

        public void LoadGridViewCTNH()
        {
            xuly.xoaSource(nhapthuoc.loadGridViewDangNhapHang(txtMaCTNH.Text));
            dgvCTNH.DataSource = nhapthuoc.loadGridViewDangNhapHang(txtMaCTNH.Text);
        }

        private void frmImportMedicine_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (gridView3.RowCount == 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn phải nhập hàng toàn bộ trước khi thoát");
            }
        }
        NhapHangDAO nh = new NhapHangDAO();
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
           
            //a.DataSource = toathuoc.rpToaThuoc(int.Parse(toathuoc.loadMaToa()));

            //ReportPrintTool tool = new ReportPrintTool(a);
            //tool.ShowPreview();
            Model.NhapHang rp = new Model.NhapHang();
            frmRPNhapHang rpBillPay = new frmRPNhapHang();
            rpBillPay.printRP(rp, nh.loadBillPay(txtMaCTNH.Text.Trim()));
            rpBillPay.ShowDialog();
        }
    }
}