<%@ Page Title="" Language="C#" MasterPageFile="~/Master Inicial.master" AutoEventWireup="true" CodeFile="Criar_Login.aspx.cs" Inherits="Criar_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('[data-toggle="popover"]').popover();
        });
    </script>
    <script type="text/javascript">
        function checkPasswordEquals() {
            document.getElementById("<%= txtCsenha.ClientID %>").style.color = "white";

            if (document.getElementById("<%= txtSenha.ClientID %>").value != document.getElementById("<%= txtCsenha.ClientID %>").value) {

                document.getElementById("<%= txtCsenha.ClientID %>").style.backgroundColor = "red";

            }
            else {

                document.getElementById("<%= txtCsenha.ClientID %>").style.backgroundColor = "green";

            }
        }
        function checkPasswordStrength() 
        {
            var password = document.getElementById("<%= txtSenha.ClientID %>").value;
            var specialCharacters = "!£$%^&*_@#~?";
            var passwordScore = 0;

            document.getElementById("<%= txtSenha.ClientID %>").style.color = "white";

            // Contains special characters
            for (var i = 0; i < password.length; i++) 
            {
                if (specialCharacters.indexOf(password.charAt(i)) > -1) 
                {
                    passwordScore += 20;
                    break;
                }
            }

            // Contains numbers
            if (/\d/.test(password))
                passwordScore += 20;

            // Contains lower case letter
            if (/[a-z]/.test(password))
                passwordScore += 20;

            // Contains upper case letter
            if (/[A-Z]/.test(password))
                passwordScore += 20;

            if (password.length >= 8) {
                passwordScore += 20;
            }

            var strength = "";
            var backgroundColor = "red";

            if (passwordScore >= 100) 
            {
                strength = "Strong";
                backgroundColor = "green";
            }
            else if (passwordScore >= 80) 
            {
                        strength = "Medium";
                backgroundColor = "gray";
            }
            else if (passwordScore >= 60) 
            {
                    strength = "Weak";
            backgroundColor = "maroon";
            }
            else 
            {
                strength = "Very Weak";
                backgroundColor = "red";
            }

            document.getElementById("<%= lblMessage.ClientID %>").innerHTML = strength;
            document.getElementById("<%= txtSenha.ClientID %>").style.backgroundColor = backgroundColor;
        }
    </script>
    <div class="text-center">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Foto de Perfil (opcional): "></asp:Label><br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Telefone: "></asp:Label>
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="E-mail: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="423px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Confirmar E-mail: "></asp:Label>
        <asp:TextBox ID="txtCemail" runat="server" Width="352px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Login: "></asp:Label>
        <asp:TextBox ID="txtLog" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Senha: "></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" OnTextChanged="txtSenha_TextChanged" onKeyup="checkPasswordStrength()"></asp:TextBox>
        <a href="#" data-toggle="popover" data-trigger="focus" title="Senhas devem conter:" data-content="Letras, números e um caracterer especial."><i class="fas fa-info-circle"></i></a>
        <asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label><br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Confirmar Senha: "></asp:Label>
        <asp:TextBox ID="txtCsenha" runat="server" TextMode="Password" OnTextChanged="txtCsenha_TextChanged" onKeyup="checkPasswordEquals()"></asp:TextBox><br />
        <br />
        <p>Para utilizar nosso site é necessário aceitar nossos:
            </p>
        <p><a href="#">Termos de Privacidade</a> e <a href="#">Termos de Uso</a></p>
        <p>
            <asp:CheckBox ID="ChkTermos" runat="server" Text="Aceitar" />
        </p>
        <asp:Button ID="btnCad" runat="server" Text="Cadastrar" OnClick="btnCad_Click"  CssClass="btn btn-primary"/>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

