using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final
{
    public partial class signIn : System.Web.UI.Page
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ss_user"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void btn_signIn_Click(object sender, EventArgs e)
        {
            String userNameGet = tb_userName.Text.Trim(),
                passwordGet = tb_password.Text.Trim();
            taiKhoan tk = _tv.getTaiKhoanTheoUserName(userNameGet);
            if (tk == null)
            {
                lb_showError.Visible = true;
                return;
            }
            String pass1 = tk.pass, pass2 = public_DB.maHoa(passwordGet);
            if (pass1.CompareTo(pass2) != 0)
            {
                lb_showError.Visible = true;
                return;
            }
            Session["ss_user"] = tk;
            Response.Redirect("default.aspx");
        }
    }
}