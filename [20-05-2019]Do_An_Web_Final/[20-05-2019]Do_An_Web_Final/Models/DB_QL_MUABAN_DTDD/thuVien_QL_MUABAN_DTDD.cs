using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD
{
    public class thuVien_QL_MUABAN_DTDD
    {
        public String slogant_headWait = "bạn chưa đăng nhập";
        public String slogant_bodyWait = "hãy đăng nhập ngay để được ưu đãi những sản phẩm mới với giá rẽ";
        public String slogant_headWellcome = "Xin Chào: ";
        public String slogant_bodyWellcome = "Bạn biết gì chưa, hiện tại website đang giảm giá rất nhiều sản phẩm hãy cùng chúng tôi khám phá những sản phẩm mới này dưới đây.";

        public DataTable getListTo_dataTable(String cauLenh)
        {
            SqlCommand cmd = new SqlCommand(cauLenh);
            cmd.CommandType = CommandType.Text;

            return public_DB.getData_TO_DATATABLE(cmd);
        }

        public int insertMotTaiKhoan(String uName,String pass,String fName,String emailAr)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TAIKHOAN (UNAME,PASS,FULL_NAME,EMAIL_ADDRESS) VALUES (@_uName,@_pass,@_fName,@_emailAr)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@_uName",uName);
            cmd.Parameters.AddWithValue("@_pass",public_DB.maHoa(pass));
            cmd.Parameters.AddWithValue("@_fName",fName);
            cmd.Parameters.AddWithValue("@_emailAr",emailAr);

            return public_DB.thucThiCauLenh(cmd);
        }

        public int insertMotTaiKhoan(String uName, String pass, String fName, String emailAr, int role, bool active)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TAIKHOAN (UNAME,PASS,FULL_NAME,EMAIL_ADDRESS,PHAN_QUYEN, ACTIVE) VALUES (@_uName,@_pass,@_fName,@_emailAr,@_role,@_active)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@_uName", uName);
            cmd.Parameters.AddWithValue("@_pass", public_DB.maHoa(pass));
            cmd.Parameters.AddWithValue("@_fName", fName);
            cmd.Parameters.AddWithValue("@_emailAr", emailAr);
            cmd.Parameters.AddWithValue("@_role",role);
            cmd.Parameters.AddWithValue("@_active",active);

            return public_DB.thucThiCauLenh(cmd);
        }

        public int insertMotHangSX(hangSX hang)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO HANGSX VALUES (@_tenHangSX, @_active, @_icon_hangSX)");
            cmd.Parameters.AddWithValue("@_tenHangSX",hang.tenHangSX);
            cmd.Parameters.AddWithValue("@_active",hang.active);
            cmd.Parameters.AddWithValue("@_icon_hangSX",hang.icon_hangSX);
            cmd.CommandType = CommandType.Text;

            return public_DB.thucThiCauLenh(cmd);
        }

        public int insertMotSanPham(int maHangSX, String tenSanPham, long gia, String hinhAnh, DateTime ngayDang, String moTa)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO SANPHAM VALUES(@_maHangSX, @_tenSanPham, @_gia, @_hinhAnh, @_ngayDang, @_moTa)");
            cmd.Parameters.AddWithValue("@_maHangSX",maHangSX);
            cmd.Parameters.AddWithValue("@_tenSanPham",tenSanPham);
            cmd.Parameters.AddWithValue("@_gia",gia);
            cmd.Parameters.AddWithValue("@_hinhAnh",hinhAnh);
            cmd.Parameters.AddWithValue("@_ngayDang",ngayDang);
            cmd.Parameters.AddWithValue("@_moTa",moTa);
            cmd.CommandType = CommandType.Text;
            return public_DB.thucThiCauLenh(cmd);
        }

        public bool isInsertTo_table(String tableName,String pkName,String pkValue)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM "+tableName+" WHERE "+pkName+" =@_value");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@_value",pkValue);
            DataTable dt = public_DB.getData_TO_DATATABLE(cmd);
            return dt.Rows.Count == 0;
        }

        public bool isInsertTo_table(String tableName, String pkName, int pkValue)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tableName + " WHERE " + pkName + " =@_value");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@_value", pkValue);
            DataTable dt = public_DB.getData_TO_DATATABLE(cmd);
            return dt.Rows.Count == 0;
        }

        public int deleteBY_primaryKey(String tableName, String pkName, int pkValue)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM "+tableName+" WHERE "+pkName+" =@_pkValue");
            cmd.Parameters.AddWithValue("@_pkValue",pkValue);
            cmd.CommandType = CommandType.Text;
            return public_DB.thucThiCauLenh(cmd);
        }

        public taiKhoan getTaiKhoanTheoPrimaryKey(int pkValue)
        {
            DataTable dt = getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE MATK='"+pkValue+"'");
            if (dt.Rows.Count == 0) return null;
            int maTk = int.Parse(dt.Rows[0]["maTk"].ToString());
            String uName = dt.Rows[0]["uName"].ToString();
            String pass = dt.Rows[0]["pass"].ToString();
            String fName = dt.Rows[0]["full_name"].ToString();
            String emailAr = dt.Rows[0]["email_address"].ToString();
            int phanQuyen = int.Parse(dt.Rows[0]["phan_quyen"].ToString());
            bool active = (bool)dt.Rows[0]["active"];
            return new taiKhoan(maTk, uName, pass, fName, emailAr, phanQuyen, active);
        }

        public taiKhoan getTaiKhoanTheoUserName(String userName)
        {
            DataTable dt = getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE UNAME='"+userName+"'");
            if (dt.Rows.Count == 0) return null;
            int maTk = int.Parse(dt.Rows[0]["maTk"].ToString());
            String uName = dt.Rows[0]["uName"].ToString();
            String pass = dt.Rows[0]["pass"].ToString();
            String fName = dt.Rows[0]["full_name"].ToString();
            String emailAr = dt.Rows[0]["email_address"].ToString();
            int phanQuyen = int.Parse(dt.Rows[0]["phan_quyen"].ToString());
            bool active = (bool)dt.Rows[0]["active"];
            return new taiKhoan(maTk, uName, pass, fName, emailAr, phanQuyen, active);
        }

        public int updateMotTaiKhoan(int maTk,String uName, String pass, String fName, String emailAr, int role, bool active)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET UNAME=@_uName, PASS=@_pass, FULL_NAME=@_fName, EMAIL_ADDRESS=@_emailAr, PHAN_QUYEN=@_role, ACTIVE=@_active WHERE MATK=@_maTk");
            cmd.Parameters.AddWithValue("@_uName",uName);
            cmd.Parameters.AddWithValue("@_pass",public_DB.maHoa(pass));
            cmd.Parameters.AddWithValue("@_fName",fName);
            cmd.Parameters.AddWithValue("@_emailAr",emailAr);
            cmd.Parameters.AddWithValue("@_role",role);
            cmd.Parameters.AddWithValue("@_active",active);
            cmd.Parameters.AddWithValue("@_maTk",maTk);

            cmd.CommandType = CommandType.Text;
            return public_DB.thucThiCauLenh(cmd);
        }

        public int updateMotTaiKhoan(int maTk, String uName, String fName, String emailAr, int role, bool active)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET UNAME=@_uName, FULL_NAME=@_fName, EMAIL_ADDRESS=@_emailAr, PHAN_QUYEN=@_role, ACTIVE=@_active WHERE MATK=@_maTk");
            cmd.Parameters.AddWithValue("@_uName", uName);
            cmd.Parameters.AddWithValue("@_fName", fName);
            cmd.Parameters.AddWithValue("@_emailAr", emailAr);
            cmd.Parameters.AddWithValue("@_role", role);
            cmd.Parameters.AddWithValue("@_active", active);
            cmd.Parameters.AddWithValue("@_maTk", maTk);

            cmd.CommandType = CommandType.Text;
            return public_DB.thucThiCauLenh(cmd);
        }

        public int updateMotHangSX(hangSX hang)
        {
            SqlCommand cmd = new SqlCommand("UPDATE HANGSX SET TENHANGSX=@_tenHangSX, ACTIVE=@_active, ICON_HANGSX=@_icon_hangSX WHERE MAHANGSX=@_maHangSX");
            cmd.Parameters.AddWithValue("@_tenHangSX",hang.tenHangSX);
            cmd.Parameters.AddWithValue("@_active",hang.active);
            cmd.Parameters.AddWithValue("@_icon_hangSX",hang.icon_hangSX);
            cmd.Parameters.AddWithValue("@_maHangSX",hang.maHangSX);
            cmd.CommandType = CommandType.Text;

            return public_DB.thucThiCauLenh(cmd);
        }

        public int updateMotSanPham(int maSanPham, int maHangSX, String tenSanPham, long gia, String hinhAnh, DateTime ngayDang, String moTa)
        {
            SqlCommand cmd = new SqlCommand("UPDATE SANPHAM SET MAHANGSX=@_maHangSX, TENSANPHAM=@_tenSanPham, GIA=@_gia, HINHANH=@_hinhAnh, NGAYDANG=@_ngayDang, MOTA=@_moTa WHERE MASANPHAM=@_maSanPham");
            cmd.Parameters.AddWithValue("@_maHangSX",maHangSX);
            cmd.Parameters.AddWithValue("@_tenSanPham",tenSanPham);
            cmd.Parameters.AddWithValue("@_gia",gia);
            cmd.Parameters.AddWithValue("@_hinhAnh",hinhAnh);
            cmd.Parameters.AddWithValue("@_ngayDang",ngayDang);
            cmd.Parameters.AddWithValue("@_moTa",moTa);
            cmd.Parameters.AddWithValue("@_maSanPham",maSanPham);
            cmd.CommandType = CommandType.Text;

            return public_DB.thucThiCauLenh(cmd);
        }

        public hangSX getHangSXTheoPrimaryKey(int pkValue)
        {
            hangSX hang = null;
            DataTable dt = getListTo_dataTable("SELECT * FROM HANGSX WHERE MAHANGSX="+pkValue);
            if (dt.Rows.Count == 0) return hang;
            int maHangSX = int.Parse(dt.Rows[0][0].ToString());
            String tenHangSX = dt.Rows[0][1].ToString();
            bool active = (bool)dt.Rows[0][2];
            String icon_hangSX = dt.Rows[0][3].ToString();
            hang = new hangSX(maHangSX, tenHangSX, active, icon_hangSX);

            return hang;
        }

        public sanPham getSanPhamTheoPrimaryKey(int pkValue)
        {
            sanPham sp = null;
            DataTable dt = getListTo_dataTable("SELECT * FROM SANPHAM WHERE MASANPHAM='"+pkValue+"'");
            if (dt.Rows.Count == 0) return sp;
            int maSanPham = int.Parse(dt.Rows[0][0].ToString());
            int maHangSX = int.Parse(dt.Rows[0][1].ToString());
            String tenSanPham = dt.Rows[0][2].ToString();
            long gia = long.Parse(dt.Rows[0][3].ToString());
            String hinhAnh = dt.Rows[0][4].ToString();
            String ngayDang = dt.Rows[0][5].ToString();
            String moTa = dt.Rows[0][6].ToString();
            sp = new sanPham(maSanPham, maHangSX, tenSanPham, gia, hinhAnh, ngayDang, moTa);

            return sp;
        }

        public int getSoLuong(String cauLenh)
        {
            SqlCommand cmd = new SqlCommand(cauLenh);
            cmd.CommandType = CommandType.Text;
            return public_DB.getSoLuong(cmd);
        }
    }
}