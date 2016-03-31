<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="HeliSound.Customer.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="pnlDropDowns" runat="server">
            <div class="divRow">
                <div class="divdata1">
                    <asp:Label ID="Label1" runat="server" Text="Select Category" CssClass="lblHeading1"></asp:Label>
                </div>
                <div class="divdata1">
                    <asp:DropDownList ID="dlCategory" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="dlCategory_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="-1">Select </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="divdata1">
                    <asp:Label ID="Label2" runat="server" Text="Manufacturer" CssClass="lblHeading1"></asp:Label>
                </div>
                <div class="divdata1">
                    <asp:DropDownList ID="dlManufacturer" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="dlManufacturer_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="divdata1">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>       
        </asp:Panel>
    </div>
    <div>
    <div class="divcoloumnLeft">
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" Width="66%" OnRowDataBound="gvProducts_RowDataBound" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ManufacturerID" HeaderText="Manufacturer" ReadOnly="True" SortExpression="ManufacturerID" />
                <asp:BoundField DataField="Model" HeaderText="Model" ReadOnly="True" SortExpression="Model" />
                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
        <div class="divcolumnRight">
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtCategory" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="Label4" runat="server" Text="Manufacturer"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtManf" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="Label5" runat="server" Text="Model"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtModel" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtSize" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="Label6" runat="server" Text="Description"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtDescrption" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                    <asp:Label ID="Label8" runat="server" Text="Price"></asp:Label>
                </div>
                <div class="divdata2">
                    <asp:TextBox ID="txtPrice" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="divRow">
                <div class="divdata2">
                <asp:Button ID="btnCart" runat="server" Text="ADD TO CART" OnClick="btnCart_Click" Width="103px" />
                </div>
                <div class="divdata2">
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </div>
            </div>
                
        </div>
    </div>
</asp:Content>
