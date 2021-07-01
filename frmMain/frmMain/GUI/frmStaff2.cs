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
    public partial class frmStaff2 : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL nv = new NhanVienBLL();
        BindingSource dsNV = new BindingSource();
        //Tránh mất dữ liệu gốc khi binding qua textbox
        //Hạn chế lỗi mất kêt nối Binding - Nguồn: K Team
        public frmStaff2()
        {
            InitializeComponent();
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
                txtTenDN.Text = "";
                txtMaNV.Text = "";
                txtTenNV.Text = "";
                txtMatKhau.Text = "";
                txtGmail.Text = "";
                txtHSL.Text = "";
                txtSDT.Text = "";
                txtLuongCB.Text = "";
                txtLuong.Text = "";
                txtHSL.Text = "";
                txtNgaySinh.Text = "";
                txtChucVu.Text = "";
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {
                double luongCB = double.Parse(txtLuongCB.Text);
                double hSL = double.Parse(txtHSL.Text);
                double luong = double.Parse(txtLuong.Text);
                try
                {
                    nv.them(txtMaNV.Text, txtTenNV.Text, txtTenDN.Text, txtMatKhau.Text, txtNgaySinh.DateTime.Date.ToShortDateString(), cbGioiTinh.SelectedText.ToString(), txtDiaChi.Text, txtGmail.Text, txtSDT.Text, txtChucVu.Text, luongCB, hSL, luong, cbMaKhoa.EditValue.ToString());
                    XtraMessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    load();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Thêm thất bại - Lỗi: " + ex.Message.ToString());
              
                }
            }
            else if (e.Button.Properties.Caption == "Xóa")
            {

                double luongCB = double.Parse(txtLuongCB.Text);
                double hSL = double.Parse(txtHSL.Text);
                double luong = double.Parse(txtLuong.Text);
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        nv.xoa(txtMaNV.Text);
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
                double luongCB = double.Parse(txtLuongCB.Text);
                double hSL = double.Parse(txtHSL.Text);
                double luong = double.Parse(txtLuong.Text);
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        nv.sua(txtMaNV.Text, txtTenNV.Text, txtTenDN.Text, txtMatKhau.Text, txtNgaySinh.DateTime.Date.ToShortDateString(), cbGioiTinh.SelectedText.ToString(), txtDiaChi.Text, txtGmail.Text, txtSDT.Text, txtChucVu.Text, luongCB, hSL, luong, cbMaKhoa.EditValue.ToString());
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
                //if (txtTim.Text.Trim().Equals(""))
                //{
                //    XtraMessageBox.Show("Vui lòng nhập tên để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{
                //    try
                //    {
                        
                //        dgvNhanVien.DataSource = dsNV;
                //        dsNV.DataSource = nv.findNV(txtTim.Text.Trim());
                //    }
                //    catch (Exception ex)
                //    {
                //        XtraMessageBox.Show("TÌm thất bại - Lỗi: " + ex.Message.ToString());
                        
                //    }
                //}

            }
           
        }
        private void BindingSource()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MANV", true, DataSourceUpdateMode.Never));

            txtTenNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TENNV", true, DataSourceUpdateMode.Never));
            txtMatKhau.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MATKHAU", true, DataSourceUpdateMode.Never));
            txtTenDN.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TENDANGNHAP", true, DataSourceUpdateMode.Never));
            txtNgaySinh.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "NGAYSINH", true, DataSourceUpdateMode.Never));
            txtGmail.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "GMAIL", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "GIOITINH", true, DataSourceUpdateMode.Never));
            txtChucVu.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "CHUCVU", true, DataSourceUpdateMode.Never));
            txtLuongCB.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "LUONGCB", true, DataSourceUpdateMode.Never));
            txtLuong.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "LUONG", true, DataSourceUpdateMode.Never));
            txtHSL.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "HSL", true, DataSourceUpdateMode.Never));
            cbMaKhoa.DataBindings.Add(new Binding("EditValue", dgvNhanVien.DataSource, "MAKHOA", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "DIACHI", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never));

        }
        private void frmStaff2_Load(object sender, EventArgs e)
        {
            KhoaBLL k = new KhoaBLL();

            load();

            cbMaKhoa.Properties.DataSource = k.loadGripview();
            cbMaKhoa.Properties.DisplayMember = "TENKHOA";
            cbMaKhoa.Properties.ValueMember = "MAKHOA";

            BindingSource();
        }
        private void load()
        {
            dgvNhanVien.DataSource = dsNV;
            dsNV.DataSource = nv.loadGripView();
        }
    }
}