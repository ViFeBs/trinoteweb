<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="HomeLog.aspx.cs" Inherits="HomeLog" %>

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
    <p class="text-right">
        <a href="Anotacoes.aspx" class="btn btn-success">Ver todas as Anotações</a>
    </p>
</asp:Content>

