<%@ Page Title="Subject Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetSubjectInfo.aspx.cs" Inherits="SRMS.UI.SubjectInfo.SetSubjectInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set User Details</h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <div class="active">
                    <h3>Subjects Info</h3>
                    <hr />
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtSubName" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgSubName" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject Code</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtSubCode" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgSubCode" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpClassLevel" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgClasssId" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Category<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                               <asp:DropDownList ID="drpCategory" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgCategory" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject Part Of<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:CheckBox ID="ckIsCombine" runat="server" OnCheckedChanged="ckIsCombine_CheckedChanged" AutoPostBack="true" />
                               <asp:DropDownList ID="drpIsCombine" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                               <asp:Label CssClass="text-danger" ID="lblReqMsgCombSub" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                <div class="active">
                    <h3>Marks Distribution<span style="color: red">*</span></h3>
                    <hr />
                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Total Marks</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="txttotalMarks" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgTotalMarks" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Creative</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtCreative" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgCreative" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">MCQ</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtMcq" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Practical</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtPractical" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
