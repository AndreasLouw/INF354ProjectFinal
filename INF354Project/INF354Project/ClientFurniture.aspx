<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientFurniture.aspx.cs" Inherits="INF354Project.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add Client Furniture</h1>
    <!-- for adding client -->

    <asp:GridView ID="ClFur" EmptyDataText="No records have been added." runat="server" AutoGenerateColumns="False" DataSourceID="sdsClFur" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="clientId" HeaderText="clientId" SortExpression="clientId" />
            <asp:BoundField DataField="furnitureId" HeaderText="furnitureId" SortExpression="furnitureId" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
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


    <asp:SqlDataSource ID="sdsClFur" runat="server" ConnectionString="<%$ ConnectionStrings:Model1 %>" DeleteCommand="DELETE FROM [tblClientFurniture] WHERE [id] = @id" InsertCommand="INSERT INTO [tblClientFurniture] ([clientId], [furnitureId], [date]) VALUES (@clientId, @furnitureId, @date)" SelectCommand="SELECT * FROM [tblClientFurniture]" UpdateCommand="UPDATE [tblClientFurniture] SET [clientId] = @clientId, [furnitureId] = @furnitureId, [date] = @date WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="clientId" Type="Int32" />
            <asp:Parameter Name="furnitureId" Type="Int32" />
            <asp:Parameter DbType="Date" Name="date" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="clientId" Type="Int32" />
            <asp:Parameter Name="furnitureId" Type="Int32" />
            <asp:Parameter DbType="Date" Name="date" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>



    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" GroupingText="Delete" Height="122px" Width="281px">
        <asp:Label ID="lable" runat="server" Text="id "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </asp:Panel>


    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" GroupingText="Add Client Furniture" Height="168px" Width="305px">
        Client Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddCName" runat="server" DataSourceID="sdsClientName" DataTextField="Name" DataValueField="id">
        </asp:DropDownList>
        <br />
        Furniture name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddFName" runat="server" DataSourceID="sdsFurName" DataTextField="Name" DataValueField="id">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnRegister_Click" Text="Add" />
        <asp:SqlDataSource ID="sdsClientName" runat="server" ConnectionString="<%$ ConnectionStrings:Model1 %>" SelectCommand="SELECT [id], [Name] FROM [tblClient]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsFurName" runat="server" ConnectionString="<%$ ConnectionStrings:Model1 %>" SelectCommand="SELECT [id], [Name] FROM [tblFurniture]">
        </asp:SqlDataSource>
        <br />
    </asp:Panel>



    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" GroupingText="Update" Height="205px" Width="299px">
        id to update:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtIDed" runat="server"></asp:TextBox>
        <br />
        Client new id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddCINew" runat="server" DataSourceID="sdsClientName" DataTextField="Name" DataValueField="id">
        </asp:DropDownList>
        <br />
        Furniture new id :&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddFidNew" runat="server" DataSourceID="sdsFurName" DataTextField="Name" DataValueField="id">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
    </asp:Panel>



    <br />
    <br />
    &nbsp;&nbsp;
    <br />
    <br />
     <asp:Panel ID="Panel4" runat="server" GroupingText="Search" Height="107px" Width="299px">
        Name to search:&nbsp;&nbsp;
        <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text=" Search" />
        &nbsp;
        <asp:Button ID="btnRevert" runat="server" OnClick="btnRevert_Click" Text="Revert" />
        <br />
    </asp:Panel>


     <br />


     <asp:Panel ID="Panel5" runat="server" GroupingText="Search with same furniture" Height="107px" Width="299px">
        Name to search:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
         <asp:Button ID="btnSearchSim" runat="server" OnClick="btnSearchSim_Click" Text=" Search" />
        &nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="btnRevert_Click" Text="Revert" />
        <br />
    </asp:Panel>



    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text="err"></asp:Label>
    :<br />&nbsp;&nbsp;&nbsp;
&nbsp;<br />
    <br />
    <asp:ListBox ID="lbxNames" runat="server"></asp:ListBox>
    <br />


</asp:Content>
