<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="TEWebForms.Rating" Title="Ratings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>All ratings.</h3>
    <asp:GridView ID="gvRatings" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Country" SortExpression="Country">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TE" HeaderText="TE" SortExpression="TE" />
            <asp:BoundField DataField="TE_Outlook" HeaderText="Outlook" SortExpression="TE_Outlook" />
            <asp:BoundField DataField="SP" HeaderText="SP" SortExpression="SP" />
            <asp:BoundField DataField="SP_Outlook" HeaderText="SP_Outlook" SortExpression="SP_Outlook" />
            <asp:BoundField DataField="Moodys" HeaderText="Moodys" SortExpression="Moodys" />
            <asp:BoundField DataField="Moodys_Outlook" HeaderText="Moodys_Outlook" SortExpression="Moodys_Outlook" />
            <asp:BoundField DataField="Fitch" HeaderText="Fitch" SortExpression="Fitch" />
            <asp:BoundField DataField="Fitch_outlook" HeaderText="Fitch_outlook" SortExpression="Fitch_outlook" />
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRatings" TypeName="TEWebForms.Services.RatingService"></asp:ObjectDataSource>
    </asp:Content>

