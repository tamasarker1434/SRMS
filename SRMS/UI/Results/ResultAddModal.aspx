<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultAddModal.aspx.cs" Inherits="SRMS.UI.Results.ResultAddModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result</title>
</head>
<body>

    <form runat="server">
        <div class="col-md-12" >
            <asp:ImageButton ID="ImageButton1"  runat="server" ImageUrl="~/Resources/printer.png" AlternateText="Print" BorderColor="WhiteSmoke" Width="45px" Height="45px" OnClick="ImageButton1_Click" />
        </div>
    </form>
    <div class="col-md-12">
        <div class="form-group">
            <asp:Panel ID="panelPdf" runat="server">
                <table border="0" style="width: 100%; height: auto; background-color: bisque">
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
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/UI/Results/IT-Theory.png" Height="45px" Width="45px" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Samadia Darul Ulum Secondary School</td>
                                </tr>
                                <tr>
                                    <td>Dhar Para, Wazirpur, Barishal</td>
                                </tr>
                                <tr>
                                    <td>Founder: Md. Fazlur Rahaman Lasker </td>
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
                        <td></td>
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
                        <td style="text-align: center" runat="server">
                           
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
            </asp:Panel>

        </div>
    </div>

</body>
</html>
