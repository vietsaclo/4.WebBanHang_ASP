using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;

namespace Do_An_Web_Final.Admin
{
    public partial class FULL_CONTROL : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String getTask = Request.QueryString["task"];
            switch (getTask)
            {
                case "taikhoanoption":
                    {
                        Controls.Add(LoadControl("taiKhoan_control.ascx"));
                        break;
                    }
                case "hangsanxuatoption":
                    {
                        Controls.Add(LoadControl("hangSanXuat_control.ascx"));
                        break;
                    }
                case "sanphamoption":
                    {
                        Controls.Add(LoadControl("sanPham_control.ascx"));
                        break;
                    }
                case "hoadonoption":
                    {
                        Controls.Add(LoadControl("hoaDon_control.ascx"));
                        break;
                    }
                default:
                    {
                        Controls.Add(LoadControl("taiKhoan_control.ascx"));
                        break;
                    }
            }
        }
    }
}