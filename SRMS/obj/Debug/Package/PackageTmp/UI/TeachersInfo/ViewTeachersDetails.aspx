<%@ Page Title="Teacher's Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTeachersDetails.aspx.cs" Inherits="SRMS.UI.TeachersInfo.ViewTeachersDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All Teacher's Info</h2>
        <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddTeacher" runat="server" Text="Add New Teacher" OnClick="btnAddTeacher_Click" />
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="teacher_id">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("teacher_id", @"SetTeacherInfo.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="teacher_name" HeaderText="Name" />
                        <asp:BoundField DataField="designation" HeaderText="Designation" />
                        <asp:BoundField DataField="LEVEL_NAME" HeaderText="Access Level" />
                        <asp:BoundField DataField="address" HeaderText="Address" />
                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" />
                        <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlStdInfo" runat="server" NavigateUrl='<%# Eval("teacher_id", @"ViewStudentDetails.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/delete.png" title="Delete"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
