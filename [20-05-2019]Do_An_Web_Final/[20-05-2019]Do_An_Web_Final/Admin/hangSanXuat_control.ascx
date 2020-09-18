<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hangSanXuat_control.ascx.cs" Inherits="Do_An_Web_Final.Admin.hangSanXuat_control" %>
<!--style start-->
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../myStyle/myCustom.css" rel="stylesheet" />
<!-- style end-->

<div class="container">
    <!-- task Account start-->
    <div class="mb-5 text-uppercase text-info font-weight-bold h5">
        [
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_listAccount" runat="server" Text="List Hãng Sản Xuất" OnClick="link_btn_listHangSanXuat_Click"></asp:LinkButton></span>
        |
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_addNewAccount" runat="server" Text="Add New Hãng Sản Xuất" OnClick="link_btn_addNewHangSanXuat_Click"></asp:LinkButton></span>
        ]
    </div>
    <!-- task Account end-->

    <!-- hiện thị hãng sản xuất và thêm hãng sản xuât start-->
    <asp:MultiView ID="mulV_hienThiHangSanXuat" runat="server" ActiveViewIndex="0">
        <asp:View ID="v0" runat="server">
            <asp:Repeater ID="rpt_hienThiHangSanxuat" runat="server" OnItemCommand="rpt_hienThiHangSanxuat_ItemCommand">
                <HeaderTemplate>
                    <table class="table-hover table">
                        <thead class="text-white bg-info">
                            <th>Mã Hãng Sản Xuất</th>
                            <th>Tên Hãng Sản Xuất</th>
                            <th>Icon Hãng</th>
                            <th>Active</th>
                            <th>Task</th>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <td><%#Eval("MAHANGSX") %></td>
                        <td><%#Eval("TENHANGSX") %></td>
                        <td><img src="images_up/hangSX/<%#Eval("icon_hangSX") %>" class="card-img" style="width: 50%" /></td>
                        <td><%#Eval("ACTIVE") %></td>
                        <td class="h6">
                            <span>
                                <asp:LinkButton ID="link_btn_update" runat="server" Text="UPDATE" CommandName="update" CommandArgument='<%#Eval("maHangSX") %>'></asp:LinkButton></span>
                            | 
                            <span>
                                <asp:LinkButton ID="link_btn_delete" runat="server" Text="DELETE" CommandName="delete" CommandArgument='<%#Eval("maHangSX") %>' OnLoad="Confirm_DELETE"></asp:LinkButton></span>
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
                <div class="col-12 col-sm-12 col-md-7 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Tên hãng sản xuất</div>
                        <div class="col-8"><asp:TextBox ID="tb_tenHangSanXuat" runat="server" CssClass="form-control" placeHolder="Enter Hãng Sản Xuất"></asp:TextBox></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-7 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Icon hãng sản xuất</div>
                        <div class="col-8"><asp:FileUpload ID="fileUp_iconHangSX" runat="server" CssClass="form-control" /></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-7 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4">Active</div>
                        <div class="col-8"><asp:CheckBox ID="cbox_active" runat="server" Text="Active" CssClass="form-check" /></div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-7 col-lg-7" >
                    <div class="p-2 border row">
                        <div class="col-4"><asp:Button ID="btn_themHangSX" runat="server" CssClass="btn-block btn-success btn" Text="Thêm hãng" OnClick="btn_themHangClicked" /></div>
                        <div><asp:Button ID="btn_huyThemSanPham" runat="server" Text="Hủy" OnClick="btn_huyThemSanPhamClicked" CssClass="btn-danger btn"  /></div>
                        <div class="col-8"><asp:Label ID="lb_showError_themHangSX" runat="server" Text="Đã bị một lỗi nào đó chưa thể thêm bây giờ!" Visible="false"></asp:Label></div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <!-- hiển thị hãng sản xuất và thêm hãng sản xuất end-->
</div>
