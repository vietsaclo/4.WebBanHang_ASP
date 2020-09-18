using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;

namespace Do_An_Web_Final
{
    public partial class signUp : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ss_user"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void btn_signUp_Click(object sender, EventArgs e)
        {
            String uName = tb_userName.Text.Trim(),
                pass = tb_password.Text.Trim(),
                fName = tb_fullName.Text.Trim(),
                emailAr = tb_emailAr.Text.Trim();
            try
            {
                if (!_tv.isInsertTo_table("TAIKHOAN", "UNAME", uName))
                {
                    lb_showError.Visible = true;
                    return;
                }
                int count = _tv.insertMotTaiKhoan(uName, pass, fName, emailAr);
                if (count < 1)
                {
                    lb_showError.Visible = true;
                    return;
                }
            }
            catch
            {
                lb_showError.Visible = true;
            }
            Response.Redirect("signIn.aspx");
        }
    }
}