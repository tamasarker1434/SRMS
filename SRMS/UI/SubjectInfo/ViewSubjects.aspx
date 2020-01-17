<%@ Page Title="Subject Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSubjects.aspx.cs" Inherits="SRMS.UI.SubjectInfo.ViewSubjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All Subject Details</h2>
         <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddUserLvl" runat="server" Text="Add Subject" OnClick="btnAddUserLvl_Click"/>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvSubDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="SUB_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("SUB_ID", @"SetSubjectInfo.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />
                        <asp:BoundField DataField="SUB_CODE" HeaderText="Code" />
                        <asp:BoundField DataField="COMBINE_SUB" HeaderText="Code" />
                        <asp:BoundField DataField="CLASS_LEVEL" HeaderText="Class" />
                        <asp:BoundField DataField="TOTAL_MARKS" HeaderText="Total Marks" />
                        <asp:BoundField DataField="CREATIVE_MARKS" HeaderText="Creative" />
                        <asp:BoundField DataField="MCQ_MARKS" HeaderText="MCQ" />
                        <asp:BoundField DataField="PRACTICAL_MARKS" HeaderText="Practical" />
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
