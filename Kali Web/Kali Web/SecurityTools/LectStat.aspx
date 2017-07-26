<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LectStat.aspx.cs" Inherits="Kali_Web.SecurityTools.LectStat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box">
                <div class="ribbon ribbon-blue">Students' Progress</div>
                <div class="box-content">
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CorrectAnswers" HeaderText="CorrectAnswers" SortExpression="CorrectAnswers">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAnswers" HeaderText="TotalAnswers" SortExpression="TotalAnswers">
                            <HeaderStyle ForeColor="Black" />
                            <ItemStyle ForeColor="Black" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT [Category], [CorrectAnswers], [TotalAnswers] FROM [QuizzResult]"></asp:SqlDataSource>
                    
                </div>
            </div>
</asp:Content>
