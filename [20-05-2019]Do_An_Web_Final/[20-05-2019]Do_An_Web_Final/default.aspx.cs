using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop.KhuVucGioHang;

namespace Do_An_Web_Final
{
    public partial class _default : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();
        taiKhoan tk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ss_user"] == null)
                {
                    setWaitUser();
                }
                else
                {
                    setWellComeUser();
                }
                loadDataFor_rpt_tatCaHangSanXuat();
            }
        }

        protected void setWellComeUser()
        {
            tk = (taiKhoan)Session["ss_user"];
            String fName = tk.fName;
            lb_slogant_head.Text = _tv.slogant_headWellcome+fName;
            lb_slogant_body.Text = _tv.slogant_bodyWellcome;
        }

        protected void setWaitUser()
        {
            lb_slogant_head.Text = _tv.slogant_headWait;
            lb_slogant_body.Text = _tv.slogant_bodyWait;
        }

        protected void loadDataFor_rpt_tatCaHangSanXuat()
        {
            rbt_tatCaHangSanXuat.DataSource = _tv.getListTo_dataTable("SELECT * FROM HANGSX WHERE ACTIVE = 1");
            rbt_tatCaHangSanXuat.DataBind();
        }

        protected void rbt_sanPhamMoiNhat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ACTION_ADD_TO_CART(int.Parse(e.CommandArgument.ToString()));
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
    }
}