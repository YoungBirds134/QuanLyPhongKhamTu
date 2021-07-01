using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuDichVuDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da;
        //REPORT
        public DataTable REPORT1(int makqdv, int madkdv)
        {
            ds1.Clear();
            da = new SqlDataAdapter("select  MAKQDV, PHIEUDKDICHVU.MADKDV,TENBN, TENNV,NGAYLAPKQ,GHICHU from KETQUADICHVU,PHIEUDKDICHVU,PHIEUKHAMBENH,BENHNHAN,NHANVIEN WHERE NHANVIEN.MANV=KETQUADICHVU.MANV AND BENHNHAN.MABN=PHIEUKHAMBENH.MABN AND PHIEUKHAMBENH.SOPHIEUKHAM=PHIEUDKDICHVU.SOPHIEUKHAM AND MAKQDV=" + makqdv + " AND PHIEUDKDICHVU.MADKDV=" + madkdv + "", cnn);
            da.Fill(ds1, "Report1");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds1.Tables["Report1"].Columns[0];
            ds1.Tables["Report1"].PrimaryKey = khoachinh;
            return ds1.Tables["Report1"];
        }
        //xử lý thanh toán
        public DataTable loadThanhToan1(string sohd)
        {
            ds2.Clear();
            da = new SqlDataAdapter("select SOHDDV,MADKDV,TENNV,NGAYLAPHDDV,TONGTIEN from HOADONDICHVU,NHANVIEN where HOADONDICHVU.MANV=NHANVIEN.MANV AND SOHDDV='" + sohd + "'", cnn);
            da.Fill(ds2, "HOADONDICHVU2");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds2.Tables["HOADONDICHVU2"].Columns[0];
            ds2.Tables["HOADONDICHVU2"].PrimaryKey = khoachinh;
            return ds2.Tables["HOADONDICHVU2"];
        }
        public DataTable loadThanhToan()
        {
            da = new SqlDataAdapter("select SOHDDV,MADKDV,TENNV,NGAYLAPHDDV,TONGTIEN from HOADONDICHVU,NHANVIEN where HOADONDICHVU.MANV=NHANVIEN.MANV ", cnn);
            da.Fill(ds, "HOADONDICHVU1");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["HOADONDICHVU1"].Columns[0];
            ds.Tables["HOADONDICHVU1"].PrimaryKey = khoachinh;
            return ds.Tables["HOADONDICHVU1"];
        }
        public bool themTT(string madkdv, string manv, string ngaylap, double tongtien)
        {
            da = new SqlDataAdapter("select MADKDV,MANV,NGAYLAPHDDV,TONGTIEN from HOADONDICHVU", cnn);
            da.Fill(ds, "HOADONDICHVU");
            try
            {
                DataRow dr = ds.Tables["HOADONDICHVU"].NewRow();
                dr["MADKDV"] = madkdv;
                dr["MANV"] = manv;
                dr["NGAYLAPHDDV"] = ngaylap;
                dr["TONGTIEN"] = tongtien;
                ds.Tables["HOADONDICHVU"].Rows.Add(dr);
                luuTT();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void luuTT()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["HOADONDICHVU"]);
        }
        //Sử lý KQ_DICHVU
        public DataTable loadGridViewKQDV(string makqdv)
        {
            ds1.Clear();
            da = new SqlDataAdapter("select * from KETQUADICHVU where MAKQDV='" + makqdv + "'", cnn);
            da.Fill(ds1, "KETQUADICHVU2");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds1.Tables["KETQUADICHVU2"].Columns[0];
            ds1.Tables["KETQUADICHVU2"].PrimaryKey = khoachinh;
            return ds1.Tables["KETQUADICHVU2"];
        }
        public DataTable loadGridViewKQ(int madkdv)
        {
            da = new SqlDataAdapter("select MAKQDV,MADKDV,TENNV,NGAYLAPKQ,GHICHU from KETQUADICHVU,NHANVIEN where KETQUADICHVU.MANV=NHANVIEN.MANV AND MADKDV="+madkdv, cnn);
            da.Fill(ds, "KETQUADICHVU1");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["KETQUADICHVU1"].Columns[0];
            ds.Tables["KETQUADICHVU1"].PrimaryKey = khoachinh;
            return ds.Tables["KETQUADICHVU1"];
        }
        public bool themKQ(int madkdv, string manv, string ngaylap, string ghichu)
        {
            da = new SqlDataAdapter("select MADKDV,MANV,NGAYLAPKQ,GHICHU from KETQUADICHVU", cnn);
            da.Fill(ds, "KETQUADICHVU");

            try
            {
                DataRow dr = ds.Tables["KETQUADICHVU"].NewRow();
                dr["MADKDV"] = madkdv;
                dr["MANV"] = manv;
                dr["NGAYLAPKQ"] = ngaylap;
                dr["GHICHU"] = ghichu;
                ds.Tables["KETQUADICHVU"].Rows.Add(dr);
                luuKQ();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaKQ(int makqdv, int madkdv, string manv, string ngaylap, string ghichu)
        {
            da = new SqlDataAdapter("select * from KETQUADICHVU ", cnn);
            da.Fill(ds, "KETQUADICHVU2");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["KETQUADICHVU2"].Columns[0];
            ds.Tables["KETQUADICHVU2"].PrimaryKey = khoachinh;
            //int ma = int.Parse(madkdv);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["KETQUADICHVU2"].Rows.Find(makqdv);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE KETQUADICHVU SET MADKDV='" + madkdv + "',MANV='" + manv + "',NGAYLAPKQ ='" + ngaylap + "',GHICHU = N'" + ghichu + "' WHERE MAKQDV='" + makqdv + "'", cnn);
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
        public void luuKQ()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["KETQUADICHVU"]);
        }

        public DataTable loadGridView(int maphieudk)
        {
            da = new SqlDataAdapter("select MACTDICHVU,MADKDV,TENDV,THANHTIEN from CT_PHIEUDKDICHVU,DICHVU where CT_PHIEUDKDICHVU.MADV=DICHVU.MADV and MADKDV=" + maphieudk + "", cnn);
            da.Fill(ds, "dsctphieudichvu");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsctphieudichvu"].Columns[0];
            ds.Tables["dsctphieudichvu"].PrimaryKey = khoachinh;
            return ds.Tables["dsctphieudichvu"];
        }
        public DataTable loadChuaXN()
        {
            da = new SqlDataAdapter("select MADKDV, SOPHIEUKHAM, TENNV, NGAYLAPPHIEUDK, TRANGTHAI, TENPHONG from PHIEUDKDICHVU, NHANVIEN, PHONG  WHERE PHIEUDKDICHVU.MABS=NHANVIEN.MANV AND PHIEUDKDICHVU.MAPHONG=PHONG.MAPHONG AND TRANGTHAI=N'Chưa thực hiện'", cnn);
            da.Fill(ds, "ChuaTH");

            return ds.Tables["ChuaTH"];
        }


        //XỬ LÝ DKDICHVU VÀ CTDKDICHVU
        public DataTable load()
        {
            da = new SqlDataAdapter("select SOPHIEUKHAM, MABS, NGAYLAPPHIEUDK, MAPHONG, TONGTIEN, TRANGTHAI from  PHIEUDKDICHVU", cnn);
            da.Fill(ds, "dsPhieuDV");
           

            return ds.Tables["dsPhieuDV"];
        }

        public bool them(int sophieukham, string mabs, string ngaylap, string maphong, double tongtien, string trangthai)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsPhieuDV"].NewRow();
                dr["SOPHIEUKHAM"] = sophieukham;
                dr["MABS"] = mabs;
                dr["NGAYLAPPHIEUDK"] = ngaylap;
                dr["MAPHONG"] = maphong;
                dr["TONGTIEN"] = tongtien;
                dr["TRANGTHAI"] = trangthai;
                ds.Tables["dsPhieuDV"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsPhieuDV"]);
        }

        public string loadMaDKDV()
        {
            da = new SqlDataAdapter("select MAX(MADKDV)AS MADKDV from  PHIEUDKDICHVU", cnn);
            da.Fill(ds, "MaxMaDKDV");

            string a = "";
            foreach(DataRow dr in ds.Tables["MaxMaDKDV"].Rows)
            {
                a = dr["MADKDV"].ToString();
            }
            return a;
        }

        public DataTable loadGirdViewCT(int madkdv)
        {
            da = new SqlDataAdapter("select  * from  CT_PHIEUDKDICHVU where MADKDV=" + madkdv + "", cnn);
            da.Fill(ds, "GridView");

            return ds.Tables["GridView"];
        }

        public void loadTT()
        {
            da = new SqlDataAdapter("select  MADKDV, MADV, THANHTIEN from  CT_PHIEUDKDICHVU", cnn);
            da.Fill(ds, "dsCTPDKDV");

        }
        public bool themCT(int madkdv, string madv, double thanhtien)
        {
            loadTT();
            try
            {
                DataRow dr = ds.Tables["dsCTPDKDV"].NewRow();
                dr["MADKDV"] = madkdv;
                dr["MADV"] = madv;
                dr["THANHTIEN"] = thanhtien;
                ds.Tables["dsCTPDKDV"].Rows.Add(dr);
                luuCT();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoaCT(int mactdkdv)
        {
            da = new SqlDataAdapter("select * from  CT_PHIEUDKDICHVU", cnn);
            da.Fill(ds, "dsCTPDKDV1");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsCTPDKDV1"].Columns[0];
            ds.Tables["dsCTPDKDV1"].PrimaryKey = khoachinh;

            try
            {
                DataRow dr = ds.Tables["dsCTPDKDV1"].Rows.Find(mactdkdv);
                if (dr != null)
                {
                    dr.Delete();
                    SqlCommandBuilder scb = new SqlCommandBuilder(da);
                    da.Update(ds.Tables["dsCTPDKDV1"]);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public void luuCT()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsCTPDKDV"]);
        }

        public void capnhat()
        {
            da = new SqlDataAdapter("select * from  PHIEUDKDICHVU", cnn);
            da.Fill(ds, "dd1");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dd1"].Columns[0];
            ds.Tables["dd1"].PrimaryKey = khoachinh;
        }

        public bool capnhatTongTienC(int madkdv, double thanhtien)
        {
            capnhat();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("UPDATE PHIEUDKDICHVU SET TONGTIEN=TONGTIEN+" + thanhtien + " WHERE MADKDV=" + madkdv + "", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capnhatTongTienT(int madkdv, double thanhtien)
        {
            capnhat();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("UPDATE PHIEUDKDICHVU SET TONGTIEN=TONGTIEN-" + thanhtien + " WHERE MADKDV=" + madkdv + "", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string tongtien(int madk)
        {
            da = new SqlDataAdapter("select * from  PHIEUDKDICHVU where MADKDV=" + madk + "", cnn);
            da.Fill(ds, "dd2");

            string a = "";
            foreach(DataRow dr in ds.Tables["dd2"].Rows)
            {
                a = dr["TONGTIEN"].ToString();
            }
            return a;
        }

        public bool capNhatTrangThaiPhieu(string madkdv)
        {
            capnhat();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("UPDATE PHIEUDKDICHVU SET TRANGTHAI=N'Đã thực hiện' WHERE MADKDV=" + madkdv + "", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
