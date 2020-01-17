<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewStudentDetails.aspx.cs" Inherits="SRMS.UI.SubjectInfo.ViewStudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="mt-5">
            <form>
                <div class="active" style="margin-top:50px">
                    <h3>Personal Info</h3>
                    <hr />
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Address</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtAddress" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Father's Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtFName" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Father's Contact No</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtFCont" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Mother's Name</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtMName" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Mother's Contact No.</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtMCont" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Std. Contact No</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtCont" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Gender</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpGender" class="form-control col-md-7 col-xs-12" ReadOnly="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Religion</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpReligion" class="form-control col-md-7 col-xs-12" ReadOnly="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Remarks</label>
                            <div class="col-sm-6">
                                <asp:TextBox CssClass="form-control" ID="txtRemarks" ReadOnly="true" runat="server"></asp:TextBox>

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
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpClass" class="form-control col-md-7 col-xs-12" ReadOnly="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Roll</label>
                            <asp:TextBox CssClass="form-control" ID="txtRoll" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Is Active</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpActive" class="form-control col-md-7 col-xs-12" ReadOnly="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button CssClass="btn btn-success" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
