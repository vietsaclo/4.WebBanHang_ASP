<%@ Page Title="" Language="C#" MasterPageFile="~/homeSite.Master" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="Do_An_Web_Final.signUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="placeHoder_homeSite" runat="server">
    <div class="jumbotron">
        <div class="p-3 bg-light form_signIn">
            <img src="images_up/logoWeb/logoWeb.png" style="width: 200px; height: 150px;" />
            <h4 class="mb-4 text-danger text-uppercase">chào mừng thành viên mới</h4>

            <div>
                <div class="text-info h4 text-left">User Name</div>
                <div>
                    <asp:TextBox ToolTip="Làm ơn nhập user name để đăng ký" ID="tb_userName" runat="server" placeHolder="Nhập user name" CssClass="mb-3 form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_userName" runat="server" ControlToValidate="tb_userName" Display="Dynamic" ForeColor="Red">#userName khác rỗng </asp:RequiredFieldValidator>
                </div>
            </div>

            <div>
                <div class="text-info h4 text-left">Password</div>
                <div>
                    <asp:TextBox ToolTip="Làm ơn nhập password mới để đăng ký" ID="tb_password" runat="server" placeHolder="Nhập password" CssClass="mb-3 form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_password" runat="server" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red">#password khác rỗng </asp:RequiredFieldValidator>
                </div>
            </div>

            <div>
                <div class="text-info h4 text-left">Retype Password</div>
                <div>
                    <asp:TextBox ToolTip="Làm ơn nhập lại password" ID="tb_nhapLaiPassword" runat="server" placeHolder="Nhập password" CssClass="mb-3 form-control" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator_password" runat="server" ControlToCompare="tb_password" ControlToValidate="tb_nhapLaiPassword" Display="Dynamic" ForeColor="Red">Nhập Khẩu không khớp.</asp:CompareValidator>
                </div>
            </div>

            <div>
                <div class="text-info h4 text-left">Full Name</div>
                <div>
                    <asp:TextBox ToolTip="Làm ơn nhập full name" ID="tb_fullName" runat="server" placeHolder="Nhập full name" CssClass="mb-3 form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_fullName" runat="server" ControlToValidate="tb_fullName" Display="Dynamic" ForeColor="Red">#fullName khác rỗng </asp:RequiredFieldValidator>
                </div>
            </div>

            <div>
                <div class="text-info h4 text-left">Email Address</div>
                <div>
                    <asp:TextBox ToolTip="Làm ơn nhập địa chỉ email của bạn" ID="tb_emailAr" runat="server" placeHolder="Nhập email Address" CssClass="mb-3 form-control" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div>
                <asp:Button ID="btn_signUp" runat="server" Text="Sign Up" CssClass="btn-danger btn" OnClick="btn_signUp_Click" />
                <br /><asp:Label ID="lb_showError" runat="server" Text="User Name này đã tồn tại hoặc Đã bị một lỗi nào đó chưa thể Đăng ký được" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>