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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static string chucVu = "";
        public static class ControlID
        {
            public static string textData { get; set; }
        }
        DangNhapBLL dn = new DangNhapBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dn.dangNhap(txtUsername.Text.Trim(), txtPassword.Text.Trim()) == true)
            {

                frmMain b = new frmMain(dn.layCHucVu(txtUsername.Text, txtPassword.Text).ToString());
                ControlID.textData = txtUsername.Text;
                this.Hide();
                b.ShowDialog();
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtUsername.Focus();
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            txtPassword.Properties.UseSystemPasswordChar = true;
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            
        }

        private void ckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPassword.Checked == true)
            {
                txtPassword.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.Properties.UseSystemPasswordChar = true;
            }
        }
    }
}