<%@ Page Title="Student Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStudentInfo.aspx.cs" Inherits="SRMS.UI.Class.ViewStudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All Student Details</h2>
        <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />
        
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvStdDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="STD_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("STD_ID", @"SetStudentInfo.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="STD_NAME" HeaderText="Name" />
                        <asp:BoundField DataField="CLASS_LEVEL" HeaderText="Class Level" />
                        <asp:BoundField DataField="STD_ROLL" HeaderText="Roll No" />
                        <asp:BoundField DataField="STD_ADDRESS" HeaderText="Address" />
                        <asp:BoundField DataField="STD_CONTACT" HeaderText="Contact No" />
                        <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlStdInfo" runat="server" NavigateUrl='<%# Eval("STD_ID", @"ViewStudentDetails.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/more-details.png" title="Details"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
