using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using frmMain.Model;
namespace frmMain.GUI
{
    public partial class rpNhapHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rpNhapHang()
        {
            InitializeComponent();
        }
        public void initData(string tenNV,string tenNCC,string ngayDat,double tongTienDat,string ngayNhap,double tongTienNhap,double giaNhap,string hsd,string maCTDH,string maDH,int soLuong, double thanhTien, List<NhapHang> lstBillPay)
        {
            pTenNV.Value = tenNV;
            pNhaCC.Value = tenNCC;
            pNgayDat.Value = ngayDat;
            pTongTienDat.Value = pTongTienDat;
            pNgayNhap.Value = ngayNhap;
            pTongTienNhap.Value = pTongTienNhap;
            pGiaNhap.Value = giaNhap;
            pHSD.Value = hsd;
            pMaCT.Value = maCTDH;
            pMaDH.Value = maDH;
            pSoLuong.Value = soLuong;
            pThanhTien.Value = thanhTien;
            objectDataSource1.DataSource = lstBillPay;
        }
    }
}
