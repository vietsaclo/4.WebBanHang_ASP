using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;
using System.Data;
using System.Data.SqlClient;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang;

namespace Do_An_Web_Final
{
    public partial class viewAllProduct : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataFor_rpt_showSanPhamTheoQuery();
            }
        }

        protected void loadDataFor_rpt_showSanPhamTheoQuery()
        {
            String getQR = Request.QueryString["option"];
            if (String.IsNullOrEmpty(getQR))
            {
                Response.Redirect("default.aspx");
                return;
            }
            switch (getQR)
            {
                case "new_product":
                    {
                        lb_sanPhamQuery.Text = "Những Sản phẩm mới";
                        rpt_showSanPhamTheoQuery.DataSource = _tv.getListTo_dataTable("SELECT * FROM SANPHAM ORDER BY NGAYDANG DESC");
                        rpt_showSanPhamTheoQuery.DataBind();
                        break;
                    }
                case "hot_product":
                    {
                        lb_sanPhamQuery.Text = "Những Sản phẩm hot";
                        rpt_showSanPhamTheoQuery.DataSource = _tv.getListTo_dataTable("SELECT * FROM SANPHAM ORDER BY GIA DESC");
                        rpt_showSanPhamTheoQuery.DataBind();
                        break;
                    }
                case "lien_quan":
                    {
                        String getQR_lienQuan = Request.QueryString["id"];
                        if (String.IsNullOrEmpty(getQR_lienQuan))
                        {
                            Response.Redirect("default.aspx");
                            return;
                        }
                        int maHangSX = 0;
                        try
                        {
                            maHangSX = int.Parse(getQR_lienQuan);
                        }
                        catch
                        {
                            Response.Redirect("default.aspx");
                            return;
                        }
                        lb_sanPhamQuery.Text = "Những Sản phẩm liên Quan";
                        rpt_showSanPhamTheoQuery.DataSource = _tv.getListTo_dataTable("SELECT * FROM SANPHAM WHERE MAHANGSX=" + maHangSX);
                        rpt_showSanPhamTheoQuery.DataBind();
                        break;
                    }
                case "hangSX":
                    {
                        String getQR_maHangSX = Request.QueryString["id"];
                        if (String.IsNullOrEmpty(getQR_maHangSX))
                        {
                            Response.Redirect("default.aspx");
                            return;
                        }
                        int maHangSX = 0;
                        try
                        {
                            maHangSX = int.Parse(getQR_maHangSX);
                        }
                        catch
                        {
                            Response.Redirect("default.aspx");
                            return;
                        }
                        DataTable dt = _tv.getListTo_dataTable("SELECT * FROM SANPHAM S, HANGSX H WHERE S.MAHANGSX = H.MAHANGSX AND S.MAHANGSX=" + maHangSX);
                        if (dt.Rows.Count == 0) lb_sanPhamQuery.Text = "Chưa có sản phẩm này";
                        else
                            lb_sanPhamQuery.Text = "Tất cả: " + dt.Rows[0]["tenHangSX"].ToString();
                        rpt_showSanPhamTheoQuery.DataSource = dt;
                        rpt_showSanPhamTheoQuery.DataBind();
                        break;
                    }
                case "search":
                    {
                        lb_sanPhamQuery.Text = "Kết Quả của bạn";
                        String getQR_search = Request.QueryString["QR"];
                        if (String.IsNullOrEmpty(getQR_search))
                        {
                            Response.Redirect("default.aspx");
                            return;
                        }
                        rpt_showSanPhamTheoQuery.DataSource = _tv.getListTo_dataTable("SELECT * FROM SANPHAM WHERE TENSANPHAM LIKE N'%"+getQR_search+"%'");
                        rpt_showSanPhamTheoQuery.DataBind();
                        break;
                    }
            }
        }

        public void ACTION_ADD_TO_CART(int maSanPham)
        {
            if (Session["ss_user"] == null)
            {
                Response.Write("<script>alert('Để thực hiện việc mua hàng, Bạn cần đăng nhập trước !')</script>");
                return;
            }
            taiKhoan tk = (taiKhoan)Session["ss_user"];
            if (tk.phanQuyen != 0)
            {
                Response.Write("<script>alert('Bạn không phải quyền user, Bạn không thể mua hàng !')</script>");
                return;
            }

            dsMatHangKhachMua list = null;
            list = (dsMatHangKhachMua)Session["ss_gioHang"];
            if (list == null)
            {
                list = new dsMatHangKhachMua();
                matHang mh = new matHang(maSanPham);
                list.Add(mh);
            }
            else
            {
                list = (dsMatHangKhachMua)Session["ss_gioHang"];
                if (!list.isExits(maSanPham))
                {
                    matHang mh = new matHang(maSanPham);
                    list.Add(mh);
                }
            }
            Session["ss_gioHang"] = list;

            Response.Redirect("~/gioHang.aspx");
        }

        protected void rpt_showSanPhamTheoQuery_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ACTION_ADD_TO_CART(int.Parse(e.CommandArgument.ToString()));
        }
    }
}