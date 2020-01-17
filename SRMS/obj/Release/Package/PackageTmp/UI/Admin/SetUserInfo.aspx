<%@ Page Title="Set User Info" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetUserInfo.aspx.cs" Inherits="SRMS.UI.Admin.SetUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set User Details</h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Employee:</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpEmployee" class="form-control col-md-7 col-xs-12" runat="server" OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Is Active:</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpActive" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                                <asp:Label CssClass="text-danger" ID="lblLvlActive" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Full Name<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblLvlNameReq" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">User Level<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpUserLevel" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgUserLvl" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">User Id<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgUserId" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Password<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" TextMode="password" ID="txtPassword" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgPassword" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Mobile<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtMobile" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgMobile" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Email:</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group row text-center">
                        <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
