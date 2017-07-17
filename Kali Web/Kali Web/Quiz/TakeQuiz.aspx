<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TakeQuiz.aspx.cs" Inherits="Kali_Web.Quiz.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row clearfix">
    </div>
    <div class="col-md-1 column">
    </div>
    <div class="col-md-10 column" style="margin-top: 20px">
        <p class="lead">Information gathering quizz</p>
        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="always">
            <ContentTemplate>
                <div class="alert alert-warning alert-dismissible" role="alert">
                    <strong>You have </strong><asp:Label ID="CounterLabel" runat="server" Text="" ></asp:Label> seconds for completing the quiz.
                </div>
                
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Repeater ID="MyRepeater" runat="server">
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <%# DataBinder.Eval(Container.DataItem, "Description") %>
                        </h3>
                    </div>
                    <div class="panel-body take-quiz">

                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>" >
                            <label style="float: left;">
                                <input type="radio" required name='question-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="1" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer1") %>
                            </label>
                        </div>
                        <div class="radio ">
                            <label style="float: left;">
                                <input type="radio" required name='question-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="2" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer2") %>
                            </label>
                        </div>
                        <div class="radio ">
                            <label style="float: left;">
                                <input type="radio" required name='question-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="3" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer3") %>
                            </label>
                        </div>
                        <div class="radio ">
                            <label style="float: left;">
                                <input type="radio" required name='question-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="4" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer4") %>
                            </label>
                        </div>
                      <%--  <div class="radio">
                            <label style="float: left; width: 100%">
                                <input type="text" required name='question-text-<%# DataBinder.Eval(Container.DataItem, "Id") %>' style="width: 100%" />
                            </label>
                        </div>--%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-md-2 col-md-offset-5" style="margin-bottom: 20px;">
            <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Submit questions" OnClick="VerifyAnswers" />
        </div>
    </div>

</asp:Content>
