<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kali_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Kali Web</h1>
        <p class="lead">Kali Web is a Web Application which allows students to use security tools which are included in the Kali Linux distribution with a simple to use user interface.</p>
        <p><a href="Account/Login.aspx" class="btn btn-custom btn-lg">Get Started &raquo;</a></p>
    </div>

    <div class="row main-content">
        <div class="col-md-4">
            <h2>Our Company</h2>
            <p>
                Angie Programming is a startup company with the vision of simplifying learning. Our debut product Kali Web is the start of our vision to spend more time on learning and less on logistics.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Contact Us</h2>
            <p>
                Angie Programming Pte Ltd.<br />
                53 Ubi Avenue 1<br />
                Paya Ubi Industrial Park<br />
                Singapore 408934
            </p>
            <p>
                Email: AngieChu@angieprogramming.com.sg<br />
                Tel No.: +6598521467
            </p>
            <p>
                Operating Hours (Mon - Fri): 9am - 9pm
            </p>
        </div>
        <div class="col-md-4">
            <h2>About Kali Linux</h2>
            <p>
                Kali Web is a website where you can use security testing tools without the need to install anything extra.
                To login, click <a href="Account/Register.aspx">here</a>! Accounts are strictly created by your school administrator. Contact your school's administrator to create an account.
            </p>
        </div>
    </div>

</asp:Content>
