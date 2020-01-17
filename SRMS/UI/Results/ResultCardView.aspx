<%@ Page Title="View Result" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ResultCardView.aspx.cs" Inherits="SRMS.UI.Results.ResultCardView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <div class="jumbotron">
            <h1>Result Card</h1>

            <p><a class="btn btn-primary btn-lg text-right" onclick=" ">Print</a></p>
        </div>

        <form id="form1" runat="server">
            <div>
                <div class="form-group">
                    <table border="0" style="width: 100%; height: auto">
                        <tr>
                            <td style="width: 20%; text-align: center">
                                <table border="1" style="width: 80%; height: auto;">
                                    <tr>
                                        <th>Marks</th>
                                        <th>Grade</th>
                                        <th>GP</th>
                                    </tr>
                                    <tr>
                                        <td>80-100</td>
                                        <td>A+</td>
                                        <td>5</td>
                                    </tr>
                                    <tr>
                                        <td>70-79</td>
                                        <td>A</td>
                                        <td>4</td>
                                    </tr>
                                    <tr>
                                        <td>60-69</td>
                                        <td>A-</td>
                                        <td>3.5</td>
                                    </tr>
                                    <tr>
                                        <td>50-59</td>
                                        <td>B</td>
                                        <td>3</td>
                                    </tr>
                                    <tr>
                                        <td>40-49</td>
                                        <td>C</td>
                                        <td>2</td>
                                    </tr>
                                    <tr>
                                        <td>33-39</td>
                                        <td>D</td>
                                        <td>1</td>
                                    </tr>
                                    <tr>
                                        <td>0-32</td>
                                        <td>F</td>
                                        <td>0</td>
                                    </tr>
                                </table>
                            </td>
                            <td style="text-align: center; width: 60%;">
                                <table style="text-align: center; width: 100%; height: 100%">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/UI/Results/IT-Theory.png" Width="60px" Height="60px" ImageAlign="AbsMiddle" /></td>
                                    </tr>
                                    <tr>
                                        <td>Ins. Name</td>
                                    </tr>
                                    <tr>
                                        <td>Location</td>
                                    </tr>
                                    <tr>
                                        <td>Founder</td>
                                    </tr>
                                    <tr>
                                        <td>Academic Transcript</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblExamType" CssClass="form-control" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Button ID="btnPrint" CssClass="btn btn-primary" runat="server" Text="Print" /></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2" style="text-align: justify">
                                <div class="col-md-12" style="font-size: large">
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

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2" style="text-align: center; font-size: large;">
                                <div class="col-md-2">
                                    <asp:Label ID="Label1" runat="server" Text="Exam :"></asp:Label>
                                    <asp:Label ID="lblExam" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label4" runat="server" Text="Year :"></asp:Label>
                                    <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">
                                <div class="col-md-12">
                                    <%-- Grid View--%>
                                    <asp:Label ID="lblStdResult" runat="server" CssClass="text-warning" Font-Bold="true" Text=""></asp:Label>
                                    <asp:GridView ID="gvResultView" Height="200px" Width="750px" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered text-center" DataKeyNames="STD_ID">
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
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2" style="text-align: justify; font-size: large">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Total Exam Markes :"></asp:Label>
                                        <asp:Label ID="lblTotalMarks" runat="server" Text=""></asp:Label>
                                    </div>

                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label6" runat="server" Text="Total Marks Obt. :"></asp:Label>
                                        <asp:Label ID="lblMarksObt" runat="server" Text=""></asp:Label>

                                    </div>
                                    <%--<div class="col-md-3">
                                    
                                    <asp:Label ID="Label11" runat="server" Text="Grade Obt. :"></asp:Label>
                                    <asp:Label ID="lblGObt" runat="server" Text=""></asp:Label>
                                   
                                </div>--%>
                                    <div class="col-md-3">

                                        <asp:Label ID="Label20" runat="server" Text="GPA Obt. :"></asp:Label>
                                        <asp:Label ID="lblPointObt" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; height: 150px">---------------------
                           </br>
                            <b>Class Teacher</b>
                            </td>
                            <td style="text-align: center">---------------------
                           </br>
                            <b>Guardian</b>
                            </td>
                            <td style="text-align: center">---------------------
                           </br>
                            <b>Institute Head</b>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>

    </body>
    </html>
</asp:Content>
