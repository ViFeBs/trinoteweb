﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Adicionar_Amigo.aspx.cs" Inherits="Adicionar_Amigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .alinhamento {
            padding-top: 80px;
            padding-left: 100px;      
        }
    </style>
    <div class="alinhamento">
        <h2>Buscar Amigo :)</h2>
        <asp:TextBox ID="txtBusca" runat="server" hint="Nome do Usuário"></asp:TextBox>
        <asp:Button ID="btnBusca" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBusca_Click"/>
        <div class="card-columns">
            <div runat="server" id="lstAmigos">

            </div>
        </div>
    </div>
</asp:Content>

