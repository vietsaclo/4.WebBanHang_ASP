using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Do_An_Web_Final.Models;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD;
using Do_An_Web_Final.Models.DB_QL_MUABAN_DTDD.cacLop;
using System.IO;

namespace Do_An_Web_Final.Admin
{
    public partial class hangSanXuat_control : System.Web.UI.UserControl
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataFor_rpt_showHangSanXuat();
            }
        }

        protected void link_btn_listHangSanXuat_Click(Object sen, EventArgs ev)
        {
            mulV_hienThiHangSanXuat.ActiveViewIndex = 0;
        }

        protected void link_btn_addNewHangSanXuat_Click(Object sen, EventArgs ev)
        {
            hiddF_task.Value = "insert";
            mulV_hienThiHangSanXuat.ActiveViewIndex = 1;
        }

        protected void loadDataFor_rpt_showHangSanXuat()
        {
            rpt_hienThiHangSanxuat.DataSource = _tv.getListTo_dataTable("SELECT * FROM HANGSX");
            rpt_hienThiHangSanxuat.DataBind();
        }

        protected void btn_themHangClicked(object sen, EventArgs ev)
        {
            String task = hiddF_task.Value;
            String getHangFromTbox = tb_tenHangSanXuat.Text.Trim();
            String getImgFromTBox = fileUp_iconHangSX.PostedFile.FileName;
            bool getActiveFromCBox = cbox_active.Checked;
            String folderIMG_hangSX = Server.MapPath("~/images_up/hangSX/");
            if (String.IsNullOrEmpty(getHangFromTbox))
            {
                Response.Write("<script>alert('Tên Hãng Sản Xuất không được để trống !')</script>");
                return;
            }
            if (task.Equals("insert"))
            {
                if (!_tv.isInsertTo_table("hangSX", "tenHangSX", getHangFromTbox))
                {
                    Response.Write("<script>alert('Hãng Sản Xuất [ " + getHangFromTbox + " ] đã tồn tại !')</script>");
                    return;
                }
                if (!String.IsNullOrEmpty(getImgFromTBox))
                {
                    fileUp_iconHangSX.PostedFile.SaveAs(folderIMG_hangSX + getImgFromTBox);
                }
                int n = _tv.insertMotHangSX(new hangSX(0, getHangFromTbox, getActiveFromCBox, getImgFromTBox));
                if (n != 1)
                {
                    lb_showError_themHangSX.Visible = true;
                    return;
                }
            }
            else
            {
                int pkValue = int.Parse(hiddF_pkValue.Value);
                String imgOld = hiddF_img.Value;
                if (String.IsNullOrEmpty(imgOld))
                {
                    if (String.IsNullOrEmpty(getImgFromTBox))
                    {
                        getImgFromTBox = "";
                    }
                    else
                    {
                        fileUp_iconHangSX.PostedFile.SaveAs(folderIMG_hangSX+getImgFromTBox);
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(getImgFromTBox))
                    {
                        getImgFromTBox = imgOld;
                    }
                    else
                    {
                        try
                        {
                            File.Delete(folderIMG_hangSX + imgOld);
                            fileUp_iconHangSX.PostedFile.SaveAs(folderIMG_hangSX+getImgFromTBox);
                        }
                        catch
                        {

                        }
                    }
                }
                int n = _tv.updateMotHangSX(new hangSX(pkValue, getHangFromTbox, getActiveFromCBox, getImgFromTBox));
                if (n != 1)
                {
                    lb_showError_themHangSX.Visible = true;
                    return;
                }
            }

            Response.Redirect(Request.Url.ToString());
        }

        protected void rpt_hienThiHangSanxuat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String update_OR_delete = e.CommandName.ToString();
            int pkValue = int.Parse(e.CommandArgument.ToString());
            if (update_OR_delete.Equals("delete"))
            {
                hangSX hang = _tv.getHangSXTheoPrimaryKey(pkValue);
                if (!String.IsNullOrEmpty(hang.icon_hangSX))
                {
                    try
                    {
                        File.Delete(Server.MapPath("images_up/hangSX/")+hang.icon_hangSX);
                    }
                    catch
                    {

                    }
                }
                int n = _tv.deleteBY_primaryKey("HANGSX", "MAHANGSX", pkValue);
                if (n != 1)
                {
                    Response.Write("<script>alert('Bị một lỗi nào đó chưa xóa được [ "+hang.tenHangSX+" ] :((')</script>");
                    return;
                }
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                hiddF_task.Value = "update";
                hiddF_pkValue.Value = pkValue.ToString();
                initUpdateHangSX(pkValue);
            }
        }

        protected void Confirm_DELETE(object sen, EventArgs ev)
        {
            LinkButton link_btn_delete = ((LinkButton)sen);
            String pkValue = link_btn_delete.CommandArgument.ToString();
            link_btn_delete.Attributes["onClick"] = "return confirm('Bạn Chắc muốn Xóa hãng có mã [ " + pkValue + " ] Chứ?')";
        }

        protected void initUpdateHangSX(int pkValue)
        {
            hangSX hang = _tv.getHangSXTheoPrimaryKey(pkValue);
            if (hang == null) return;
            tb_tenHangSanXuat.Text = hang.tenHangSX;
            hiddF_img.Value = hang.icon_hangSX;
            cbox_active.Checked = hang.active;
            btn_themHangSX.Text = "UPDATE";
            mulV_hienThiHangSanXuat.ActiveViewIndex = 1;
        }

        protected void btn_huyThemSanPhamClicked(Object sen, EventArgs ev)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}