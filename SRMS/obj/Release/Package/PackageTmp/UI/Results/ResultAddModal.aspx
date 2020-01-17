<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultAddModal.aspx.cs" Inherits="SRMS.UI.Results.ResultAddModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Result</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <button type="reset" class="btn btn-default">Cancel</button>
                    <asp:Button CssClass="btn btn-primary" ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
