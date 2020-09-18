<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sanPham_control.ascx.cs" Inherits="Do_An_Web_Final.Admin.sanPham_control" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!-- style start-->
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../myStyle/myCustom.css" rel="stylesheet" />
<!-- style end-->

<!-- danh sách sản phẩm và thêm mới sản phẩm start-->
<div class="container">
    <!-- task Account start-->
    <div class="mb-5 text-uppercase text-info font-weight-bold h5">
        [
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_listSanPham" runat="server" Text="List Sản Phẩm" OnClick="link_btn_listSanPham_Click"></asp:LinkButton></span>
        |
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_addNewSanPham" runat="server" Text="Add New Sản Phẩm" OnClick="link_btn_addNewSanPham_Click"></asp:LinkButton></span>
        ]
    </div>
    <!-- task Account end-->

    <!-- mulV sản phẩm và thêm mới start-->
    <asp:MultiView ID="mulV_show_sanPham" runat="server" ActiveViewIndex ="0">
        <asp:View ID="v0" runat="server">
            <asp:Repeater ID="rpt_showSanPham" runat="server" OnItemCommand="rpt_showSanPham_ItemCommand">
                <HeaderTemplate>
                    <table class="table-hover table">
                        <thead class="text-white bg-info">
                            <th>Mã Sản Phẩm</th>
                            <th>Tên sản phẩm</th>
                            <th>Giá</th>
                            <th>Hình ảnh</th>
                            <th>Hãng sản xuất</th>
                            <th>Task</th>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <td><%#Eval("MASANPHAM") %></td>
                        <td><%#Eval("TENSANPHAM") %></td>
                        <td><%#Eval("GIA") %></td>
                        <td><img src="images_up/sanPham/<%#Eval("HINHANH") %>" style="width: 100px;height:100px;" class="card-img"/></td>
                        <td><%#Eval("TENHANGSX") %></td>
                        <td class="h6">
                            <span>
                                <asp:LinkButton ID="link_btn_update" runat="server" Text="UPDATE" CommandName="update" CommandArgument='<%#Eval("MASANPHAM") %>'></asp:LinkButton></span>
                            | 
                            <span>
                                <asp:LinkButton ID="link_btn_delete" runat="server" Text="DELETE" CommandName="delete" CommandArgument='<%#Eval("MASANPHAM") %>' OnLoad="Confirm_DELETE"></asp:LinkButton></span>
                        </td>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hiddF_task" runat="server" />
            <asp:HiddenField ID="hiddF_pkValue" runat="server" />
            <asp:HiddenField ID="hiddF_img" runat="server" />
        </asp:View>
        
        <asp:View ID="v1" runat="server">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Hãng Sản Xuất</div>
                        <div class="col-8"><asp:DropDownList ID="dropList_hangSanXuat" runat="server" CssClass="form-control"></asp:DropDownList></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Tên Sản Phẩm</div>
                        <div class="col-8"><asp:TextBox ID="tb_tenSanPham" runat="server" placeHolder="Enter Tên Sản Phẩm" CssClass="form-control"></asp:TextBox></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Giá Sản Phẩm</div>
                        <div class="col-8"><asp:TextBox ID="tb_gia" runat="server" placeHolder="Enter Giá Sản Phẩm" CssClass="form-control"></asp:TextBox></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Hình Ảnh</div>
                        <div class="col-8"><asp:FileUpload ID="fileUP_hinhAnh" runat="server" CssClass="form-control" /></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-2">Mô Tả</div>
                        <div class="col-10">
                            <FTB:FreeTextBox ID="FreeTextBox_moTa" runat="server"></FTB:FreeTextBox>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4"><asp:Button ID="btn_themSanPham" runat="server" Text="Thêm Sản Phẩm" CssClass="btn-block btn-success btn" OnClick="btn_themSanPham_Click" /></div>
                        <div><asp:Button ID="btn_huyThemSanPham" runat="server" Text="Hủy" OnClick="btn_huyThemSanPhamClicked" CssClass="btn-danger btn"  /></div>
                        <div class="col-8"><asp:Label ID="lb_showError_themSanPham" runat="server" Text="Đã bị Một lỗi nào đó chưa thể thêm bây giờ!" ForeColor="Red" Visible="false"></asp:Label></div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <!-- mulV sản phẩm và thêm mới end-->
</div>
<!-- danh sách sản phẩm và thêm mới sản phẩm end-->