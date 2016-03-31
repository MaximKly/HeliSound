<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Customer.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HeliSound.Customer.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="button">
    <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" OnClick="btnLogout_Click" />
        </div>
</asp:Content>
