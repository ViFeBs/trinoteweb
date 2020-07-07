<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Paga_Anuncio.aspx.cs" Inherits="Paga_Anuncio" %>

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
            <h1 class="jumbotron-heading">Eba! Seu anúncio foi aceito:</h1>
            <p class="lead text-muted">
                Agora que seu anúncio foi aceito você pode pagar seu anúncio e ativá-lo no site (atualmente só aceitamos pagamentos via cartão de crédito).
            </p>
        </div>
    </div>
    <div class="text-center">
        <h3>Dados do Cartão:</h3><br />
        <span class="alert-heading">Número do Cartão:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="alert-heading">Código de Segurança:</span><br />
        <asp:TextBox ID="txtCreditCard" runat="server" Placeholder="Cartão de Crédito" Width="260px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtCVV" runat="server" Placeholder="CVV" Width="72px"></asp:TextBox><br />
        <br />
        <span class="alert-heading">Nome:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="alert-heading">Data de Vencimento:</span><br />
        <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome do Proprietário" Width="214px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtDtMe" runat="server" Placeholder="Mês" Width="40px"></asp:TextBox>
        &nbsp;<asp:TextBox ID="txtDtye" runat="server" Placeholder="Ano" Width="39px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnValida" runat="server" Text="Finalizar Compra" CssClass="btn-outline-primary" Width="361px" OnClick="btnValida_Click"/>
    </div>
</asp:Content>

