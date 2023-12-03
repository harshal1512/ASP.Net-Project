<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="Asp.net.page2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:TextBox ID="txtuserid" runat="server"></asp:TextBox><br />
   <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnprevious" runat="server" Text="previous" OnClick="btnprevious_Click" />
</asp:Content>
