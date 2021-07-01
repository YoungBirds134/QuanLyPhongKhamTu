using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DatHangDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        ThongTinNhanVienDAL thongtin = new ThongTinNhanVienDAL();

        //public DataTable loadGridView()
        //{
        //    da = new SqlDataAdapter("select MATHUOC, TENTHUOC, TENNSX, HSD, SOLUONGBAN from THUOC,NHASANXUAT WHERE THUOC.MANSX=NHASANXUAT.MANSX AND (SOLUONGBAN<=5 OR DATEDIFF(DAY,GETDATE(),HSD)<7)", cnn);
        //    da.Fill(ds, "DS");

        //    return ds.Tables["DS"];
        //}

        //public void loadDatHang(TextBox ma, TextBox tennv, TextBox ngaydat, string manv)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("select * from DATHANG", cnn);
        //    da.Fill(ds, "dathang");

        //    DataColumn[] khoachinh = new DataColumn[1];
        //    khoachinh[0] = ds.Tables["dathang"].Columns[0];
        //    ds.Tables["dathang"].PrimaryKey = khoachinh;


        //    int a = ds.Tables["dathang"].Rows.Count + 1;
        //    ma.Text = "DH0" + a;
        //    tennv.Text = thongtin.tenNV(manv);
        //    ngaydat.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //}

        public DataTable load()
        {
            da = new SqlDataAdapter("select * from  DATHANG", cnn);
            da.Fill(ds, "dsDatHang");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsDatHang"].Columns[0];
            ds.Tables["dsDatHang"].PrimaryKey = khoachinh;

            return ds.Tables["dsDatHang"];
        }

        public string loadMaDH()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            string truyvan = "select count(*) from DATHANG";
            SqlCommand cmd = new SqlCommand(truyvan, cnn);
            int d = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            return "DH0" + d.ToString();
        }

        public bool them(string madathang, string mancc, string manv, string ngaydat, double tongtien, string trangthai)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsDatHang"].NewRow();
                dr["MADATHANG"] = madathang;
                dr["MANCC"] = mancc;
                dr["MANV"] = manv;
                dr["NGAYDATHANG"] = ngaydat;
                dr["TONGTIENDAT"] = tongtien;
                dr["TRANGTHAI"] = trangthai;
                ds.Tables["dsDatHang"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaTongThanhTienC(string madathang, double tongtien)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsDatHang"].Rows.Find(madathang);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE DATHANG SET TONGTIENDAT= TONGTIENDAT+" + tongtien + " WHERE MADATHANG='" + madathang + "'", cnn);
                    capnhat.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool suaTongThanhTienT(string madathang, double tongtien)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsDatHang"].Rows.Find(madathang);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE DATHANG SET TONGTIENDAT= TONGTIENDAT-" + tongtien + " WHERE MADATHANG='" + madathang + "'", cnn);
                    capnhat.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public string kTraTrangThai(string madat)
        {
            da = new SqlDataAdapter("select * from  DATHANG ", cnn);
            da.Fill(ds, "AAA");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["AAA"].Columns[0];
            ds.Tables["AAA"].PrimaryKey = khoachinh;

            DataRow dr = ds.Tables["AAA"].Rows.Find(madat);
            string a = "";
            if (dr != null)
            {
                a = dr["TRANGTHAI"].ToString();
            }
            return a;
        }

        public bool suaTrangThai(string madathang)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsDatHang"].Rows.Find(madathang);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE DATHANG SET TRANGTHAI='Đã giao'  WHERE MADATHANG='" + madathang + "'", cnn);
                    capnhat.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDH(string mahoadon)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsDatHang"].Rows.Find(mahoadon);
                if (dr != null)
                {
                    dr.Delete();
                    luu();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsDatHang"]);
        }

        public DataTable loadGridViewDangDatHang(string madathang)
        {
            da = new SqlDataAdapter("select MACTDATHANG,MADATHANG,TENTHUOC,SOLUONGDAT,GIANHAP,THANHTIENDAT FROM CT_DATHANG,THUOC WHERE CT_DATHANG.MATHUOC=THUOC.MATHUOC AND MADATHANG='" + madathang + "'", cnn);
            da.Fill(ds, "DS1");

            return ds.Tables["DS1"];
        }

        public string loadMaCTDH()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            string truyvan = "select count(*) from CT_DATHANG";
            SqlCommand cmd = new SqlCommand(truyvan, cnn);
            int d = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            return "CTDH0" + d;
        }

        public DataTable loadCTDatHang()
        {
            da = new SqlDataAdapter("select * from  CT_DATHANG", cnn);
            da.Fill(ds, "dsCTDatHang");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsCTDatHang"].Columns[0];
            ds.Tables["dsCTDatHang"].PrimaryKey = khoachinh;

            return ds.Tables["dsCTDatHang"];
        }

        public bool themDSThuoc(string machitiet, string madathang, string mathuoc, int soluongdat, double gianhap, double thanhtien)
        {
            loadCTDatHang();
            try
            {
                DataRow dr = ds.Tables["dsCTDatHang"].NewRow();
                dr["MACTDATHANG"] = machitiet;
                dr["MADATHANG"] = madathang;
                dr["MATHUOC"] = mathuoc;
                dr["SOLUONGDAT"] = soluongdat;
                dr["GIANHAP"] = gianhap;
                dr["THANHTIENDAT"] = thanhtien;
                ds.Tables["dsCTDatHang"].Rows.Add(dr);
                luuDS();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa(string macthoadon)
        {
            loadCTDatHang();
            try
            {
                DataRow dr = ds.Tables["dsCTDatHang"].Rows.Find(macthoadon);
                if (dr != null)
                {
                    dr.Delete();
                    luuDS();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public void luuDS()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsCTDatHang"]);
        }

        //public DataTable loadReport(string mahd)
        //{
        //    da = new SqlDataAdapter("select  TENTHUOC, SOLUONGDAT, GIANHAP, THANHTIENDAT FROM CT_DATHANG,THUOC WHERE THUOC.MATHUOC=CT_DATHANG.MATHUOC AND MADATHANG='" + mahd + "'", cnn);
        //    da.Fill(ds, "Report");

        //    return ds.Tables["Report"];
        //}

        //public string tenNCC(string mahd)
        //{
        //    da = new SqlDataAdapter("select  TENNCC FROM DATHANG,NHACUNGCAP WHERE DATHANG.MANCC=NHACUNGCAP.MANCC AND MADATHANG='" + mahd + "'", cnn);
        //    da.Fill(ds, "Report1");

        //    string tenncc = "";
        //    DataRow dr = ds.Tables["Report1"].Rows[0];
        //    tenncc = dr["TENNCC"].ToString();
        //    return tenncc;
        //}

        public DataTable loadGridViewTKMaDH(string madh)
        {
            da = new SqlDataAdapter("select MADATHANG, TENNCC, TENNV, NGAYDATHANG, TONGTIENDAT, TRANGTHAI FROM NHANVIEN,NHACUNGCAP,DATHANG WHERE NHACUNGCAP.MANCC=DATHANG.MANCC AND NHANVIEN.MANV=DATHANG.MANV AND MADATHANG='" + madh + "'", cnn);
            da.Fill(ds, "TIMKIEM");

            return ds.Tables["TIMKIEM"];
        }

        public DataTable loadGridViewTKCTDH(string madh)
        {
            da = new SqlDataAdapter("select MACTDATHANG, MADATHANG, TENTHUOC, SOLUONGDAT, GIANHAP, THANHTIENDAT FROM CT_DATHANG,THUOC WHERE  CT_DATHANG.MATHUOC=THUOC.MATHUOC AND MADATHANG='" + madh + "'", cnn);
            da.Fill(ds, "TIMKIEM1");

            return ds.Tables["TIMKIEM1"];
        }
    }

}



