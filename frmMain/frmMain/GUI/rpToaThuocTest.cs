using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using frmMain.Model;
using System.Collections.Generic;
using frmMain.Model;
namespace frmMain.GUI
{
    public partial class rpToaThuocTest : DevExpress.XtraReports.UI.XtraReport
    {
        public rpToaThuocTest()
        {
            InitializeComponent();
        }
        public void initData(string tenNV, string tenBN,string ngayLap, double tongTien,string dVT, double giaBan, string tenThuoc,int maToa, int soLuong, double thanhTien, List<rpToaThuoc> lstBillPay)
        {
            pTenNV.Value = tenNV;
            pTenBN.Value = tenBN;
            pNgayLap.Value = ngayLap;
            pTongTien.Value = tongTien;
            pSoLuong.Value = soLuong;
            pGiaBan.Value = giaBan;
            pThanhTIen.Value = thanhTien;
            pTenThuoc.Value = tenThuoc;
            pDVT.Value = dVT;
            pMaToa.Value = maToa;
            objectDataSource1.DataSource = lstBillPay;
        }
    }
}
