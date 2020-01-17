<%@ Page Title="Set Course Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetCourseDetails.aspx.cs" Inherits="SRMS.UI.Courses.SetCourseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set Course Details</h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5">
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpClass" class="form-control col-md-7 col-xs-12" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpClass_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgClass" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subjects<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpSubject" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgSub" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
             <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class Teacher<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpTeacher" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgTeacher" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Is Active<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpCombine" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgCombine" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="text-center">
                    <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
