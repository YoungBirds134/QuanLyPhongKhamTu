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
using DevExpress.XtraReports.UI;

namespace frmMain.GUI
{
    public partial class frmTest : DevExpress.XtraEditors.XtraForm
    {
        PhieuDichVuBLL phieudichvu = new PhieuDichVuBLL();
        XuLyGirdViewBLL xuly = new XuLyGirdViewBLL();
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();

        public frmTest()
        {
            InitializeComponent();
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //Các nút thêm, xóa, sửa...
            if (e.Button.Properties.Caption == "Lập Phiếu")
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
            else if (e.Button.Properties.Caption == "Xem Phiếu")
            {


            }
            else if (e.Button.Properties.Caption == "In Phiếu")
            {


            }
            else if (e.Button.Properties.Caption == "Thoát")
            {


            }
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            dtg_ChoXetNghiem.DataSource = phieudichvu.loadChuaXN();
            txtNhanVien.Text = thongtin.tenNV(Program.frmDN.txtUsername.Text);
            dateNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadtt();
        }

        private void dtg_ChoXetNghiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadGridViewDSCT();
        }

        public void loadGridViewDSCT()
        {
            xuly.xoaSource(phieudichvu.loadGridView(int.Parse(dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString())));
            dtg_chitiet.DataSource = phieudichvu.loadGridView(int.Parse(dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString()));
        }
        public void loadkq()
        {
            //xuly.xoaSource(phieudichvu.loadGridViewKQ(int.Parse(dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString())));
            dtg_kq.DataSource = phieudichvu.loadGridViewKQ(int.Parse(dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString()));
        }

        public void themkq()
        {
            string madkdv = dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString();
            int madk = int.Parse(madkdv);
            string manv = thongtin.maNV(Program.frmDN.txtUsername.Text);
            string ngaylap = dateNgayLap.Text;
            string ghichu = rtb_ghichu.Text;
            bool kq1 = phieudichvu.themKQ(madk, manv, ngaylap, ghichu);
            if (kq1 == true)
            {
                MessageBox.Show("Đã Thêm");
                loadkq();
            }
            else
                MessageBox.Show("Chưa Thêm");
        }
        public void suakq()
        {
            string masddv = dtg_kq.CurrentRow.Cells[0].Value.ToString();
            string madkdv = dtg_kq.CurrentRow.Cells[1].Value.ToString();
            string ngaylap = dateNgayLap.Text;
            if (phieudichvu.suaKQ(int.Parse(masddv), int.Parse(madkdv), thongtin.maNV(Program.frmDN.txtUsername.Text), ngaylap, rtb_ghichu.Text) == true)
            {
                MessageBox.Show("Sửa Thành Công");
                loadkq();
            }
            else
                MessageBox.Show("Chưa Sửa");
        }
        public void bingding()
        {
            string ten = thongtin.tenNV(Program.frmDN.txtUsername.Text);
            string ngaylap = dtg_kq.CurrentRow.Cells[3].Value.ToString();
            string ghichu = dtg_kq.CurrentRow.Cells[4].Value.ToString();
            txtNhanVien.Text = ten;
            dateNgayLap.Text = ngaylap;
            rtb_ghichu.Text = ghichu;
        }
        public void thanhtoan()
        {
            string madkdv = dtg_chitiet.CurrentRow.Cells[1].Value.ToString();
            string manv = thongtin.maNV(Program.frmDN.txtUsername.Text);
            string ngaylap = DateTime.Now.Date.ToString();
            string tien = dtg_chitiet.CurrentRow.Cells[3].Value.ToString();
            double tongtien = double.Parse(tien);
            if (phieudichvu.themTT(madkdv, manv, ngaylap, tongtien) == true)
            {
                MessageBox.Show("Đã Thanh toán");
                loadtt();
            }
            else
                MessageBox.Show("Chưa Thanh Toán");
        }
        public void loadtt()
        {
            dtg_thanhtoan.DataSource = phieudichvu.loadThanhToan();
        }
        private void btn_themkq_Click(object sender, EventArgs e)
        {
            if (rtb_ghichu.Text.Length != 0)
            {
                themkq();
                rtb_ghichu.Text = "";
                dtg_chitiet.Rows.Remove(dtg_chitiet.CurrentRow);
                if (dtg_chitiet.Rows.Count == 1)
                {
                    phieudichvu.capNhatTrangThaiPhieu(dtg_ChoXetNghiem.CurrentRow.Cells[0].Value.ToString());
                    LoadGridViewChuaKham();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        public void LoadGridViewChuaKham()
        {
            xuly.xoaSource(phieudichvu.loadChuaXN());
            dtg_ChoXetNghiem.DataSource = phieudichvu.loadChuaXN();
        }

        private void btn_suakq_Click(object sender, EventArgs e)
        {
            suakq();
        }

        private void dtg_kq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bingding();
        }

        private void btn_inkq_Click(object sender, EventArgs e)
        {
            InKQ hd = new InKQ();
            hd.DataSource = phieudichvu.REPORT1(int.Parse(dtg_kq.CurrentRow.Cells[0].Value.ToString()), int.Parse(dtg_kq.CurrentRow.Cells[1].Value.ToString()));
            ReportPrintTool tool = new ReportPrintTool(hd);
            tool.ShowPreview();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            thanhtoan();
        }

        private void btn_xuathoadon_Click(object sender, EventArgs e)
        {
            string sohd = dtg_thanhtoan.CurrentRow.Cells[0].Value.ToString();
            InHoaDon hd = new InHoaDon();
            hd.DataSource = phieudichvu.loadThanhToan1(sohd);
            ReportPrintTool tool = new ReportPrintTool(hd);
            tool.ShowPreview();
        }
    }
}