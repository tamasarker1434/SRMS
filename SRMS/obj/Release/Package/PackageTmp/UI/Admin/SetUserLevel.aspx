<%@ Page Title="Set User Level" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetUserLevel.aspx.cs" Inherits="SRMS.UI.Admin.SetUserLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set User Level Details</h2>
       <h3><asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3> 
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <div class="form-group row">
                    <label for="input" class="col-sm-2 col-form-label font-weight-bold">Level Name<span style="color: red">*</span></label>
                    <div class="col-sm-6">
                        <asp:TextBox CssClass="form-control" ID="txtUserLevelName" runat="server"></asp:TextBox>
                        <asp:Label CssClass="text-danger" ID="lblLvlNameReq" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="input" class="col-sm-2 col-form-label font-weight-bold">Remarks</label>
                    <div class="col-sm-6">
                        <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server"></asp:TextBox>
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
