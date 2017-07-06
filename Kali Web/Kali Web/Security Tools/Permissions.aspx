<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.cs" Inherits="Kali_Web.Security_Tools.StudList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- add codes to show list of students from database-->
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Email_Address" HeaderText="Email_Address" SortExpression="Email_Address" />
                <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                <asp:BoundField DataField="Phone_Number" HeaderText="Phone_Number" SortExpression="Phone_Number" />
                <asp:BoundField DataField="Permission" HeaderText="Permission" SortExpression="Permission" />
                <asp:CheckBoxField DataField="IGAccess" HeaderText="IGAccess" SortExpression="IGAccess" />
                <asp:CheckBoxField DataField="VAAccess" HeaderText="VAAccess" SortExpression="VAAccess" />
                <asp:CheckBoxField DataField="PWAccess" HeaderText="PWAccess" SortExpression="PWAccess" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT [Id], [Email_Address], [FName], [LName], [Phone_Number], [Permission], [IGAccess], [VAAccess], [PWAccess] FROM [User] WHERE ([Permission] = @Permission)">
            <SelectParameters>
                <asp:Parameter DefaultValue="student" Name="Permission" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
</asp:Content>
