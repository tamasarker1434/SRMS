<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewCourses.aspx.cs" Inherits="SRMS.UI.Courses.ViewCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>All Course Details</h2>
        <asp:Button CssClass="btn btn-primary btn-lg " ID="btnAddCourse" runat="server" Text="Add New Course" OnClick="btnAddCourse_Click" />
       
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="course_id">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlInfo" runat="server" NavigateUrl='<%# Eval("course_id", @"SetCourseDetails.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CLASS_LEVEL" HeaderText="class" />
                        <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />                        
                        <asp:BoundField DataField="teacher_name" HeaderText="Class Teacher" />                        
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlStdInfo" runat="server" NavigateUrl='<%# Eval("course_id", @"ViewStudentDetails.aspx?Id={0}") %>' Text=''>
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
