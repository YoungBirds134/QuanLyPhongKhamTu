using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class ThuocDAL
    {
        DataSet ds = new DataSet();
        SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-8VCHS1JQ\\SQLEXPRESS;Initial Catalog=QLPHONGKHAMBENH;User ID=sa;Password=sa2012");
        SqlDataAdapter da;

        public DataTable loadGridView()
        {
            da = new SqlDataAdapter("select * from THUOC", cnn);
            da.Fill(ds, "dsT");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsT"].Columns[0];
            ds.Tables["dsT"].PrimaryKey = khoachinh;
            return ds.Tables["dsT"];
        }

        public bool them(string maThuoc, string tenThuoc, string maLoai, string maNSX, string congDung, string hamLuong, string HSD, string donViCB, double giaCB, double soLuongCB, string donViBan, double giaBan, double soLuongBan, double giaTriQuyDoi,string quyCachDongGoi,string maViTri, string moTa)
        {
            try
            {
                DataRow dr = ds.Tables["dsT"].NewRow();
                dr["MATHUOC"] = maThuoc;
                dr["TENTHUOC"] = tenThuoc;
                dr["MALOAI"] = maLoai;
                dr["MANSX"] = maNSX;
                dr["CONGDUNG"] = congDung;
                dr["HAMLUONG"] = hamLuong;
                dr["HSD"] = HSD;
                dr["DONVICB"] = donViCB;
                dr["GIACB"] = giaCB;
                dr["SOLUONGCB"] = soLuongCB;
                dr["DONVIBAN"] = donViBan;
                dr["GIABAN"] = giaBan;
                dr["SOLUONGBAN"] = soLuongBan;
                dr["GIATRIQUYDOI"] = giaTriQuyDoi;
                dr["QUICACHDONGGOI"] = quyCachDongGoi;
                dr["MAVITRI"] = maViTri;
                dr["MOTA"] = moTa;
                ds.Tables["dsT"].Rows.Add(dr);
                luu();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool xoa(string maThuoc)
        {
            try
            {
                DataRow dr = ds.Tables["dsT"].Rows.Find(maThuoc);
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

        public bool sua(string maThuoc, string tenThuoc, string maLoai, string maNSX, string congDung, string hamLuong, string HSD, string donViCB, double giaCB, double soLuongCB, string donViBan, double giaBan, double soLuongBan, double giaTriQuyDoi, string quyCachDongGoi, string maViTri, string moTa)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsT"].Rows.Find(maThuoc);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET TENTHUOC=N'" + tenThuoc + "',MALOAI = '" + maLoai + "',MANSX = '" + maNSX + "',CONGDUNG = N'" + congDung + "',HAMLUONG =N'" + hamLuong + "',HSD = '" + HSD + "',DONVICB = N'" + donViCB + "', GIACB=" + giaCB + ",SOLUONGCB=" + soLuongCB + ",DONVIBAN= N'" + donViBan + "',SOLUONGBAN=" + soLuongBan + ",GIATRIQUYDOI = " + giaTriQuyDoi + ",QUICACHDONGGOI = N'" + quyCachDongGoi + "',MAVITRI='" + maViTri + "',MOTA=N'" + moTa + "' WHERE MATHUOC='" + maThuoc + "'", cnn);
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
            da.Update(ds.Tables["dsT"]);
        }

        public void load()
        {
            da = new SqlDataAdapter("select * from THUOC", cnn);
            da.Fill(ds, "dsTHUOC1");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsTHUOC1"].Columns[0];
            ds.Tables["dsTHUOC1"].PrimaryKey = khoachinh;


        }

        public string maThuoc(string tenthuoc)
        {
            da = new SqlDataAdapter("select * from THUOC WHERE TENTHUOC=N'" + tenthuoc + "'", cnn);
            da.Fill(ds, "dsTHUOC2");
            string a = "";
            foreach (DataRow dr in ds.Tables["dsTHUOC2"].Rows)
            {
                a = dr["MATHUOC"].ToString();
            }
            return a;
        }

        public string tenThuoc(string mathuoc)
        {
            da = new SqlDataAdapter("select * from THUOC WHERE MATHUOC=N'" + mathuoc + "'", cnn);
            da.Fill(ds, "dsTHUOC3");
            string a = "";
            foreach (DataRow dr in ds.Tables["dsTHUOC3"].Rows)
            {
                a = dr["TENTHUOC"].ToString();
            }
            return a;
        }

        public bool suaNhapThuoc(string ma, int soluongban, string hsd)
        {
            load();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsTHUOC1"].Rows.Find(ma);
                if (dr != null)
                {
                    SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET HSD='" + hsd + "', SOLUONGBAN=" + soluongban + ", SOLUONGCB=" + soluongban + " * GIATRIQUYDOI  WHERE MATHUOC='" + ma + "'", cnn);
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


        public DataTable loadThuocHetHanHetHang()
        {
            da = new SqlDataAdapter("select MATHUOC,TENTHUOC,TENNSX,SOLUONGBAN,HSD,TENLOAI,QUICACHDONGGOI from THUOC,NHASANXUAT,LOAITHUOC WHERE THUOC.MANSX=NHASANXUAT.MANSX AND THUOC.MALOAI=LOAITHUOC.MALOAI AND (SOLUONGBAN<=5 OR DATEDIFF(DAY,GETDATE(),HSD)<7)", cnn);
            da.Fill(ds, "dsHH");

            return ds.Tables["dsHH"];
        }


        public void loadThuoc()
        {
            da = new SqlDataAdapter("select * from THUOC", cnn);
            da.Fill(ds, "dsTT");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsTT"].Columns[0];
            ds.Tables["dsTT"].PrimaryKey = khoachinh;
        }

        public void loadDVTTheoThuoc(string mathuoc, ComboBox com)
        {
            loadThuoc();
            DataRow dr = ds.Tables["dsTT"].Rows.Find(mathuoc);
            if (dr != null)
            {
                com.Items.Add(dr["DONVICB"].ToString());
                com.Items.Add(dr["DONVIBAN"].ToString());
            }          
        }

        public string loadGiaTheoDVT(string mathuoc, ComboBox com, int trangthai)
        {
            loadThuoc();
            DataRow dr = ds.Tables["dsTT"].Rows.Find(mathuoc);
            string gia = "";
            if (dr != null)
            {
                if (trangthai == 1)
                {
                    gia =  dr["GIACB"].ToString();
                }
                if (trangthai == 2)
                {
                    gia =  dr["GIABAN"].ToString();
                }
            }           
            return gia;
        }

        public void capNhat()
        {
            da = new SqlDataAdapter("select * from THUOC", cnn);
            da.Fill(ds, "dsTHUOC");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = ds.Tables["dsTHUOC"].Columns[0];
            ds.Tables["dsTHUOC"].PrimaryKey = khoachinh;
        }

        public bool capnhatSLThuocThem(string ma, int soluongmua, int kieumua)
        {
            capNhat();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsTHUOC"].Rows.Find(ma);
                if (dr != null)
                {
                    if (kieumua == 2)
                    {
                        SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET SOLUONGBAN=SOLUONGBAN-" + soluongmua + ", SOLUONGCB=SOLUONGCB-(" + soluongmua + "*GIATRIQUYDOI)   WHERE MATHUOC='" + ma + "'", cnn);
                        capnhat.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    }
                    if (kieumua == 1)
                    {
                        SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET SOLUONGCB=SOLUONGCB-" + soluongmua + ", SOLUONGBAN=(SOLUONGCB-" + soluongmua + ")/GIATRIQUYDOI   WHERE MATHUOC='" + ma + "'", cnn);
                        capnhat.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool capnhatSLThuocXoa(string ma, int soluongmua, int kieumua)
        {
            capNhat();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                DataRow dr = ds.Tables["dsTHUOC"].Rows.Find(ma);
                if (dr != null)
                {
                    if (kieumua == 2)
                    {
                        SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET SOLUONGBAN=SOLUONGBAN+" + soluongmua + ", SOLUONGCB=SOLUONGCB+(" + soluongmua + "*GIATRIQUYDOI)   WHERE MATHUOC='" + ma + "'", cnn);
                        capnhat.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    }
                    if (kieumua == 1)
                    {
                        SqlCommand capnhat = new SqlCommand("UPDATE THUOC SET SOLUONGCB=SOLUONGCB+" + soluongmua + ", SOLUONGBAN=(SOLUONGCB+" + soluongmua + ")/GIATRIQUYDOI   WHERE MATHUOC='" + ma + "'", cnn);
                        capnhat.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public int sLTon(string mathuoc, int trangthai)
        {
            da = new SqlDataAdapter("select * from THUOC WHERE MATHUOC='" + mathuoc + "'", cnn);
            da.Fill(ds, "SLTon");
            int slton = 0;
            if (trangthai == 1)
            {
                foreach(DataRow dr in ds.Tables["SLTon"].Rows)
                {
                    slton = int.Parse(dr["SOLUONGCB"].ToString());
                }
            }
            if (trangthai == 2)
            {
                foreach (DataRow dr in ds.Tables["SLTon"].Rows)
                {
                    slton = int.Parse(dr["SOLUONGBAN"].ToString());
                }
            }
            return slton;
        }

        public double giaBan(string mathuoc)
        {
            da = new SqlDataAdapter("select * from THUOC WHERE MATHUOC='" + mathuoc + "'", cnn);
            da.Fill(ds, "GiaBan");
            double giaban = 0;
            foreach(DataRow dr in ds.Tables["GiaBan"].Rows)
            {
                giaban = double.Parse(dr["GIABAN"].ToString());
            }
            return giaban;
        }
    }
}
