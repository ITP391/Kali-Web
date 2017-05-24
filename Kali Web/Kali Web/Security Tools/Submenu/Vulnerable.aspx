<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vulnerable.aspx.cs" Inherits="Kali_Web.Security_Tools.Vulnerable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Only one tool for this section because it is a different scan using the same software -->
    <div class="row">
        <div class="col-md-4">
            <h2>Nmap</h2>
            <p>
                Nmap (Network Mapper) is a security scanner used to discover hosts and services on a computer network, thus building a "map" of the network. To accomplish its goal, Nmap sends specially crafted packets to the target host(s) and then analyzes the responses.

                This verson of the tool performs an in depth scan. For a more in quicker scan, use the Nmap scan in the Vulnerability section.
            </p>
            <p>
                <a href="/Security Tools/Tool UI/nmap.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Coming Soon!</h2>
            <p>
                A new tool is being developed and tested and will arrive shortly!
            </p>
            <p>
                <a href="/Security Tools/Tool UI/Wireshark.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Coming Soon!</h2>
            <p>
                A new tool is being developed and tested and will arrive shortly!
            </p>
        </div>
    </div>
</asp:Content>