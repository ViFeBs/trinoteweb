<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Login_Anunciante.aspx.cs" Inherits="Login_Anunciante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .jumbotron{
            background-color:white;
        }
    </style>
    <div class="text-center">
        <div  class="jumbotron">
            <div class="container">
                <h1 class="jumbotron-heading">Login Para Anunciantes</h1>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnLog" runat="server" Text="Logar" OnClick="btnLog_Click"  CssClass="btn btn-primary"/>
        <br />
        <br />
        <a href="Anuncie.aspx">Não possui Login? Crie um agora, clique aqui./a>
    </div>
</asp:Content>

