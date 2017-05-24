<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeStud.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeStud1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Information Gathering</h2>
            <p>
                Tools included in this category are used to gather information usually before an attack is commenced
            </p>
            <p>
                <a href="/Security Tools/Submenu/Recon.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Vulnerability Analysis</h2>
            <p>
                Tools included in this category are used to analyse for vulnerabilities in the target
            </p>
            <p>
                <a href="/Security Tools/Submenu/Vulnerable.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Password Attack</h2>
            <p>
                Tools included in this category are used to crack passwords
            </p>
            <p>
                <a href="/Security Tools/Submenu/PassAttack.aspx">Click Here for the tool</a>
            </p>
        </div>
    </div>
</asp:Content>