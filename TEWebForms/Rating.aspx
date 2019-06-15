<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="TEWebForms.Rating" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Your application description page.</h3>
    <asp:GridView ID="gvRatings" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" />
            <asp:CheckBoxField DataField="IsCanceled" HeaderText="IsCanceled" ReadOnly="True" SortExpression="IsCanceled" />
            <asp:CheckBoxField DataField="IsCompleted" HeaderText="IsCompleted" ReadOnly="True" SortExpression="IsCompleted" />
            <asp:BoundField DataField="CreationOptions" HeaderText="CreationOptions" ReadOnly="True" SortExpression="CreationOptions" />
            <asp:CheckBoxField DataField="IsFaulted" HeaderText="IsFaulted" ReadOnly="True" SortExpression="IsFaulted" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRatings" TypeName="TECore.Services.RatingService"></asp:ObjectDataSource>
</asp:Content>

