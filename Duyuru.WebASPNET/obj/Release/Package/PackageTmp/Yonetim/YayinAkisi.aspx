<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.Master" AutoEventWireup="true" CodeBehind="YayinAkisi.aspx.cs" Inherits="Duyuru.WebASPNET.Yonetim.YayinAkisi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
           
            $(document.getElementById('<%=txtsontarih.ClientID%>')).datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6">
<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table class="table table-hover">
                    <thead>
                        <tr>
                        <th>
                            İşlemler
                        </th>
                        <th>
                            Başlık
                        </th>
                        <th>
                           Url
                        </th>
                        <th>
                          Ekleyen
                        </th>
                    </tr>
                         </thead>
            </HeaderTemplate>
            <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                 <tr>
                   <th scope="row">
                       <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs"  CommandName="g" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "IcerikID")%>'>Yayınla</asp:LinkButton>  
                       <td>
                        <%#Eval("Baslik")%> 
                    </td>
                      <td>
                        <%#Eval("IcerikURL")%> 
                    </td>
                     <td>
                        <%#Eval("Yoneticiler.AdSoyad")%> 
                    </td>
                </tr>
            </ItemTemplate>
            
            <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr>
                    <td colspan="4">
                        
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate><!-- son satırda tabloyu kapayıyoruz  -->
                  </tbody>
                </table>
            </FooterTemplate>
    </asp:Repeater>        
    </div>
    <div class="col-lg-6">
        <div class="col-lg-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />İçerik Başlığı :
            <asp:Label ID="lblbaslik" runat="server" Text="" CssClass="text-info"></asp:Label> 
            <p>Gösterim Süresi(sn)</p>
            <asp:TextBox ID="txtsuresi" runat="server"></asp:TextBox>
            <p>Son Gösterim Tarihi</p>
            <asp:TextBox ID="txtsontarih" runat="server"></asp:TextBox>
            <asp:Button ID="btnkaydet" runat="server" CssClass="btn btn-success" Text="Kaydet" OnClick="btnkaydet_Click" />
        </div>
        <hr />
        <div class="col-lg-12">
            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
            <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table class="table table-hover">
                    <thead>
                        <tr>
                        <th>
                            İşlemler
                        </th>
                        <th>
                            Baslık
                        </th>
                        <th>
                           Gosterim Suresi
                        </th>
                         <th>
                          Son Gosterim
                        </th>
                       
                    </tr>
                         </thead>
            </HeaderTemplate>
            <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                 <tr>
                   <th scope="row">
                       <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs"  CommandName="g" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "YayinAkisiID")%>'>Güncelle</asp:LinkButton> ||  <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-danger btn-xs"  CommandName="s" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"YayinAkisiID")%>'>Sil</asp:LinkButton> 
                       <td>
                        <%#Eval("Icerikler.Baslik")%> 
                    </td>
                      <td>
                        <%#Eval("GosterimSuresi")+" sn"%> 
                    </td>
                     <td>
                        <%# ConvertToDateTime(Eval("SonGosterimTarihi").ToString()).ToLongDateString()%> 
                    </td>
                </tr>
            </ItemTemplate>
            
            <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr>
                    <td colspan="4">
                        
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate><!-- son satırda tabloyu kapayıyoruz  -->
                  </tbody>
                </table>
            </FooterTemplate>
    </asp:Repeater>
        </div>
    </div>
</asp:Content>
