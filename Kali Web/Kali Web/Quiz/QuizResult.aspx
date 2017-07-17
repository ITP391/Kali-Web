<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizResult.aspx.cs" Inherits="Kali_Web.Quiz.QuizResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h3>You scored <asp:label id="correctAnswersLabel" runat="server" /> out of <asp:label id="totalAnswersLabel" runat="server" /> </h3>
    <asp:label id="notCompletedInTimeLabel" runat="server" /><br/>
    <div class="btn-group" style="margin-bottom: 20px">
        <asp:HyperLink id="RetakQuizButton" 
                       NavigateUrl="#"
                       Text="Retake quiz"
                       runat="server"/>
    </div>
    

    <div class="row clearfix">
    </div>
    <div class="col-md-1 column">
    </div>
    <div class="col-md-10 column" style="margin-top: 20px">
        <p class="lead">Quiz results:</p>
        <asp:Repeater ID="QuizAnswers" runat="server">
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <%# DataBinder.Eval(Container.DataItem, "QuestionDescription") %>
                        </h3>
                    </div>
                    <div class="panel-body take-quiz" style="font-size: 18px; font-family: Arial">

                        <div class="radio">

                            <label style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenAnswer").ToString() == "1" ? 
                                    ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "1")  ? 
                                    "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "1")  ? "correct-answer" :""))%>">

                                <%# DataBinder.Eval(Container.DataItem, "Answer1") %>
                            </label>
                        </div>
                        <div class="radio">
                            <label style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenAnswer").ToString() == "2" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "2")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "2")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer2") %>
                            </label>
                        </div>
                        <div class="radio">
                            <label style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenAnswer").ToString() == "3" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "3")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "3")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer3") %>
                            </label>
                        </div>
                        <div class="radio">
                            <label style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenAnswer").ToString() == "4" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "4")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "4")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer4") %>
                            </label>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>


</asp:Content>
