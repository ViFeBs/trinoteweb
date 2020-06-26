<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .jumbotron{
            background-color:white;
        }
        .Alinhamento{
            margin-left:50px;
        }
    </style>
    <div  class="jumbotron">
        <div class="container">
            <h1 class="jumbotron-heading">Dados Pessoais:</h1>
        </div>
    </div>
      <div class="text-right">
         <asp:ImageButton ID="imgedit" runat="server" ImageUrl="~/Images/Editar.jpg" Width="40px" Height="40px" OnClick="imgedit_Click"/> 
    </div>
    <div class="Alinhamento">
        <h2>
            <asp:Label ID="Label1" runat="server" Text="Foto de Perfil: "></asp:Label>
        </h2>
        <asp:Image ID="imgPerfil" runat="server" Width="500px" Height="500px"/>
        <asp:FileUpload ID="fupImg" runat="server" /><br />
        <br />

        <h2>
            <asp:Label ID="lbl" runat="server" Text="Nome: " ></asp:Label>
        </h2>
        <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        <br />

        <h2>
            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
        </h2>
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <br />

        <h2>
            <asp:Label ID="Label3" runat="server" Text="Telefone: "></asp:Label>
        </h2>
         <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="Salvar Edição" CssClass="btn btn-success" OnClick="btnEdit_Click"/>
    </div>
</asp:Content>

