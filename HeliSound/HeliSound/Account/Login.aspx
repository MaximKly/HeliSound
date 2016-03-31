<%@ Page Title="" Language="C#" MasterPageFile="~/HeliSound.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HeliSound.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">  
    <div class="divRow">
    <div class="divCol1"> 
        <asp:Label ID="Label1" runat="server" Text="Email" Font-Bold="true" Font-Size="Large"></asp:Label>
    </div>               
    <div class="divCol2">
        <asp:TextBox ID="txtLogin" runat="server" ></asp:TextBox>
    </div>
    </div>    
    <div class="divRow">         
    <div class="divCol1">
        <asp:Label ID="Label2" runat="server" Text="Password" Font-Bold="true" Font-Size="Large"></asp:Label>
    </div>                      
    <div class="divCol2">           
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    </div>
    <div class="divRow">   
    <div class="divCol1">
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Font-Bold="true" Font-Size="Medium"/>
    </div>                      
    <div class="divCol2">            
        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" ForeColor="#CC0000" Font-Size="Large"></asp:Label>
    </div>
    </div>

    <div class="divRowbutton"">
    <div class="divCol1">        
        <asp:LinkButton ID="lnkCreate" runat="server" Font-Bold="true" Font-Size="Large" PostBackUrl="~/Account/Profile.aspx?Sess=0">Create Profile</asp:LinkButton>
    </div>
        </div>
        </div>
</asp:Content>
