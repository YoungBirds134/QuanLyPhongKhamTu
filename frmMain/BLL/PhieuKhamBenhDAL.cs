using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhieuKhamBenhDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataTable loadChoKham()
        {
            da = new SqlDataAdapter("select SOPHIEUKHAM,TENBN from  PHIEUKHAMBENH,BENHNHAN WHERE PHIEUKHAMBENH.MABN=BENHNHAN.MABN AND TRANGTHAIPHIEU=N'Chưa khám'", cnn);
            da.Fill(ds, "dsChoKham");

            return ds.Tables["dsChoKham"];
        }

        public DataTable loadChoXetNghiem()
        {
            da = new SqlDataAdapter("select SOPHIEUKHAM,TENBN from  PHIEUKHAMBENH,BENHNHAN WHERE PHIEUKHAMBENH.MABN=BENHNHAN.MABN AND TRANGTHAIPHIEU=N'Chưa xét nghiệm'", cnn);
            da.Fill(ds, "dsChoXetNghiem");

            return ds.Tables["dsChoXetNghiem"];
        }

        public DataTable load()
        {
            da = new SqlDataAdapter("select * from  PHIEUKHAMBENH ", cnn);
            da.Fill(ds, "ds");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["ds"].Columns[0];
            ds.Tables["ds"].PrimaryKey = khoachinh;

            return ds.Tables["ds"];
        }

        public bool suaTrangThaiDaKham(int sopk)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["ds"].Rows.Find(sopk);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE PHIEUKHAMBENH SET TRANGTHAIPHIEU=N'Đã khám' WHERE SOPHIEUKHAM=" + sopk + "", cnn);
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

        public bool suaTrangThaiChoXetNghiem(int sopk)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["ds"].Rows.Find(sopk);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE PHIEUKHAMBENH SET TRANGTHAIPHIEU=N'Chưa xét nghiệm' WHERE SOPHIEUKHAM=" + sopk + "", cnn);
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

        public DataTable loadPhieuKhamBenh(int tenBN)
        {
            da = new SqlDataAdapter("exec rpPhieuKhamBenh " + tenBN, cnn);
            da.Fill(ds, "dsPK");

            return ds.Tables["dsPK"];
        }

        public bool them(int maPhieu, int maBN, string maNV, string ngayLapPhieu, string maPhong, string tinhTrangSucKhoe, string deNghiKham, string maGiaKham, string trangThaiPhieu)
        {

            try
            {
                DataRow dr = ds.Tables["dsPKB"].NewRow();

                dr["SOPHIEUKHAM"] = maPhieu;
                dr["MABN"] = maBN;
                dr["MANV"] = maNV;
                dr["NGAYLAPPHIEU"] = ngayLapPhieu;
                dr["MAPHONG"] = maPhong;
                dr["TINHTRANGSUCKHOE"] = tinhTrangSucKhoe;
                dr["DENGHIKHAM"] = deNghiKham;
                dr["MAGIAKHAM"] = maGiaKham;
                dr["TRANGTHAIPHIEU"] = trangThaiPhieu;
                ds.Tables["dsPKB"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable load_PhieuKhamBenh()
        {
            da = new SqlDataAdapter("select * from PhieuKhamBenh", cnn);
            da.Fill(ds, "dsPKB");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsPKB"].Columns[0];
            ds.Tables["dsPKB"].PrimaryKey = khoachinh;
            return ds.Tables["dsPKB"];
        }

        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsPKB"]);
        }

        public int layMaPhieuKhamBenh(int maBenhNhan)
        {
            string id = "";

            SqlCommand cmd = new SqlCommand("Select * from PHIEUKHAMBENH where MABN=" + maBenhNhan + "", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    id = dr["SOPHIEUKHAM"].ToString();
                }
            }

            int idd = int.Parse(id);
            return idd;
        }

        public string TrangThaiBN(int sophieukham)
        {
            da = new SqlDataAdapter("select * from PhieuKhamBenh WHERE SOPHIEUKHAM =" + sophieukham + "", cnn);
            da.Fill(ds, "dsTrangThaiBN");
            string a = "";
            foreach(DataRow dr in ds.Tables["dsTrangThaiBN"].Rows)
            {
                a = dr["TINHTRANGSUCKHOE"].ToString();
            }
            return a;
        }
    }
}
