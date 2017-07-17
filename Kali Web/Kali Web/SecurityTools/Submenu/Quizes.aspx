<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quizes.aspx.cs" Inherits="Kali_Web.Security_Tools.Submenu.Quizes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main-content">
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Information Gathering</div>
                <div class="box-content">
                    <p>Review questions for Information Gathering</p>
                    <p class="tool-link"><a href="/SecurityTools/Submenu/Recon.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-green">Vulnerability Analysis</div>
                <div class="box-content">
                    <p>Review questions for Vulnerability Analysis</p>
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
                    <p>Review questions for Password Attack</p>
                    <p class="tool-link"><a href="/SecurityTools/Submenu/PassAttack.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>