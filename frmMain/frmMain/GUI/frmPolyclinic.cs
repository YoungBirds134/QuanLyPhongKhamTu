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
using frmMain.GUI.DAO;
using DevExpress.XtraReports.UI;
namespace frmMain.GUI
{
    public partial class frmPolyclinic : DevExpress.XtraEditors.XtraForm
    {
        ThongTinNhanVienBLL thongtin = new ThongTinNhanVienBLL();
        PhieuKhamBenhBLL phieukham = new PhieuKhamBenhBLL();
        PhongBLL phong = new PhongBLL();
        ThuocBLL thuoc = new ThuocBLL();
        ToaThuocBLL toathuoc = new ToaThuocBLL();
        XuLyGirdViewBLL xuly = new XuLyGirdViewBLL();
        HoaDonThuocBLL hoadonthuoc = new HoaDonThuocBLL();
        

        public frmPolyclinic()
        {
            InitializeComponent();
        }

        private void groupControl4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Nhập")
            {
                //Sử dụng LookupEdit
                //cbMaKhoa.Properties.DataSource = ...;
                //cbMaKhoa.Properties.ValueMember = "MaDM";
                //cbMaKhoa.Properties.DisplayMember = "TenDM";
                //cbMaKhoa.ItemIndex = 0;
            }
            else if (e.Button.Properties.Caption == "In Phiếu")
            {

            }
            else if (e.Button.Properties.Caption == "Xóa")
            {


            }
            else if (e.Button.Properties.Caption == "Sửa")
            {

            }

            else if (e.Button.Properties.Caption == "Yêu Cầu Xét Nghiệm")
            {


            }
        }

