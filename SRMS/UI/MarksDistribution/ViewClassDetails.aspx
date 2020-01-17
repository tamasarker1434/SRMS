<%@ Page Title="All Class Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClassDetails.aspx.cs" Inherits="SRMS.UI.Class.ViewClassDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All Class Details</h2>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvClassDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="CLASS_ID">
                    <Columns>
                        <asp:BoundField DataField="CLASS_LEVEL" HeaderText="Class Level" />
                        <asp:BoundField DataField="REMARKS" HeaderText="Remarkss" />
                        <asp:TemplateField HeaderText="Go to Result Page">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("CLASS_ID", @"~/UI/Results/ViewStudentMarksTeacherwise.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/go.png" title="Go"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
