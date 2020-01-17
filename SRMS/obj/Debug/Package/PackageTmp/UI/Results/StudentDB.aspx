<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDB.aspx.cs" Inherits="SRMS.UI.Results.StudentDB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="color: aqua">
        <h2>Student Result Database<asp:Label ID="lblClassLevel" runat="server" Text=""></asp:Label></h2>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="col-md-4">
                        <asp:DropDownList ID="drpClass" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtRoll" runat="server" placeholder="Roll" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtName" runat="server" placeholder="Name" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-12 text-left" style="margin-top:15px; margin-bottom:15px">
                    <div class="col-md-5">
                      <span style="color:red">*</span>  <asp:DropDownList ID="drpYear" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                    <asp:Label ID="lblYearerr" runat="server" CssClass=" text-danger" Text=""></asp:Label>
                    </div>
                    <div class="col-md-5">
                       <span style="color:red">*</span> <asp:DropDownList ID="drpExamType" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                        <asp:Label ID="lblExmErr" runat="server" CssClass=" text-danger" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div class="col-md-12" style="margin-top: 20px">
                    <%-- Grid View--%>
                    <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="False" OnRowCommand="myGridView_RowCommand" class="table table-striped table-bordered text-center" DataKeyNames="STD_ID">
                        <Columns>
                            <asp:BoundField DataField="CLASS_ID" HeaderText="Class" />
                            <asp:BoundField DataField="STD_ROLL" HeaderText="Roll" />
                            <asp:BoundField DataField="STD_NAME" HeaderText="Name" />
                            <asp:BoundField DataField="STD_CONTACT" HeaderText="Contact" />
                            <asp:TemplateField HeaderText="View Result">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlStdInfo" runat="server" Text=''>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Resources/more-details.png" Width="25px" Height="25px" CommandArgument='<%# Eval("CLASS_ID") +","+Eval("STD_ID") %>' />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
       
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2 class="panel-title">Result View</h2>
                <div class="text-right">
                    <asp:ImageButton ID="imgBtnPrint" runat="server" AlternateText="Print" BorderColor="#ff9933" BackColor="White" ImageUrl="~/Resources/printer.png" Width="35px" Height="35px" OnClick="imgBtnPrint_Click" />
                </div>
            </div>
           <div class="panel-body">
                <div class="col-md-12">
                    <div class="col-md-2">
                        <asp:Label ID="Label13" runat="server" Text="Class :"></asp:Label>
                        <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="Name :"></asp:Label>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="Label5" runat="server" Text="Roll :"></asp:Label>
                        <asp:Label ID="lblRoll" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Exam :"></asp:Label>
                        <asp:Label ID="lblExam" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="Label4" runat="server" Text="Year :"></asp:Label>
                        <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-md-12" style="margin-top: 25px">
                    
                    <asp:Label ID="lblStdResult" runat="server" CssClass="text-warning" Font-Bold="true" Text=""></asp:Label>
                    <asp:GridView ID="gvResultView" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered text-center" DataKeyNames="STD_ID">
                        <Columns>
                            <asp:BoundField DataField="SUB_NAME" HeaderText="Subject" />
                            <asp:BoundField DataField="TOTAL_MARKS" HeaderText="Total" />
                            <asp:BoundField DataField="CREATIVE" HeaderText="Creative" />
                            <asp:BoundField DataField="MCQ" HeaderText="MCQ" />
                            <asp:BoundField DataField="PRACTICAL" HeaderText="Practical" />
                            <asp:BoundField DataField="TOTAL_MARKS_OBT" HeaderText="Total Marks Obt." />
                            <asp:BoundField DataField="STD_GRADE" HeaderText="Grade" />
                            <asp:BoundField DataField="STD_CGPA" HeaderText="CGPA" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
