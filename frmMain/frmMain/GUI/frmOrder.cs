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

namespace frmMain.GUI
{
    public partial class frmOrder : DevExpress.XtraEditors.XtraForm
    {
        ThuocBLL thuoc = new ThuocBLL();
        NhaCungCapBLL ncc = new NhaCungCapBLL();
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();
        DatHangBLL dathang = new DatHangBLL();
        XuLyGirdViewBLL xuly = new XuLyGirdViewBLL();
        double tongthanhtien = 0;

        public frmOrder()
        {
            InitializeComponent();
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //Các nút thêm, xóa, sửa...
            if (e.Button.Properties.Caption == "Thêm")
            {
                //Sử dụng LookupEdit
                //cbMaKhoa.Properties.DataSource = ...;
                //cbMaKhoa.Properties.ValueMember = "MaDM";
                //cbMaKhoa.Properties.DisplayMember = "TenDM";
                //cbMaKhoa.ItemIndex = 0;
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {

            }
            else if (e.Button.Properties.Caption == "Xóa")
            {


            }
            else if (e.Button.Properties.Caption == "Sửa")
            {

            }
            else if (e.Button.Properties.Caption == "Tìm")
            {


            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            dgvThuoc.DataSource = thuoc.loadThuocHetHanHetHang();
            cboNhaCC.DataSource = ncc.loadCCB();
            cboNhaCC.ValueMember = "MANCC";
            cboNhaCC.DisplayMember = "TENNCC";
            txtNgayLap.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtNhanVien.Text = thongtin.tenNV(Program.frmDN.txtUsername.Text);
            txtMaDatHang.Text = dathang.loadMaDH();
            txtMaCTDH.Text = dathang.loadMaCTDH();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            btnLapPhieu.Enabled = false;
            if (dathang.them(txtMaDatHang.Text, cboNhaCC.SelectedValue.ToString(), thongtin.maNV(Program.frmDN.txtUsername.Text), DateTime.Now.ToShortDateString(), 0, "Chưa giao"))
            {
                MessageBox.Show("Đẵ lập phiếu đặt hàng thành công");
                txtMaDH.Text = txtMaDatHang.Text;
                txtSLDat.Enabled = true;
                txtGiaNhap.Enabled = true;               
                dgvCTDH.Enabled = true;
            }
            else
            {
                MessageBox.Show("Đẵ lập phiếu đặt hàng thất bại");
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            txtThuoc.Text = gridView2.GetFocusedRowCellValue("TENTHUOC").ToString();
            btnThem.Enabled = true;
            txtGiaBan.Text = thuoc.giaBan(gridView2.GetFocusedRowCellValue("MATHUOC").ToString()) + " VNĐ";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSLDat.Text.Length != 0 && txtGiaNhap.Text.Length != 0)
            {
                if (int.Parse(txtSLDat.Text) > 0)
                {
                    double thanhtien = int.Parse(txtSLDat.Text) * double.Parse(txtGiaNhap.Text);
                    if (double.Parse(txtGiaNhap.Text) < thuoc.giaBan(gridView2.GetFocusedRowCellValue("MATHUOC").ToString()))
                    {
                        if (dathang.themDSThuoc(txtMaCTDH.Text, txtMaDH.Text, thuoc.maThuoc(txtThuoc.Text), int.Parse(txtSLDat.Text), double.Parse(txtGiaNhap.Text), thanhtien))
                        {
                            tongthanhtien = tongthanhtien + thanhtien;
                            MessageBox.Show("Bạn đã thêm thuốc này vào phiếu đặt thành công");
                            txtThanhTienDat.Text = thanhtien + " VNĐ";
                            LoadGridViewCTDH();
                            dathang.suaTongThanhTienC(txtMaDatHang.Text, thanhtien);
                            txtTongTien.Text = tongthanhtien + " VNĐ";
                            txtMaCTDH.Text = dathang.loadMaCTDH();
                            btnThem.Enabled = false;
                            txtSLDat.Text = "";
                            txtGiaNhap.Text = "";
                            txtThanhTienDat.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Bạn đã thêm thuốc này vào phiếu đặt thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá nhập phải nhỏ hơn giá bán");
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng đặt phải lớn hơn 0");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        public void LoadGridViewCTDH()
        {
            xuly.xoaSource(dathang.loadGridViewDangDatHang(txtMaDH.Text));
            dgvCTDH.DataSource = dathang.loadGridViewDangDatHang(txtMaDH.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double thanhtien = int.Parse(txtSLDat.Text) * double.Parse(txtGiaNhap.Text);
            if (dathang.xoa(txtMaCTDH.Text))
            {
                tongthanhtien = tongthanhtien - thanhtien;
                MessageBox.Show("Đã xóa thuốc này ra khỏi phiếu đặt thành công");
                LoadGridViewCTDH();
                dathang.suaTongThanhTienT(txtMaDatHang.Text, thanhtien);
                txtTongTien.Text = tongthanhtien + " VNĐ";
                btnXoa.Enabled = false;
                txtSLDat.Text = "";
                txtGiaNhap.Text = "";
                txtThanhTienDat.Text = "";
            }
            else
            {
                MessageBox.Show("Đã xóa thuốc này ra khỏi phiếu đặt thất bại");
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            txtMaCTDH.Text = gridView1.GetFocusedRowCellValue("MACTDATHANG").ToString();
            txtThuoc.Text = gridView1.GetFocusedRowCellValue("TENTHUOC").ToString();
            txtSLDat.Text = gridView1.GetFocusedRowCellValue("SOLUONGDAT").ToString();
            txtGiaNhap.Text = gridView1.GetFocusedRowCellValue("GIANHAP").ToString();
            txtThanhTienDat.Text = gridView1.GetFocusedRowCellValue("THANHTIENDAT").ToString() + " VNĐ";
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {           
            if (gridView1.RowCount == 0)
            {
                DialogResult r = MessageBox.Show("Hóa đơn của bạn chưa có danh sách thuốc. Nếu bạn thoát bây giờ thì hóa đơn này sẽ bị hủy", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    e.Cancel = false;
                    dathang.xoaDH(txtMaDH.Text);
                }               
            }
        }

        private void txtSLDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSLDat_TextChanged(object sender, EventArgs e)
        {
            loadThanhTienDat();
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            loadThanhTienDat();
        }

        public void loadThanhTienDat()
        {
            if (txtGiaNhap.Text.Length != 0 && txtSLDat.Text.Length != 0)
            {
                txtThanhTienDat.Text = int.Parse(txtSLDat.Text) * double.Parse(txtGiaNhap.Text) + " VNĐ";
            }
            else
            {
                txtThanhTienDat.Text = "0 VNĐ";
            }
        }
    }
}