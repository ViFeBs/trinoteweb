<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="Criar_Anotacao.aspx.cs" Inherits="Criar_Anotacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .items-margin{
            margin-left:50px;
        }
        .jumbotron{
            background-color:white;
        }
    </style>
    <div  class="jumbotron">
        <div class="container">
            <h1 class="jumbotron-heading">Criar Anotação</h1>
        </div>
    </div>
    <div class="items-margin">
        <asp:Label ID="Label3" runat="server" Text="Font: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Classica</asp:ListItem>
            <asp:ListItem>Amatic SC</asp:ListItem>
            <asp:ListItem>Sacramento</asp:ListItem>
            <asp:ListItem>Dancing Script</asp:ListItem>
            <asp:ListItem>Press Start 2P</asp:ListItem>
            <asp:ListItem>Tangerine</asp:ListItem>
            <asp:ListItem>Notable</asp:ListItem>
            <asp:ListItem>Reenie Beanie</asp:ListItem>
            <asp:ListItem>Pinyon Script</asp:ListItem>
            <asp:ListItem>Ruge Boogie</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="lblFont" runat="server" Font-Size="40px" Text="ABCDEFGHIJKLMNOPQRSŠTUVWXYZŽ <br /> abcdefghijklmnopqrsštuvwxyzž <br /> 1234567890 <br /> ‘?’“!”(%)[#]{@}/&\<-+÷×=>®©$€£¥¢:;,.*"></asp:Label><br />

        <asp:Label ID="Label4" runat="server" Text="Adicionar Imagem: "></asp:Label><br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />

        <asp:Label ID="Label1" runat="server" Text="Título: "></asp:Label><br />
        <asp:TextBox ID="txtTitulo" runat="server" Width="754px"></asp:TextBox><br />

        <asp:Label ID="Label2" runat="server" Text="Anotação: "></asp:Label><br />
        <asp:TextBox ID="TxtAnotacao" runat="server" Height="441px" TextMode="MultiLine" Width="761px"></asp:TextBox><br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" /><br />
        <br />
        <br />
        <br />
        <br />
    </diV>

</asp:Content>

