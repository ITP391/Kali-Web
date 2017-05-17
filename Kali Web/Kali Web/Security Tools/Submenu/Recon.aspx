<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recon.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Nmap</h2>
            <p>
                Nmap (Network Mapper) is a security scanner used to discover hosts and services on a computer network, thus building a "map" of the network. To accomplish its goal, Nmap sends specially crafted packets to the target host(s) and then analyzes the responses.

                This verson of the tool scans only for open ports. For a more in depth scan, use the Nmap scan in the Vulnerability section.
            </p>
            <p>
                <a href="/Security Tools/Tool UI/nmap.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Wireshark Terminal</h2>
            <p>
                Wireshark is a free and open source packet analyzer. It is used for network troubleshooting, analysis, software and communications protocol development, and education. Originally named Ethereal, the project was renamed Wireshark in May 2006 due to trademark issues.
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