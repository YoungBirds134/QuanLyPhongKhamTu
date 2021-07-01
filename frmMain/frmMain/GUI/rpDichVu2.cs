using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using frmMain.Model;
namespace frmMain.GUI
{
    public partial class rpDichVu2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpDichVu2()
        {
            InitializeComponent();
        }
        public void initData(string tenNV,string tenBN,int maDKDV, string tenDV,double tongTien,double thanhTien, double gia,string ngayLap, List<DichVu> lstBillPay)
        {
            ptenNV.Value = tenNV;
            pTenBN.Value = tenBN;
            pMaDKDV.Value = maDKDV;
            pTenDV.Value = tenDV;
            pTongTien.Value = tongTien;
            pThanhTien.Value = thanhTien;
            pGia.Value = gia;
            pNgayLap.Value = ngayLap;
            objectDataSource1.DataSource = lstBillPay;
        }
    }
}
