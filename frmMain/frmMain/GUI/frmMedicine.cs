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
    public partial class frmMedicine : DevExpress.XtraEditors.XtraForm
    {
        BindingSource dsT = new BindingSource();
        ThuocBLL t = new ThuocBLL();
        //Tránh mất dữ liệu gốc khi binding qua textbox
        //Hạn chế lỗi mất kêt nối Binding - Nguồn: K Team
        public frmMedicine()
        {
            InitializeComponent();
        }
        private void load()
        {
            dgvThuoc.DataSource = dsT;
            dsT.DataSource = t.loadGripView();
        }
        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //Các nút thêm, xóa, sửa...
            if (e.Button.Properties.Caption == "Tải Lại")
            {
                load();
            }
            else if (e.Button.Properties.Caption == "Thêm")
            {
                //Sử dụng LookupEdit
                //cbMaKhoa.Properties.DataSource = ...;
                //cbMaKhoa.Properties.ValueMember = "MaDM";
                //cbMaKhoa.Properties.DisplayMember = "TenDM";
                //cbMaKhoa.ItemIndex = 0;

                txtMaThuoc.Text = "";
                txtMoTa.Text = "";
                txtQuyCachDongGoi.Text = "";
                txtSoLuongBan.Text = "";
                txtSoLuongCB.Text = "";
                txtTenThuoc.Text = "";
                txtHSD.Text = "";
                txtHamLuong.Text = "";
                txtGiaTriQuyDoi.Text = "";
                txtGiaCB.Text = "";
                txtGiaBan.Text = "";
                txtDonViCB.Text = "";

                txtDonViBan.Text = "";
                txtCongDung.Text = "";
                txtMaThuoc.Focus();
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {
                double giaCB = double.Parse(txtGiaCB.Text);
                double soLuongCB = double.Parse(txtSoLuongCB.Text);
                double giaBan = double.Parse(txtGiaBan.Text);
                double soLuongBan = double.Parse(txtSoLuongBan.Text);
                double giaTriQuyDoi = double.Parse(txtGiaTriQuyDoi.Text);
                try
                {
                    t.them(txtMaThuoc.Text, txtTenThuoc.Text, cbMaLoai.EditValue.ToString(), cbMaNSX.EditValue.ToString(), txtCongDung.Text, txtHamLuong.Text, txtHSD.DateTime.Date.ToShortDateString(), txtDonViCB.Text, giaCB, soLuongCB, txtDonViBan.Text, giaBan, soLuongBan, giaTriQuyDoi, txtQuyCachDongGoi.Text, cbMaViTri.EditValue.ToString(), txtMoTa.Text);
                    XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    load();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Thêm thất bại - Lỗi: " + ex.Message.ToString());

                }
            }
            else if (e.Button.Properties.Caption == "Xóa")
            {

                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        t.xoa(txtMaThuoc.Text);
                        XtraMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        load();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Xóa thất bại - Lỗi: " + ex.Message.ToString());

                    }
                }
            }
            else if (e.Button.Properties.Caption == "Sửa")
            {
                double giaCB = double.Parse(txtGiaCB.Text);
                double soLuongCB = double.Parse(txtSoLuongCB.Text);
                double giaBan = double.Parse(txtGiaBan.Text);
                double soLuongBan = double.Parse(txtSoLuongBan.Text);
                double giaTriQuyDoi = double.Parse(txtGiaTriQuyDoi.Text);
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        t.sua(txtMaThuoc.Text, txtTenThuoc.Text, cbMaLoai.EditValue.ToString(), cbMaNSX.EditValue.ToString(), txtCongDung.Text, txtHamLuong.Text, txtHSD.DateTime.Date.ToShortDateString(), txtDonViCB.Text, giaCB, soLuongCB, txtDonViBan.Text, giaBan, soLuongBan, giaTriQuyDoi, txtQuyCachDongGoi.Text, cbMaViTri.EditValue.ToString(), txtMoTa.Text);
                        XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        load();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Sửa thất bại - Lỗi: " + ex.Message.ToString());

                    }
                }
            }
            else if (e.Button.Properties.Caption == "Tìm Kiếm")
            {


            }
        }
        NhaSanXuatBLL nsx = new NhaSanXuatBLL();
        LoaiThuocBLL lt = new LoaiThuocBLL();
        ViTriBLL vt = new ViTriBLL();
        private void frmMedicine_Load(object sender, EventArgs e)
        {
            cbMaNSX.Properties.DataSource = nsx.loadGripView();
            cbMaNSX.Properties.DisplayMember = "TENNSX";
            cbMaNSX.Properties.ValueMember = "MANSX";

            cbMaLoai.Properties.DataSource = lt.loadGripView();
            cbMaLoai.Properties.DisplayMember = "TENLOAI";
            cbMaLoai.Properties.ValueMember = "MALOAI";

            cbMaViTri.Properties.DataSource = vt.loadGripView();
            cbMaViTri.Properties.DisplayMember = "TENVITRI";
            cbMaViTri.Properties.ValueMember = "MAVITRI";

            load();
            BindingSource();
        }
        private void BindingSource()
        {
            txtMaThuoc.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "MATHUOC", true, DataSourceUpdateMode.Never));
            txtTenThuoc.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "TENTHUOC", true, DataSourceUpdateMode.Never));
            cbMaLoai.DataBindings.Add(new Binding("EditValue", dgvThuoc.DataSource, "MALOAI", true, DataSourceUpdateMode.Never));
            cbMaNSX.DataBindings.Add(new Binding("EditValue", dgvThuoc.DataSource, "MANSX", true, DataSourceUpdateMode.Never));
            txtCongDung.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "CONGDUNG", true, DataSourceUpdateMode.Never));
            txtHamLuong.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "HAMLUONG", true, DataSourceUpdateMode.Never));
            txtHSD.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "HSD", true, DataSourceUpdateMode.Never));
            txtDonViCB.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "DONVICB", true, DataSourceUpdateMode.Never));
            txtGiaCB.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "GIACB", true, DataSourceUpdateMode.Never));
            txtSoLuongCB.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "SOLUONGCB", true, DataSourceUpdateMode.Never));
            txtDonViBan.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "DONVIBAN", true, DataSourceUpdateMode.Never));
            txtGiaBan.DataBindings.Add(new Binding("EditValue", dgvThuoc.DataSource, "GIABAN", true, DataSourceUpdateMode.Never));
            txtSoLuongBan.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "GIABAN", true, DataSourceUpdateMode.Never));
            txtGiaTriQuyDoi.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "GIATRIQUYDOI", true, DataSourceUpdateMode.Never));
            txtMoTa.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "MOTA", true, DataSourceUpdateMode.Never));
            txtQuyCachDongGoi.DataBindings.Add(new Binding("Text", dgvThuoc.DataSource, "QUICACHDONGGOI", true, DataSourceUpdateMode.Never));
            cbMaViTri.DataBindings.Add(new Binding("EditValue", dgvThuoc.DataSource, "MAVITRI", true, DataSourceUpdateMode.Never));

        }
    }
}