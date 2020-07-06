<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="fb-profile">
            <asp:Image align="left" ID="imgBanner" runat="server" CssClass="fb-image-lg" ImageUrl="~/Images/Default_Banner.jpg"/>
            <asp:Image ID="imgPerfil" runat="server" CssClass="fb-image-profile thumbnail" align="left"/>
            <asp:FileUpload ID="fupImg" runat="server"/>
            <div class="fb-profile-text">
                <div class="text-right">
                     <asp:ImageButton ID="imgedit" runat="server" ImageUrl="~/Images/Editar.jpg" Width="40px" Height="40px" OnClick="imgedit_Click"/> 
                </div>
                <h5>Dados Pessoais:</h5>
                Nome:
                <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" Width="240px"></asp:TextBox>

                <br />
                E-mail:

                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
          

                &nbsp;&nbsp;&nbsp; Telefone:
          

                <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtTel" runat="server" Width="140px"></asp:TextBox><br />
                <br />
            </div>
            <asp:Button ID="btnEdit" runat="server" Text="Salvar Edição" CssClass="btn btn-success" OnClick="btnEdit_Click"/>
        </div>
    </div>
</asp:Content>

