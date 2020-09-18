using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final
{
    public partial class administrator : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ss_user"] == null)
            {
                Response.Redirect("default.aspx");
                return;
            }
            else
            {
                taiKhoan tk = (taiKhoan)Session["ss_user"];
                if (tk.phanQuyen != 2)
                {
                    Response.Redirect("default.aspx");
                    return;
                }
                else
                {
                    holder_content_Admin.Controls.Add(LoadControl("Admin/FULL_CONTROL.ascx"));
                }
            }

            if (!IsPostBack)
            {
                setThongKeSoLuong();
            }
        }

        protected void setThongKeSoLuong()
        {
            lb_showSoLuongTaiKhoan.Text = _tv.getSoLuong("SELECT COUNT(*) FROM TAIKHOAN").ToString();
            lb_showSoLuongHangSX.Text = _tv.getSoLuong("SELECT COUNT(*) FROM HANGSX").ToString();
            lb_showSoLuongSanPham.Text = _tv.getSoLuong("SELECT COUNT(*) FROM SANPHAM").ToString();
            lb_showSoLuongHoaDon.Text = _tv.getSoLuong("SELECT COUNT(*) FROM HOADON").ToString();
        }
    }
}