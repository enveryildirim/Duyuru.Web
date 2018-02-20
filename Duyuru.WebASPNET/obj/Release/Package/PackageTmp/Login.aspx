<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Duyuru.WebASPNET.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Ekranı</title>
     <meta name="viewport" content=meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge/">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="text-center">
    <div class="col-lg-12">
         <p>Adınız</p> <asp:TextBox ID="txtad" runat="server" ></asp:TextBox>
        </div>
        <div class="col-lg-12">
        <p> Şifreniz</p> <asp:TextBox ID="txtsifre" runat="server" TextMode="Password" ></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Button ID="btngiris" runat="server" Text="Giriş Yap" OnClick="btngiris_Click" />&nbsp; &nbsp; &nbsp;<asp:Button ID="btniptal" runat="server" Text="İptal" OnClick="btniptal_Click" />
        </div>
        <br />
        <hr />
        <div class="col-lg-12">
            <p class="text-danger">
                <asp:Label ID="lbluyari" runat="server" Text="" Font-Size="Large"></asp:Label></p>
        </div>
    </div>
    </form>
</body>
</html>
