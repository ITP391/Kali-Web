<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnswerAnnouncement.aspx.cs" Inherits="Kali_Web.Announcements.AnswerAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <h3>Answer announcement:</h3>
    <hr />
    <br />
    <div class="col-md-10 column col-md-offset-1">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title text-left">
                    <asp:Label class="text-left" ID="AnnouncementDescription" runat="server"></asp:Label>
                </h3>
            </div>
            
            <div class="panel-body">
                <div class="form-group" >
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="AnnouncementTextLabel" runat="server" Text="Answer:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="AnswerTextBox" runat="server" class="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AnswerTextBox"
                                                    CssClass="text-danger pull-left" ErrorMessage="Answer is required." />
                    </div>
                </div>
                

                <div class="form-group">
                    <div class="col-xs-4 col-md-offset-4">
                        <asp:Button 
                            ID="Button1"
                            runat="server"
                            class="btn btn-success" 
                            Text="Answer" 
                            OnClick="AnswerAnnouncement_Callback" />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
