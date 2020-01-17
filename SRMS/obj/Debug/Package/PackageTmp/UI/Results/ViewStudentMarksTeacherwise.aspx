<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewStudentMarksTeacherwise.aspx.cs" Inherits="SRMS.UI.Results.ViewStudentMarksTeacherwise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Mark Sheet History</h2>
        <asp:Button CssClass="btn btn-primary btn-lg " ID="btnMarkAdd" runat="server" Text="Add Subject Marks" OnClick="btnMarkAdd_Click" />

    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="RESULT_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("RESULT_ID", @"ClasswiseStudentMarks.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EXAM_TYPE_TEXT" HeaderText="Exam" />
                        <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />
                        <%--<asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlStdInfo" runat="server" NavigateUrl='<%# Eval("STD_ID", @"ViewStudentDetails.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/delete.png" title="Delete"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </div>
</asp:Content>
