﻿<%@ Page Title="Student Marks" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClasswiseStudentMarks.aspx.cs" Inherits="SRMS.App_Code.Services.Results.ClasswiseStudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .boxSize {
            width: 100px;
        }
    </style>
     <div class="jumbotron" style="color: aqua">
        <h2>All Student of Class<asp:Label ID="lblClassLevel" runat="server" Text=""></asp:Label></h2>
       <%-- <div class="col-md-12">
            <div class="col-md-5">
                <div class="form-group row">
                    <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="drpSubject" class="form-control col-md-7 col-xs-12" runat="server" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <div class="form-group row">
                    <label for="input" class="col-sm-3 col-form-label font-weight-bold">Roll No</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtRoll" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group row">
                    <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" />
                </div>
            </div>
        </div>--%>
        <h3>
            <asp:Label ID="lblResultShow" CssClass="text-danger" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="container">
        <div class="mt-5" style="text-align: center">
            <form>
                <div class="col-md-12 text-center">
                
                    <div class="radio col-md-6 text-center well" style="background-color: cadetblue; color: red; font-size: large">
                        <div class="form-group row">
                            <label for="input" class="col-sm-3 col-form-label font-weight-bold">Subject</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="drpSubject" class="form-control col-md-7 col-xs-12" runat="server" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text="Select Exam Session:"></asp:Label>
                        <asp:RadioButton runat="server" CssClass="radio" GroupName="examType" ID="rBtnMid" Text="Mid Term"></asp:RadioButton>
                        <asp:RadioButton runat="server" CssClass="radio" GroupName="examType" ID="rBtnFinal" Text="Final Term"></asp:RadioButton>
                        <div>
                            <asp:Label ID="lblRadiochecked" Style="color: red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>


                <%-- Add Grid View--%>
                <asp:GridView ID="gvStdDetails" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" DataKeyNames="STD_ID,STD_ROLL,TOTAL_MARKS">
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlClassInfo" runat="server" NavigateUrl='<%# Eval("STD_ID", @"StudentResultView.aspx?Id={0}") %>' Text=''>
                                            <img src="../../Resources/edit.png" title="Edit"  />
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="STD_ID" HeaderText="Std Id" Visible="false" />
                        <asp:BoundField DataField="STD_ROLL" HeaderText="Roll No" />
                        <asp:BoundField DataField="STD_NAME" HeaderText="Name" />
                        <asp:BoundField DataField="TOTAL_MARKS" HeaderText="Total Marks" />
                        <%--<asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotal" ReadOnly="true" CssClass="form-control boxSize" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Creative">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCreative" TextMode="Number" CssClass="form-control boxSize" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MCQ">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMCQ" TextMode="Number" CssClass="form-control boxSize" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Practical">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPractical" TextMode="Number" CssClass="form-control boxSize" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Marks Obt.">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotal" ReadOnly="true" CssClass="form-control boxSize" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <div class="col-md-12">
                    <div class="text-right">
                        <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button CssClass="btn btn-warning" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

