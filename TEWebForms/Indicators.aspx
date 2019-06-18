<%@ Page Async="true" Title="Indicators" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indicators.aspx.cs" Inherits="TEWebForms.Indicators" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>All indicators.</h3>
    <asp:GridView ID="gvIndicators" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="LatestValue" HeaderText="Latest" SortExpression="LatestValue" />
            <asp:BoundField DataField="LatestValueDate" HeaderText="Latest Date" SortExpression="LatestValueDate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Source" HeaderText="Source" SortExpression="Source" />
            <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="Unit" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" Visible="False" />
            <asp:BoundField DataField="CategoryGroup" HeaderText="Group" SortExpression="CategoryGroup" />
            <asp:BoundField DataField="Adjustment" HeaderText="Adjustment" SortExpression="Adjustment" />
            <asp:BoundField DataField="Frequency" HeaderText="Frequency" SortExpression="Frequency" />
            <asp:BoundField DataField="PreviousValue" HeaderText="Previous" SortExpression="PreviousValue" />
            <asp:BoundField DataField="PreviousValueDate" HeaderText="Previous Date" SortExpression="PreviousValueDate" DataFormatString="{0:d}" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetIndicators" TypeName="TEWebForms.Services.IndicatorService"></asp:ObjectDataSource>

</asp:Content>
