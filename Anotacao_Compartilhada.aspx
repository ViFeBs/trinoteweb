<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Anotacao_Compartilhada.aspx.cs" Inherits="Anotacao_Compartilhada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Alinhamento" class="text-center">
        <h1 runat="server" id="lblTitulo" class="font"></h1>
        <asp:Image ID="imgAnotacao" runat="server" Width="1040px" Height="500px"/>
        <p runat="server" id="lblConteudo" class="font"></p>
    </div>
    <style runat="server" id="fonte">
        #Alinhamento {
            padding: 20px;
            margin: 20px;
            flex-direction: column;
            justify-content: center;
            display: flex;
        }
    </style>
</asp:Content>

