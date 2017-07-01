<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuccessfulRegistration.aspx.cs" Inherits="Kali_Web.Account.SuccessfulRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3><asp:Label ID="Label3" runat="server" Text="INTERNAL USE ONLY"></asp:Label></h3>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Successful Registration. Student may now login."></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Click"></asp:Label><a href ="/Account/Login"> here </a><asp:Label ID="Label2" runat="server" Text="to return to login."></asp:Label>
&nbsp; 
</asp:Content>