        private void groupControl5_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

        }

        private void groupXetNghiem_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Thêm")
            {

            }
        }

        private void frmPolyclinic_Load(object sender, EventArgs e)
        {
            groupKeToa.Enabled = false;
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtBacSi.Text = thongtin.tenNV(Program.frmDN.txtUsername.Text);
            dgvChoKham.DataSource = phieukham.loadChoKham();
            dvgChoXetNghiem.DataSource = phieukham.loadChoXetNghiem();
            cboThuoc.DataSource = thuoc.loadGripView();
            cboThuoc.DisplayMember = "TENTHUOC";
            cboThuoc.ValueMember = "MATHUOC";
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtSoPhieuKham.Text = gridView1.GetFocusedRowCellValue("SOPHIEUKHAM").ToString();
            txtBenhNhan.Text = gridView1.GetFocusedRowCellValue("TENBN").ToString();
            xuly.xoaSource(toathuoc.loadDS(toathuoc.loadMaToa()));
            txtChuanDoan.Text = "";
            txtDieuTri.Text = "";
            btnKeToa.Enabled = true;
            btnDichVu.Enabled = true;
            txtTinhTrang.Text = phieukham.TrangThaiBN(int.Parse(gridView1.GetFocusedRowCellValue("SOPHIEUKHAM").ToString()));
        }

        private void groupControl4_Click(object sender, EventArgs e)
        {


        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {

        }

        private void btnDichVu_Click_1(object sender, EventArgs e)
        {


            phieukham.suaTrangThaiChoXetNghiem(int.Parse(txtSoPhieuKham.Text));
            loadGridViewChoXetNghiem();
        }

        public void loadGridViewChoXetNghiem()
        {
            xuly.xoaSource(phieukham.loadChoXetNghiem());
            dvgChoXetNghiem.DataSource = phieukham.loadChoXetNghiem();
        }

        private void btnKeToa_Click(object sender, EventArgs e)
        {
            if (txtSoPhieuKham.Text.Length != 0 && txtBenhNhan.Text.Length != 0 && txtTinhTrang.Text.Length != 0 && txtChuanDoan.Text.Length != 0 && txtDieuTri.Text.Length != 0)
            {
                DialogResult r = MessageBox.Show("Bạn có muốn kê toa cho bệnh nhân không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    phieukham.suaTrangThaiDaKham(int.Parse(txtSoPhieuKham.Text));
                    loadGridViewChuaKham();
                    loadGridViewChoXetNghiem();
                    if (toathuoc.them(int.Parse(txtSoPhieuKham.Text), thongtin.maNV(Program.frmDN.txtUsername.Text), DateTime.Now.ToShortDateString(), txtTinhTrang.Text, txtChuanDoan.Text, txtDieuTri.Text, 0))
                    {
                        MessageBox.Show("Bạn đã thêm toa thuốc thành công");
                        groupKeToa.Enabled = true;
                        btnKeToa.Enabled = false;
                        btnDichVu.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã thêm toa thuốc thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void loadGridViewChuaKham()
        {
            xuly.xoaSource(phieukham.loadChoKham());
            dgvChoKham.DataSource = phieukham.loadChoKham();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {

        }

        private void cboThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = cboDonViTinh.Items.Count - 1; i >= 0; i--)
            {
                cboDonViTinh.Items.RemoveAt(i);
            }
            thuoc.loadDVTTheoThuoc(cboThuoc.SelectedValue.ToString(), cboDonViTinh);
        }

        private void cboDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonViTinh.SelectedIndex == 0)
            {
                txtGiaBan.Text = thuoc.loadGiaTheoDVT(cboThuoc.SelectedValue.ToString(), cboDonViTinh, 1) + " VNĐ";
            }
            else
            {
                txtGiaBan.Text = thuoc.loadGiaTheoDVT(cboThuoc.SelectedValue.ToString(), cboDonViTinh, 2) + " VNĐ";
            }
            txtSLCon.Text = thuoc.sLTon(cboThuoc.SelectedValue.ToString(), cboDonViTinh.SelectedIndex + 1).ToString();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length != 0 && txtGiaBan.Text.Length != 0) 
            {
                txtThanhTien.Text = int.Parse(txtSoLuong.Text) * double.Parse(txtGiaBan.Text.Trim().Substring(0, txtGiaBan.Text.Length - 4)) + " VNĐ";
            }
            else
            {
                txtThanhTien.Text = "0 VNĐ";
            }
        }

        private void btnDichVu_Click_2(object sender, EventArgs e)
        {
            if (txtSoPhieuKham.Text.Length != 0)
            {
                DialogResult r = MessageBox.Show("Bạn có muốn sử dụng dịch vụ cho bệnh nhân không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    frmService dichvu = new frmService();
                    dichvu.Show();

                    phieukham.suaTrangThaiChoXetNghiem(int.Parse(txtSoPhieuKham.Text));
                    loadGridViewChoXetNghiem();
                    loadGridViewChuaKham();
                }              
            }
            else
            {
                MessageBox.Show("Vui lòng chọn số phiếu khám");
            }
            
        }

        public void loadTT()
        {
            txtSoLuong.Text = "";
            txtCachDung.Text = "";
            txtGiaBan.Text = "";
            txtThanhTien.Text = "";
            txtCachDung.Text = "";
            txtSLCon.Text = "";
        }

        private void btnThemDS_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length != 0 && txtGiaBan.Text.Length != 0 && txtCachDung.Text.Length != 0) 
            {
                if (int.Parse(txtSoLuong.Text) <= int.Parse(txtSLCon.Text))
                {
                    if (toathuoc.themDSThuoc(int.Parse(toathuoc.loadMaToa()), cboThuoc.SelectedValue.ToString(), int.Parse(txtSoLuong.Text),
                double.Parse(txtGiaBan.Text.Trim().Substring(0, txtGiaBan.Text.Length - 4)), cboDonViTinh.SelectedItem.ToString(), txtCachDung.Text,
                double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4))))
                    {
                        MessageBox.Show("Bạn đã thêm thuốc này vào toa thuốc thành công");
                        loadGridViewDSThuoc();
                        toathuoc.capnhatTongThanhTienC(int.Parse(toathuoc.loadMaToa()), double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4)));
                        thuoc.capnhatSLThuocThem(cboThuoc.SelectedValue.ToString(), int.Parse(txtSoLuong.Text), cboDonViTinh.SelectedIndex + 1);
                        loadTT();
                        btnThanhToan.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thuốc này đã được thêm vào toa trước đó");
                        loadTT();
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng thuốc trong kho không đủ đáp ứng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void btnXoaDS_Click(object sender, EventArgs e)
        {
            if (toathuoc.xoaDSThuoc(int.Parse(toathuoc.loadMaToa()), cboThuoc.SelectedValue.ToString()))
            {
                MessageBox.Show("Bạn đã xóa thuốc này khỏi toa thuốc thành công");
                loadGridViewDSThuoc();
                toathuoc.capnhatTongThanhTienT(int.Parse(toathuoc.loadMaToa()), double.Parse(txtThanhTien.Text.Trim().Substring(0, txtThanhTien.Text.Length - 4)));
                thuoc.capnhatSLThuocXoa(cboThuoc.SelectedValue.ToString(), int.Parse(txtSoLuong.Text), cboDonViTinh.SelectedIndex + 1);
                loadTT();
                if (gridView3.RowCount != 0)
                {
                    btnThanhToan.Enabled = true;
                }
                else
                {
                    btnThanhToan.Enabled = false;
                }
                btnXoaDS.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn đã xóa thuốc này khỏi toa thuốc thất bại");
            }
        }

        public void loadGridViewDSThuoc()
        {
            xuly.xoaSource(toathuoc.loadDS(toathuoc.loadMaToa()));
            dgvDSThuoc.DataSource = toathuoc.loadDS(toathuoc.loadMaToa());
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            cboThuoc.SelectedValue = gridView3.GetFocusedRowCellValue("MATHUOC").ToString();
            txtSoLuong.Text = gridView3.GetFocusedRowCellValue("SOLUONG").ToString();
            txtGiaBan.Text = gridView3.GetFocusedRowCellValue("GIABAN").ToString() + " VNĐ";
            cboDonViTinh.SelectedItem = gridView3.GetFocusedRowCellValue("DVT").ToString();
            txtCachDung.Text = gridView3.GetFocusedRowCellValue("CACHDUNG").ToString();
            txtThanhTien.Text = gridView3.GetFocusedRowCellValue("THANHTIEN").ToString() + " VNĐ";
            btnXoaDS.Enabled = true;
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            txtSoPhieuKham.Text = gridView2.GetFocusedRowCellValue("SOPHIEUKHAM").ToString();
            txtBenhNhan.Text = gridView2.GetFocusedRowCellValue("TENBN").ToString();
            xuly.xoaSource(toathuoc.loadDS(toathuoc.loadMaToa()));
            txtTinhTrang.Text = phieukham.TrangThaiBN(int.Parse(gridView2.GetFocusedRowCellValue("SOPHIEUKHAM").ToString()));
            txtChuanDoan.Text = "";
            txtDieuTri.Text = "";
            btnKeToa.Enabled = true;
            btnDichVu.Enabled = true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            double tongtien = 0;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                tongtien = tongtien + double.Parse(gridView3.GetRowCellValue(i, "THANHTIEN").ToString());
            }
            MessageBox.Show("Tổng tiền của toa thuốc là: " + tongtien + " VNĐ");
            btnInToa.Enabled = true;
            hoadonthuoc.them(int.Parse(toathuoc.loadMaToa()), DateTime.Now.ToShortDateString(), tongtien);
        }
        rpToaThuocDAO rpDAO = new rpToaThuocDAO();
        private void btnInToa_Click(object sender, EventArgs e)
        {
            //rpToaThuocReport a = new rpToaThuocReport();
            int b = int.Parse(toathuoc.loadMaToa());
            //a.DataSource = toathuoc.rpToaThuoc(int.Parse(toathuoc.loadMaToa()));

            //ReportPrintTool tool = new ReportPrintTool(a);
            //tool.ShowPreview();
            Model.rpToaThuoc rp = new Model.rpToaThuoc();
            frmRPToaThuoc rpBillPay = new frmRPToaThuoc();
            rpBillPay.printRP(rp, rpDAO.loadBillPay(b));
            rpBillPay.ShowDialog();

        }
    }
}