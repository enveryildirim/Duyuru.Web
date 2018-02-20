<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Duyuru.WebASPNET.Yonetim.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-lg-12">
         <p>Adınız</p> <asp:TextBox ID="txtad" runat="server" ValidationGroup="a" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ad  Boş Olamaz" ControlToValidate="txtad" ValidationGroup="a">***</asp:RequiredFieldValidator>
        </div>
        <div class="col-lg-12">
        <p>Şifreniz</p> <asp:TextBox ID="txtsifre" runat="server" TextMode="Password" ValidationGroup="a" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Sifre Boş olamaz" ControlToValidate="txtsifre" ValidationGroup="a">***</asp:RequiredFieldValidator>
        </div>
        <div class="col-lg-12">
        <p> Yeni Şifreniz</p> <asp:TextBox ID="txtyenisifre" runat="server" TextMode="Password" ValidationGroup="a"  ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Boş olamaz" ControlToValidate="txtyenisifre" ValidationGroup="a">***</asp:RequiredFieldValidator>
        </div>
        <div class="col-lg-12">
         <p>Yeni Şifreniz(Tekrar)</p> <asp:TextBox ID="txtyenisifretekrar" runat="server" TextMode="Password" ValidationGroup="a"  ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="boş olamaz" ControlToValidate="txtyenisifretekrar" ValidationGroup="a">***</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Şifreler Aynı Değil " ControlToCompare="txtyenisifre" ControlToValidate="txtyenisifretekrar">---</asp:CompareValidator>
        </div>
        
        <hr />
        <div class="col-lg-12">
          <asp:Button ID="btnguncelle" runat="server" Text="Guncelle" OnClick="btnguncelle_Click" ValidationGroup="a" /> &nbsp; &nbsp; &nbsp;<asp:Button ID="btniptal" runat="server" Text="İptal" OnClick="btniptal_Click" />
        </div>
         <div class="col-lg-12">
             <asp:Label ID="lblhata" runat="server" Text="">

             </asp:Label><asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Uyarılar" ValidationGroup="a" ShowMessageBox="True" ShowModelStateErrors="False" />
        </div>
    </div>
</asp:Content>
