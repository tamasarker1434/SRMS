<%@ Page Title="View All User Level" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewAllUserLevel.aspx.cs" Inherits="SRMS.UI.Admin.ViewAllUserLevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All User Level Details</h2>
        <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddUserLvl" runat="server" Text="Add User Level" OnClick="btnAddUserLvl_Click" />
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvUserLevelDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-hover" DataKeyNames="LEVEL_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("LEVEL_ID", @"SetUserLevel.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="LEVEL_NAME" HeaderText="User Level" />
                        <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
