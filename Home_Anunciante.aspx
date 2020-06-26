<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Home_Anunciante.aspx.cs" Inherits="Home_Anunciante" %>

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
            <h1 class="jumbotron-heading">Gerenciar Anuncios</h1>
            <p class="lead text-muted" runat="server" id="Enunciado">
                Olá anunciante
            </p>
        </div>
    </div>
    <a class="btn btn-success text-left" href="Criar_Anuncio.aspx" role="button">Criar um Novo Anuncio</a><br />
    <br />
    <div class="card-columns">
        <div class="card">
            <div class="card-body">
                <h2 class="card-title">Propostas Enviadas</h2>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Enviado.png" CssClass="card-img-top" Width="300px" Height="300px"/>
                <p>Total Propostas Enviadas Aguardando Resposta: <asp:Label ID="lblEnviados" runat="server" Text="0" Font-Size="Large" ForeColor="#42c5f5"></asp:Label></p>
                <a href="PropEnviadas.aspx" class="btn btn-primary">Ver Detalhadamente</a>
            </div>
        </div>
        <div class="card">
            <div class="card-body">
                <h2>Proposta Aceitas</h2>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Aceito.png" CssClass="card-img-top" Width="300px" Height="300px"/>
                <p>Total Propostas Aceitas: <asp:Label ID="lblAceitos" runat="server" Text="0" Font-Size="Large" ForeColor="#28a745"></asp:Label></p>
                <a href="PropAceitas.aspx" class="btn btn-success">Ver Detalhadamente</a>
            </div>
        </div>
        <div class="card">
            <div class="card-body">
                <h2>Proposta Recusadas</h2>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Recusado.png" CssClass="card-img-top" Width="300px" Height="300px"/>
                <p>Total Propostas Recusadas: <asp:Label ID="lblRecusados" runat="server" Text="0" Font-Size="Large" ForeColor="#ff6363"></asp:Label></p>
                <a href="PropRecusadas.aspx" class="btn btn-danger">Ver Detalhadamente</a>
            </div>
        </div>
    </div>
</asp:Content>

