﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeLect.aspx.cs" Inherits="Kali_Web.Security_Tools.HomeLect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- add some codes for teacher side - add show/hide buttons, add list of students-->
    <div class="row main-content">
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Information Gathering</div>
                <div class="box-content">
                    <p>Tools included in this category are used to gather information usually before an attack is commenced</p>
                    <p class="tool-link"><a href="/Security Tools/Submenu/Recon.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-green">Vulnerability Analysis</div>
                <div class="box-content">
                    <p>Tools included in this category are used to analyse for vulnerabilities in the target</p>
                    <p class="tool-link">          
                        <a href="/Security Tools/Submenu/Vulnerable.aspx" class="button">Click Here for the tool</a>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-orange">Password Attack</div>
                <div class="box-content">
                    <p>Tools included in this category are used to crack passwords</p>
                    <p class="tool-link"><a href="/Security Tools/Submenu/PassAttack.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-orange">Quiz Completion</div>
                <div class="box-content">
                    <p>Test</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Student Permissions</div>
                <div class="box-content">
                    <p>Test</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Server Tools</div>
                <div class="box-content">
                    <p>A few preset administrative commands to send to the server</p>
                    <p class="tool-link">          
                        <a href="/Security Tools/Tool UI/ServerTools.aspx" class="button">Click Here for the tool</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
