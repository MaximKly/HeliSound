<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="HeliSound.Customer.Receipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divBody">
        <div class="margin-top:12px;">
            <asp:GridView ID="gvReceipt" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="gvReceipt_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="Category" ReadOnly="True" SortExpression="CategoryID" />
                    <asp:BoundField DataField="Model" HeaderText="Model" ReadOnly="True" SortExpression="Model" />
                    <asp:BoundField DataField="PaidEach" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    <div class="divRow">
        <div class="divCol1">
            <asp:Label ID="Label1" runat="server" Text="Order total"></asp:Label>
        </div>
        <div class="divCol2">
            <asp:TextBox ID="txtOrderTotal" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
            <div class="divRow">
        <div class="divCol1">
            <asp:Label ID="Label2" runat="server" Text="Taxes"></asp:Label>
        </div>
        <div class="divCol2">
            <asp:TextBox ID="txtTaxes" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
            <div class="divRow">
        <div class="divCol1">
            <asp:Label ID="Label3" runat="server" Text="Order total"></asp:Label>
        </div>
        <div class="divCol2">
            <asp:TextBox ID="txtSubTotal" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    </div>
</asp:Content>
