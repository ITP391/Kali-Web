<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddChoiceQuestion.aspx.cs" Inherits="Kali_Web.Quiz.AddChoiceQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <h3>Add a new question:</h3>
    <hr />
    <br />
    <div class="col-md-10 column col-md-offset-1">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Add a new qeustions
                </h3>
            </div>
            <div class="panel-body">
                <div class="form-group" >
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label7" runat="server" Text="Category:"></asp:Label>
                   
                    <%-- QUIZ: This is asp markup for the dropdown list of questions categories--%>
                    <div class="col-xs-8">
                        <asp:DropDownList ID="QuestionCategory" runat="server" class="form-control"  style="margin-bottom: 15px">
                            <asp:ListItem Text="Information gathering" Value="IG"></asp:ListItem>
                            <asp:ListItem Text="Vulnerability analysis" Value="VA"></asp:ListItem>
                            <asp:ListItem Text="Password attack" Value="PA"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="clear:both"></div>

                <%-- QUIZ: Label for questions description--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label1" runat="server" Text="Description:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="QuestionDescriptionTextBox" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="QuestionDescriptionTextBox"
                                                    CssClass="text-danger" ErrorMessage="Question description is required." />
                    </div>
                </div>
                
                <%-- QUIZ: Label for the first option of the questions--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label2" runat="server" Text="Answer 1:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="Answer1TextBox" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer1TextBox"
                                                    CssClass="text-danger" ErrorMessage="All answers are required." />
                    </div>
                </div>
                
                <%-- QUIZ: Label for the second option of the questions--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label3" runat="server" Text="Answer 2:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="Answer2TextBox" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer2TextBox"
                                                    CssClass="text-danger" ErrorMessage="All answers are required." />
                    </div>
                </div>
                
                <%-- QUIZ: Label for the third option of the questions--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label4" runat="server" Text="Answer 3:" ></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="Answer3TextBox" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer3TextBox"
                                                    CssClass="text-danger" ErrorMessage="All answers are required." />
                    </div>
                </div>
                
                <%-- QUIZ: Label for the forth option of the questions--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label5" runat="server" Text="Answer 4:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="Answer4TextBox" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer4TextBox"
                                                    CssClass="text-danger" ErrorMessage="All answers are required." />
                    </div>
                </div>
                
                <%-- QUIZ: Label for the correct answer, with range validation with min:1, maximum:4 --%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label6" runat="server" Text="Correct answer:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox type="number" ID="CorrectAnswerTextBox" autocomplete="off" runat="server" class="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CorrectAnswerTextBox"
                                                    CssClass="text-danger" ErrorMessage="A correct answer is required" />
                        <asp:RangeValidator 
                            ID="correctAnswer" 
                            runat="server" 
                            ControlToValidate="CorrectAnswerTextBox" 
                            ErrorMessage="Correct answer must be between 1 and 4." 
                            MaximumValue="4" 
                            MinimumValue="1" 
                            style="display: block; width: 500px;color: red;"
                            Type="Integer"></asp:RangeValidator>
                    </div>
                </div>
                
                <%-- QUIZ: Button for adding the question in the database--%>
                <div class="form-group">
                    <div class="col-xs-4 col-md-offset-4">
                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Add question" OnClick="AddChoiceQuestion_Callback" />
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
