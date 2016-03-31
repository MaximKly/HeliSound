<%@ Page Title="" Language="C#" MasterPageFile="~/HeliSound.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HeliSound.Account.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="divRow">
         <div class="divdata1">
             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="First Name"></asp:Label>
         </div>
         <div class="divdata2">
            <asp:TextBox ID="txtFirstName" runat="server" Font-Size="Large" Width="238px"></asp:TextBox>
         </div>
         <div class="divdata1">
              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Last Name"></asp:Label>
         </div>
         <div class="divdata2">
 <asp:TextBox ID="txtLastName" runat="server" Font-Size="Large" Width="246px"></asp:TextBox>
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
        <asp:TextBox ID="txtApt" runat="server" Width="208px" Font-Size="Large"></asp:TextBox>
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
        <asp:TextBox ID="txtProvince" runat="server" Font-Size="Large" Width="211px"></asp:TextBox>
        </div>
    
    </div>

    <div class="divRow">
        <div class="divdata1">
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Postal Code"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtPostalCode" runat="server" Font-Size="Large"></asp:TextBox>
        </div>
        <div class="divdata1">
         <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Email"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtEmail" runat="server" Font-Size="Large" 
    Width="261px"></asp:TextBox>
        </div>
    </div>

    <div class="labeluser">
    <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Password & Security Questions" ForeColor="#3333FF"></asp:Label>
  </div>

    <div class="divRow">
        <div class="divdata1">
            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Password"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtPassword" runat="server" Font-Size="Large" Width="104px" TextMode="Password"></asp:TextBox>
        </div>
        <div class="divdata1">
           <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Confirm"></asp:Label>
        </div>
        <div class="divdata2">
        <asp:TextBox ID="txtConfirm" runat="server" Font-Bold="False" Font-Size="Large" TextMode="Password"></asp:TextBox>
        </div>
    </div>

        <div class = "divRow">
        <div class = "divdata1">
            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Secret Question"></asp:Label>
        </div>
        <div class = "divdata2">
        <asp:TextBox ID="txtQuestion" runat="server" Font-Size="Large" 
    Width="153px"></asp:TextBox>
        </div>
        <div class = "divdata1">
        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="Answer"></asp:Label>
        </div>
        <div class = "divdata2">
        <asp:TextBox ID="txtAnswer" runat="server" Font-Size="Large" Width="211px"></asp:TextBox>
        </div>
</div>
    <div>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
<div class="divRowbutton">
    <div class="divCenter">
<asp:Button ID="btnSave" runat="server" Font-Bold="True" Font-Size="Large" 
    Text="Save" onclick="btnSave_Click" CssClass="button" />


<asp:Button ID="btnClear" runat="server" Font-Bold="True" Font-Size="Large" 
    Text="Clear" onclick="btnClear_Click" CssClass="button" />
    </div>
</div>
</asp:Content>
