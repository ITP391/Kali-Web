<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wireshark.aspx.cs" Inherits="Kali_Web.Security_Tools.Wireshark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Wireshark - Packet Analyser</h2>
    <h3>DO NOT USE OUTSIDE OF CLASSROOM ENVIRONMENT</h3>

    <div class="main-content">


        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
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

                        <div class="input-group">
                            <!--<asp:TextBox runat="server" ID="IP" CssClass="form-control" Style="display: inline-block; width: 100%;" />-->
                            <span class="input-group-btn">
                                <asp:Button runat="server" Text="Run Wireshark" CssClass="btn btn-default" OnClick="Unnamed3_Click" Style="display: inline-block; width: 100%;" />
                            </span>
                        </div>

                        <asp:TextBox ID="Output" runat="server" CssClass="form-control form-textarea" TextMode="MultiLine" Height="252px" Width="" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
