<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="TEWebForms.Rating" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Your application description page.</h3>
    <asp:GridView ID="gvRatings" runat="server" AutoGenerateColumns="true" ItemType="TEWebForms.Models.Responses.RatingResponse">
        
    </asp:GridView>
    </asp:Content>

