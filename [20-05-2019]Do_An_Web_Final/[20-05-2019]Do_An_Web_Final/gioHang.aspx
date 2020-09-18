<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="gioHang.aspx.cs" Inherits="Do_An_Web_Final.gioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <div class="container">
        <div class="center_page mb-4 card col-md-6 row" style="margin-top: 60px;">
            <div class="bg-secondary p-2 card row">
                <p class="text-left"><a href="default.aspx" class="btn btn-outline-light" role="button">Mua tiếp sản phẩm</a></p>
                <p class="text-right"><span class="text-light font-weight-bolder h3" >Giỏ Hàng Của Bạn</span></p>
            </div>
            <asp:Repeater ID="rbt_show_gioHang" runat="server" OnItemCommand="rbt_show_gioHang_ItemCommand">
                <ItemTemplate>
                    <div class="text-center pb-1 card-header col-md-12">
                        <img src='images_up/sanPham/<%#Eval("hinhAnh") %>' class="card-img" style="width: 100px;height:100px;"/>
                        <p class="text-danger h5">Tên Sản Phẩm: <%#Eval("tenSanPham") %></p>
                        <p class="text-danger h5">Giá: <%#string.Format("{0:N0}",Eval("gia")) %></p>
                        <p class="text-right"><asp:LinkButton ID="link_btn_xoaMotSanPham" runat="server" Text="Xóa Sản Phẩm Này" CssClass="btn-link" CommandName="xoaMotSanPham" CommandArgument='<%#Eval("maSanPham") %>' OnLoad="delete_confirm_clicked"></asp:LinkButton></p>
                    </div>
                    <div class="cod-md-12">
                        <div class="list-group-item">
                            <asp:Button ID="btn_giamSoLuongSanPham" runat="server" Text="-" CssClass="btn_tangSoLuong" CommandName="giamSoLuongSanPham" CommandArgument='<%#Eval("maSanPham") %>'/>
                            <asp:TextBox ID="tb_show_soLuongSanPham" runat="server" CssClass="tb_showSoLuong" Enabled="false" Text='<%#Eval("soLuong") %>'></asp:TextBox>
                            <asp:Button ID="btn_tangSoLuongSanPham" runat="server" Text="+" CssClass="btn_tangSoLuong" CommandName="tangSoLuongSanPham" CommandArgument='<%#Eval("maSanPham") %>' />
                            <label class="text-left text-black-50">chọn số lượng mong muốn bạn đặt</label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="mt-5 card-footer">
                <div class="text-capitalize mb-4 p-3 card">
                    <p class="text-info h4" >tổng tiền thanh toán: <asp:Label ID="lb_showTongTienThanhToan" runat="server" CssClass="text-danger"></asp:Label></p>
                </div>
                <div class="mb-4">
                    <asp:RadioButtonList ID="rdbList_anhOrChi" runat="server" RepeatColumns="2" CssClass="form-control">
                        <asp:ListItem Value="0">Anh</asp:ListItem>
                        <asp:ListItem Value="1">Chị</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="mb-4 row">
                    <div class="col-6 col-sm-6 col-md-6 col-lg-6" >
                        <asp:TextBox ID="tb_SDT" runat="server" CssClass="form-control" placeHolder="Mời nhập SDT(bắt Buộc)"></asp:TextBox>
                    </div>
                    <div class="col-6 col-sm-6 col-md-6 col-lg-6" >
                        <asp:TextBox ID="tb_email" runat="server" CssClass="form-control" placeHolder="Mời nhập Email(không bắt Buộc)"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-4">
                    <asp:TextBox ID="tb_diaChi" runat="server" CssClass="form-control" placeHolder="Mời nhập Địa Chỉ(bắt Buộc)"></asp:TextBox>
                </div>
                <div class="mb-4 row">
                    <div class="col-md-6">
                        <asp:Button ID="btn_xacNhapMua" runat="server" Text="Thanh Toán Ngay" CssClass="btn btn-block btn-success" />
                    </div>
                    <div class="text-right col-md-6">
                        <asp:LinkButton ID="link_btn_resetGioHang" runat="server" Text="Xóa Tất Cả giỏ hàng" CssClass="card-link" OnLoad="delete_confirm_clicked" OnClick="link_btn_xoaTatCaSanPham_clicked" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
