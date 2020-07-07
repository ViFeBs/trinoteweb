<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Anuncie.aspx.cs" Inherits="Anuncie" %>

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
            <h1 class="jumbotron-heading">Criar Login</h1>
            <p class="lead text-muted">
                Olá anunciante! A TriNote oferece uma plataforma de anúncios simples e prática para você. <br />
                Basta cadastrar suas informações, adicionar um login e uma senha e pronto, você poderá enviar propostas de anúncio
                para o site. <br /> Você também terá acesso a uma página onde poderá ver seus anúncios ativos e suas propostas enviadas.
            </p>
        </div>
    </div>
    <div class="text-center">
            <h1>Dados Cadastrais: </h1>
            <br />
            <div runat="server" id="Visivel">
                <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Telefone: "></asp:Label>
                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="CNPJ: "></asp:Label>
                <asp:TextBox ID="txtCNPJ" runat="server"></asp:TextBox>
                <asp:Label ID="Label7" runat="server" Text="E-Mail: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Login: "></asp:Label>
                <asp:TextBox ID="txtLog" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Senha: "></asp:Label>
                <asp:TextBox ID="txtSen" runat="server" TextMode="Password"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Confirmar senha: "></asp:Label>
                <asp:TextBox ID="txtConsen" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSend" runat="server"  Text="Cadastrar-se" OnClick="btnSend_Click1" CssClass="btn btn-primary"/>
            </div>
       </div>
</asp:Content>

