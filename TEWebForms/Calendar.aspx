<%@ Page Culture ="auto" UICulture="auto" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="TEWebForms.Calendar" Title="Events" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server" >
    <link href="/TEWebForms/Content/flags.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:Repeater ID="rptCalendar" runat="server" OnItemDataBound="rptCalendar_ItemDataBound"  >
        <HeaderTemplate>
            <table  style="width:80%;" >  
   
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="background-color:lightgray;margin:2px;border:solid 1px; border-color:lightcyan; padding:5px; font-size:large">
                <td colspan="3"><asp:Label ID="labelDate" runat="server" Text='<%#string.Format("{0:D}",Eval("Date")) %>'  /></td>
                <td>Actual</td>
                <td>Previous</td>
                <td>Forecast</td>
            </tr>
            <asp:Repeater ID="rtpDetails" runat="server" OnItemDataBound="rptDetails_ItemDataBound" >
                <ItemTemplate>
                    <tr style="margin:2px;border:solid 1px; border-color:lightcyan;">
                        <asp:HiddenField id="hfCountry" runat="server"  />
                <td>
                   <div style="width:70%" class ="calendarTime"><asp:Label  ID="lblDate" runat="server" Text='<%#string.Format("{0:t}",Eval("Date")) %>' /></div> 
                </td>
                        <td>
                    <%--<asp:Label ID="Label2" runat="server" Text='<%#Eval("Country") %>' />--%>
                            <asp:Table ID="tblCountry" runat="server" ></asp:Table>
                </td>
                        <td>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Event") %>' />
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

