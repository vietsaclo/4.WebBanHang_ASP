<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="taiKhoan_control.ascx.cs" Inherits="Do_An_Web_Final.Admin.taiKhoan_control" %>

<!-- style start-->
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../myStyle/myCustom.css" rel="stylesheet" />
<!-- style end-->

<div class="container">
    <!-- task start-->
    <div class="mb-5 row">
        <div class="text-uppercase text-info font-weight-bold h5 col-12 col-sm-12 col-md-9 col-lg-6">
            [
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_listAccount" runat="server" Text="List Account" OnClick="link_btn_listAccount_Click"></asp:LinkButton></span>
            |
    <span>
        <asp:LinkButton CssClass="text-danger" ID="link_btn_addNewAccount" runat="server" Text="Add New Account" OnClick="link_btn_addNewAccount_Click"></asp:LinkButton></span>
            ]
        </div>
        <div class="bg-light border p-3 col-12 col-sm-12 col-md-9 col-lg-6">
            <div class="row">
                <div class="col-4">
                    <asp:DropDownList ID="dropList_Role_searchUserAdmin" runat="server" CssClass="form-control" OnSelectedIndexChanged="dropList_Role_searchUserAdmin_SelectedIndexChanged">
                        <asp:ListItem>ALL</asp:ListItem>
                        <asp:ListItem Value="0">User Normal</asp:ListItem>
                        <asp:ListItem Value="1">Poster</asp:ListItem>
                        <asp:ListItem Value="2">Admin</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-5">
                    <asp:RadioButtonList ID="rblist_searchUserAdmin" runat="server" RepeatColumns="3" CellPadding="20" CssClass="form-check-inline">
                        <asp:ListItem Value="ALL" Selected="True">ALL</asp:ListItem>
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Ban</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-3">
                    <asp:Button ID="btn_1_searchUserAdmin" runat="server" Text=" EXPRESS  " CssClass="btn-outline-success btn" OnClick="btn_1_searchUserAdmin_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-4">
                    <asp:DropDownList ID="dropList_searchUserAdmin" runat="server" CssClass="form-control">
                        <asp:ListItem Value="UNAME">User Name</asp:ListItem>
                        <asp:ListItem Value="FULL_NAME">Full Name</asp:ListItem>
                        <asp:ListItem Value="EMAIL_ADDRESS">Email Address</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-5">
                    <asp:TextBox ID="tb_searchUserAdmin" runat="server" placeHolder="Enter To Search" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-3">
                    <asp:Button ID="btn_2_searchUserAdmin" runat="server" CssClass="btn-outline-success btn" Text="GO FILTER" OnClick="btn_2_searchUserAdmin_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- task end-->

    <!-- multy view start-->
    <asp:MultiView ID="mulV_taiKhoan" runat="server" ActiveViewIndex="0">
        <asp:View ID="v0" runat="server">
            <asp:Repeater ID="rpt_showListAccount" runat="server" OnItemCommand="rpt_showListAccount_ItemCommand">
                <HeaderTemplate>
                    <table class="table-hover table">
                        <thead class="text-white bg-info">
                            <th>Mã Tài khoản</th>
                            <th>User Name</th>
                            <th>Full Name</th>
                            <th>Email Address</th>
                            <th>Roles</th>
                            <th>Active</th>
                            <th>Task</th>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <td><%#Eval("MATK") %></td>
                        <td><%#Eval("UNAME") %></td>
                        <td><%#Eval("FULL_NAME") %></td>
                        <td><%#Eval("EMAIL_ADDRESS") %></td>
                        <td><%#Eval("PHAN_QUYEN") %></td>
                        <td><%#Eval("ACTIVE") %></td>
                        <td class="h6">
                            <span>
                                <asp:LinkButton ID="link_btn_update" runat="server" Text="UPDATE" CommandName="update" CommandArgument='<%#Eval("MATK") %>'></asp:LinkButton></span>
                            | 
                            <span>
                                <asp:LinkButton ID="link_btn_delete" runat="server" Text="DELETE" CommandName="delete" CommandArgument='<%#Eval("MATK") %>' OnLoad="xacNhanXoaTaiKhoan"></asp:LinkButton></span>
                        </td>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hiddF_pkValue" runat="server" />
            <asp:HiddenField ID="hiddF_task" runat="server" />
        </asp:View>

        <asp:View ID="v1" runat="server">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Enter User Name</div>
                        <div class="col-8">
                            <asp:TextBox ID="tb_userName" runat="server" placeHolder="Enter User Name" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_tb_userName" runat="server" ControlToValidate="tb_userName" Display="Dynamic" ForeColor="Red"># User Name khác rỗng</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Enter Password</div>
                        <div class="col-8">
                            <asp:TextBox ID="tb_password" runat="server" placeHolder="Enter Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_password" runat="server" ControlToValidate="tb_password" Display="Dynamic" ForeColor="Red">#Password khác rỗng</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Enter Full Name</div>
                        <div class="col-8">
                            <asp:TextBox ID="tb_fName" runat="server" placeHolder="Enter full Name" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_fName" runat="server" ControlToValidate="tb_fName" Display="Dynamic" ForeColor="Red"># Full Name khác rỗng</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Enter Email Address</div>
                        <div class="col-8">
                            <asp:TextBox ID="tb_emailAr" runat="server" placeHolder="Enter Email Address" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_emailAr" runat="server" ControlToValidate="tb_emailAr" Display="Dynamic" ForeColor="Red"># Email Address khác rỗng</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Select Roles</div>
                        <div class="col-8">
                            <asp:DropDownList ID="dropList_select_roles" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">User Normal</asp:ListItem>
                                <asp:ListItem Value="1">Poster</asp:ListItem>
                                <asp:ListItem Value="2">Admin</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">Choose Active</div>
                        <div class="col-8">
                            <asp:CheckBox ID="cbox_active" runat="server" Text="Active" CssClass="form-check" />
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-12 col-md-8 col-lg-6">
                    <div class="p-1 border row">
                        <div class="col-4">
                            <asp:Button ID="btn_xacNhanThemTaiKhoan" runat="server" Text="Thêm User" CssClass="btn-success btn" OnClick="btn_xacNhanThemTaiKhoan_Click" />
                        </div>
                        <div class="col-8">
                            <a href="administrator.aspx" role="button" class="mr-3 btn-danger btn">Hủy</a>
                            <asp:Label ID="lb_showError_themThanhVien" runat="server" Text="Đã bị một lỗi nào đó, Hoặc Trùng User Name chưa thể thêm bây giờ :((" ForeColor="Red" Visible="False"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <!-- multy view end-->
</div>
