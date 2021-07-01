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
using BLL;
using frmMain.GUI;
using frmMain.DAO;
namespace frmMain
{
    public partial class frmService : DevExpress.XtraEditors.XtraForm
    {
        PhongBLL phong = new PhongBLL();
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();
        PhieuDichVuBLL phieudichvu = new PhieuDichVuBLL();
        XuLyGirdViewBLL xuly = new XuLyGirdViewBLL();
        DichVuBLL dichvu = new DichVuBLL();

        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            txtSoPhieuKham.Text = Program.frmKhamBenh.txtSoPhieuKham.Text;
            cboPhongDichVu.DataSource = phong.loadPhongXetNghiem();
            cboPhongDichVu.DisplayMember = "TENPHONG";
            cboPhongDichVu.ValueMember = "MAPHONG";
            dateNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtMaBS.Text = thongtin.maNV(Program.frmDN.txtUsername.Text);
            txtTrangThai.Text = "Chưa thực hiện";
            groupChiTiet.Enabled = false;
            groupDanhSach.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (phieudichvu.them(int.Parse(txtSoPhieuKham.Text), txtMaBS.Text, DateTime.Now.ToShortDateString(), cboPhongDichVu.SelectedValue.ToString(), 0, txtTrangThai.Text)) 
            {
                MessageBox.Show("Thêm phiếu dịch vụ thành công");
                btnLapPhieu.Enabled = false;
                groupChiTiet.Enabled = true;
                groupDanhSach.Enabled = true;
                txtMaDKDV.Text = phieudichvu.loadMaDKDV();
                cboDichVu.DataSource = dichvu.loadCBBDV();
                cboDichVu.DisplayMember = "TENDV";
                cboDichVu.ValueMember = "MADV";
                dgvDanhSach.DataSource = phieudichvu.loadGirdViewCT(int.Parse(txtMaDKDV.Text));
            }
            else
            {
                MessageBox.Show("Thêm phiếu dịch vụ thất bại");
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            txtMaDKDV.Text = gridView1.GetFocusedRowCellValue("MADKDV").ToString();
            cboDichVu.SelectedValue = gridView1.GetFocusedRowCellValue("MADV").ToString();
            txtThanhTien.Text = gridView1.GetFocusedRowCellValue("THANHTIEN").ToString() + " VNĐ";
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = dichvu.loadThanhTien(cboDichVu.SelectedValue.ToString()) + " VNĐ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (phieudichvu.themCT(int.Parse(txtMaDKDV.Text), cboDichVu.SelectedValue.ToString(), double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4))))
            {
                MessageBox.Show("Bạn đã thêm dịch vụ này vào trong phiếu đăng ký dịch vụ thành công");
                loadGridViewDV();
                phieudichvu.capnhatTongTienC(int.Parse(txtMaDKDV.Text), double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4)));
                txtTongTien.Text = phieudichvu.tongtien(int.Parse(txtMaDKDV.Text)) + " VNĐ";
            }
            else
            {
                MessageBox.Show("Bạn đã thêm dịch vụ này vào trong phiếu đăng ký dịch vụ thất bại");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (phieudichvu.xoaCT(int.Parse(gridView1.GetFocusedRowCellValue("MACTDICHVU").ToString())))
            {
                MessageBox.Show("Bạn đã xóa dịch vụ này ra khỏi phiếu đăng ký dịch vụ thành công");
                loadGridViewDV();
                btnXoa.Enabled = false;
                phieudichvu.capnhatTongTienT(int.Parse(txtMaDKDV.Text), double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4)));
                txtTongTien.Text = phieudichvu.tongtien(int.Parse(txtMaDKDV.Text)) + " VNĐ";
            }
            else
            {
                MessageBox.Show("Bạn đã xóa dịch vụ này ra khỏi phiếu đăng ký dịch vụ thất bại");
            }
        }

        public void loadGridViewDV()
        {
            xuly.xoaSource(phieudichvu.loadGirdViewCT(int.Parse(txtMaDKDV.Text)));
            dgvDanhSach.DataSource = phieudichvu.loadGirdViewCT(int.Parse(txtMaDKDV.Text));
        }

        private void frmService_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        DichVuDAO dv = new DichVuDAO();
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            int b = int.Parse(txtMaDKDV.Text);
            //a.DataSource = toathuoc.rpToaThuoc(int.Parse(toathuoc.loadMaToa()));

            //ReportPrintTool tool = new ReportPrintTool(a);
            //tool.ShowPreview();
            Model.DichVu rp = new Model.DichVu();
            frmRPDichVu rpBillPay = new frmRPDichVu();
            rpBillPay.printRP(rp, dv.loadBillPay(b));
            rpBillPay.ShowDialog();
        }
    }
}