using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using System.Data;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final
{
    public partial class homeSite : System.Web.UI.MasterPage
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();
        taiKhoan tk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isGioHang();
                if (Session["ss_user"] == null)
                {
                    setWaitUser();
                }
                else
                {
                    setWelComeUser();
                }
            }
        }

        protected void isGioHang()
        {
            if (Session["ss_gioHang"] == null)
            {
                icon_gioHang.Visible = false;
            }
            else
            {
                icon_gioHang.Visible = true;
            }
        }

        protected void setWelComeUser()
        {
            tk = (taiKhoan)Session["ss_user"];
            if (tk.phanQuyen == 2)
            {
                lb_showAdminName.Text = tk.uName;
                role_dropDownOf_admin.Visible = true;
                role_dropDownOf_user.Visible = false;
                btn_signIn.Visible = false;
                btn_signUp.Visible = false;
            }
            else
            {
                lb_showUserName.Text = tk.uName;
                role_dropDownOf_user.Visible = true;
                role_dropDownOf_admin.Visible = false;
                btn_signIn.Visible = false;
                btn_signUp.Visible = false;
            }
        }

        protected void setWaitUser()
        {
            role_dropDownOf_user.Visible = false;
            role_dropDownOf_admin.Visible = false;
            btn_signIn.Visible = true;
            btn_signUp.Visible = true;
        }

        protected void btn_dangXuat_admin_clicked(Object sen, EventArgs ev)
        {
            Session["ss_user"] = null;
            Response.Redirect("default.aspx");
        }

        protected void btn_dangXuat_user_clicked(Object sen, EventArgs ev)
        {
            Session["ss_user"] = null;
            Session["ss_gioHang"] = null;
            Response.Redirect("default.aspx");
        }

        protected void btn_searchClicked(Object sen, EventArgs ev)
        {
            String QR = tb_search.Text.Trim();
            Response.Redirect("viewAllProduct.aspx?option=search&QR="+QR);
        }
    }
}