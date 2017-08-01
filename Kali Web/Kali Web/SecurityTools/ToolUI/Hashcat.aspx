<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hashcat.aspx.cs" Inherits="Kali_Web.Security_Tools.Tool_UI.Hashcat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main-content">
        <h2 style="margin-top: 35px">Hashcat - Hash Cracker</h2>
        <h3>DO NOT USE OUTSIDE OF CLASSROOM ENVIRONMENT</h3>

        <%-- Row that appears only when an error occurs --%>
        <%-- It has a red box with an icon as an error message, styling takenf from Bootstrap --%>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                    <div class="alert alert-danger" role="alert">
                        <%-- Alert icon --%>
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Error:</span>
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="Literal1" />
                            =                   
                        </p>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>

        <%-- Container of the form needed to be submitted to execute a specific tool  --%>
        <div class="row" style="padding: 10px; padding-top: 20px;">
            <div class="col-md-12">
                <%-- col-md-offset-2 added to center the box that has 8cols --%>
                <div class="col-md-8 col-md-offset-2  form-box" style="text-align: left">
                    <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="Hash" CssClass="col-md-2 control-label middle-label">Hash</asp:Label>

                        <%-- Input group taken from bootstrap to show the button next to the input --%>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="Hash" CssClass="form-control" Style="display: inline-block; width: 100%;" />
                            <span class="input-group-btn">
                                <asp:Button runat="server" Text="Find" CssClass="btn btn-default" OnClick="Unnamed3_Click" />
                            </span>
                        </div>

                        <asp:TextBox ID="Output" runat="server" CssClass="form-control form-textarea" TextMode="MultiLine" Height="252px" Width="" ReadOnly="True"></asp:TextBox>

                        <asp:Label runat="server" AssociatedControlID="Result" CssClass="col-md-2 control-label middle-label">Result</asp:Label>
                        <asp:TextBox runat="server" ID="Result" CssClass="form-control" Style="display: inline-block; width: 100%;" ReadOnly="True" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
