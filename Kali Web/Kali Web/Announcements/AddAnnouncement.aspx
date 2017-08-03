<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAnnouncement.aspx.cs" Inherits="Kali_Web.Announcements.AddAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <br />
    <h3>Add a new announcement:</h3>
    <hr />
    <br />
    <div class="col-md-10 column col-md-offset-1">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Add a new text question:
                </h3>
            </div>
            
            <%-- QUIZ: This is asp markup for the dropdown list of questions categories--%>
            <div class="panel-body">
                <div class="form-group" >
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="AnnouncementTextLabel" runat="server" Text="Announcement:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="AnnouncementTextBox" runat="server" class="form-control"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AnnouncementTextBox"
                                                    CssClass="text-danger pull-left" ErrorMessage="Announcement description is required." />
                    </div>
                </div>
                <div style="clear:both"></div>
                
                <%-- QUIZ: This is the input for the questions description--%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label1" runat="server" Text="Start date:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="StartDateTextBox" runat="server" class="form-control" placeholder="DD-MM-YYYY" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="LabelStartDateError" runat="server" CssClass="text-danger pull-left"></asp:Label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="StartDateTextBox"
                                                    CssClass="text-danger pull-left" ErrorMessage="Start date is required." />
                    </div>
                </div>
                
                <%-- QUIZ: This is the input for the correct answer --%>
                <div class="form-group">
                    <asp:Label class="col-xs-3 control-label text-left" Font-Size="20px" ID="Label2" runat="server" Text="End date:"></asp:Label>
                    <div class="col-xs-8">
                        <asp:TextBox ID="EndDateTextBox" runat="server" class="form-control" placeholder="DD-MM-YYYY" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="LabelEndDateError" runat="server" CssClass="text-danger pull-left"></asp:Label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="EndDateTextBox"
                                                    CssClass="text-danger pull-left" ErrorMessage="End date is required." />
                    </div>
                </div>
                
                <%-- QUIZ: This is button for adding the announcement--%>
                <div class="form-group">
                    <div class="col-xs-4 col-md-offset-4">
                        <asp:Button 
                            ID="Button1"
                            runat="server"
                            class="btn btn-success" 
                            Text="Add question" 
                            OnClick="AddAnnouncement_Callback" />
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
