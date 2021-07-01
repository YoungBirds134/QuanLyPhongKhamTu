using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace UnitTestCNPM
{
    [TestClass]
    public class UnitTest1
    {
        string madathang = "";
        string mancc = "";
        string manv = "";
        string ngaydat = "";
        double tongtien = 0;
        string trangthai = "";
        string machitiet = "";
        string mathuoc = "";
        int soluongdat;
        double gianhap;
        double thanhtien = 0;
        DatHangDAL dathang = new DatHangDAL();

        [TestMethod]
        [TestCategory("Failed")]
        public void TC01()
        {
            // trường hợp sai chuổi kết nối => bỏ
            //bool kiemtra = dathang.them(madathang, mancc, manv, ngaydat, tongtien, trangthai);
            //bool mongmuon = true;
            //Assert.AreEqual(mongmuon, kiemtra, "Thêm thành công");
        }
        [TestMethod]
        [TestCategory("Failed")]
        public void TC02()
        {
            //trường hợp thêm phiếu đặt
            madathang = "DH08";
            mancc = "NCC0001";
            manv = "NV0008";
            ngaydat = "08/06/2021";
            tongtien = 0;
            trangthai = "Chưa giao";
            bool kiemtra = dathang.them(madathang, mancc, manv, ngaydat, tongtien, trangthai);
            bool mongmuon = true;
            Assert.AreEqual(mongmuon, kiemtra, "Thêm thành công");
        }


        [TestMethod]
        [TestCategory("Failed")]
        public void TC03()
        {
            //trường hợp thêm chi tiết phiếu đặt
            machitiet = "CTDH06";
            madathang = "DH08";
            mathuoc = "SPKUT0001";
            soluongdat = 20;
            gianhap = 400000;
            thanhtien = 800000;
            bool kiemtra = dathang.themDSThuoc(machitiet, madathang, mathuoc, soluongdat, gianhap, thanhtien);
            bool mongmuon = true;
            Assert.AreEqual(mongmuon, kiemtra, "Thêm thành công");
        }

        [TestMethod]
        [TestCategory("Failed")]
        public void TC04()
        {
            //Thêm chi tiết rỗng số lượng
            machitiet = "CTDH07";
            madathang = "DH08";
            mathuoc = "SPKUT0001";
            gianhap = 400000;
            thanhtien = 0;
            bool kiemtra = dathang.themDSThuoc(machitiet, madathang, mathuoc, int.Parse(""), gianhap, thanhtien);
            bool mongmuon = true;
            Assert.AreEqual(mongmuon, kiemtra, "Thêm thất bại");
        }

        [TestMethod]
        [TestCategory("Failed")]
        public void TC05()
        {
            //Thêm chi tiết rỗng giá đặt
            machitiet = "CTDH07";
            madathang = "DH08";
            mathuoc = "SPKUT0001";
            soluongdat = 20;
            thanhtien = 0;
            bool kiemtra = dathang.themDSThuoc(machitiet, madathang, mathuoc, soluongdat, double.Parse(""), thanhtien);
            bool mongmuon = true;
            Assert.AreEqual(mongmuon, kiemtra, "Thêm thất bại");
        }
    }
}
