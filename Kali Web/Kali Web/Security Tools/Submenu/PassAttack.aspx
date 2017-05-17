<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PassAttack.aspx.cs" Inherits="Kali_Web.Security_Tools.Submenu.Exploit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Hashcat</h2>
            <p>
                Hashcat is the self-proclaimed world’s fastest CPU-based password recovery tool. Versions are available for Linux, OS X, and Windows and can come in CPU-based or GPU-based variants. Examples of hashcat supported hashing algorithms are Microsoft LM hashes, MD4, MD5, SHA-family, Unix Crypt formats, MySQL, Cisco PIX.
            </p>
            <p>
                <a href="/Security Tools/Tool UI/Hashcat.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Ncrack</h2>
            <p>
                Ncrack is a high-speed network authentication cracking tool. It was built to help companies secure their networks by proactively testing all their hosts and networking devices for poor passwords. Security professionals also rely on Ncrack when auditing their clients. 
            </p>
            <p>
                <a href="/Security Tools/Tool UI/ncrack.aspx">Click Here for the tool</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Coming Soon!</h2>
            <p>
                A new tool is in development and will arrive shortly!
            </p>
        </div>
    </div>
</asp:Content>