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
        
        <%-- QUIZ: This is a repeater for all the questions that were answered  --%>
        <asp:Repeater ID="QuizAnswers" runat="server">
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        
                        <%-- QUIZ: The question description --%>
                        <h3 class="panel-title">
                            <%# DataBinder.Eval(Container.DataItem, "QuestionDescription") %>
                        </h3>
                    </div>
                    <div class="panel-body take-quiz" style="font-size: 18px; font-family: Arial">
                        
                        <%-- QUIZ: This is the first option of the question (if question is type CHOICE) --%>
                        <%-- QUIZ: If the correct answer was this option (option 1) and the user selected this, 
                            it will show green (by adding class 'correct-answer')
                            otherwise it will be red (by adding class 'wrong-answer') --%>
                        <%-- This will be showed only when question is type CHOICE --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label 
                                style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenChoiceAnswer").ToString() == "1" ? 
                                    ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "1")  ? 
                                    "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "1")  ? "correct-answer" :""))%>">

                                <%# DataBinder.Eval(Container.DataItem, "Answer1") %>
                            </label>
                        </div>
                        
                         
                        <%-- QUIZ: This is the first option of the question (if question is type CHOICE) --%>
                        <%-- QUIZ: If the correct answer was this option (option 2) and the user selected this, 
                            it will show green (by adding class 'correct-answer') 
                            otherwise it will be red (by adding class 'wrong-answer') --%>
                        <%-- This will be showed only when question is type CHOICE --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenChoiceAnswer").ToString() == "2" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "2")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "2")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer2") %>
                            </label>
                        </div>
                        
                        <%-- QUIZ: This is the first option of the question (if question is type CHOICE) --%>
                        <%-- QUIZ: If the correct answer was this option (option 3) and the user selected this, 
                            it will show green (by adding class 'correct-answer') 
                            otherwise it will be red (by adding class 'wrong-answer') --%>
                        <%-- This will be showed only when question is type CHOICE --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label 
                                style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenChoiceAnswer").ToString() == "3" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "3")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "3")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer3") %>
                            </label>
                        </div>
                        
                        <%-- QUIZ: This is the first option of the question (if question is type CHOICE) --%>
                        <%-- QUIZ: If the correct answer was this option (option 4) and the user selected this, 
                            it will show green (by adding class 'correct-answer') 
                            otherwise it will be red (by adding class 'wrong-answer') --%>
                        <%-- This will be showed only when question is type CHOICE --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "TEXT" ? "hidden" : "" %>">
                            <label 
                                style="float: left;"
                                class="<%#(DataBinder.Eval(Container.DataItem, "ChosenChoiceAnswer").ToString() == "4" ? 
                                                 ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "4")  ? 
                                                     "correct-answer" :"wrong-answer"): ((DataBinder.Eval(Container.DataItem, "CorrectAnswer").ToString() == "4")  ? "correct-answer" :""))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Answer4") %>
                            </label>
                        </div>
                        

                        <%-- QUIZ: This will be shown only when question is type = 'TEXT' --%>
                        <div class="radio <%# DataBinder.Eval(Container.DataItem, "QuestionType").ToString() == "CHOICE" ? "hidden" : "" %>">
                           
                            <%-- In case the answer is correct, this div will be shown --%>
                            <div class="<%# DataBinder.Eval(Container.DataItem, "AnswerIsCorrect").ToString() == "False" ? "hidden" : "" %>">
                                <label
                                    class="correct-answer"
                                    style="float: left;">
                                    Your answer was correct: <%# DataBinder.Eval(Container.DataItem, "CorrectTextAnswer") %>
                                </label>
                            </div>

                            <%-- In case the answer is not correct, this div will be shown --%>                            
                            <div class="<%# DataBinder.Eval(Container.DataItem, "AnswerIsCorrect").ToString() == "True" ? "hidden" : "" %>">
                                <p class="correct-answer"
                                   style="text-align: left;">
                                    Correct answer was: <%# DataBinder.Eval(Container.DataItem, "CorrectTextAnswer") %>
                                 </p>
                                <p class="wrong-answer"
                                   style="text-align: left;">
                                    You chose: <%# DataBinder.Eval(Container.DataItem, "ChosenTextAnswer") %>
                                </p>  
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>


</asp:Content>
