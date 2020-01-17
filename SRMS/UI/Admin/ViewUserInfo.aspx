<%@ Page Title="View User Info" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUserInfo.aspx.cs" Inherits="SRMS.UI.Admin.ViewUserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron" style="color: aqua">
        <h2>All User Details</h2>
         <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvUserDetails" runat="server" AutoGenerateColumns="False" class="table" DataKeyNames="USER_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlUserInfo" runat="server" NavigateUrl='<%# Eval("USER_ID", @"SetUserInfo.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FULL_NAME" HeaderText="User Name" />
                        <asp:BoundField DataField="LEVEL_NAME" HeaderText="User Level " />
                        <asp:BoundField DataField="USERNAME" HeaderText="User Id" />
                        <asp:BoundField DataField="MOBILE" HeaderText="Mobile" />
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
