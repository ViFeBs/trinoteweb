<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="Anotacoes.aspx.cs" Inherits="Anotacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="text-center">Minhas Anotações:</h2>
    <p class="text-right">
      <a href="Criar_Anotacao.aspx" class="btn btn-success">Criar Anotação</a>
    </p>
    <div class="card-columns">
        <div runat="server" id="GeraAnotacao">
        </div>
    </div>
</asp:Content>

