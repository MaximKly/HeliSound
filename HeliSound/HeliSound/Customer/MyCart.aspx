<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="HeliSound.Customer.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divBody">
        <div style="margin-top:12px;">
            <asp:GridView ID="gvMyCart" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvMyCart_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvMyCart_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" SortExpression="ProductID" />
                    <asp:BoundField DataField="CategoryID" HeaderText="Category" ReadOnly="True" SortExpression="CategoryID" />
                    <asp:BoundField DataField="ManufacturerID" HeaderText="Manufacturer" ReadOnly="True" SortExpression="ManufacturerID" />
                    <asp:BoundField DataField="Model" HeaderText="Model" ReadOnly="True" SortExpression="Model" />
                    <asp:BoundField DataField="Descrption" HeaderText="Description" ReadOnly="True" SortExpression="Descrption" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
                    <asp:CommandField HeaderText="Delete" ShowHeader="True" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <asp:Panel ID="pnlCustomerInfo" runat="server">
            <div class="divCenter">           
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Payment Method" ForeColor="#3333FF"></asp:Label> 
                        &nbsp;<asp:DropDownList ID="dlPayment" runat="server" Font-Bold="True">
                            <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="1">Visa</asp:ListItem>
                            <asp:ListItem Value="2">Master Card</asp:ListItem>
                            <asp:ListItem Value="3">AmEx</asp:ListItem>
                        </asp:DropDownList>
                        </div>
 <div class="divRow">
         <div class="divdata1">
             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Card Holder Name"></asp:Label>
         </div>
         <div class="divdata2">
            <asp:TextBox ID="txtCardHolderName" runat="server" Font-Size="Large" Width="273px" style="margin-left: 0px"></asp:TextBox>
         </div>
         <div class="divdata1">
              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Card Number"></asp:Label>
         </div>
         <div class="divdata2">
 <asp:TextBox ID="txtCardNumber" runat="server" Font-Size="Large" Width="273px"></asp:TextBox>
         </div>
    </div>
    <div class="divRow">
         <div class="divdata1">
             <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Expiry Date"></asp:Label>
         </div>
         <div class="divdata2">
             <asp:DropDownList ID="dlMonth" runat="server">
                 <asp:ListItem Selected="True" Value="-1">Month</asp:ListItem>
                 <asp:ListItem>01</asp:ListItem>
                 <asp:ListItem>02</asp:ListItem>
                 <asp:ListItem>03</asp:ListItem>
                 <asp:ListItem>04</asp:ListItem>
                 <asp:ListItem>05</asp:ListItem>
                 <asp:ListItem>06</asp:ListItem>
                 <asp:ListItem>07</asp:ListItem>
                 <asp:ListItem>08</asp:ListItem>
                 <asp:ListItem>09</asp:ListItem>
                 <asp:ListItem>10</asp:ListItem>
                 <asp:ListItem>11</asp:ListItem>
                 <asp:ListItem>12</asp:ListItem>
             </asp:DropDownList>
             &nbsp;<asp:DropDownList ID="dlYear" runat="server">
                 <asp:ListItem Selected="True" Value="-1">Year</asp:ListItem>
                 <asp:ListItem>2015</asp:ListItem>
                 <asp:ListItem>2016</asp:ListItem>
                 <asp:ListItem>2017</asp:ListItem>
                 <asp:ListItem>2018</asp:ListItem>
                 <asp:ListItem>2019</asp:ListItem>
                 <asp:ListItem>2020</asp:ListItem>
                 <asp:ListItem>2021</asp:ListItem>
                 <asp:ListItem>2022</asp:ListItem>
                 <asp:ListItem>2023</asp:ListItem>
                 <asp:ListItem>2024</asp:ListItem>
                 <asp:ListItem>2025</asp:ListItem>
             </asp:DropDownList>
         </div>
         <div class="divdata1">
              <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="CVC"></asp:Label>
         </div>
         <div class="divdata2">
 <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large" Width="273px"></asp:TextBox>
         </div>
    </div>
   
   
   <div class="labeluser">
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Shipping Address" ForeColor="#3333FF"></asp:Label>
  </div>

   
   <div class="divRow">
        <div class="divdata1">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Street Address"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtStreetAddress" runat="server" Width="273px" 
    Font-Size="Large"></asp:TextBox>
        </div>
        <div class="divdata1">
         <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Apt #"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtApt" runat="server" Width="100px" Font-Size="Large"></asp:TextBox>
        </div>
   
   </div>

    <div class = "divRow">
        <div class = "divdata1">
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="City"></asp:Label>
        </div>
        <div class = "divdata2">
        <asp:TextBox ID="txtCity" runat="server" Font-Size="Large" 
    Width="153px"></asp:TextBox>
        </div>
        <div class = "divdata1">
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Province"></asp:Label>
        </div>
        <div class = "divdata2">
        <asp:TextBox ID="txtProvince" runat="server" Font-Size="Large" Width="100px"></asp:TextBox>
        </div>
    
    </div>

    <div class="divRow">
        <div class="divdata1">
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Postal Code"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtPostalCode" runat="server" Font-Size="Large" Width="153px"></asp:TextBox>
        </div>
        <div class="divdata1">
         <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Email"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtEmail" runat="server" Font-Size="Large" 
    Width="273px"></asp:TextBox>
        </div>
    </div>


    <div>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
        </asp:Panel>
<div class="divCenter">
<asp:Button ID="btnPurchase" runat="server" Font-Bold="True" Font-Size="Large" 
    Text="Purchase" CssClass="button" OnClick="btnPurchase_Click" />
<asp:Button ID="btnEmpty" runat="server" Font-Bold="True" Font-Size="Large" 
    Text="Empty Cart" CssClass="button" OnClick="btnEmpty_Click" />
    </div>
        <div>
            <asp:Label ID="lblClear" runat="server" Text=""></asp:Label></div>
    </div>
</asp:Content>
