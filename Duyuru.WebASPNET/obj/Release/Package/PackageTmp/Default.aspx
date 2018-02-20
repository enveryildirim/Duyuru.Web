<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Duyuru.WebASPNET.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anasayfa</title>
    

    <meta name="viewport" content=meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge/">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
     <script src="~/Scripts/jquery-1.9.1.min.js"></script>
     <script src="~/Scripts/bootstrap.min.js"></script>
</head>
<body style="background-color:#DCDCDC">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
     <div class="col-lg-9">
         <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
                 <div id="divicerik" class="center-block" runat="server"></div>
                 <asp:Timer ID="Timer4" runat="server" Interval="1000" OnTick="Timer4_Tick"></asp:Timer>
             </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Timer4" EventName="Tick" />
             </Triggers>
         </asp:UpdatePanel>
    </div>

    <div class="col-lg-3">
      
            <div class="col-lg-12">
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         <!-- Bugun yemekçiler panel  -->
                        <div class="panel panel-primary">
                        <div class="panel-heading">Bugün Yemekçiler</div>
                         <asp:Literal ID="ltrbugunyemekciler" runat="server"></asp:Literal>
                         </div>
                        <!--Yarın Yemekçiler Panel-->
                         <div class="panel panel-primary">
                        <div class="panel-heading">Yarın Yemekçiler</div>
                         <asp:Literal ID="ltryarinyemekcier" runat="server"></asp:Literal>
                         </div>
                        <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>

        </div>
               

            <div class="col-lg-12"> 
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         <!-- Bugun nobetçiler panel  -->
                        <div class="panel panel-success">
                        <div class="panel-heading">Bugün Nöbetçiler</div>
                         <asp:Literal ID="ltrbugunnobetciler" runat="server"></asp:Literal>
                         </div>
                         <!-- Bugun nobetçiler panel  -->
                        <div class="panel panel-success">
                        <div class="panel-heading">Yarın Nöbetçiler</div>
                        <asp:Literal ID="ltryarinnobetciler" runat="server"></asp:Literal>
                        </div>
                        <asp:Timer ID="Timer2" runat="server" Interval="10000" OnTick="Timer2_Tick"></asp:Timer>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>
                        </asp:UpdatePanel>
            </div>

            <div class="col-lg-12">
               <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         <!-- Bugun kantin panel  -->
                        <div class="panel panel-info bg-danger">
                        <div class="panel-heading">Kantin</div>
                        <h4><asp:Literal ID="ltrkantin" runat="server"></asp:Literal></h4>
                        </div>
                        <asp:Timer ID="Timer3" runat="server" Interval="10000" OnTick="Timer3_Tick"></asp:Timer>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer3" EventName="Tick" />
                    </Triggers>
                        </asp:UpdatePanel>

            </div>
       </div>
  </div>
    </form>
</body>
</html>
