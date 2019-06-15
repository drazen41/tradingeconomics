<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="TEWebForms.Rating" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Your application description page.</h3>
    <asp:GridView ID="gvRatings" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            <asp:BoundField DataField="TE" HeaderText="TE" SortExpression="TE" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="Agency" HeaderText="Agency" SortExpression="Agency" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
            <asp:BoundField DataField="Outlook" HeaderText="Outlook" SortExpression="Outlook" />
            <asp:BoundField DataField="TE_Outlook" HeaderText="TE_Outlook" SortExpression="TE_Outlook" />
            <asp:BoundField DataField="SP" HeaderText="SP" SortExpression="SP" />
            <asp:BoundField DataField="SP_Outlook" HeaderText="SP_Outlook" SortExpression="SP_Outlook" />
            <asp:BoundField DataField="Moodys" HeaderText="Moodys" SortExpression="Moodys" />
            <asp:BoundField DataField="Moodys_Outlook" HeaderText="Moodys_Outlook" SortExpression="Moodys_Outlook" />
            <asp:BoundField DataField="Fitch" HeaderText="Fitch" SortExpression="Fitch" />
            <asp:BoundField DataField="Fitch_outlook" HeaderText="Fitch_outlook" SortExpression="Fitch_outlook" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRatings" TypeName="TEWebForms.Services.RatingService"></asp:ObjectDataSource>
</asp:Content>

