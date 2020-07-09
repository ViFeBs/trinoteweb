<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="Visualiza_Anotacao.aspx.cs" Inherits="Visualiza_Anotacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        #conteudo{
            width: 700px;
            margin:auto;
        }
        .items-margin{
            margin-left:50px;
        }
        /* The Modal (background) */
        .Boxshare {
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content/Box */
        .share-content {
          background-color: #fefefe;
          margin: 15% auto; /* 15% from the top and centered */
          padding: 20px;
          border: 1px solid #888;
          width: 80%; /* Could be more or less, depending on screen size */
        }

        /* The Close Button */
        .close {
          color: #aaa;
          float: right;
          font-size: 28px;
          font-weight: bold;
        }

        .close:hover,
        .close:focus {
          color: black;
          text-decoration: none;
          cursor: pointer;
        }
    </style>
    <h2 class="text-center">Minha Anotação</h2>
    <div class="text-right">
         <asp:ImageButton ID="imgBedit" runat="server" ImageUrl="~/Images/Editar.jpg" Width="40px" Height="40px" OnClick="imgBedit_Click"/> 
         <asp:ImageButton ID="imgBdelet" runat="server" ImageUrl="~/Images/Deletar.png" Width="40px" Height="40px" OnClick="imgBdelet_Click"/>
         <asp:ImageButton ID="imgBshare" runat="server"  ImageUrl="~/Images/Compartilhar.png.jpg" Width="40px" Height="40px" OnClick="imgBshare_Click"/><br />
    </div>
    <div class="items-margin">
        <br />

        <br />
        <div id="editFont" runat="server">
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
            <asp:Label ID="lblFont" runat="server" ForeColor="White" Font-Size="12px" Text="ABCDEFGHIJKLMNOPQRSŠTUVWXYZŽ <br /> abcdefghijklmnopqrsštuvwxyzž <br /> 1234567890 <br /> ‘?’“!”(%)[#]{@}/&\<-+÷×=>®©$€£¥¢:;,.*"></asp:Label>
        </div>
    </div>
    <br />
    <div class="text-center">
        <h2>Titulo:
            <asp:Label ID="lblTitulo" runat="server" Text="" ForeColor="White"></asp:Label>
            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
        </h2><br />
        <asp:Image ID="imgAno" runat="server" Width="1000" Height="500"/><br />
        <br />
        <p id="imgEdit" runat="server">Alterar Imagem: <asp:FileUpload ID="fupImg" runat="server" /></p>
        <h2>Conteudo:</h2>
        <div id="conteudo">
            <asp:Label ID="lblConteudo" runat="server" Text="" CssClass="text-center" ForeColor="White"></asp:Label>
            <asp:TextBox ID="txtConteudo" runat="server" Height="166px" TextMode="MultiLine" Width="610px"></asp:TextBox>
        </div>
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-outline-light" OnClick="btnSalvar_Click" Height="44px" Width="193px"/>
        <div id="myModal" class="Boxshare" runat="server">
            <div class="share-content">
                <asp:Button ID="btnclose" runat="server" Text="&times;" CssClass="close" OnClick="btnclose_Click"/>
                <div class="container mt-3">
                    <div class="media border p-3" id="lstAmigos" runat="server">

                    </div>
                </div>
            </div>
        </div>
    </diV>
</asp:Content>

