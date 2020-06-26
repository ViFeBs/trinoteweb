<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="PropAceitas.aspx.cs" Inherits="PropAceitas" %>

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
            <h1 class="jumbotron-heading">Propostas Aceitas:</h1>
        </div>
    </div>
    <div class="card-columns">
        <div runat="server" id="GeraAnun">

        </div>
    </div>
</asp:Content>

