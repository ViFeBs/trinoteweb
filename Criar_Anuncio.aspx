<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Criar_Anuncio.aspx.cs" Inherits="Criar_Anuncio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .jumbotron{
            background-color:white;
        }
    </style>
    <div  class="jumbotron">
        <div class="container">
            <h1 class="jumbotron-heading">Propósta de Anuncio</h1>
            <p class="lead text-muted">
                Sua Proposta será enviada para nossos avaliadores,se ela for aceita você será comunicado via e-mail,você tambem poderá ver seus anuncios na sua página inicial do anunciante,os anuncios funcionam com um sistema de tempo quanto mais tempo você deixa-lo no site mais caro ele ficará
            </p>
        </div>
    </div>
     <div class="card text-center">
        <div class="card-body">
            <h2>Exemplo de Anuncio:</h2>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/67-672874_clipart-cloud-atomic-bomb-fallout-4-guy-thumbs.png" CssClass="card-img" Width="400px" Height="300px"/><br />
            <asp:Label ID="Label6" runat="server" Text="Exemplo Titulo Do anuncio" CssClass="card-title" Font-Size="Larger" color="Bold"></asp:Label><br />
            <asp:Label ID="Label7" runat="server" Text="Algum texto de exemplo.Mais um texto de exemplo" CssClass="card-text"></asp:Label><br />
            <a href="#" class="btn btn-primary">Ver Mais</a>
        </div>
    </div>
    <br />
    <div class="text-center">
        <asp:Label ID="Label1" runat="server" Text="Tempo do anuncio no site: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1 Semana $30 Reais</asp:ListItem>
            <asp:ListItem>1 Mês $100 Reais</asp:ListItem>
            <asp:ListItem>1 Ano $1000,00 Reais</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Link que o anuncio vai direcionar: "></asp:Label>
        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Titulo do anuncio: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Anuncio: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAnuncio" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Adicionar uma Imagem ao Anuncio: "></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        &nbsp;
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnSend" runat="server"  Text="Enviar Propósta de anuncio" OnClick="btnSend_Click1"/>
    </div>
</asp:Content>

