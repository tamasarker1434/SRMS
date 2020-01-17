<%@ Page Title="Admin Panel" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllAdminPanel.aspx.cs" Inherits="SRMS.UI.Admin.ViewAllAdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="container">
        <div class="mt-5" style="margin-top: 25px;">
            <form>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <%-- Panel Title--%>
                                <h3 class="panel-title">User Level Panel</h3>
                            </div>
                            <div class="panel-body text-center">
                                <%-- Panel content--%>
                                <div class="alert alert-dismissible alert-success" style="font-size:xx-large;">
                                    <strong>Total User Level: </strong><asp:Label ID="lblUserLvlNo" runat="server" Text=""></asp:Label>
                                </div>
                                <asp:Button CssClass="btn btn-primary btn-lg " ID="btnViewUserLevel" runat="server" Text="View All User Level" OnClick="btnViewUserLevel_Click" />
                                <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddUserLvl" runat="server" Text="Add User Level" OnClick="btnAddUserLvl_Click" />
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h3 class="panel-title">User Panel</h3>
                            </div>
                            <div class="panel-body text-center"">
                                <%--Panel content--%>
                                <div class="alert alert-dismissible alert-success" style="font-size:xx-large;">
                                    <strong>Total User: </strong><asp:Label ID="lblUserNo" runat="server" Text=""></asp:Label>
                                </div>
                                <asp:Button CssClass="btn btn-primary btn-lg " ID="btnViewUser" runat="server" Text="View All User" OnClick="btnViewUser_Click"/>
                                <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </form>
        </div>
    </div>
</asp:Content>
