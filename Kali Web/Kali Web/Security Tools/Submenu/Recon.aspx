<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recon.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeStud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main-content">   
         <%--Container for a box of a category--%>
        <div class="col-md-4">
            <div class="box box-large">    
                <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-blue">Nmap</div>
                <div class="box-content">
                    <p>Nmap (Network Mapper) is a security scanner used to discover hosts and services on a computer network, thus building a "map" of the network. To accomplish its goal, Nmap sends specially crafted packets to the target host(s) and then analyzes the responses. This verson of the tool scans only for open ports. For an Operating System scan, use the Nmap scan in the Vulnerability section.</p>
                    <p class="tool-link"><a href="/Security Tools/Tool UI/nmap.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
         <%--Container for a box of a category--%>
        <div class="col-md-4">
            <div class="box box-large">    
                <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-green">Wireshark Terminal</div>
                <div class="box-content">
                    <p>Wireshark is a free and open source packet analyzer. It is used for network troubleshooting, analysis, software and communications protocol development, and education. Originally named Ethereal, the project was renamed Wireshark in May 2006 due to trademark issues.</p>
                    <p class="tool-link"><a href="/Security Tools/Tool UI/Wireshark.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>     
         <%--Container for a box of a category--%>
        <!-- I will add a new tool soon -->
        <div class="col-md-4">
             <div class="box box-large">
                 <%-- Ribbon container of a box --%>  
                <div class="ribbon ribbon-orange">Ping</div>
                <div class="box-content">
                    <p>ping is a computer network administration software utility used to test the reachability of a host on an Internet Protocol (IP) network. It measures the round-trip time for messages sent from the originating host to a destination computer that are echoed back to the source.</p>
                    <p class="tool-link"><a href="/Security Tools/Tool UI/ping.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>