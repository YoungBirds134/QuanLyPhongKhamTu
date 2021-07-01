using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ThongTinNhanVienDAL
    {
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        KhoaDAL khoa = new KhoaDAL();

        public string tenNV(string tendangnhap)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", cnn);
            da.Fill(ds, "NV");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["NV"].Columns[2];
            ds.Tables["NV"].PrimaryKey = khoachinh;

            DataRow dr = ds.Tables["NV"].Rows.Find(tendangnhap);
            string ten = "";
            if (dr != null)
            {
                ten = dr["TENNV"].ToString();
            }
            return ten;
        }

        public string maNV(string tendangnhap)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", cnn);
            da.Fill(ds, "NV1");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["NV1"].Columns[2];
            ds.Tables["NV1"].PrimaryKey = khoachinh;

            DataRow dr = ds.Tables["NV1"].Rows.Find(tendangnhap);
            string ma = "";
            if (dr != null)
            {
                ma = dr["MANV"].ToString();
            }
            return ma;
        }

        public void loadProFile(TextBox ma, TextBox ten, TextBox tendn, TextBox matkhau, DateTimePicker ngaysinh, ComboBox gioitinh, TextBox diachi, TextBox gmail, TextBox sdt, TextBox chucvu, TextBox tenkhoa, TextBox luongcb, TextBox hsl, TextBox luong, string tendangnhap)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", cnn);
            da.Fill(ds, "profileNV");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["profileNV"].Columns[2];
            ds.Tables["profileNV"].PrimaryKey = khoachinh;

            DataRow dr = ds.Tables["profileNV"].Rows.Find(tendangnhap);
            if (dr != null)
            {
                ma.Text = dr["MANV"].ToString();
                ten.Text = dr["TENNV"].ToString();
                tendn.Text = dr["TENDANGNHAP"].ToString();
                matkhau.Text = dr["MATKHAU"].ToString();
                ngaysinh.Text = dr["NGAYSINH"].ToString();
                gioitinh.SelectedItem = dr["GIOITINH"].ToString();
                diachi.Text = dr["DIACHI"].ToString();
                gmail.Text = dr["GMAIL"].ToString();
                sdt.Text = dr["SDT"].ToString();
                chucvu.Text = dr["CHUCVU"].ToString();
                tenkhoa.Text = khoa.tenKhoa(dr["MAKHOA"].ToString());
                luongcb.Text = dr["LUONGCB"].ToString(); 
                hsl.Text = dr["HSL"].ToString();
                luong.Text = dr["LUONG"].ToString();
            }
        }



        public bool sua(string ma, string ten, string tendn, string matkhau, string ngaysinh, string gioitinh, string diachi, string gmail, string sdt)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", cnn);
            da.Fill(ds, "profileNV1");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["profileNV1"].Columns[0];
            ds.Tables["profileNV1"].PrimaryKey = khoachinh;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["profileNV1"].Rows.Find(ma);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE NHANVIEN SET TENNV=N'" + ten + "',TENDANGNHAP='" + tendn + "', MATKHAU='" + matkhau + "', NGAYSINH='" + ngaysinh + "', GIOITINH=N'" + gioitinh + "', DIACHI=N'" + diachi + "', GMAIL=N'" + gmail + "', SDT='" + sdt + "'  WHERE MANV='" + ma + "'", cnn);
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


    }
}
