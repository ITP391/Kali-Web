<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudQuizzes.aspx.cs" Inherits="Kali_Web.Security_Tools.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <nav>
      
                <ul class="nav col-md-12">
       
                    <li class="col-md-4"><a href="../Quiz/TakeQuiz.aspx?category=IG" class="icon-home"><p style="margin-top: 30px;">Information gathering quiz</p></a></li>

                    <li class="col-md-4"><a href="../Quiz/TakeQuiz.aspx?category=VA" class="icon-cog"><p style="margin-top: 30px;">Vulnerability analysis quiz</p></a></li>

                    <li class="col-md-4"><a href="../Quiz/TakeQuiz.aspx?category=PA" class="icon-cw"><p style="margin-top: 30px;">Pasword analysis quiz</p></a></li>

                </ul>

            </nav>
        </div>
    </div>
</asp:Content>