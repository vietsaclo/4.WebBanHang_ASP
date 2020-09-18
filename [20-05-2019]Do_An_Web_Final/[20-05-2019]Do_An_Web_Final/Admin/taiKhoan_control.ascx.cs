using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;

namespace Do_An_Web_Final.Admin
{
    public partial class taiKhoan_control : System.Web.UI.UserControl
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();
        taiKhoan tk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataFor_rbt_showListAccount();
            }
        }

        protected void link_btn_listAccount_Click(object sender, EventArgs e)
        {
            mulV_taiKhoan.ActiveViewIndex = 0;
        }

        protected void link_btn_addNewAccount_Click(object sender, EventArgs e)
        {
            hiddF_task.Value = "insert";
            btn_xacNhanThemTaiKhoan.Text = "Thêm User";
            mulV_taiKhoan.ActiveViewIndex = 1;
        }

        protected void loadDataFor_rbt_showListAccount()
        {
            rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN");
            rpt_showListAccount.DataBind();
        }

        protected void btn_xacNhanThemTaiKhoan_Click(object sender, EventArgs e)
        {
            String task = hiddF_task.Value;
            if (task.Equals("insert"))
            {
                themMotTaiKhoan();
            }
            else
            {
                int pkValue = int.Parse(hiddF_pkValue.Value.ToString());
                capNhapMotTaiKhoan(pkValue);
            }
        }

        protected void themMotTaiKhoan()
        {
            String uName = tb_userName.Text.Trim(),
                pass = tb_password.Text.Trim(),
                fName = tb_fName.Text.Trim(),
                emailAr = tb_emailAr.Text.Trim();
            int role = int.Parse(dropList_select_roles.SelectedValue.ToString());
            bool active = cbox_active.Checked;
            if (!_tv.isInsertTo_table("taiKhoan", "uName", uName))
            {
                lb_showError_themThanhVien.Visible = true;
                return;
            }
            int n = _tv.insertMotTaiKhoan(uName, pass, fName, emailAr, role, active);
            if (n != 1)
            {
                lb_showError_themThanhVien.Visible = true;
                return;
            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void capNhapMotTaiKhoan(int pkValue)
        {
            String uName = tb_userName.Text.Trim(),
                pass = tb_password.Text.Trim(),
                fName = tb_fName.Text.Trim(),
                emailAr = tb_emailAr.Text.Trim();
            int role = int.Parse(dropList_select_roles.SelectedValue.ToString());
            bool active = cbox_active.Checked;
            taiKhoan tk = _tv.getTaiKhoanTheoPrimaryKey(pkValue);
            int n=-1;
            if (tk.pass.CompareTo(pass) == 0)
                n = _tv.updateMotTaiKhoan(pkValue, uName, fName, emailAr, role, active);
            else
                n = _tv.updateMotTaiKhoan(pkValue, uName,pass, fName, emailAr, role, active);
            if (n != 1)
            {
                lb_showError_themThanhVien.Visible = true;
                return;
            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void rpt_showListAccount_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String update_or_delete = e.CommandName.ToString();
            int pkValue = int.Parse(e.CommandArgument.ToString());
            if (update_or_delete.Equals("delete"))
            {
                _tv.deleteBY_primaryKey("TAIKHOAN", "MATK", pkValue);
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                hiddF_task.Value = "update";
                hiddF_pkValue.Value = pkValue.ToString();
                initUpdateTaiKhoan(pkValue);
            }
        }

        protected void xacNhanXoaTaiKhoan(Object sen, EventArgs ev)
        {
            ((LinkButton)sen).Attributes["onClick"] = "return confirm('Bạn có chắc muốn xóa?')";
        }

        protected void initUpdateTaiKhoan(int pkValue)
        {
            tk = _tv.getTaiKhoanTheoPrimaryKey(pkValue);
            if (tk == null) return;
            tb_userName.Text = tk.uName;
            tb_password.Text = tk.pass;
            tb_fName.Text = tk.fName;
            tb_emailAr.Text = tk.emailAr;
            dropList_select_roles.SelectedValue = tk.phanQuyen.ToString();
            cbox_active.Checked = tk.active;

            tb_userName.Enabled = false;
            btn_xacNhanThemTaiKhoan.Text = "UPDATE";
            mulV_taiKhoan.ActiveViewIndex = 1;
        }

        protected void dropList_Role_searchUserAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            mulV_taiKhoan.ActiveViewIndex = 0;
            String value1 = "", value2 = "";
            value1 = dropList_Role_searchUserAdmin.SelectedValue;
            value2 = rblist_searchUserAdmin.SelectedValue;
            if (value1.Equals("ALL"))
            {
                if (value2.Equals("ALL"))
                {
                    rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN");
                    rpt_showListAccount.DataBind();
                }
                else
                {
                    rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE ACTIVE=" + value2);
                    rpt_showListAccount.DataBind();
                }
            }
            else
            {
                if (value2.Equals("ALL"))
                {
                    rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE PHAN_QUYEN=" + value1);
                    rpt_showListAccount.DataBind();
                }
                else
                {
                    rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE PHAN_QUYEN=" + value1 + " AND ACTIVE=" + value2);
                    rpt_showListAccount.DataBind();
                }
            }
        }

        protected void btn_1_searchUserAdmin_Click(object sender, EventArgs e)
        {
            dropList_Role_searchUserAdmin_SelectedIndexChanged(null, null);
        }

        protected void btn_2_searchUserAdmin_Click(object sender, EventArgs e)
        {
            mulV_taiKhoan.ActiveViewIndex = 0;
            String roleValue = "", activeValue = "", filterSelect = "", filterValue = "";
            roleValue = dropList_Role_searchUserAdmin.SelectedValue;
            activeValue = rblist_searchUserAdmin.SelectedValue;
            filterSelect = dropList_searchUserAdmin.SelectedValue;
            filterValue = tb_searchUserAdmin.Text.Trim();
            if (filterValue.Equals("*") || String.IsNullOrEmpty(filterValue))
            {
                btn_1_searchUserAdmin_Click(null, null);
            }
            else
            {
                if (roleValue.Equals("ALL"))
                {
                    if (activeValue.Equals("ALL"))
                    {
                        rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE " + filterSelect + " LIKE N'%" + filterValue + "%'");
                        rpt_showListAccount.DataBind();
                    }
                    else
                    {
                        rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE ACTIVE=" + activeValue + " AND " + filterSelect + " LIKE N'%" + filterValue + "%'");
                        rpt_showListAccount.DataBind();
                    }
                }
                else
                {
                    if (activeValue.Equals("ALL"))
                    {
                        rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE PHAN_QUYEN=" + roleValue + " AND " + filterSelect + " LIKE N'%" + filterValue + "%'");
                        rpt_showListAccount.DataBind();
                    }
                    else
                    {
                        rpt_showListAccount.DataSource = _tv.getListTo_dataTable("SELECT * FROM TAIKHOAN WHERE PHAN_QUYEN=" + roleValue + " AND ACTIVE=" + activeValue + " AND " + filterSelect + " LIKE N'%" + filterValue + "%'");
                        rpt_showListAccount.DataBind();
                    }
                }
            }
            tb_searchUserAdmin.Text = "";
        }
    }
}