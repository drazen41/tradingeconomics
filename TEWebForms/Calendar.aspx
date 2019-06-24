<%@ Page Culture ="auto" UICulture="auto" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="TEWebForms.Calendar" Title="Events" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server" >
    <link href="/TEWebForms/Content/flags.css" rel="stylesheet" />
    <script src="/TEWebForms/Scripts/calendar.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>
            <br />
            <table style="width:100%">
                <tbody>
                    <tr id="buttons">
                        <td >
                             <div class="btn-group">
    <button class ="btn btn-default" type="submit" onclick="toggleCountries()" runat="server" id="btnCountries" onserverclick="btnCountries_ServerClick"   >
        <i class="glyphicon glyphicon-globe"></i>
        &nbsp;Countries&nbsp;
        <span class="caret"></span>
    </button>
    
    <div class="btn-group">
 
    <button class ="btn btn-default" type="button">
        <i class="glyphicon glyphicon-calendar"></i>
        &nbsp;Dates&nbsp;
        <span class="caret"></span>
    </button>
    </div>
<div class="btn-group">
    <button class ="btn btn-default" type="button">
        <i class="glyphicon glyphicon-star"></i>
        &nbsp;Impact&nbsp;
        <span class="caret"></span>
    </button>
    </div>
        <div class="btn-group">                    
    <button class ="btn btn-default" type="button">
        
        &nbsp;UTC&nbsp;
        <span class="caret"></span>
    </button>
    </div></div>
                        </td>
                        <td>
                           
                        </td>
                       
                    </tr>
                </tbody>
            </table>

   <asp:Panel runat="server" ID="pnlCountries" OnPreRender="pnlCountries_PreRender"   >
       
   </asp:Panel>
   <br /><br />
    <asp:Repeater ID="rptCalendar" runat="server" OnItemDataBound="rptCalendar_ItemDataBound"  >
        <HeaderTemplate>
            <table  style="width:80%;" >  
   <%--<tr style="background-color:lightgray;margin:2px;border:solid 1px; border-color:lightcyan; padding:5px; font-size:large">
                <td colspan="3"><asp:Label ID="labelDate" runat="server" Text='<%#string.Format("{0:D}",Eval("Date")) %>'  /></td>
                <td>Actual</td>
                <td>Previous</td>
                <td>Forecast</td>
            </tr>--%>
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
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCalendars" TypeName="TEWebForms.Services.CalendarService"></asp:ObjectDataSource>
        </asp:Content>

