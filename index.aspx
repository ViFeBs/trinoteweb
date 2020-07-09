<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center">
            <div class="Elementos">
                <asp:Label ID="Label1" runat="server" Text="Login: "></asp:Label>
                &nbsp;<asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
                &nbsp;<asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnLog" runat="server" Text="Logar" OnClick="btnLog_Click"  CssClass="btn btn-primary"/>
                <br />
                <a href="Criar_Login.aspx">Não possui Login? Crie um agora, clique aqui.</a>
            </div>
    </div>
</asp:Content>

