<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="INF354Project._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Chart ID="Chart1" runat="server" DataSourceID="sdsClient">
        <series>
            <asp:Series Name="Series1" XValueMember="clientId" YValueMembers="furnitureId">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
    <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:Model1 %>" SelectCommand="SELECT * FROM [tblClientFurniture]"></asp:SqlDataSource>

</asp:Content>
