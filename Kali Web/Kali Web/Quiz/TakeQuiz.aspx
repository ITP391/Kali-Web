<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TakeQuiz.aspx.cs" Inherits="Kali_Web.Quiz.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row clearfix">
    </div>
    <div class="col-md-1 column">
    </div>
    <div class="col-md-10 column" style="margin-top: 20px">
        <p class="lead">Information gathering quizz</p>
        
        <%-- This is the markup for the time, which executes Timer1_Tick function every second (1000 ms)--%>
        <%-- CounterLabel is the text of the time, which will be updated every second --%>
        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="always">
            <ContentTemplate>
                <div class="alert alert-warning alert-dismissible" role="alert">
                    <strong>You have </strong>
                    <asp:Label ID="CounterLabel" runat="server" Text="" ></asp:Label> seconds for completing the quiz.
                </div>
                
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <%-- This is the repeater for all the questions of this quiz --%>
        <asp:Repeater ID="MyRepeater" runat="server">
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        
                        <%-- Title of the questions --%>
                        <h3 class="panel-title">
                            <%# DataBinder.Eval(Container.DataItem, "Description") %>
                        </h3>
                    </div>
                    <div class="panel-body take-quiz">
                       
                        <%-- This will be visible only when question type is 'CHOICE' --%>
                        <%-- This is the first answer option of the question --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>" >
                            <label style="float: left;">
                                <input type="radio" <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "required" : "" %> name='question-choice-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="1" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer1") %>
                            </label>
                        </div>
                        
                        <%-- This will be visible only when question type is 'CHOICE' --%>
                        <%-- This is the second answer option of the question --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label style="float: left;">
                                <input type="radio" <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "required" : "" %> name='question-choice-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="2" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer2") %>
                            </label>
                        </div>
                        
                        <%-- This will be visible only when question type is 'CHOICE' --%>
                        <%-- This is the third answer option of the question --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label style="float: left;">
                                <input type="radio" <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "required" : "" %> name='question-choice-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="3" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer3") %>
                            </label>
                        </div>
                        
                        <%-- This will be visible only when question type is 'CHOICE' --%>
                        <%-- This is the forth answer option of the question --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label style="float: left;">
                                <input type="radio" <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "required" : "" %> name='question-choice-<%# DataBinder.Eval(Container.DataItem, "Id") %>' value="4" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer4") %>
                            </label>
                        </div>
                        
                        <%-- This will be visible only when question type is 'TEXT' --%>
                        <%-- This is the input for entering the TEXT answer --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "hidden" : "" %>">
                            <label style="float: left; width: 100%" class="<%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "hidden" : "" %>">
                                <input type="text" 
                                    <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "required" : "" %> 
                                    name='question-text-<%# DataBinder.Eval(Container.DataItem, "Id") %>' 
                                    <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "disabled" : "" %>
                                    style="width: 100%" />
                            </label>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-md-2 col-md-offset-5" style="margin-bottom: 20px;">
            <asp:Button ID="Button1" runat="server" type="button" class="btn btn-success" Text="Submit questions" OnClick="VerifyAnswers" />
        </div>
    </div>

</asp:Content>
