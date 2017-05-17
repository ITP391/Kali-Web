<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeStud.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeStud1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Information Gathering</h2>
            <p>
                Tools included in this category are used to gather information usually before an attack is commenced
            </p>
            <p>
                <a href="Recon.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Vulnerability Analysis</h2>
            <p>
                Tools included in this category are used to analyse for vulnerabilities in the target
            </p>
            <p>
                <a href="Vulnerable.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Stress Testing</h2>
            <p>
                Tools included in this category are used to stress test targets
            </p>
            <p>
                <a href="Stress.aspx">Click Here for the tool</a>
            </p>
        </div>
    </div>
</asp:Content>