<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nmap.aspx.cs" Inherits="Kali_Web.Security_Tools.nmap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nmap - Network Mapper</h2>
    <h3>DO NOT USE OUTSIDE OF CLASSROOM ENVIRONMENT</h3>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="IP" CssClass="col-md-2 control-label">IP Address</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="IP" CssClass="form-control" />
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Find" CssClass="btn btn-default" OnClick="Unnamed3_Click" />
                            <br />
                            <br />
                            <asp:TextBox ID="Output" runat="server" CssClass="form-control" TextMode="MultiLine" Height="252px" Width="1438px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>