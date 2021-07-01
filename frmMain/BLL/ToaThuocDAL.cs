using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ToaThuocDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataTable load()
        {
            da = new SqlDataAdapter("select SOPHIEUKHAM, MABS, NGAYLAPTOA, TINHTRANG, CHUANDOAN, HUONGDIEUTRI, TONGTIEN from  TOATHUOC", cnn);
            da.Fill(ds, "dsToaThuoc");


            return ds.Tables["dsToaThuoc"];
        }

        public bool them(int sophieukham, string mabs, string ngaylaptoa, string tinhtrang, string chuandoan, string huongdieutri, double tongtien)
        {
            load();
            try
            {
                DataRow dr = ds.Tables["dsToaThuoc"].NewRow();
                dr["SOPHIEUKHAM"] = sophieukham;
                dr["MABS"] = mabs;
                dr["NGAYLAPTOA"] = ngaylaptoa;
                dr["TINHTRANG"] = tinhtrang;
                dr["CHUANDOAN"] = chuandoan;
                dr["HUONGDIEUTRI"] = huongdieutri;
                dr["TONGTIEN"] = tongtien;
                ds.Tables["dsToaThuoc"].Rows.Add(dr);
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
            da.Update(ds.Tables["dsToaThuoc"]);
        }

        public string loadMaToa()
        {
            da = new SqlDataAdapter("select MAX(MATOA) AS MATOA from  TOATHUOC", cnn);
            da.Fill(ds, "DSMATOA");

            string matoa = "";
            foreach(DataRow dr in ds.Tables["DSMATOA"].Rows)
            {
                matoa = dr["MATOA"].ToString();
            }
            return matoa;
        }

        public DataTable loadDS(string matoa)
        {
            da = new SqlDataAdapter("select * from  CT_TOATHUOC WHERE MATOA='" + matoa + "'", cnn);
            da.Fill(ds, "dsDS");

            DataColumn[] khoachinh = new DataColumn[2];
            khoachinh[0] = ds.Tables["dsDS"].Columns[0];
            khoachinh[1] = ds.Tables["dsDS"].Columns[1];
            ds.Tables["dsDS"].PrimaryKey = khoachinh;

            return ds.Tables["dsDS"];
        }

        public void loadDSThuoc()
        {
            da = new SqlDataAdapter("select * from  CT_TOATHUOC", cnn);
            da.Fill(ds, "dsDSThuoc");

            DataColumn[] khoachinh = new DataColumn[2];
            khoachinh[0] = ds.Tables["dsDSThuoc"].Columns[0];
            khoachinh[1] = ds.Tables["dsDSThuoc"].Columns[1];
            ds.Tables["dsDSThuoc"].PrimaryKey = khoachinh;

        }

        public bool themDSThuoc(int matoa, string mathuoc, int soluong, double giaban, string dvt, string cachdung, double thanhtien)
        {
            loadDSThuoc();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("INSERT INTO CT_TOATHUOC VALUES (" + matoa + ",'" + mathuoc + "'," + soluong + "," + giaban + ",N'" + dvt + "',N'" + cachdung + "'," + thanhtien + ")", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaDSThuoc(int matoa, string mathuoc)
        {
            loadDSThuoc();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("DELETE FROM CT_TOATHUOC WHERE MATOA=" + matoa + " AND MATHUOC='" + mathuoc + "'", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
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
            da.Update(ds.Tables["dsDSThuoc"]);
        }

        public void loadThanhTien(int matoa)
        {
            da = new SqlDataAdapter("select * from  TOATHUOC WHERE MATOA=" + matoa + "", cnn);
            da.Fill(ds, "dsThanhTien");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsThanhTien"].Columns[0];
            ds.Tables["dsThanhTien"].PrimaryKey = khoachinh;

        }

        public bool capnhatTongThanhTienC(int matoa, double thanhtien) 
        {
            loadThanhTien(matoa);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("UPDATE TOATHUOC SET TONGTIEN=TONGTIEN+" + thanhtien + " WHERE MATOA=" + matoa + "", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool capnhatTongThanhTienT(int matoa, double thanhtien)
        {
            loadThanhTien(matoa);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand capnhat = new SqlCommand("UPDATE TOATHUOC SET TONGTIEN=TONGTIEN-" + thanhtien + " WHERE MATOA=" + matoa + "", cnn);
                capnhat.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable rpToaThuoc(int matoa)
        {
            da = new SqlDataAdapter("exec procToaThuoc " + matoa, cnn);
            da.Fill(ds, "dsRPToaThuoc");
            return ds.Tables["dsRPToaThuoc"];
        }
    }
}
