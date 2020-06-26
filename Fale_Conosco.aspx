<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Fale_Conosco.aspx.cs" Inherits="Fale_Conosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-center">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Motivo do Contato"></asp:Label><br />
        <br />
        <asp:RadioButton ID="rdnBug" runat="server" Text="Reportar Bug" GroupName="MotivoContatoGroup" />
        <asp:RadioButton ID="rdnHate" runat="server" Text="Reclamação" GroupName="MotivoContatoGroup" />
        <asp:RadioButton ID="rdnOutro" runat="server" Text="Outro" GroupName="MotivoContatoGroup" /><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Dados Para Contato"></asp:Label><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome: "></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="E-Mail: "></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Mensagem: "></asp:Label>
        <br />
        <asp:TextBox ID="txtMen" runat="server" TextMode="MultiLine" style="resize:none" Height="120px" Width="355px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnEnv" runat="server" Text="Enviar"  CssClass="btn btn-primary" OnClick="btnEnv_Click"/>
    </div>
</asp:Content>

