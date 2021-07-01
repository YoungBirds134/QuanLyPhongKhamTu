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

namespace frmMain.GUI
{
    public partial class frnAcount : DevExpress.XtraEditors.XtraForm
    {
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();
        public frnAcount()
        {
            InitializeComponent();
        }

        private void frnAcount_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            thongtin.loadProFile(txtMaNV, txtTenNV, txtTenDN, txtMatKhau, date_ngaysinh, cbGioiTinh, txtDiaChi, txtGmail, txtSDT, txtChucVu, txtTenKhoa, txtLuongCB, txtHSL, txtLuong, Program.frmDN.txtUsername.Text);
        }

        private void groupControl2_Click(object sender, EventArgs e)
        {
            if (thongtin.sua(txtMaNV.Text, txtTenNV.Text, txtTenDN.Text, txtMatKhau.Text, date_ngaysinh.Text, cbGioiTinh.SelectedItem.ToString(), txtDiaChi.Text, txtGmail.Text, txtSDT.Text))
            {
                MessageBox.Show("Bạn đã cập nhật thông tin thành công");
            }
            else
            {
                MessageBox.Show("Bạn đã cập nhật thông tin thất bại");
            }
        }
    }
}