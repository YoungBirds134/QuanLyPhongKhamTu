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
    public class NhapThuocDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;


        public string loadMaDH()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            string truyvan = "select count(*) from NHAPHANG";
            SqlCommand cmd = new SqlCommand(truyvan, cnn);
            int d = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
            return "NH0" + d.ToString();

        }
        public DataTable load()
        {
            da = new SqlDataAdapter("select * from  NHAPHANG", cnn);
            da.Fill(ds, "dsNhapHang");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsNhapHang"].Columns[0];
            ds.Tables["dsNhapHang"].PrimaryKey = khoachinh;

            return ds.Tables["dsNhapHang"];
        }

        public bool them(string manhap, string madat, string manv, string ngaynhap, double tongtien)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsNhapHang"].NewRow();
                dr["MANHAPHANG"] = manhap;
                dr["MADATHANG"] = madat;
                dr["MANV"] = manv;
                dr["NGAYNHAP"] = ngaynhap;
                dr["TONGTIENNHAP"] = tongtien;
                ds.Tables["dsNhapHang"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaTongThanhTien(string manhap, double tongtien)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsNhapHang"].Rows.Find(manhap);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE NHAPHANG SET TONGTIENNHAP=TONGTIENNHAP+" + tongtien + " WHERE MANHAPHANG='" + manhap + "'", cnn);
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

        public bool xoaNH(string manhap)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsNhapHang"].Rows.Find(manhap);
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
            da.Update(ds.Tables["dsNhapHang"]);
        }

        public DataTable loadGridViewDangNhapHang(string manhaphang)
        {
            da = new SqlDataAdapter("select * FROM CT_NHAPHANG WHERE MANHAPHANG='" + manhaphang + "'", cnn);
            da.Fill(ds, "DS");

            return ds.Tables["DS"];
        }

        public int loadMaCTNH()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            string truyvan = "select count(*) from CT_NHAPHANG";
            SqlCommand cmd = new SqlCommand(truyvan, cnn);
            int d = int.Parse(cmd.ExecuteScalar().ToString());
            return d;
        }

        public DataTable loadCTNhapHang()
        {
            da = new SqlDataAdapter("select * from  CT_NHAPHANG", cnn);
            da.Fill(ds, "dsCTNhapHang");

            DataColumn[] khoachinh = new DataColumn[2];
            khoachinh[0] = ds.Tables["dsCTNhapHang"].Columns[0];
            khoachinh[1] = ds.Tables["dsCTNhapHang"].Columns[1];
            ds.Tables["dsCTNhapHang"].PrimaryKey = khoachinh;

            return ds.Tables["dsCTNhapHang"];
        }

        public bool themDSCTNhapHang(string manhaphang, string mactdathang, int soluongnhap, double gianhap, double thanhtien, string hsd)
        {
            loadCTNhapHang();
            try
            {
                DataRow dr = ds.Tables["dsCTNhapHang"].NewRow();
                dr["MANHAPHANG"] = manhaphang;
                dr["MACTDATHANG"] = mactdathang;
                dr["SOLUONGNHAP"] = soluongnhap;
                dr["GIANHAP"] = gianhap;
                dr["THANHTIENNHAP"] = thanhtien;
                dr["HSD"] = hsd;
                ds.Tables["dsCTNhapHang"].Rows.Add(dr);
                luuDS();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void luuDS()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsCTNhapHang"]);
        }
    }
}
