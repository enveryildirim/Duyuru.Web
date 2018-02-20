<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.Master" AutoEventWireup="true" CodeBehind="SesliDuyuru.aspx.cs" Inherits="Duyuru.WebASPNET.Yonetim.SesliDuyuru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            Duyuru Adı
                        </th>
                        <th>
                           Url
                        </th>
                        
                    </tr>
                         </thead>
            </HeaderTemplate>
            <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                 <tr>
                   <th scope="row">
                       <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs"  CommandName="g" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DuyuruID")%>'>Yayınla</asp:LinkButton>  
                      
                      <td>
                        <%#Eval("DuyuruAdi")%> 
                    </td>
                     <td>
                        <%#Eval("DuyuruAdresi")%> 
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
    </asp:Repeater> </div>
    <div class="col-lg-6">
        <div class="col-lg-12">
            <asp:Button ID="Button1" runat="server" Text="Duyuruyu Yap" CssClass="btn btn-success" OnClick="Button1_Click" /></div>
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
            <HeaderTemplate><!-- görüntülenecek bilgilerin başlıkları  -->
                <table class="table table-hover">
                    <thead>
                        <tr>
                        <th>
                            İşlemler
                        </th>
                        <th>
                            Duyuru Adı
                        </th>
                        <th>
                           Url
                        </th>
                        
                    </tr>
                         </thead>
            </HeaderTemplate>
            <ItemTemplate> <!-- okunan bilgilerden hangileri nerde gösterilecek  -->
                 <tr>
                   <th scope="row">
                       <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary btn-xs"  CommandName="g" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DuyuruID")%>'>Sil</asp:LinkButton>  
                      <td>
                        <%#Eval("DuyuruInfo.DuyuruAdi")%> 
                    </td>
                     <td>
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
</asp:Content>
