<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.Master" AutoEventWireup="true" CodeBehind="Kullanicilar.aspx.cs" Inherits="Duyuru.WebASPNET.Yonetim.Kullanicilar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row"><button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModalEkleme"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Yeni Ekle</button></div>

<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table class="table table-hover">
                    <thead>
                        <tr>
                        <th>
                            İşlemler
                        </th>
                        <th>
                            Kullanıcı Adı
                        </th>
                        <th>
                           Yetki
                        </th>
                       
                    </tr>
                         </thead>
            </HeaderTemplate>
            <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                 <tr>
                   <th scope="row">
                       <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs"  CommandName="g" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "YoneticiID")%>'>Güncelle</asp:LinkButton> ||  <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-danger btn-xs"  CommandName="s" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"YoneticiID")%>'>Sil</asp:LinkButton> 
                       <td>
                        <%#Eval("AdSoyad")%> 
                    </td>
                      <td>
                        <%#Eval("Yetkiler.Adi")%> 
                    </td>
                </tr>
            </ItemTemplate>
            
            <SeparatorTemplate> <!-- kayıtlar arasında çizgi  -->
                <tr>
                    <td colspan="3">
                        
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate><!-- son satırda tabloyu kapayıyoruz  -->
                  </tbody>
                </table>
            </FooterTemplate>
    </asp:Repeater>

<!--Ekleme Modal -->
<div class="modal fade" id="myModalEkleme" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalEklemeLabel">Ekleme Paneli</h4>
      </div>
      <div class="modal-body">
        <div class="col-lg-12">
            <p>Kullanıcı Adı</p>
            <asp:TextBox ID="txtkullaniciadi" runat="server" ValidationGroup="a" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Boş Olamaz" ControlToValidate="txtkullaniciadi" ValidationGroup="a">***</asp:RequiredFieldValidator>
        </div>
         
          <div class="col-lg-12">
             <p>Şifresi</p>
             <asp:TextBox ID="txtsifresi" runat="server" ValidationGroup="a" ></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Boş Olamaz" ControlToValidate="txtsifresi" ValidationGroup="a">***</asp:RequiredFieldValidator>
          </div>
          <div class="col-lg-12">
              <p>Yetki</p>
              <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
          </div>
          <div class="col-lg-12">
              <asp:Label ID="lblhata" runat="server" Text=""></asp:Label>
          </div>
          <div class="col-lg-12">
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a" ShowMessageBox="True" ShowModelStateErrors="False" />

          </div>
      </div>
        
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">İptal</button>
          <asp:Button ID="Button1" runat="server" Text="Ekle" CssClass="btn btn-primary" OnClick="Button1_Click" ValidationGroup="a" />
      </div>
    </div>
  </div>
</div>

<!--Günceleme Modal -->
<div class="modal fade" id="myModalGuncelleme" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="H1">Güncelleme Paneli</h4>
      </div>
      <div class="modal-body">
          <div class="col-lg-12">
          <asp:HiddenField ID="HiddenField1" runat="server" />
         <p>Kullanıcı Adı</p>
            <asp:TextBox ID="txtguncellekullaniciadi" runat="server" ValidationGroup="b" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Boş Olamaz" ControlToValidate="txtguncellekullaniciadi" ValidationGroup="b">***</asp:RequiredFieldValidator>
        </div>
         
          <div class="col-lg-12">
             <p>Şifresi</p>
             <asp:TextBox ID="txtguncellesifre" runat="server" ValidationGroup="b" ></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Boş Olamaz" ControlToValidate="txtguncellesifre" ValidationGroup="b">***</asp:RequiredFieldValidator>
          </div>
          <div class="col-lg-12">
              <p>Yetki</p>
              <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
          </div>
          <div class="col-lg-12">
              <asp:Label ID="lblguncellehata" runat="server" Text=""></asp:Label>
          </div>
          <div class="col-lg-12">
          <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="b" ShowMessageBox="True" ShowModelStateErrors="False" />

          </div>
      </div>
       
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">İptal</button>
          <asp:Button ID="Button3" runat="server" Text="Guncelle" CssClass="btn btn-primary" OnClick="Button3_Click" ValidationGroup="b" />
      </div>
         </div>
    </div>
  </div>


<!-- Modal -->
<div class="modal fade" id="myModalSil" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="H2">Silme Paneli</h4>
      </div>
      <div class="modal-body">
          <asp:HiddenField ID="HiddenField2" runat="server" />
         <div class="col-lg-12">
            <p>Kullanıcı</p>
            <asp:Label ID="lblkullaniciadi" runat="server" Text=""  CssClass="text-danger"></asp:Label>
        </div>
         </div>
   
        
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">İptal</button>
          <asp:Button ID="Button2" runat="server" Text="Sil" CssClass="btn btn-danger" OnClick="Button2_Click"/>
      </div>
    </div>
  </div>

    </div>
</asp:Content>
