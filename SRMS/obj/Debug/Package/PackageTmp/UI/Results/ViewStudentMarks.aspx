<%@ Page Title="Student Result" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStudentMarks.aspx.cs" Inherits="SRMS.UI.Results.StudentResultView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=50);
            opacity: 0.8;
        }

        .Popup {
            background-color: black;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: auto;
            height: auto;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
        /* Thick red border */
        hr.greenRoundBorder {
            border: 10px solid green;
            border-radius: 5px;
        }
    </style>
    <div class="jumbotron" style="color: aqua">
        <h2>Result Dashboard</h2>
        <%--  <div class="col-md-12">
            <div class="col-md-3">
                <asp:Label ID="lblClass" runat="server" Text="Class:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblRoll" runat="server" Text="Roll:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:Button CssClass="btn btn-primary" ID="btnAddResult" runat="server" Text="Add Result" OnClick="btnAddResult_Click" />
            </div>
        </div>--%>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <form class="form-horizontal">
        <fieldset>
            <legend>Action Filters</legend>
            <div class="col-md-12" style="border-bottom: 10px">
                <div class="col-md-3">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpClass" class="form-control col-md-7 col-xs-12" runat="server" OnSelectedIndexChanged="drpClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Exam Type</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpExamType" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group row">
                        <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpSubject" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-2 text-right">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
        </fieldset>
    </form>

    <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Unpublished Results</h3>
        </div>
        <div class="panel-body text-center">
            <div class="container">
            </div>
            <%-- Grid View--%>
            <asp:GridView ID="gvAllResult" runat="server" AutoGenerateColumns="False" OnRowCommand="myGridView_RowCommand" class="table table-striped table-bordered text-center" DataKeyNames="RESULT_ID,SUB_ID">
                <Columns>
                    <asp:BoundField DataField="EXAM_TYPE_TEXT" HeaderText="Exam Type" />
                    <asp:BoundField DataField="CLASS_LEVEL" HeaderText="Class" />
                    <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />
                    <asp:TemplateField HeaderText="Publish">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlStdInfo" runat="server" Text=''>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Resources/publish.png" Width="25px" Height="25px" CommandArgument='<%# Eval("RESULT_ID") %>' />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <%-- <div class="panel-body">
            <ajaxTool:modalpopupextender id="mp1" runat="server" popupcontrolid="Panl1" targetcontrolid="btnAddResult"
                cancelcontrolid="btnClose" backgroundcssclass="Background">
            </ajaxTool:modalpopupextender>
            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe style="width: 900px; height: 600px;" id="irm1" src="~/UI/Results/ResultAddModal" runat="server"></iframe>
                <br />
                <asp:Button CssClass="btn btn-default text-right" ID="btnClose" runat="server" Text="Close" />

            </asp:Panel>
        </div>--%>
    </div>
   <%-- <hr class=" greenRoundBorder">--%>

    <%--  <fieldset>
        <legend>Action Filters</legend>
         <asp:Label ID="lblPublishNotice" runat="server" Text="" Font-Bold="true"></asp:Label>
        <div class="col-md-12" style="margin-bottom: 20px">
            <div class="col-md-4">
                <div class="form-group row">
                    <label for="input" class="col-sm-3 col-form-label font-weight-bold">Class</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="drpClassFR" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group row">
                    <label for="input" class="col-sm-3 col-form-label font-weight-bold">Exam Type</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="drpExamTypeFR" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group row">
                    <label for="input" class="col-sm-3 col-form-label font-weight-bold">Year</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="drpYearFR" class="form-control col-md-7 col-xs-12" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-4 text-right">
                <%--<asp:Button ID="btnShowFR" CssClass="btn btn-primary" runat="server" Text="Show Full Result" OnClick="btnShowFR_Click" />
                <asp:Button ID="btnShowResult" runat="server" CssClass="btn btn-primary" Text="Show Full Result" OnClick="btnShowResult_Click" />
            </div>
        </div>
    </fieldset>--%>

  <%--  <div class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Students Result              
            </h3>

        </div>
        <div class="panel-body">
            <asp:GridView ID="gvPublishedResult" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered text-center" DataKeyNames="CLASS_ID">
                <Columns>
                    <%--<asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("CLASS_ID", @"StudentResultById.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="CLASS_LEVEL" HeaderText="Class" />
                    <asp:TemplateField HeaderText="Result Details">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlStdInfo" runat="server" NavigateUrl='<%# Eval("CLASS_ID", @"StudentResultById.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/AppIcon.png" title="Result Details" style="width:35px;height:35px" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>--%>
</asp:Content>
