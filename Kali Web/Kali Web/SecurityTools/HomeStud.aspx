<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeStud.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeStud1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main-content">
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Information Gathering</div>
                <div class="box-content">
                    <p>Tools included in this category are used to gather information usually before an attack is commenced</p>
                    <p class="tool-link"><a href="/SecurityTools/Submenu/Recon.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-green">Vulnerability Analysis</div>
                <div class="box-content">
                    <p>Tools included in this category are used to analyse for vulnerabilities in the target</p>
                    <p class="tool-link">          
                        <a href="/SecurityTools/Submenu/Vulnerable.aspx" class="button">Click Here for the tool</a>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-orange">Password Attack</div>
                <div class="box-content">
                    <p>Tools included in this category are used to crack passwords</p>
                    <p class="tool-link"><a href="/SecurityTools/Submenu/PassAttack.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <div class="box twice-box">
                <div class="ribbon ribbon-orange">Your Progress</div>
                <br />
                <div class="box-content">
                    <div class="meter-value" style="background-color: #0a0; width: 90%; text-align:center; margin:auto;">
            <div class="meter-text">
                       100%
                </div>
            </div>
                    <p class="tool-link"><a href="/SecurityTools/QuizDetails.aspx" class="button">Click Here for more</a></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Your Quizzes</div>
                <div class="box-content">
                    <p>Complete these quizzes to make sure you understand the usage of the tools!</p>
                    <p class="tool-link"><a href="/SecurityTools/StudQuizzes.aspx" class="button">Click Here for Quizes!</a> </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>