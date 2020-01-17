<%@ Page Title="Set Teacher's Details" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetTeacherInfo.aspx.cs" Inherits="SRMS.UI.TeachersInfo.SetTeacherInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set Teacher's Details</h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5">
            <div class="active">
                <h3>Personal Info</h3>
                <hr />
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Name<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Address<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgAddress" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Contact No<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:TextBox CssClass="form-control" ID="txtCont" runat="server"></asp:TextBox>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgCon" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Gender<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpGender" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgGender" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Religion<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpReligion" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgReligion" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Remarks</label>
                        <div class="col-sm-6">
                            <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
            <div class="active">
                <h3>Academic Info</h3>
                <hr />
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Designation<span style="color: red">*</span></label>
                        <asp:TextBox CssClass="form-control" ID="txtDesig" runat="server"></asp:TextBox>
                        <asp:Label CssClass="text-danger" ID="lblReqMsgDesig" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Access Level<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpUserLevel" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgUserLevel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Is Active<span style="color: red">*</span></label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpActive" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgActive" runat="server" Text=""></asp:Label>
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
