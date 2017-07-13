<%@ Page validateRequest="false" Title= "Server Tools" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServerTools.aspx.cs" Inherits="Kali_Web.Security_Tools.Tool_UI.SSHTerminal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-content">

        <h2 style="margin-top: 35px">Server Tools</h2>
        <h3>DO NOT USE OUTSIDE OF CLASSROOM ENVIRONMENT</h3>

        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="False">
                    <div class="alert alert-danger" role="alert">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Error:</span>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                            =                   
                        </p>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>

        <div class="row" style="padding: 10px; padding-top: 20px;">
            <div class="col-md-12">
                <div class="col-md-8 col-md-offset-2  form-box" style="text-align: left">
                    <div class="form-group">

                        <asp:Label runat="server" CssClass="control-label middle-label">Commands</asp:Label>

                        <div class="input-group">
                            
                            <span class="input-group-btn">
                                <asp:Button runat="server" Text="Shut Down" CssClass="btn btn-default big-button" OnClick="Unnamed2_Click" />
                                <asp:Button runat="server" Text="ifconfig" CssClass="btn btn-default big-button" OnClick="Unnamed3_Click" />
                                <asp:Button runat="server" Text="Reboot" CssClass="btn btn-default big-button" OnClick="Unnamed4_Click" />
                                <asp:Button runat="server" Text="Date" CssClass="btn btn-default big-button" OnClick="Unnamed5_Click" />
                                <asp:Button runat="server" Text="Processes" CssClass="btn btn-default big-button" OnClick="Unnamed6_Click" />
                                <asp:Button runat="server" Text="Users" CssClass="btn btn-default big-button" OnClick="Unnamed7_Click" />
                            </span>
                        </div>

                        <asp:TextBox ID="Output" runat="server" CssClass="form-control form-textarea" TextMode="MultiLine" Height="252px" Width="" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>