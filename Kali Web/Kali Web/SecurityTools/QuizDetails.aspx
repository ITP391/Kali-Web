<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizDetails.aspx.cs" Inherits="Kali_Web.SecurityTools.QuizDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
    <div class="box box-large">
        <div class="ribbon ribbon-green">Quiz Details</div>
        <div class="box-content">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="269px">
            <Columns>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category">
                <HeaderStyle ForeColor="Black" />
                <ItemStyle ForeColor="Black" />
                </asp:BoundField>
                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" >
                <HeaderStyle ForeColor="Black" />
                <ItemStyle ForeColor="Black" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
            <br />
            <asp:Table ID="quizTable" runat="server" Height="111px" Width="265px">
               <asp:TableHeaderRow= runat="server">
                <asp:TableHeaderCell>Quiz</asp:TableHeaderCell>
                <asp:TableHeaderCell>Score</asp:TableHeaderCell>
                <asp:TableHeaderCell>Time</asp:TableHeaderCell>
            </asp:TableHeaderRow>
                <asp:TableRow= runat="server">
                    <asp:TableCell="Password Attack"></asp:TableCell>
                    <asp:TableCell="2/3"></asp:TableCell>
                    <asp:TableCell="30 seconds"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
         <br>
            <p style="color:gray; text-align:left;">IG - Information Gathering</p>
            <p style="color:gray; text-align:left;">VA - Vulnerability Access</p>
            <p style="color:gray; text-align:left;">PA - Password Attack</p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT [Category], [Score] FROM [QuizzResult] WHERE ([UserId] = @UserId)">
        <SelectParameters>
              <asp:Parameter DefaultValue="1" Name="UserId" Type="Int32" />
            </SelectParameters> 
        </asp:SqlDataSource>
        </div>
        </div>
    </div>

        <div class="col-md-4">
        <div class="box box-large">
            <div class ="ribbon ribbon-orange">Your Grade</div>
            <div class ="box-content">
            <br />
       <p> 
           Your Current Grade is:
           <asp:Label ID="grade" runat="server" Font-Italic="True" ForeColor="#333333" Text="Complete all quizzes"></asp:Label>
                </p>
    </div>
    </div>
  </div>
</asp:Content>
