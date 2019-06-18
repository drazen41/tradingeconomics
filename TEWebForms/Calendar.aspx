<%@ Page Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="TEWebForms.Calendar" Title="Events" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>All events.</h3>
    <asp:Repeater ID="rptCalendar" runat="server" >
        <HeaderTemplate>
            <table style="border:1px solid #0000FF; width:500px" cellpadding="0">  
    <%--<tr style="background-color:#FF6600; color:#000000; font-size: large; font-weight: bold;">  
    <td >  
    <b><asp:Label ID="lblDate" runat="server" Text='<%#Bind("Date") %>' /></b>  
        <td></td>
          <td></td>
          <td></td>
    </td>  
    </tr>  --%>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="labelDate" runat="server" Text='<%#FormatiranDatum(Eval("Date").ToString()) %>' /></td>
                <td>Actual</td>
                <td>Previous</td>
                <td>Forecast</td>
            </tr>
            <asp:Repeater ID="rtpDetails" runat="server">
                <ItemTemplate>
                    <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' />
                </td>
                <td>
                    <asp:Label ID="lblActual" runat="server" Text='<%#Eval("Actual") %>' />
                </td>
                <td>
                    <asp:Label ID="lblPrevious" runat="server" Text='<%#Eval("Previous") %>' />
                </td>
                <td>
                    <asp:Label ID="lblForecast" runat="server" Text='<%#Eval("Forecast") %>' />
                </td>
            </tr>
                </ItemTemplate>
                
            </asp:Repeater>
            

        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCalendars" TypeName="TEWebForms.Services.CalendarService"></asp:ObjectDataSource>
    </asp:Content>

