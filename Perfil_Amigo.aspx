﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Perfil_Amigo.aspx.cs" Inherits="Perfil_Amigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="fb-profile">
            <br /><br />
            <asp:Image align="left" ID="imgBanner" runat="server" CssClass="fb-image-lg" ImageUrl="~/Images/Default_Banner.jpg"/>
            <asp:Image align="left" ID="imgPerfil" runat="server" CssClass="fb-image-profile thumbnail" ImageUrl="~/Images/Profile_Default.png"/>
            <div class="fb-profile-text">
                <h1><asp:Label ID="lblNome" runat="server" Text="Nome Usuario" ForeColor="White"></asp:Label></h1>
                <asp:Button ID="btnAdicionar" runat="server" Text="Enviar Solicitação de Amizade" CssClass="btn btn-primary d-inline" OnClick="btnAdicionar_Click"/>
            </div>
        </div>
        <br />
        <br />
        <h2 runat="server" class="text-center" id="anoAmigo">Anotações compartilhadas comigo:</h2>
        <br />
        <div class="jumbotron jumbotron-fluid" runat="server" id="nadaEncontrado">
        </div>
        <div class="card-columns">
            <div runat="server" id="GeraAnotacaoAmigo">
            </div>
        </div>
    </div> <!-- /container -->  

</asp:Content>

