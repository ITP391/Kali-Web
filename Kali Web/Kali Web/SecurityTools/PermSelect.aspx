<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PermSelect.aspx.cs" Inherits="Kali_Web.SecurityTools.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <!-- add some codes for teacher side - add show/hide buttons, add list of students-->
    <div class="row main-content">
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-blue">Permissions</div>
                <div class="box-content">
                    <p>Set permissions by individuals</p>
                    <p class="tool-link"><a href="/SecurityTools/Permissions.aspx" class="button">Go</a> </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="box">
                <div class="ribbon ribbon-green">Permissions</div>
                <div class="box-content">
                    <p>Set permissions by module groups</p>
                    <p class="tool-link">          
                        <a href="/SecurityTools/ModGrps.aspx" class="button">Go</a>
                    </p>
                </div>
            </div>
        </div>
     
  
     
   
    </div>
</asp:Content>
