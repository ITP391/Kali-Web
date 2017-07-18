<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfigureQuiz.aspx.cs" Inherits="Kali_Web.Quiz.ConfigureQuiz" %>
<%@ Import Namespace="System.ComponentModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Questions administration:</h3>
    <hr />
    <br />
    <div class="row clearfix">
    </div>

    <div class="col-md-3 col-md-offset-3">
        <div class="btn-group">
            
            <%-- QUIZ: Button foradding questions with choices  --%>
            <a href="AddChoiceQuestion.aspx">
                <button class="btn btn-default btn-lg" type="button">
                    Add new question with choices
                </button>
            </a>
        </div>
    </div>
    <div class="col-md-3">
        <div class="btn-group">
            
            <%-- QUIZ: Button foradding questions with text  --%>
            <a href="AddTextQuestion.aspx">
                <button class="btn btn-default btn-lg" type="button">
                    Add new text question
                </button>
            </a>
        </div> 
    </div>

    <div class="col-md-10 column col-md-offset-1" style="margin-top: 20px">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Information gathering questions:
                </h3>
            </div>
            <div class="panel-body">
                
                <%-- QUIZ: This is a repeater that repeats the question from the Information Gathering repeater --%>
                <asp:Repeater ID="InformationGatheringQuestionsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <!-- Default panel contents -->
                            
                            <%-- QUIZ: This is the description of the question --%>
                            <div class="panel-heading" style="text-align: left;">
                                <%# DataBinder.Eval(Container.DataItem, "Description") %>
                                <a runat="server" onserverclick="DeleteQuestion" question-id='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                                    <span class="glyphicon glyphicon-remove" style="float: right; cursor: pointer" aria-hidden="true"></span>
                                </a>
                                <span class="glyphicon glyphicon-align-justify" style="float: right; margin-right: 10px; cursor: pointer" aria-hidden="true" data-toggle="collapse" data-target="#list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>"></span>
                            </div>
                            
                            <%-- QUIZ: This is a list of possible answers --%>
                            <ul id="list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-align: left" class="list-group collapse">
                                <li class="list-group-item  <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>"><%# DataBinder.Eval(Container.DataItem, "Answer1") %></li>
                                <li class="list-group-item <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>"><%# DataBinder.Eval(Container.DataItem, "Answer2") %></li>
                                <li class="list-group-item <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>"><%# DataBinder.Eval(Container.DataItem, "Answer3") %></li>
                                <li class="list-group-item <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>"><%# DataBinder.Eval(Container.DataItem, "Answer4") %></li>
                                <%-- QUIZ: In case the question is of type TEXT, the previous li's are going to be hidden and only the one below will be visible --%>
                                <li class="list-group-item <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "hidden" : "" %>"><%# DataBinder.Eval(Container.DataItem, "CorrectTextAnswer") %></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="col-md-10 col-md-offset-1" style="margin-top: 20px">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Vulnerability attack questions:
                </h3>
            </div>
            <div class="panel-body">
                
                <%-- QUIZ: This is a repeater that repeats the question from the Vulnerability analysis category --%>
                <asp:Repeater ID="VulnerabilityAnalysisQuestionsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <!-- Default panel contents -->

                            <%-- QUIZ: This is the description of the question --%>
                            <div class="panel-heading" style="text-align: left;">
                                <%# DataBinder.Eval(Container.DataItem, "Description") %>
                                <a runat="server" onserverclick="DeleteQuestion" question-id='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                                    <span class="glyphicon glyphicon-remove" style="float: right; cursor:pointer" aria-hidden="true"></span>
                                </a>
                                <span class="glyphicon glyphicon-align-justify" style="float: right; margin-right: 10px; cursor:pointer" aria-hidden="true" data-toggle="collapse" data-target="#list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>"></span>
                            </div>

                            <%-- QUIZ: This is a list of possible answers --%>
                            <ul id="list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-align: left" class="list-group collapse">
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer1") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer2") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer3") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer4") %></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="col-md-10 col-md-offset-1" style="margin-top: 20px">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Password attack questions:
                </h3>
            </div>
            <div class="panel-body">
                
                <%-- QUIZ: This is a repeater that repeats the question from the Password attack category --%>
                <asp:Repeater ID="PasswordAttackQuestionsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <!-- Default panel contents -->
                            
                            <%-- QUIZ: This is the description of the question --%>
                            <div class="panel-heading" style="text-align: left;">
                                <%# DataBinder.Eval(Container.DataItem, "Description") %>
                                <a runat="server" onserverclick="DeleteQuestion" question-id='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                                    <span class="glyphicon glyphicon-remove" style="float: right; cursor:pointer" aria-hidden="true"></span>
                                </a>
                                <span class="glyphicon glyphicon-align-justify" style="float: right; margin-right: 10px; cursor:pointer" aria-hidden="true" data-toggle="collapse" data-target="#list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>"></span>
                            </div>

                            <%-- QUIZ: This is a list of possible answers --%>
                            <ul id="list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-align: left" class="list-group collapse">
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer1") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer2") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer3") %></li>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Answer4") %></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    
    <br />
</asp:Content>
