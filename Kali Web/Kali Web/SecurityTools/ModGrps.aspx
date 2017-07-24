<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModGrps.aspx.cs" Inherits="Kali_Web.SecurityTools.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound = "OnRowDataBound">
            <Columns>
                <asp:BoundField DataField="ModGrp" HeaderText="Module Group" SortExpression="ModGrp" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="IGAcc" DataField="IGAccess" HeaderText="IGAccess" SortExpression="IGAccess" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        Information Gathering Access
                    </HeaderTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="VAA" DataField="VAAccess" HeaderText="VAAccess" SortExpression="VAAccess" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        Vulnerability Analysis Access
                    </HeaderTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="PWA" DataField="PWAccess" HeaderText="PWAccess" SortExpression="PWAccess" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        Password Attack Access
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localdbConnectionString1 %>" SelectCommand="SELECT DISTINCT [ModGrp], [IGAccess], [VAAccess], [PWAccess] FROM [User] WHERE ([Permission] = @Permission)">
            <SelectParameters>
                <asp:Parameter DefaultValue="student" Name="Permission" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />

    </div>

</asp:Content>
