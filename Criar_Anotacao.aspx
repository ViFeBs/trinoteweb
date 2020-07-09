<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="Criar_Anotacao.aspx.cs" Inherits="Criar_Anotacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .items-margin{
            margin-left:50px;
        }
    </style>
    <asp:Label ID="Label3" runat="server" Text="Font: " ForeColor="White"></asp:Label>
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
    <asp:Label ID="lblFont" runat="server" ForeColor="White" Font-Size="20px" Text="ABCDEFGHIJKLMNOPQRSŠTUVWXYZŽ <br /> abcdefghijklmnopqrsštuvwxyzž <br /> 1234567890 <br /> ‘?’“!”(%)[#]{@}/&\<-+÷×=>®©$€£¥¢:;,.*"></asp:Label><br />

    <div class="text-center">
        <asp:Label ID="Label4" runat="server" Text="Adicionar Imagem: " ForeColor="White"></asp:Label><br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />

        <asp:Label ID="Label1" runat="server" Text="Título: " ForeColor="White"></asp:Label><br />
        <asp:TextBox ID="txtTitulo" runat="server" Width="754px"></asp:TextBox><br />

        <asp:Label ID="Label2" runat="server" Text="Anotação: " ForeColor="White"></asp:Label><br />
        <asp:TextBox ID="TxtAnotacao" runat="server" Height="441px" TextMode="MultiLine" Width="761px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"  CssClass="btn btn-outline-light" Width="274px"/><br />
    </div>


</asp:Content>

