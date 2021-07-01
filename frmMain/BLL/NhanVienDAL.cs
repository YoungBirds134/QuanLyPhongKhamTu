using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class NhanVienDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from NHANVIEN", cnn);
            da.Fill(ds, "dsNV");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsNV"].Columns[0];
            ds.Tables["dsNV"].PrimaryKey = khoachinh;
            return ds.Tables["dsNV"];
        }

        public bool them(string maNV, string tenNV, string tenDN, string matKhau, string ngaySinh, string gioiTinh, string diaChi, string gmail, string sDT,string chucVu,double luongCB, double hSL,double luong, string maKhoa)
        {
            try
            {
                DataRow dr = ds.Tables["dsNV"].NewRow();
                dr["MANV"] = maNV;
                dr["TENNV"] = tenNV;
                dr["TENDANGNHAP"] = tenDN;
                dr["MATKHAU"] = matKhau;
                dr["NGAYSINH"] = ngaySinh;
                dr["GIOITINH"] = gioiTinh;
                dr["DIACHI"] = diaChi;
                dr["GMAIL"] = gmail;
                dr["SDT"] = sDT;
                dr["CHUCVU"] = chucVu;
                dr["LUONGCB"] = luongCB;
                dr["HSL"] = hSL;
                dr["LUONG"] = luong;
                dr["MAKHOA"] = maKhoa;
                ds.Tables["dsNV"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool xoa(string maNV)
        {
            try
            {
                DataRow dr = ds.Tables["dsNV"].Rows.Find(maNV);
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

        public bool sua(string maNV, string tenNV, string tenDN, string matKhau, string ngaySinh, string gioiTinh, string diaChi, string gmail, string sDT, string chucVu, double luongCB, double hSL, double luong, string maKhoa)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsNV"].Rows.Find(maNV);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE NHANVIEN SET TENNV=N'" + tenNV+ "',TENDANGNHAP = N'"+tenDN+"',MATKHAU = '"+matKhau+"',NGAYSINH = '"+ngaySinh+"',GIOITINH =N'"+gioiTinh+"',DIACHI = N'"+diaChi+"',GMAIL = '"+gmail+"', SDT='"+sDT+"',CHUCVU=N'"+chucVu+"',LUONGCB = "+luongCB+",HSL="+hSL+",LUONG = "+luong+",MAKHOA = '"+maKhoa+"' WHERE MANV='" + maNV+ "'", cnn);
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
        public void luu()
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dsNV"]);
        }

        public DataTable layThongTinNhanVien(string tenDangNhap)
        {
            da = new SqlDataAdapter("select NHANVIEN.MANV,NHANVIEN.TENNV from NHANVIEN where TENDANGNHAP=N'" + tenDangNhap + "'", cnn);

            da.Fill(ds, "NV");
            return ds.Tables["NV"];
        }
    }
}
