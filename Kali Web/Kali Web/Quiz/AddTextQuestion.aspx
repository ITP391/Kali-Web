<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTextQuestion.aspx.cs" Inherits="Kali_Web.Quiz.AddTextQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <h3>Add a new question:</h3>
    <hr />
    <br />
    <div class="col-md-10 column col-md-offset-1">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Add a new text question:
                </h3>
            </div>
            
            <%-- QUIZ: This is asp markup for the dropdown list of questions categories--%>
            <div class="panel-body">
                <div class="form-group" >
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label7" runat="server" Text="Category:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:DropDownList ID="QuestionCategory" runat="server" class="form-control"  style="margin-bottom: 15px">
                            <asp:ListItem Text="Information gathering" Value="IG"></asp:ListItem>
                            <asp:ListItem Text="Vulnerability analysis" Value="VA"></asp:ListItem>
                            <asp:ListItem Text="Password attack" Value="PA"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="clear:both"></div>
                
                <%-- QUIZ: This is the input for the questions description--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label1" runat="server" Text="Description:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="QuestionDescriptionTextBox" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="QuestionDescriptionTextBox"
                                                    CssClass="text-danger" ErrorMessage="Question description is required." />
                    </div>
                </div>
                
                <%-- QUIZ: This is the input for the correct answer --%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label2" runat="server" Text="Correct answer:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="QuestionsCorrectAnswerTextBox" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="QuestionsCorrectAnswerTextBox"
                                                    CssClass="text-danger" ErrorMessage="Question must have a correct answer." />
                    </div>
                </div>
                
                <%-- QUIZ: This is button for adding the questions--%>
                <div class="form-group">
                    <div class="col-xs-4 col-md-offset-4">
                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Add question" OnClick="AddQuestion_Callback" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    
    <%-- QUIZ: Button for going back to all questions --%>
    <div class="btn-group" style="margin-bottom: 10px">
        <a href="ConfigureQuiz.aspx">
            <button class="btn btn-default btn-lg" type="button">
                All questions
            </button>
        </a>
    </div>
    <br />
</asp:Content>
