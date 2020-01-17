<%@ Page Title="Student Result" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="StudentResultById.aspx.cs" Inherits="SRMS.UI.Results.StudentResultById" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="mt-5" style="margin: 50px">
            <form>
                <div class="panel panel-default">
                    <div class="panel-body text-warning">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <asp:Label ID="Label13" runat="server" Text="Class :"></asp:Label>
                                <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label3" runat="server" Text="Name :"></asp:Label>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label5" runat="server" Text="Roll :"></asp:Label>
                                <asp:Label ID="lblRoll" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-3">

                                <asp:Button ID="btnFail" CssClass="btn btn-danger " runat="server" Text="Fail" OnClick="btnFail_Click" />
                                <asp:Button ID="btnPass" CssClass="btn btn-success " runat="server" Text="Pass" OnClick="btnPass_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Add Grid View--%>
                <asp:GridView ID="gvStdDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="STD_ID">
                    <Columns>
                        <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />
                        <asp:BoundField DataField="TOTAL_MARKS" HeaderText="Total" />
                        <asp:BoundField DataField="CREATIVE" HeaderText="Creative" />
                        <asp:BoundField DataField="MCQ" HeaderText="MCQ" />
                        <asp:BoundField DataField="PRACTICAL" HeaderText="Practical" />
                        <asp:BoundField DataField="TOTAL_MARKS_OBT" HeaderText="Total Marks Obt." />
                        <asp:BoundField DataField="STD_GRADE" HeaderText="Grade" />
                        <asp:BoundField DataField="STD_CGPA" HeaderText="CGPA" />
                    </Columns>
                </asp:GridView>
                <div class="col-md-12">
                    <div class="text-right">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="text-center">
                        <asp:Button ID="btnPrev" runat="server" CssClass="btn btn-default" Text="Previous" OnClick="btnPrev_Click" />
                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
