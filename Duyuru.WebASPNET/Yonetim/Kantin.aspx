<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.Master" AutoEventWireup="true" CodeBehind="Kantin.aspx.cs" Inherits="Duyuru.WebASPNET.Yonetim.Kantin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  Kantin =  <asp:Label ID="lbldurum" runat="server" Text=""></asp:Label> &nbsp; ||||&nbsp;  <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
</asp:Content>
