<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LectStat.aspx.cs" Inherits="Kali_Web.SecurityTools.LectStat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box ">
                <div class="ribbon ribbon-blue">Overall Quiz</div>
                <div class="box-content">
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="342px">
                        <Columns>
                            <asp:BoundField DataField="UserId" HeaderText="Student" SortExpression="UserId">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Category" HeaderText="Quiz" SortExpression="Category">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CorrectAnswers" HeaderText="Score" SortExpression="CorrectAnswers">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAnswers" HeaderText="Full Score" SortExpression="TotalAnswers">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <p style="color:gray; text-align:left;">IG - Information Gathering</p>
                     <p style="color:gray; text-align:left;">VA - Vulnerability Access</p>
                     <p style="color:gray; text-align:left;">PA - Password Attack</p>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT [UserId], [Category], [CorrectAnswers], [TotalAnswers] FROM [QuizzResult]"></asp:SqlDataSource>
                    
                </div>
            </div>
</asp:Content>
