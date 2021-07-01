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
using DevExpress.XtraReports.UI;

namespace frmMain.GUI
{
    public partial class frmMedicalBill : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBLL nv = new NhanVienBLL();
        BangGiaKhamBenh_HuyBLL bgkb = new BangGiaKhamBenh_HuyBLL();
        PhieuKhamBenhBLL pkb = new PhieuKhamBenhBLL();
        BenhNhan_HuyBLL bn = new BenhNhan_HuyBLL();
        PhongDieuTri_HuyBLL pdt = new PhongDieuTri_HuyBLL();
        HoaDonKhamBenh_HuyBLL hdkb = new HoaDonKhamBenh_HuyBLL();
        BindingSource dspkb = new BindingSource();

        public frmMedicalBill()
        {
            InitializeComponent();
        }

        private void frmMedicalBill_Load(object sender, EventArgs e)
        {
            try
            {
                txtNhanVien.Text = layTTNV().Rows[0].ItemArray[1].ToString();
            }
            catch (Exception)
            {
                txtNhanVien.Text = "Loi";

            }
            comBoBox_PhongDieuTri();
            comBoBox_BangGiaKhamBenh();
            txtNgayLap.Text = DateTime.Now.ToShortDateString();
            txtTenBN.Text = frmStaffNursing.BenhNhanTiepNhan.tenBenhNhan;
            pkb.load_PhieuKhamBenh();
            hdkb.load_HDKB();
        }


        //////////////////////////HAM///////////////
        ///


        void comBoBox_BangGiaKhamBenh()
        {
            cbHinhThucKham.Properties.DisplayMember = "HINHTHUCKHAM";
            cbHinhThucKham.Properties.ValueMember = "MAGIAKHAM";
            cbHinhThucKham.Properties.DataSource = bgkb.load_BangGiaKhamBenh();
            cbHinhThucKham.ItemIndex = 0;
        }
        void comBoBox_PhongDieuTri()
        {
            cbPhong.Properties.DisplayMember = "TENPHONG";
            cbPhong.Properties.ValueMember = "MAPHONG";
            cbPhong.Properties.DataSource = pdt.load_cbPhongDieuTri();
            cbPhong.ItemIndex = 0;
        }
        void themPhieuKhamBenh()
        {
            Random rd = new Random();
            int maPKB = rd.Next(1, 10000);
            try
            {
                pkb.them(maPKB, bn.layMaBenhNhan(frmStaffNursing.BenhNhanTiepNhan.tenBenhNhan.ToString(), frmStaffNursing.BenhNhanTiepNhan.diaChi.ToString()), layTTNV().Rows[0].ItemArray[0].ToString(), txtNgayLap.DateTime.Date.ToShortDateString(), cbPhong.EditValue.ToString(), txtTinhTrangSK.Text, txtDeNghiKham.Text, cbHinhThucKham.EditValue.ToString(), txtTrangThai.Text);
                XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thêm thất bại - Lỗi: " + ex.Message.ToString());

            }
        }
        void themHoaDonKhamBenh()
        {
            Random rd = new Random();
            int maHDKB = rd.Next(1, 10000);
            try
            {
                hdkb.them(maHDKB, pkb.laySoPhieuKham(bn.layMaBenhNhan(frmStaffNursing.BenhNhanTiepNhan.tenBenhNhan.ToString(), frmStaffNursing.BenhNhanTiepNhan.diaChi.ToString())), txtNgayLap.DateTime.Date.ToShortDateString(), bgkb.layGiaKhamBenh(cbHinhThucKham.EditValue.ToString()));
                XtraMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Thêm thất bại - Lỗi: " + ex.Message.ToString());

            }
        }
        DataTable layTTNV()
        {
            return nv.layTTNhanVien(frmLogin.ControlID.textData.ToString());
        }
        void load_PhieuKhamBenh()
        {

            dspkb.DataSource = pkb.load_PhieuKhamBenh();
            Report_HoaDonKhamBenh_HuyBLL hd = new Report_HoaDonKhamBenh_HuyBLL();
 
        }
        ///////////////////////
        private void btnChoKham_Click(object sender, EventArgs e)
        {
            if (txtTinhTrangSK.Text.Length != 0 && txtDeNghiKham.Text.Length != 0)
            {
                themPhieuKhamBenh();
                themHoaDonKhamBenh();
                rpKhamBenh a = new rpKhamBenh();
                a.DataSource = pkb.loadPhieuKhamBenh(bn.layMaBenhNhan(frmStaffNursing.BenhNhanTiepNhan.tenBenhNhan, frmStaffNursing.BenhNhanTiepNhan.diaChi));
                ReportPrintTool tool = new ReportPrintTool(a);
                a.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
   
    }
}