<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SRMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="color: aqua">
        <h2>Student Result Management System</h2>
        <p class="lead">Software for store student data and publish the result in a formal card</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Student Details</h2>
            <p>
                For getting student general information. 
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">See All &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Subject Details</h2>
            <p>
                For take a look on subject details.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">All Subject &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Result View</h2>
            <p>
                Student Performance data.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">View All &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
