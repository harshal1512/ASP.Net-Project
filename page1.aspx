<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="Asp.net.page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="txtuserid" runat="server"></asp:TextBox><br />
    <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox><br />
    <asp:Button ID="Btnnextpage" runat="server" Text="Next Page" OnClick="Btnnextpage_Click" />

</asp:Content>
