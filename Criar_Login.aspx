<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Criar_Login.aspx.cs" Inherits="Criar_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Foto de Perfil (Opcional): "></asp:Label><br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Telefone: "></asp:Label>
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="E-Mail: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="423px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Confirmar E-Mail: "></asp:Label>
        <asp:TextBox ID="txtCemail" runat="server" Width="352px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Login: "></asp:Label>
        <asp:TextBox ID="txtLog" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Senha: "></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Confirmar Senha: "></asp:Label>
        <asp:TextBox ID="txtCsenha" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <p>Para utilizar nosso site é necessário aceitar nossos termos de uso: 
            <a href="#">Termos de Privacidade</a> e <a href="#">Termos de Uso</a><br />
            <asp:CheckBox ID="ChkTermos" runat="server" Text="Aceitar" />
        </p>
        <asp:Button ID="btnCad" runat="server" Text="Cadastrar" OnClick="btnCad_Click"  CssClass="btn btn-primary"/>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

