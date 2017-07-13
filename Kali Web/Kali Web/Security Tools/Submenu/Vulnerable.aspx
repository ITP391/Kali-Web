<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vulnerable.aspx.cs" Inherits="Kali_Web.Security_Tools.Vulnerable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Only one tool for this section because it is a different scan using the same software -->
    <div class="row main-content">       
         <%--Container for a box of a category--%>
            <div class="col-md-4">
                <div class="box box-large">
                     <%-- Ribbon container of a box --%>
                    <div class="ribbon ribbon-blue">Nmap</div>
                    <div class="box-content">
                        <p>Nmap (Network Mapper) is a security scanner used to discover hosts and services on a computer network, thus building a "map" of the network. To accomplish its goal, Nmap sends specially crafted packets to the target host(s) and then analyzes the responses. This verson of the tool scans only for operation system and extra details. For a more shorter scan, use the nmap tool in the Information Gathering page. </p>
                        <p class="tool-link"><a href="/Security Tools/Tool UI/nmapVul.aspx" class="button">Click Here for the tool</a> </p>
                    </div>
                </div>
            </div>
        <div class="col-md-4">
             <%--Container for a box of a category--%>
            <div class="box box-large">
                 <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-green">Coming Soon!</div>
                <div class="box-content">
                    <p>A new tool is being developed and tested and will arrive shortly!</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">  
             <%--Container for a box of a category--%>
            <div class="box box-large">      
                 <%-- Ribbon container of a box --%>
                <div class="ribbon ribbon-orange">Coming Soon!</div>
                <div class="box-content">
                    <p>A new tool is being developed and tested and will arrive shortly!</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>