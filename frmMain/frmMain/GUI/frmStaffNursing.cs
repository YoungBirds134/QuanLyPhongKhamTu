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
    public partial class frmStaffNursing : DevExpress.XtraEditors.XtraForm
    {
        BenhNhan_HuyBLL bn = new BenhNhan_HuyBLL();
        public static class BenhNhanTiepNhan
        {
            public static string tenBenhNhan { get; set; }
            public static string diaChi { get; set; }
        }

        public frmStaffNursing()
        {
            InitializeComponent();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //Các nút thêm, xóa, sửa...
            if (e.Button.Properties.Caption == "Tải Lại")
            {

            }
            else if (e.Button.Properties.Caption == "Xuất Word")
            {
                //Sử dụng LookupEdit
                //cbMaKhoa.Properties.DataSource = ...;
                //cbMaKhoa.Properties.ValueMember = "MaDM";
                //cbMaKhoa.Properties.DisplayMember = "TenDM";
                //cbMaKhoa.ItemIndex = 0;
            }
            else if (e.Button.Properties.Caption == "Xuất Excel")
            {

            }
            
        }

        private void frmStaffNursing_Load(object sender, EventArgs e)
        {
            txtNgaySinh.Text = DateTime.Now.ToShortDateString();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            bn.loadGripView();
            cbGioiTinh.SelectedIndex = 0;
        }




        /////////////////////HAM////////////

        void themBenhNhan()
        {
            Random rd = new Random();
            int mabenhNhan = rd.Next(1, 10000);
            try
            {
                bn.them(mabenhNhan, txtTenBN.Text, txtNgaySinh.Text, cbGioiTinh.SelectedItem.ToString(), txtDiaChi.Text, txtSDT.Text);
                XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thêm thất bại - Lỗi: " + ex.Message.ToString());

            }
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (txtTenBN.Text.Length != 0 && txtDiaChi.Text.Length != 0 && txtSDT.Text.Length != 0)
            {
                themBenhNhan();
                BenhNhanTiepNhan.tenBenhNhan = txtTenBN.Text.ToString();
                BenhNhanTiepNhan.diaChi = txtDiaChi.Text.ToString();
                frmMedicalBill form = new frmMedicalBill();
                form.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
    }
}