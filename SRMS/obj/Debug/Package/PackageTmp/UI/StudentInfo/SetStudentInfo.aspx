<%@ Page Title="Set Student Info" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetStudentInfo.aspx.cs" Inherits="SRMS.UI.Class.SetStudentInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set Student Details</h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
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
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Father's Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtFName" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgFName" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Father's Contact No</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtFCont" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgFCont" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Mother's Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtMName" runat="server"></asp:TextBox>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgMName" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Mother's Contact No.</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtMCont" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Std. Contact No<span style="color: red">*</span></label>
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
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class<span style="color: red">*</span></label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpClass" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                                <asp:Label CssClass="text-danger" ID="lblReqMsgClass" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Roll<span style="color: red">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="txtRoll" runat="server"></asp:TextBox>
                            <asp:Label CssClass="text-danger" ID="lblReqMsgRoll" runat="server" Text=""></asp:Label>
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnRollGen" runat="server" Text="Generate Roll" OnClick="btnRollGen_Click" />
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
                <div class="text-center">
                    <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
