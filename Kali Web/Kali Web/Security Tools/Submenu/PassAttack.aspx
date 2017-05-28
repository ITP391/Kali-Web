<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PassAttack.aspx.cs" Inherits="Kali_Web.Security_Tools.Submenu.Exploit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row main-content">
        <%--Container for a box of a category--%>
        <div class="col-md-4">
            <div class="box box-large">
                <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-blue">Hashcat</div>
                <div class="box-content">
                    <p>Hashcat is the self-proclaimed world’s fastest CPU-based password recovery tool. Versions are available for Linux, OS X, and Windows and can come in CPU-based or GPU-based variants. Examples of hashcat supported hashing algorithms are Microsoft LM hashes, MD4, MD5, SHA-family, Unix Crypt formats, MySQL, Cisco PIX.</p>
                    <p class="tool-link"><a href="/Security Tools/Tool UI/Hashcat.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>  
         <%--Container for a box of a category--%>
        <div class="col-md-4">
            <div class="box box-large">   
                <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-green">Ncrack</div>
                <div class="box-content">
                    <p>Ncrack is a high-speed network authentication cracking tool. It was built to help companies secure their networks by proactively testing all their hosts and networking devices for poor passwords. Security professionals also rely on Ncrack when auditing their clients.</p>
                    <p class="tool-link"><a href="/Security Tools/Tool UI/ncrack.aspx" class="button">Click Here for the tool</a> </p>
                </div>
            </div>
        </div>         
        <%--Container for a box of a category--%>
        <div class="col-md-4">
           <div class="box box-large">       
               <%-- Ribbon container of a box --%> 
                <div class="ribbon ribbon-orange">Coming Soon!</div>
                <div class="box-content">
                    <p>A new tool is being developed and tested and will arrive shortly!</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>