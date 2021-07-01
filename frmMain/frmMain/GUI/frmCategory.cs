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
    public partial class frmCategory : DevExpress.XtraEditors.XtraForm
    {
        BindingSource dsLT = new BindingSource();
        //Tránh mất dữ liệu gốc khi binding qua textbox
        //Hạn chế lỗi mất kêt nối Binding - Nguồn: K Team
        public frmCategory()
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
                txtTenLoai.Text = "";
                txtMaLoai.Text = "";
                txtMaLoai.Focus();
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {
                try
                {
                    lt.them(txtMaLoai.Text,txtTenLoai.Text);
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
                        lt.xoa(txtMaLoai.Text);
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
                DialogResult rs = XtraMessageBox.Show("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        lt.sua(txtMaLoai.Text,txtTenLoai.Text);
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
        private void BindingSource()
        {
            txtMaLoai.DataBindings.Add(new Binding("Text", dgvLoaiThuoc.DataSource, "MALOAI", true, DataSourceUpdateMode.Never));
            txtTenLoai.DataBindings.Add(new Binding("Text", dgvLoaiThuoc.DataSource, "TENLOAI", true, DataSourceUpdateMode.Never));
            

        }
        LoaiThuocBLL lt = new LoaiThuocBLL();
        private void frmCategory_Load(object sender, EventArgs e)
        {
            load();
            BindingSource();
        }
        private void load()
        {
            dgvLoaiThuoc.DataSource = dsLT;
            dsLT.DataSource = lt.loadGripView();
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}