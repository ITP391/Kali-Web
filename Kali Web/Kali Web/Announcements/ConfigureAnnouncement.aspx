<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfigureAnnouncement.aspx.cs" Inherits="Kali_Web.Announcements.ConfigureAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    
    <br />
    <h3>View announcement:</h3>
    <hr />
    <br />
    <div class="col-md-10 column col-md-offset-1">
        <asp:Repeater ID="AnnouncementRepeater" runat="server" OnItemDataBound="ItemBound" >
            <ItemTemplate>
                <div class="panel panel-default">

                    <%-- QUIZ: This is the description of the question --%>
                    <div class="panel-heading" style="text-align: left;">
                        <strong> <%# DataBinder.Eval(Container.DataItem, "Description") %> </strong> (from  <%# DataBinder.Eval(Container.DataItem, "StartDate") %> until  <%# DataBinder.Eval(Container.DataItem, "EndDate") %>)   
                        <a runat="server" onserverclick="DeleteAnnouncement" announcement-id='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                            <span class="glyphicon glyphicon-remove" style="float: right; cursor:pointer" aria-hidden="true"></span>
                        </a>
                        <span class="glyphicon glyphicon-align-justify" style="float: right; margin-right: 10px; cursor: pointer" aria-hidden="true" data-toggle="collapse" data-target="#list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>"></span>
                    </div>

                    <%-- QUIZ: This is a list of possible answers --%>
                    <ul id="list-group-<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-align: left" class="list-group collapse">
                        <asp:Repeater ID="AnnouncementAnswersRepeater" runat="server">
                            <ItemTemplate>
                                <li class="list-group-item"><%# DataBinder.Eval(Container.DataItem, "Response") %> (from <%# DataBinder.Eval(Container.DataItem, "FirstName") %> <%# DataBinder.Eval(Container.DataItem, "LastName") %>) </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <div class="row">
        <div class="col-md-2 col-md-offset-5">
            <div class="btn-group" style="margin-top: 20px">
                <a href="./AddAnnouncement.aspx">
                    <button class="btn btn-default btn-lg" type="button" >
                        Add announcement
                    </button>
                </a>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
