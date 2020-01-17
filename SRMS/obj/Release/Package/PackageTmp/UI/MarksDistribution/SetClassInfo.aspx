<%@ Page Title="Set Class Info" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetClassInfo.aspx.cs" Inherits="SRMS.UI.Class.SetClassInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Set Class Details</h2>
    </div>
    <div class="container">
        <div class="mt-5">
            <form>
                <div class="form-group row">
                    <label for="input" class="col-sm-2 col-form-label font-weight-bold">Class Level:</label>
                    <div class="col-sm-6">
                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtClassLevel" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="input" class="col-sm-2 col-form-label font-weight-bold">Remarks:</label>
                    <div class="col-sm-6">
                        <asp:TextBox CssClass="form-control" ID="txtRemarks" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="text-left">
                    <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                    
                    <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" />
                </div>

            </form>
        </div>
    </div>
</asp:Content>
