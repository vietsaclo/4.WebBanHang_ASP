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
    public partial class sanPham_control : System.Web.UI.UserControl
    {
        thuVien_QL_MUABAN_DTDD _tv = new thuVien_QL_MUABAN_DTDD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDataFor_rpt_showSanPham();
                loadDataFor_dropList_hangSanXuat();
            }
        }

        protected void link_btn_listSanPham_Click(Object sen, EventArgs ev)
        {
            mulV_show_sanPham.ActiveViewIndex = 0;
        }

        protected void link_btn_addNewSanPham_Click(Object sen, EventArgs ev)
        {
            hiddF_task.Value = "insert";
            btn_themSanPham.Text = "Thêm Sản Phẩm";
            mulV_show_sanPham.ActiveViewIndex = 1;
        }

        protected void loadDataFor_rpt_showSanPham()
        {
            rpt_showSanPham.DataSource = _tv.getListTo_dataTable("SELECT S.MASANPHAM, S.TENSANPHAM, S.GIA, S.HINHANH, H.TENHANGSX FROM SANPHAM S, HANGSX H WHERE S.MAHANGSX = H.MAHANGSX");
            rpt_showSanPham.DataBind();
        }

        protected void loadDataFor_dropList_hangSanXuat()
        {
            dropList_hangSanXuat.DataSource = _tv.getListTo_dataTable("SELECT * FROM HANGSX WHERE ACTIVE=1");
            dropList_hangSanXuat.DataValueField = "MAHANGSX";
            dropList_hangSanXuat.DataTextField = "TENHANGSX";
            dropList_hangSanXuat.DataBind();
        }

        protected void Confirm_DELETE(Object sen, EventArgs ev)
        {
            LinkButton link_btn_delte = ((LinkButton)sen);
            String pkValue = link_btn_delte.CommandArgument;
            link_btn_delte.Attributes["onClick"] = "return confirm('Bạn có chắc muốn xóa sản phẩm có mã [ " + pkValue + " ] Không ?')";
        }

        protected void rpt_showSanPham_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String update_OR_delete = e.CommandName.ToString();
            int pkValue = int.Parse(e.CommandArgument.ToString());
            if (update_OR_delete.Equals("delete"))
            {
                sanPham sp = _tv.getSanPhamTheoPrimaryKey(pkValue);
                if (sp == null) return;
                String imgOf_sp = sp.hinhAnh;
                if (!String.IsNullOrEmpty(imgOf_sp))
                {
                    try
                    {
                        File.Delete(Server.MapPath("images_up/sanPham/") + imgOf_sp);
                    }
                    catch
                    {

                    }
                }
                int n = _tv.deleteBY_primaryKey("sanPham", "maSanPham", pkValue);
                if (n != 1)
                {
                    Response.Write("<script>alert('Bị một Lỗi nào đó chưa xóa [ " + sp.tenSanPham + " ] được :((')</script>");
                    return;
                }
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                hiddF_task.Value = "update";
                hiddF_pkValue.Value = pkValue.ToString();
                initUpdate_sanPham(pkValue);
            }
        }

        protected void initUpdate_sanPham(int pkValue)
        {
            sanPham sp = _tv.getSanPhamTheoPrimaryKey(pkValue);
            if (sp == null) return;
            dropList_hangSanXuat.SelectedValue = sp.maHangSX.ToString();
            tb_tenSanPham.Text = sp.tenSanPham;
            tb_gia.Text = sp.gia.ToString();
            FreeTextBox_moTa.Text = sp.moTa;
            btn_themSanPham.Text = "UPDATE";
            hiddF_img.Value = sp.hinhAnh;
            tb_tenSanPham.Enabled = false;
            mulV_show_sanPham.ActiveViewIndex = 1;
        }

        protected void btn_themSanPham_Click(object sender, EventArgs e)
        {
            String task = hiddF_task.Value.ToString();
            int maHangSX = int.Parse(dropList_hangSanXuat.SelectedValue);
            String tenSanPham = tb_tenSanPham.Text.Trim();
            long gia = 0;
            try
            {
                gia = long.Parse(tb_gia.Text.Trim());
            }
            catch
            {
                Response.Write("<script>alert('Nhập giá không đúng định dạng')</script>");
                return;
            }
            String newImg = fileUP_hinhAnh.PostedFile.FileName;
            String moTa = FreeTextBox_moTa.Text.Trim();
            String folderImg = Server.MapPath("images_up/sanPham/");
            if (task.Equals("insert"))
            {
                if (String.IsNullOrEmpty(tenSanPham) || !_tv.isInsertTo_table("sanPham", "tenSanPham", tenSanPham))
                {
                    Response.Write("<script>alert('Lỗi ở tên sản phẩm Hoặc sản phẩm [ " + tenSanPham + " ] này đã có rồi !')</script>");
                    return;
                }
                if (!String.IsNullOrEmpty(newImg))
                {
                    fileUP_hinhAnh.PostedFile.SaveAs(folderImg + newImg);
                }
                int n = _tv.insertMotSanPham(maHangSX, tenSanPham, gia, newImg, DateTime.Now, moTa);
                if (n != 1)
                {
                    Response.Write("<script>alert('Bị một lỗi nào đó chưa thể thêm [ " + tenSanPham + " ] được :((')</script>");
                    return;
                }
            }
            else
            {
                int pkValue = int.Parse(hiddF_pkValue.Value);
                String oldImg = hiddF_img.Value;
                if (String.IsNullOrEmpty(oldImg))
                {
                    if (String.IsNullOrEmpty(newImg))
                    {
                        newImg = oldImg;
                    }
                    else
                    {
                        fileUP_hinhAnh.PostedFile.SaveAs(folderImg + newImg);
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(newImg))
                    {
                        newImg = oldImg;
                    }
                    else
                    {
                        try
                        {
                            File.Delete(folderImg + oldImg);
                            fileUP_hinhAnh.PostedFile.SaveAs(folderImg + newImg);
                        }
                        catch
                        {

                        }
                    }
                }
                int n = _tv.updateMotSanPham(pkValue, maHangSX, tenSanPham, gia, newImg, DateTime.Now, moTa);
                if (n != 1)
                {
                    Response.Write("<script>alert('Bị Một lỗi nào đó chưa thể cập nhật sản phẩm [ " + tenSanPham + " ] được :((')</script>");
                    return;
                }
            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void btn_huyThemSanPhamClicked(Object sen, EventArgs ev)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}